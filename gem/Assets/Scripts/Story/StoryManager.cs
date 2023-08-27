using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Rendering;
using System.IO;
using SuperTiled2Unity;
using System.Linq.Expressions;

public class StoryManager : MonoBehaviour
{
    // https://www.youtube.com/watch?v=raQ3iHhE_Kk
    // https://www.youtube.com/watch?v=KSRpcftVyKg&list=PL3viUl9h9k78KsDxXoAzgQ1yRjhm7p8kl&index=1
    // but modified a bit

    [Header("Main Ink File")]
    [SerializeField] private TextAsset mainInkAsset;

    [Header("Story UI")]
    [SerializeField] private SignalSO endInteractSignal;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private float defaultTypingSpeed = 0.04f;
    private float typingSpeed;
    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Audio")]
    [SerializeField] private DialogueAudioInfoSO defaultAudioInfo;
    [SerializeField] private DialogueAudioInfoSO[] audioInfos;
    [SerializeField] private bool makePredictable;
    private DialogueAudioInfoSO currentAudioInfo;
    private Dictionary<string, DialogueAudioInfoSO> audioInfoDictionary;
    private AudioSource audioSource;

    [Header("Cutscenes")]
    [SerializeField] public SignalSO resumeCutsceneSignal;
    [SerializeField] public SignalSO pauseCutsceneSignal;
    private bool pausedByCutscene;
    private string prePausedLine;
    
    // list of signals you can call from ink
    // you call them by name
    private List<SignalSO> inkCallableSignals = new List<SignalSO> { };

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;
    private bool trySkipDialogue = false;

    private Coroutine displayLineCoroutine;

    private static StoryManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string AUDIO_TAG = "audio";
    private const string SPEED_TAG = "speed";

    private StoryVariables dialogueVariables;
    private InkExternalFunctions inkExternalFunctions;

    string currentLayout;
    string currentPortrait;

    int stateNameHash;

    private void Awake()
    {
        currentStory = new Story(mainInkAsset.text);
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        typingSpeed = defaultTypingSpeed;

        dialogueVariables = new StoryVariables(mainInkAsset);
        inkExternalFunctions = new InkExternalFunctions();

        audioSource = this.gameObject.AddComponent<AudioSource>();
        currentAudioInfo = defaultAudioInfo;

        pausedByCutscene = false;

        currentStory.BindExternalFunction("pauseForCutscene", () =>
        {
            pauseAndHideStory();
        });    
        
        // find and load all signals we could call from ink
        // this path is relative to the Assets/Resources folder
        UnityEngine.Object[] loadedResources = Resources.LoadAll("Signals", typeof(SignalSO));

        foreach (UnityEngine.Object obj in loadedResources)
        {
            if (obj is SignalSO)
            {
                inkCallableSignals.Add( (SignalSO) obj );
                print(obj.name + " loaded to be called from ink");
            }
        }

        // register listener
        // in the main ink file, you need this line:
        // EXTERNAL callSignal(signalName)
        currentStory.BindExternalFunction("callSignal", (string signalName) =>
        {
            CallSignalFromInk(signalName);
        });

        currentStory.BindExternalFunction("goToNext", (int delayTime) =>
        {
            StartCoroutine(GoToNext(delayTime));
        });
    }

    public static StoryManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // get the layout animator
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        // get all of the choices text 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        InitializeAudioInfoDictionary();

        
    }

    private void CallSignalFromInk(string signalName)
    {
        //Debug.Log("Searching for " + signalName);

        foreach (SignalSO inkSignal in inkCallableSignals)
        {
            if (signalName.Equals(inkSignal.name))
            {
                Debug.Log("Raising " + signalName);
                inkSignal.Raise();
                // end now, dont keep searching.
                return;
            }
        }
        // if we never raised one, we didnt find it.
        Debug.LogError("Signal " + signalName + " not found.");
    }

    private IEnumerator GoToNext(int delayTime)
    {
        // waits for a period of time
        // then tries to continue. skips to end of text first.
        // remember, only works if there isnt a choice or something.
        
        // if you wanted, you could put a delay here to let the text finish typing

        // this line will finish typing
        trySkipDialogue = true;

        // this will wait
        yield return new WaitForSeconds(delayTime);
        
        // this line will take you to the next one        
        TryContinue();
    }

    private void InitializeAudioInfoDictionary()
    {
        audioInfoDictionary = new Dictionary<string, DialogueAudioInfoSO>();
        audioInfoDictionary.Add(defaultAudioInfo.id, defaultAudioInfo);
        foreach (DialogueAudioInfoSO audioInfo in audioInfos)
        {
            audioInfoDictionary.Add(audioInfo.id, audioInfo);
        }
    }

    private void SetCurrentAudioInfo(string id)
    {
        DialogueAudioInfoSO audioInfo = null;
        audioInfoDictionary.TryGetValue(id, out audioInfo);
        if (audioInfo != null)
        {
            this.currentAudioInfo = audioInfo;
        }
        else
        {
            Debug.LogWarning("Failed to find audio info for id: " + id);
        }
    }

    public void TryContinue()
    {
        print("raised contuinue");

        if (pausedByCutscene) { return; }

        if (!dialogueIsPlaying) { return; }

        if (!canContinueToNextLine)
        {
            trySkipDialogue = true;
        }

        if (canContinueToNextLine
            && currentStory.currentChoices.Count == 0)
        {
            print("actually continue");
            ContinueStory();
        }
    }

    // this is called from inside ink to pause the story
    // and allow an animation to play.
    public void pauseAndHideStory()
    {
        print("pause and hide");
        // hide panels
        SoftExitDialogueMode();

        // stop accepting input
        pausedByCutscene = true;

        // trigger sequence
        if (resumeCutsceneSignal != null)
        {
            resumeCutsceneSignal.Raise();
        }

        print("done pausing and hiding");
    }

    // this function is called by a signal from the timeline
    // which resumes the story where it was last.
    public void resumeAndShowStory()
    {
        // accept input again
        pausedByCutscene = false;

        // pause the animation
        if (pauseCutsceneSignal != null)
        {
            pauseCutsceneSignal.Raise();
        }

        SoftEnterDialogueMode();
    }

    public void EnterDialogueMode(string knotName)
    {
        print("starting " + knotName);
        // currentStory = new Story(mainInkAsset.text);
        dialogueIsPlaying = true;
        trySkipDialogue = false;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        // reset portrait, layout, and speaker
        //displayNameText.text = "???";
        portraitAnimator.Play("default");
        //layoutAnimator.Play("none");

        currentStory.ChoosePathString(knotName);
        ContinueStory();
    }

    public void EnterDialogueMode(string knotName, Animator emoteAnimator)
    {
        // this overload is currently unused. It allows you to make a character
        // like jump or something on screen when it talks.

        // currentStory = new Story(mainInkAsset.text);
        dialogueIsPlaying = true;
        trySkipDialogue = false;
        dialoguePanel.SetActive(true);
    
        dialogueVariables.StartListening(currentStory);
        inkExternalFunctions.Bind(currentStory, emoteAnimator);
    
        // reset portrait, layout, and speaker
        displayNameText.text = "???";
        // portraitAnimator.Play("default");
        //layoutAnimator.Play("none");
    
        currentStory.ChoosePathString(knotName);
        ContinueStory();
    }

    // can only call this AFTER A SOFT EXIT
    private void SoftEnterDialogueMode()
    {
        dialogueIsPlaying = true;
        trySkipDialogue = false;
        dialoguePanel.SetActive(true);
        layoutAnimator.Play(currentLayout);
        portraitAnimator.Play(currentPortrait);
        TryContinue();
    }

    private void SoftExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);
        inkExternalFunctions.Unbind(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        // go back to default audio
        SetCurrentAudioInfo(defaultAudioInfo.id);
        endInteractSignal.Raise();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

            string nextLine;

            if (prePausedLine !=  null)
            {
                nextLine = prePausedLine;
                prePausedLine = null;
            } else
            {
                nextLine = currentStory.Continue();
            }

            // return speed to default, if it needs to change it will inside handletags
            typingSpeed = defaultTypingSpeed;
            // handle tags
            HandleTags(currentStory.currentTags);

            // if paused, just return and wait for the next time to continue.
            if (pausedByCutscene)
            {
                prePausedLine = nextLine;
                return;
            }

            // handle case where the last line is an external function
            if (nextLine.Equals("") && !currentStory.canContinue)
            {
                StartCoroutine(ExitDialogueMode());
            }
            // otherwise, handle the normal case for continuing the story
            else
            {
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));
            }
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        // set the text to the full line, but set the visible characters to 0
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        // hide items while text is typing
        continueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            // if the submit button is pressed, finish up displaying the line right away
            if (trySkipDialogue)
            {
                dialogueText.maxVisibleCharacters = line.Length;
                trySkipDialogue = false;
                break;
            }

            // check for rich text tag, if found, add it without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else
            {
                PlayDialogueSound(dialogueText.maxVisibleCharacters, dialogueText.text[dialogueText.maxVisibleCharacters]);
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // actions to take after the entire line has finished displaying
        continueIcon.SetActive(true);
        DisplayChoices();

        canContinueToNextLine = true;
    }

    private void PlayDialogueSound(int currentDisplayedCharacterCount, char currentCharacter)
    {
        // set variables for the below based on our config
        AudioClip[] dialogueTypingSoundClips = currentAudioInfo.dialogueTypingSoundClips;
        int frequencyLevel = currentAudioInfo.frequencyLevel;
        float minPitch = currentAudioInfo.minPitch;
        float maxPitch = currentAudioInfo.maxPitch;
        bool stopAudioSource = currentAudioInfo.stopAudioSource;

        // play the sound based on the config
        if (currentDisplayedCharacterCount % frequencyLevel == 0)
        {
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            AudioClip soundClip = null;
            // create predictable audio from hashing
            if (makePredictable)
            {
                int hashCode = currentCharacter.GetHashCode();
                // sound clip
                int predictableIndex = hashCode % dialogueTypingSoundClips.Length;
                soundClip = dialogueTypingSoundClips[predictableIndex];
                // pitch
                int minPitchInt = (int)(minPitch * 100);
                int maxPitchInt = (int)(maxPitch * 100);
                int pitchRangeInt = maxPitchInt - minPitchInt;
                // cannot divide by 0, so if there is no range then skip the selection
                if (pitchRangeInt != 0)
                {
                    int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt;
                    float predictablePitch = predictablePitchInt / 100f;
                    audioSource.pitch = predictablePitch;
                }
                else
                {
                    audioSource.pitch = minPitch;
                }
            }
            // otherwise, randomize the audio
            else
            {
                // sound clip
                int randomIndex = UnityEngine.Random.Range(0, dialogueTypingSoundClips.Length);
                soundClip = dialogueTypingSoundClips[randomIndex];
                // pitch
                audioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
            }

            // play sound
            audioSource.PlayOneShot(soundClip);
        }
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {
            // parse the tag
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            // handle the tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    // this saves users from having to use the layout tag:
                    // they can just pass "portrait:none" and it will work.

                    if (tagValue.Equals("none"))
                    {
                        // user wants no portrait to be visible.
                        currentLayout = "none";
                        currentPortrait = "default";
                    } else
                    {
                        // use the "right" layout, show a portrait from the tag
                        currentLayout = "right";
                        currentPortrait = tagValue;
                    }

                    layoutAnimator.Play(currentLayout);
                    portraitAnimator.Play(currentPortrait);

                    print("played " + currentLayout);

                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case AUDIO_TAG:
                    SetCurrentAudioInfo(tagValue);
                    break;
                case SPEED_TAG:
                    // set the speed temporarily to a different value
                    try {
                        typingSpeed = tagValue.ToFloat();
                    } catch (Exception e) { print(e.Message); }
                    
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            // NOTE: The below two lines were added to fix a bug after the Youtube video was made
            print("made choice " + choiceIndex);
            // discard the continue
            // String answer = currentStory.Continue();
            ContinueStory();
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    // This method will get called anytime the application exits.
    // Depending on your game, you may want to save variable state in other places.
    public void OnApplicationQuit()
    {
        // disabling this because we are using files and manual saves.
        //dialogueVariables.SaveVariables();
        SaveFile();
    }

    public List<string> EnumerateSaves()
    {
        // function to get list of save files
        // to then display them in a menu or something
        // im realizing i should just focus on making one save file work
        // so this is UNFINISHED!!!

        List<string> results = new List<string>();

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // webgl doesnt support saves well
            // and if we update the game also loses all saves
            // easier to just say download the game.
            results.Add("***Save data is not supported on web. Please consider downloading the game!");
            return results;
        }
        

        string path = Application.persistentDataPath;

        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.json");

        foreach (FileInfo f in info)
        {
            print("Found: " + f.Name);
            results.Add(f.Name);
        }

        return results;

    }

    public void SaveFile()
    {
        // load any unity variables back into ink
        dialogueVariables.SaveVariables();

        // windows + windows editor
        // %userprofile%\AppData\LocalLow\<companyname>\<productname>
        // linux
        // $HOME/.config/unity3d
        // as i make these updates, i have changed the companyname to
        // Fragile Ebro Studio
        string path = Application.persistentDataPath + "/savedata.json";

        string storystate = currentStory.state.ToJson();

        // write to json file
        File.WriteAllText(path, storystate);

    }

    public void LoadFile()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        string storystate = File.ReadAllText(path);

        currentStory.state.LoadJson(storystate);
    }

}
