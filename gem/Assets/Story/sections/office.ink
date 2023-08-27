===1_begin_cutscene_1===
//#CUTSCENE: Fade to black.
You have been dormant for so long. #portrait:none #speed:0.1
You cannot remember how long you have been down here...
A <u>year</u>? A <b>decade</b>? A <i>century</i>?
// ->DONE

~pauseForCutscene()

// ===1_begin_cutscene_2===
//#CUTSCENE: black screen fades to the study
Time feels just as stagnant as the air in this room-- changeless, clogged with dust. It has been sealed so long and so well that nothing has even had the chance to decompose for you to estimate with.
Maybe besides your memories. Your patience. Your CHARITABILITY.
You are so. Goddamn. Bored.
\-\-and there's nothing you can do about it, besides wait.
...until...
//#SFX: rumbling sound
“Hm..?” #portrait:gem_statue_neutral
//#SFX: CRASH
Someone crashes into the room. Through the… dumbwaiter? Huh, you forgot that was there. #portrait:none
“Oh? Finally!” #portrait:gem_statue_excited
//#SFX: shuffling. The adventurer is sitting on the floor, distressed.
"Ow..." #portrait:adv_worried_nogem
“Huh... where am I?” #portrait:adv_confused_nogem
“Oh, oh no! I have to get back up there!” #portrait:adv_worried_nogem
"I better get their attention..."  #portrait:gem_statue_worried
// ->DONE

// ===1_begin_cutscene_3===
//#PLAYER: When the player press any move keys or act keys, the gem wiggles instead, giving off a little shimmer.
"...!" #portrait:adv_neutral_nogem
//#CUTSCENE: The adventurer approaches the Gem, and touches it.
This is it! Your way out... Better think twice how you should approach this. #portrait:none
	+   Greet them in a friendly manner, you can't scare them away! 
    	"Fine evening, Adventurer! How can I help you?" #portrait:gem_statue_excited
	+   Be clear and precise. This might be your only opportunity.
    	“Listen closely, Adventurer…” #portrait:gem_statue_neutral
    	“If you want a chance to get out of here, do NOT let go!”
	// +	test!#portrait:none

- ...Ah!!!! Who's there?” #portrait:adv_worried_nogem
// ->DONE

// ===1_begin_cutscene_4===
//#CUTSCENE: The adventurer backs away a few steps, walks around the office, tries to exit the door (SFX: locked door) and then sits down defeatedly.
“Wait- don't move! Listen to me!”  #portrait:gem_statue_angry
“Don't hurt me! I didn't stealing anything from you!” #portrait:adv_worried_nogem
	+   \(The statue can't talk back, Dulbert...\)  #portrait:gem_statue_angry
	+   \(If there's no contact, I can't talk to them...\)  #portrait:gem_statue_angry
	+   \(Humans are SO. STUPID.\)  #portrait:gem_statue_angry
// ->DONE

// ===1_begin_cutscene_5===
//#CUTSCENE: Fade to black.
- You think you blew your chance. #portrait:none
...
// ->DONE

// ===1_begin_cutscene_6===
//CUTSCENE: wait like. a few seconds?
"..." #portrait:adv_curious_nogem
// ->DONE

// ===1_begin_cutscene_7===
//#CUTSCENE: Fade from black.
"...hello? Are you still there?" #portrait:adv_neutral_nogem
	+ \(Damn it. I need to get their attention again.\)
// ->DONE

// ===1_begin_cutscene_8===
//PLAYER: wiggle time
//CUTSCENE: the guy notices and approaches the gem.
- The Adventurer hesitates, then walks back over-- good! --And pokes you. It’ll do. #portrait:none
“DON’T take your hand away! I cannot speak to you otherwise.” #portrait:gem_angry
“Ah–!” #portrait:adv_worried_nogem
“...How are you speaking with your mouth closed?”  #portrait:adv_frown_nogem
“LOOK DOWN FUCKFACE” #portrait:gem_statue_angry
“You’re… the gem?” #portrait:adv_curious_nogem
“Indeed! Telepathy, Dulbert.” #portrait:gem_statue_neutral
“...” #portrait:adv_curious_nogem
“...Oh, I must be losing it.” #portrait:adv_frown_nogem
“Listen, kid… There are oddities in this world so stupendous that you may never understand with your humble little brain… Not unless you’ve seen them with your own eyes, touched them with your own fingers.” #portrait:gem_statue_excited
 “\-\- Which you are in the perfect position to do! You can witness wonderful things here, with ME, if you could just… get me OUT of this shiny little prison!”
“...”  #portrait:adv_frown_nogem
You can’t quite tell what they’re thinking, but they seem far too worried about something else to admire your spectacular self. Odd! You’ve always been good with charming humans. Better step up your game...! #portrait:none
	+   [Threaten them.]"You’re not going to get anywhere alone, Dulbert."  #portrait:gem_statue_neutral
    	“That’s not my name-” #portrait:adv_worried_nogem //#signal:try_continue
    	“I know this mansion like the back of my crystal faces, DULBERT. I have the key to this office gate that you couldn’t budge. My guidance is the best chance you’ve got.” #portrait:gem_statue_angry
    	“But of course, you feel free to go ahead and try it on your own,  fail, stay stuck in here for a thousand years, and then die of BOREDOM.” #portrait:gem_statue_neutral
    	“...DIE?” #portrait:adv_worried_nogem
    	“Oh, right, that too! And probably much, much sooner!” #portrait:gem_statue_excited
    	“...”  #portrait:adv_frown_nogem
    	“Well, tell me when you make up your mind! I’ll be here dozing away, it’s not like it matters to me.” #portrait:gem_statue_neutral
    	You wiggle once more, pretending to tuck yourself into those golden fingers. #portrait:none
    	+ + \(...\)
			\(...Are they looking?\)#portrait:gem_statue_worried
	+   [Reassure them.] "Fear not Dulbert, nothing to be concerned about! I know exactly how we could get out of here…“ #portrait:gem_statue_neutral
    	~ friendship += 1
    	“But…” #portrait:adv_worried_nogem
    	“Now, now, I understand. People are often scared of what they don’t understand. Lucky for you, I know this mansion like my very own crystalline structure, and I’m a great tutor too!”#portrait:gem_statue_excited
    	"Not to mention the unimaginable power that I possess..."#portrait:gem_statue_neutral
    	"That sounds... intense." #portrait:adv_frown_nogem
    	“Fret not, fret not. Never ever would I let you get in harm’s way, I promise! As long as you do exactly what I instruct, you’ll be PERFECTLY FINE.”#portrait:gem_statue_neutral
- The Adventurer looks around the room briefly, as if for some other last minute option, before turning back to you. #portrait:none
“...fine.” #portrait:adv_frown_nogem
“Very well! I'm glad you chose correctly!” #portrait:gem_statue_excited
"..." #portrait:adv_frown_nogem
“For the first stage of your guided tour, you've got to get me out of this statue.” #portrait:gem_statue_neutral
“I.. guess so-- how?” #portrait:adv_frown_nogem
	*   [“There's a dagger, on the shelf over there."]
    	~ friendship += 1
    	"If memory serves, that is. Pry me out! Don't take your time.” #portrait:gem_statue_neutral
   	 	“Where? There's.. a lot of stuff in here,” #portrait:adv_curious_nogem
   	 	“That way-- on the right.” #portrait:gem_statue_neutral
   	 	\[MOVE using WASD or ARROW KEYS\] #portrait:none
    	\[INTERACT using E or Z\]
	*   [“I don't CARE, just break it!"]
    	“I don't CARE, just break it! Seems like it should be a familiar enough concept to you!” #portrait:gem_statue_angry
   	 “Fine! I'm sorry about the dumbwaiter...” #portrait:adv_worried_nogem
    	“It wasn't being used for much. Fine, there might be a dagger on that shelf\-\-that way--” #portrait:gem_statue_neutral
    	[MOVE using WASD or ARROW KEYS] #portrait:none
    	[INTERACT using E or Z]

-    
->DONE

// ===1_begin===
// The adventurer is stuck in the office!
// + [check the shelf] -> 1_shelf
// + [check the bottles] -> 1_bottles
// + [check the statue] -> 1_statue
// + {has_key} [turn gold] -> 1_transmute_key
// + [check the door] -> 1_door

===1_shelf===
{stopping:
    -
    The Adventurer picks up an ornate dagger from the dusty shelf. #portrait:none
	//note: little bit of flavor text like this whenever you pick something up
	// sfx: shuffle of “item acquired but im lowkey about it also I'm tucking it away”
	[Open menu using ESC key. Select the dagger from inventory, and then USE in front of the alchemist statue.]
	~ has_dagger = true
    -
    It's just an empty shelf.  #portrait:none
}
->DONE


===1_statue===
{
- not has_dagger:
   {stopping:
   - "I'm so glad you enjoy admiring me, but I would love to get out of here first. Would you please hurry up?
    	#portrait:gem_angry
   - "..."
  	#portrait:gem_angry
   }
- has_dagger:
	{stopping:
    	-
    	It's a bit unflattering how you tumble to the ground, but you'd feel more indignant if it didn't mean a step towards freedom. #portrait:none
    	//sfx: clink
    	They pick you up.
    	“...How're we gonna open the door anyway?” #portrait:adv_curious
    	“Transmutation, adventurer. I am-- I mean WE, are going to make a key.” #portrait:gem_excited
    	“Like.. out of wood or something? That's gonna take a while.” #portrait:adv_frown
    	“No! Don't be ridiculous. Do you think the Great Alchemist would have her door locked with a wooden key? Gold! Only Gold would do. And we're going to dabble with some alchemy to create gold. Didn't you hear me?” #portrait:gem_angry
    	“I did-- but I don't know how to do magic, and ah.. you don't have hands,” #portrait:adv_frown
    	“It’s alchemy, not magic!? The DISRESPECT...” #portrait:gem_angry
    	“Well, I don’t know anything about either of those!” #portrait:adv_frown
    	*  [ “Did you hit your head? Why are you even here then??" ] #portrait:gem_angry
        	//should there be a better explanation from the adv?
         	“Did you hit your head? Why are you even here, if not to seek the Great Alchemist? ” #portrait:gem_angry
   		 The Adventurer looks away, unreadable. #portrait:none
   		 "..." #portrait:adv_neutral
   		 “--just tell me how to get out of here,” #portrait:adv_annoyed
   		 “Fine, I'll show you how. Bring me to those bottles.” #portrait:gem_neutral
        	-> 1_collect_gem
    	*   "Urgh... Fine, good thing my schedule's open all day... Let me explain." #portrait:gem_neutral
        	~ friendship += 1
        	"Transmutation is the science of transforming a pure material from one to another. I am a conduit for such processes."
        	"See, telepathy is just one of my many skills! I can also transform the most useless material into gold... Which is what we'll be doing now. Is that clear?" #portrait:gem_excited
        	"...it is. Yeah." #portrait:adv_smile 
        	"Very well then! For transmutation to proceed, we need material from the shelves. Bring me to those bottles over there." #portrait:gem_neutral
        	-> 1_collect_gem
    	-
    	The statue is broken now. Your life long prison/best friend forever, shattered and gone. #portrait:none
	}
}
->DONE

===1_collect_gem===
The adventurer collects the gem. #portrait:none
~has_gem = true
->DONE


===1_bottles===
{
- not has_dagger:
	{cycle:
	- (There's nothing there! Stop snooping around...)
    	#portrait:gem_angry
	- (This human is not very bright...)
    	#portrait:gem_angry
	- (ARGHHH!!!!!!)
    	#portrait:gem_angry
	}
- not has_gem:
	(if you don't come get me first, those things will not mean anything to you!)
 	#portrait:gem_angry
- has_gem:
	{stopping:
    	-
    	“You're gonna make a key out of …” #portrait:adv_confused
    	They pick up a jar and squint to read it's faded label,
    	“...salt??”
    	“Transmutation works only on pure substances and living things, and we need something malleable enough to shape.” #portrait:gem_neutral
    	“Perhaps lead will do.. over there,” #portrait:gem_neutral
    	The Adventurer collects a small piece of lead. #portrait:none
    	//#SFX: shuffle of “item acquired but im lowkey about it also im tucking it away”
    	“Shape it into a key, now.”  #portrait:gem_neutral
    	//#SFX:: schlopr. Idk buttons please come up with something
    	With some concentration, The Adventurer molds the lump of lead into a key. #portrait:none
    	//#CUTSCENE: there is a key sprite on the table
    	*   “Perfect!”  #portrait:gem_excited
        	~ friendship += 1
   		 “I’ve had some clay shaping experiences in my life.”  #portrait:adv_happy
   		 “Ah, you a master poterie?” #portrait:gem_excited
   		 “... No, I mean I’ve played with mud when I was a child.” #portrait:adv_frown
   		 -> 1_shaped_key
    	*   “Hm. It'll do.”  #portrait:gem_neutral
   		 “...Alright.” #portrait:adv_frown
   		 -> 1_shaped_key
    	-
    	"There sure is a lot of stuff here..." #portrait:adv_curious
    	"This isn't even half of it! Don't worry, we'll see more once we're out of here." #portrait:gem_excited
	}
}
->DONE

=== 1_shaped_key ===
“A lead key, of course, won't hold its shape when you turn it in a lock-- now it's my time to shine! Just hold me out, and...”  #portrait:gem_excited
[TRANSMUTE using C]
->DONE

=== 1_transmute_key === //triggered when transmute successful
// sfx: turned to gold
~has_key = true
The Adventurer watches as the dull gray shape turns gilded, and glittering in the dim, dusty light. They look surprised, but not as impressed as they REALLY ought to. #portrait:none
“Oh! Huh..”  #portrait:adv_curious
“...” #portrait:gem_neutral
	*   [You won't throw a fit, not now.] #portrait:gem_angry
    	The Adventurer can almost definitely feel your annoyance. Telepathy was never good for keeping your emotions to yourself.  #portrait:gem_angry
    	"Ahh, what's wrong?"  #portrait:adv_worried
    	"...You will see the value in my power eventually."  #portrait:gem_angry
    	"Oh, no... It was cool! It's just..." #portrait:adv_neutral
	*   [Throw a fit right now!!!]
    	“'Huh' to the greatest alchemical achievement ever realized? You really must've hit your head, Dulbert!” #portrait:gem_angry
   	 The adventurer makes a distasteful face. #portrait:adv_frown
   	 "Sorry! It was... It was like nothing I've ever seen before, but..."
	- “Listen, I really just need to get out of here.” #portrait:adv_frown
  	“Then let's go!”  #portrait:gem_angry
  	“Please,”  #portrait:adv_frown
  ->DONE


===1_door===
{
- not has_key:
	//sfx: locked door
	The door is locked.#portrait:none
	"..." #portrait:adv_neutral_nogem
	->DONE
- else:
	//sfx: door unlocked!
	The door is unlocked! #portrait:none
	"Oh! It worked..." #portrait:adv_curious
	"See, I told you how you can rely on me. Now, just follow my lead..."  #portrait:gem_excited
	Your total friendship point: {friendship}
	->DONE
}
