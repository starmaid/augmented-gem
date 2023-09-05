===1_begin_cutscene_1===
//#CUTSCENE: Fade to black.
You have been dormant for so long. #portrait:none 
You cannot remember how long you have been down here...
A year? A decade? A <i>century</i>?
Time feels just as stagnant as the air in this room-- changeless, clogged with dust. It has been sealed so long and so well that there isn't even any decomposition for you to estimate with.
Maybe besides your memories. Your patience. Your <i>charitability</i>.
You are so. Goddamn. Bored. #speed:0.1
\-\-and there's nothing you can do about it, besides wait.
...until...
~pauseForCutscene()
//#SFX: rumbling sound
“Hm..?” #portrait:gem_statue_neutral
~pauseForCutscene()
//#SFX: CRASH
//#CUTSCENE: black screen fades to the study
Someone crashes into the room. Through the… dumbwaiter? Huh, you forgot that was there. #portrait:none
“Oh? Finally!” #portrait:gem_statue_excited
~pauseForCutscene()

//#SFX: shuffling. The adventurer is sitting on the floor, distressed.
"Ow..." #portrait:adv_worried_nogem
“Huh... where am I?” #portrait:adv_confused_nogem
“Oh, oh no! I have to get back up there!” #portrait:adv_worried_nogem
~pauseForCutscene()

"I better get their attention while they're still here..."  #portrait:gem_statue_worried
~callSignal("WiggleMode")
\[Press and hold Z to WIGGLE.\]
// ~callSignal("PauseCutsceneSignal")
->DONE

===1_begin_cutscene_2===

//#PLAYER: When the player press any move keys or act keys, the gem wiggles instead, giving off a little shimmer.
"...!" #portrait:adv_neutral_nogem

~pauseForCutscene()
//#CUTSCENE: The adventurer approaches the Gem, and touches it. 
The adventurer approaches the statue, admiring its golden features. Their eyes fall on you, running their fingers along your dust covered, perfect edges.
This is it! Your way out... Better think twice how you should approach this. #portrait:none
	+   [Greet them in a friendly manner, you can't scare them away! ]
    	"Fine evening, Adventurer! How can I be of assistance?" #portrait:gem_statue_excited
	+   [Be clear and precise. This might be your only opportunity.]
    	“Listen closely, Adventurer…” #portrait:gem_statue_neutral
    	“If you want a chance to get out of here, do <i>not</i> let go!”
- "...Ah!!!! Who's there?” #portrait:adv_worried_nogem
“Wait- don't move! Listen to me!”  #portrait:gem_statue_angry
~pauseForCutscene()

//#CUTSCENE: The adventurer backs away a few steps
“Don't hurt me! I didn't steal anything from you!” #portrait:adv_worried_nogem
Damn it! They walked off... #portrait:gem_statue_angry
	+   \(The statue can't talk back, Dulbert!\)  #portrait:gem_statue_angry
	+   \(If there's no contact, I can't talk to you!\)  #portrait:gem_statue_angry
	+   \(Humans are SO. STUPID.\)  #portrait:gem_statue_angry
-"Ugh, this place is creeping me out..." #portrait:adv_worried_nogem
"Come on... There's gotta be a way out somewhere..."
~pauseForCutscene()

//#CUTSCENE: the adventurer walks away.
//#CUTSCENE: Fade to black.
You think you blew your chances. That human's your best chance to escape this dreadful place. #portrait:none
You watch as they fiddle with the lock with no finesse of a thief, pry at the door with no strength of a fighter.
Lucky for you, this adventurer seems far from competent enough to escape a locked dungeon alone.
You just need to wait a little bit longer-- they'll eventually come back, begging for your grace and guidance.
~pauseForCutscene()

//Wait like. a few seconds?
...
"...hello? Are you still there? Talking statue?"  #portrait:adv_curious_nogem
Unlucky for you, <i>this</i> is the human that you’re stuck with. #portrait:none
~pauseForCutscene()

//#CUTSCENE: Fade from black.The adventurer is standing at the edge of the
Hesitantly, the adventurer walks back over-- good! --And pokes you. It’ll do. #portrait:none
“<i>Don’t</i> take your hand away! I cannot speak to you otherwise.” #portrait:gem_angry
“Ah–!” #portrait:adv_worried_nogem
“...How are you speaking with your mouth closed?”  #portrait:adv_frown_nogem
“LOOK DOWN FUCKFACE” #portrait:gem_statue_angry
“You’re… the gem?” #portrait:adv_curious_nogem
“Indeed! Contact telepathy, Dulbert.” #portrait:gem_statue_neutral
“...” #portrait:adv_curious_nogem
“...Oh, I must be losing it.” #portrait:adv_frown_nogem
“Listen, kid… There are oddities in this world so stupendous that you may never understand with your humble little brain… "#portrait:gem_statue_excited
"Not unless you’ve seen them with your own eyes, touched them with your own fingers.”
“\-\- Which you are in the perfect position to do! You can witness wonderful things here, with <i>me,</i> if you could just… get me <i>out</i> of this shiny little prison!”
“...”  #portrait:adv_frown_nogem
You can’t quite tell what they’re thinking, but they seem far too worried about something else to admire your spectacular self. Odd! You’ve always been good with charming humans. Better step up your game...! #portrait:none
	+   [Threaten them.]"You’re not going to get anywhere alone, Dulbert."  #portrait:gem_statue_neutral
    	“That’s not my name-” #portrait:adv_worried_nogem //#signal:try_continue
		// ~ goToNext(0.3f) //dont thing this works
    	“I know this mansion like the back of my crystal faces, <i>Dulbert</i>. I have the key to this office gate that you couldn’t budge. My guidance is the best chance you’ve got.” #portrait:gem_statue_angry
    	“But of course, you feel free to go ahead and try it on your own,  fail, stay stuck in here for a thousand years, and then die of <i>BOREDOM</i>.” #portrait:gem_statue_neutral
    	“...<i>Die</i>?” #portrait:adv_worried_nogem
    	“Oh, right, that too! And probably much, much sooner!” #portrait:gem_statue_excited
    	“...”  #portrait:adv_frown_nogem
    	“Well, tell me when you make up your mind! I’ll be here dozing away, it’s not like it matters to me.” #portrait:gem_statue_neutral
    	You wiggle once more, pretending to tuck yourself into those golden fingers as comfortably as you can. #portrait:none
    	+ + \(...\)
			\(...Are they looking?\)#portrait:gem_statue_worried
	+   [Reassure them.] "Fear not Dulbert, nothing to be concerned about! I know exactly how we could get out of here…“ #portrait:gem_statue_neutral
    	~ friendship += 1
    	“But…” #portrait:adv_worried_nogem
    	“Now, now, I understand. People are often scared of what they don’t understand. Lucky for you, I know this mansion like my very own crystalline structure, and I’m a great tutor too!”#portrait:gem_statue_excited
    	"Not to mention the unimaginable power that I possess..."#portrait:gem_statue_neutral
    	"That sounds... intense." #portrait:adv_frown_nogem
    	“Fret not, fret not. Never ever would I let you get in harm’s way, I promise! As long as you do exactly what I instruct, you’ll be <i>perfectly fine</i>.”#portrait:gem_statue_neutral
- The Adventurer looks around the room briefly, as if for some other last minute option, before turning back to you. #portrait:none
“...fine.” #portrait:adv_frown_nogem
“Very well! I'm glad you chose correctly!” #portrait:gem_statue_excited
"..." #portrait:adv_frown_nogem
“For the first stage of your guided tour, you've got to get me out of this statue.” #portrait:gem_statue_neutral
“I.. guess so-- how?” #portrait:adv_frown_nogem
	*   “There's a dagger, near the shelf over there." #portrait:gem_statue_neutral
    	~ friendship += 1
    	"If memory serves, that is. Pry me out! Don't take your time.” #portrait:gem_statue_neutral
   	 	“Where? There's.. a lot of stuff in here,” #portrait:adv_curious_nogem
   	 	“That way-- on the right.” #portrait:gem_statue_neutral
   	 	\[MOVE using WASD or ARROW KEYS\] #portrait:none
    	\[INTERACT using Z\]
	*   [“I don't <i>care</i>, just break it!"]
    	“I don't <i>care</i>, just break it! Seems like it should be a familiar enough concept to you!” #portrait:gem_statue_angry
   	 “Fine! I'm sorry about the dumbwaiter...” #portrait:adv_worried_nogem
    	“It wasn't being used for much. Fine, there might be a dagger near that shelf\-\-that way--” #portrait:gem_statue_neutral
    	\[MOVE using WASD or ARROW KEYS\] #portrait:none
    	\[INTERACT using Z\]
-    
~startBackgroundAudio()
->DONE

// ===1_begin===
// The adventurer is stuck in the office!
// + [check the shelf] -> 1_dagger
// + [check the bottles] -> 1_bottles
// + [check the statue] -> 1_statue
// + {has_key} [turn gold] -> 1_transmute_key
// + [check the door] -> 1_door

===1_dagger===
{stopping:
	// -
	// FOR the sake of convenience, here's the key #portrait:none //DEBUG
	// ~has_key = true
    -
    The Adventurer picks up an ornate dagger beside a pile of dusty books. #portrait:none
	//note: little bit of flavor text like this whenever you pick something up
	// sfx: shuffle of “item acquired but im lowkey about it also I'm tucking it away”
	// \[Open menu using ESC key. Select the dagger from inventory, and then USE in front of the alchemist statue.\]
	~ has_dagger = true
	~ callSignal("ItemRetrieved")
    // -
    // It's just an empty shelf.  #portrait:none
}
->DONE


===1_statue===
{
- not has_dagger:
   {stopping:
   - "I'm so glad you enjoy admiring me, but I would love to get out of here first. Would you please hurry up? #portrait:gem_angry
   - "..." #portrait:gem_angry
   }
- has_dagger:
	{stopping:
    	-
    	It's a bit unflattering how you tumble to the ground, but you'd feel more indignant if it didn't mean a step towards freedom. #portrait:none
    	~ callSignal("BreakStatue")
    	They pick you up.
		~ callSignal("ItemRetrieved")
    	“...How're we gonna open the door anyway?” #portrait:adv_curious
    	“Transmutation, adventurer. I am-- I mean WE, are going to make a key.” #portrait:gem_excited
    	“Like.. out of wood or something? That's gonna take a while.” #portrait:adv_frown
    	“No! Don't be ridiculous. Do you think the Great Alchemist would have her door locked with a wooden key?"  #portrait:gem_angry
		"Gold! Only Gold would do. And we're going to dabble with some alchemy to create gold. Didn't you hear me?” #portrait:gem_angry
    	“I did-- but I don't know how to do magic, and ah.. you don't have hands,” #portrait:adv_frown
    	“It’s alchemy, not magic!? The <i>disrespect</i>...” #portrait:gem_angry
    	“Well, I don’t know anything about either of those!” #portrait:adv_frown
    	*  [ “Why are you even here then??" ]
        	//should there be a better explanation from the adv?
         	“Did you hit your head? Why are you even here, if not to seek the Great Alchemist? ” #portrait:gem_angry
   		 The Adventurer looks away, unreadable. #portrait:none
   		 "..." #portrait:adv_neutral
   		 “--just tell me how to get out of here,” #portrait:adv_annoyed
   		 “Fine, I'll show you how. Bring me to those bottles.” #portrait:gem_neutral
        	-> 1_collect_gem
    	*   ["Urgh... Fine, let me explain." ]
			"Urgh... Fine, good thing my schedule's open all day... Let me explain." #portrait:gem_neutral
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
	- (There's nothing there! Stop snooping around...) #portrait:gem_angry
	//   for simplicity debug: ur getting the dagger and the gem
	//   ~ has_dagger = true
	//   ~ has_gem = true
	- (This human is not very bright...) #portrait:gem_angry
	- (ARGHHH!!!!!!) #portrait:gem_angry
	}
- not has_gem:
	(if you don't come get me first, those things will not mean anything to you!) #portrait:gem_angry
- has_gem:
	{stopping:
    	-
    	“You're gonna make a key out of …” #portrait:adv_confused
    	They pick up a jar and squint to read it's faded label,
    	“...salt??”
		“Transmutation works only on pure substances and living things, and we need something malleable enough to shape.” #portrait:gem_neutral
		“Perhaps lead will do.. over there,” #portrait:gem_neutral
		The Adventurer collects a small piece of lead. #portrait:none
		“Shape it into a key, now.”  #portrait:gem_neutral	

    	->1_check_bottles
    	-
    	"There sure is a lot of stuff here..." #portrait:adv_curious
    	"This isn't even half of it! Don't worry, we'll see more once we're out of here." #portrait:gem_excited
	}
}
->DONE

=== 1_check_bottles ===

~callSignal("BeginSceneKeyshaping")
~pauseForCutscene()
//#SFX:: schlopr. Idk buttons please come up with something
//#CUTSCENE: there is a key sprite on the table
With some concentration, The Adventurer molds the lump of lead into a key. #portrait:none
~pauseForCutscene()
"How is this?" #portrait:adv_neutral
"Hmm..."#portrait:gem_neutral
*   “Perfect!”  #portrait:gem_excited
	~ friendship += 1
	“I’ve had some clay shaping experiences in my life.”  #portrait:adv_happy
	“Ah, you a master poterie?” #portrait:gem_excited
	“... No, I mean I played with mud when I was a child.” #portrait:adv_frown
	-> 1_shaped_key
*   “Hm. It'll do.”  #portrait:gem_neutral
	“...Alright.” #portrait:adv_frown
	-> 1_shaped_key
->DONE

=== 1_shaped_key ===
“A lead key, of course, won't hold its shape when you turn it in a lock-- now it's my time to shine! Just hold me out, and...”  #portrait:gem_excited
[TRANSMUTE using C]
->DONE

=== 1_transmute_key === //triggered when transmute successful
// sfx: turned to gold
~has_key = true
The Adventurer watches as the dull gray shape turns gilded, and glittering in the dim, dusty light.
“Oh! Huh..”  #portrait:adv_curious
They look surprised, but not as impressed as they <i>really</i> ought to. #portrait:none
“...” #portrait:gem_neutral
	*   [You won't throw a fit, not now.]
		"..." #portrait:gem_angry
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
	~callSignal("ItemRetrieved")
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
	// Your total friendship point: {friendship}
	~callSignal("UnlockDoor")
	->DONE
}

===2_door===
{cycle:
- 	"..."
	"Where do you think you're going?"
	"We might've missed something in there, I thought we could check?"
	"What? No. No you haven't."
	"There are far more exciting things"
	"There's a patch of cobblestone on the ceiling two paces south of the shelf that is shaped like a cat or a cow."
	"Ta. Tour over. There's nothing else in that room."
}
->DONE

===z_cushion_spotted===
"Huh? A dead end... Strange, I didn't remember it being there." #portrait:gem_neutral
"Some conveniently placed pillows...!" #portrait:adv_smile
	* 	"Hey, now's not the time to slack off!"  #portrait:gem_angry
		The adventurer ignores your words and head straight for the comfortable looking cushions.
	* 	"...Fine, take a break then." #portrait:gem_angry
		"Goodness!"
-With all the strange things going on, you might as well take a break. 

->DONE

===z_demo_end===
Thank you for completing the demo of <i> Chrysopoeia: A Glimmer in the Dark </i>!
What? "That's too short?" you say? Sorry, carving out an underground castle was more time consuming than we anticipated!
If you enjoy what you've played and would like to know more about the Adventurer and the gem, consider leaving a comment!
We still have a lot of ideas we want to put in this game, and much more story to tell, but it'll be your support that'll help us see it through. It means a lot to us.
We hope to see you return to the dark in the future...
-> DONE

=== 1_lion_statue ===
{
- not has_gem:
	{stopping:
	- 
	The Adventurer stops to look at a statue of a lion with an orb in it's mouth.
	-
	{cycle:
	- (Why do you care about a statue! <i>I'm</i> right here!) #portrait:gem_statue_angry
	- (This human is not very bright...) #portrait:gem_statue_angry
	- (ARGHHH!!!!!!) #portrait:gem_statue_angry
		}
- has_gem:
	{stopping:
	- 
	The Adventurer stops to look at a statue of a lion with an orb in it's mouth.
	"This is pretty..." #portrait:adv_curious
	"This is <i>nothing</i> compared to what I could show you\-\-" #portrait:gem_excited
	"\-\-once we're <i>out of this stupid room!</i>" #portrait:gem_angry
	"I just think big cats are nice..." #portrait:adv_frown
	-
	"She had some sort of <i>something</i> with lions..." #portrait:gem_neutral  
		}
	}
}
    ->DONE

=== 1_books ===
{
- not has_gem:
	{stopping:
	- 
	The Adventurer flips through book. The dust that rises off the page makes them sneeze.
	-
	{cycle:
	- (You probably can't even read that! Leave it alone!) #portrait:gem_angry
	- (This human is not very bright...) #portrait:gem_angry
	- (ARGHHH!!!!!!) #portrait:gem_angry
		}
	}
- has_gem:
	{stopping:
	- 
	The Adventurer flips through book. The dust that rises off the page makes them sneeze (again.)
	"..." #portrait:adv_curious
	"What's <i>'Chrsopoeia: The Great Work of Alchemy'?</i>" portrait:adv_neutral
	"Look at me, and then ask that question one more time. Really slowly." #portrait:gem_neutral
	-
	"There are plenty more ah... <i>coherent</i> books in the library." #portrait:gem_worried
	}
}
	->DONE


=== 1_papers ===
{
- not has_gem:
	{stopping:
	- 
	The Adventurer squints at the scribbled papers scattered around the room.
	-
	{cycle:
	- (They <i>definitely</i> can't read those...) #portrait:gem_angry
	- (This human is not very bright...) #portrait:gem_angry
	- (ARGHHH!!!!!!) #portrait:gem_angry
		}
	}
- has_gem:
	{stopping:
	- 
	The Adventurer squints at the scribbled papers scattered around the room.
	"..." #portrait:adv_confused
	"Err.. I can't read this." #portrait:adv_frown
	"She wrote everything in code, so no one else could claim credit for her work." #portrait:gem_neutral
	"Do you know how to translate it?" #portrait:adv_curious
	"I don't think you would find it much more comprehensible." #portrait:gem_neutral
	-
	"One of the skills I am going to have to teach you is <i>'prioritization.'</i>" #portrait:gem_angry
	}
}
->DONE

=== 1_alchemy_equiptment ===
{
- not has_gem:
	{stopping:
		- 
		The Adventurer pokes at some glassware on a table. 
		-
		{cycle:
		- (Are they ignoring me?) #portrait:gem_angry
		- (This human is not very bright...) #portrait:gem_angry
		- (ARGHHH!!!!!!) #portrait:gem_angry
		}
	}
- has_gem:
	{stopping:
	- 
	The Adventurer pokes at some glassware on a table.
	"Are you sure you're not interested in alchemy?" #portrait:gem_excited
	"Oh\-\- that's what that's for?" #portrait:adv_curious
	"..What did you THINK it was for?" #portrait:gem_neutral
	"I dunno... cooking maybe?" #portrait:adv_frown
	-
	"This is useless to both of us right now." #portrait:gem_angry
	}
}
->DONE

=== 1_rubble ===
{
- not has_gem:
	{stopping:
	- 
	The Adventurer looks at the crumbled stone where the dumbwaiter used to be.
	-
	{cycle:
	- (They're not going to try to climb that, are they? ...That would be entertaining to watch.) #portrait:gem_neutral
	- (This human is not very bright...) #portrait:gem_angry
	- (ARGHHH!!!!!!) #portrait:gem_angry
	}
	}
- has_gem:
	{stopping:
	- 
	The Adventurer looks at the crumbled stone where the dumbwaiter used to be.
	"This place took ages to build..." #portrait:gem_worried
	"..." #portrait:gem_neutral
	"Kick it for me!" #portrait:gem_angry
	"..." #portrait:adv_frown
	The adventurer gives the wall a light kick, and a few more pebbles tumble down. They wince.
	"Did that ah.. help..?" #portrait:adv_neutral
	"..." #portrait:gem_worried
	"Let's just leave!" #portrait:gem_neutral
	-
	"Things aren't in the best shape up there..." #portrait:adv_frown
	}
}
->DONE


=== 1_bookw ===
{
- not has_gem:
	{stopping:
	-
	The Adventurer pauses at a bookshelf.
	// -
    {cycle:
    - (Hpmh. The human probably isn't even bright enough to read them.) #portrait:gem_statue_angry
    - (That is very clearly not a dagger... what is the human doing?) #portrait:gem_statue_angry
    - (Is the human blind? That is a <i>book<i>shelf, not a <i>dagger<i> shelf...) #portrait:gem_statue_angry
    }
    }
- has_gem:
	{stopping:
	-
	The Adventurer pauses as a bookshelf.
	"That's a lot of dust... I can't even read the titles of the books" #portrait:adv_curious
	+ "You probably can't even read them anyways, dulbert." #portrait:gem_angry
	-> DONE
	+ "We do not have time to read books, dusty or otherwise." #portrait:gem_neurtral
	-> DONE
    }
}
-> DONE


=== 1_booke ===
{
- not has_gem:
	{stopping:
	-
	The Adventurer checks out a bookshelf.
	{cycle:
		- (Hpmh. The human probably isn't even bright enough to read them.) #portrait:gem_statue_angry
		- (That is very clearly not a dagger... what is the human doing?) #portrait:gem_statue_angry
		- (Is the human blind? That is a <i>book<i>shelf, not a <i>dagger<i> shelf...) #portrait:gem_statue_angry
		}
    }
- has_gem:
	{stopping:
	-
	The Adventurer checks out a bookshelf.
	"'Properties of Gold'?, 'The Journey to Immortal Life'?, <i>'Urine to ur Riches'?!<i>" #portrait:adv_curious
	+ "Don't be so scandalized. This is all standard alchemical practice" #portrait:gem_neutral
		"I- huh... okay?" #portrait:adv_neutral
		"'OKAY'??? Clearly your mind is too simple to realize the- ... I am not going to bother explaining this to a dulbert. Let's just go" #portrait:gem_angry
		-> DONE
	+ "While it  might seem strange to common folk, like you, to an alchemist this is standard practice." #portrait:gem_neutral
		"Oh. Huh, interesting" #portrait:adv_curious
		"Interesting is just the start of it! But... let's discuss this another time. Preferably once we're out of this castle" #portrait:gem_excited
		-> DONE
    }
}
-> DONE