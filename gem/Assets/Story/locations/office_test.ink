VAR has_gem = false
VAR has_dagger = false
VAR has_key = false
VAR has_gold_key = false

-> begin

===begin===
//square brackets are used so when the choice is selected, [this part] will not be shown.
//this choice branch is to simulate 
The adventurer is stuck in the office!
+ [check the shelf] -> shelf 
+ [check the bottles] -> bottles
+ [check the statue] -> statue
+ {has_key} [turn gold] -> transmute_key
+ [check the door] -> door

===shelf===
{stopping:
	-
	The Adventurer picks up an ornate dagger from the dusty shelf. #portrait:none
    //note: little bit of flavor text like this whenever you pick something up
    // sfx: shuffle of “item acquired but im lowkey about it also im tucking it away”
    [Open menu using ESC key. Select the dagger from inventory, and then USE in front of the alchemist statue.]
    ~ has_dagger = true

	-
	It's just an empty shelf.  #portrait:none
}
->DONE

===bottles===
{
- not has_dagger:
    {cycle:
    - (There's nothign there! Stop snooping around...) 
        #portrait:gem_angry
    - (you are not very bright are you.)
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
        “Transmutation works only on pure substances, and living things, and we need something malleable enough to shape.” #portrait:gem_neutral
        “Perhaps lead will do.. over there,” #portrait:gem_neutral
        The Adventurer collects a small piece of lead. #portrait:none
        // sfx: shuffle of “item acquired but im lowkey about it also im tucking it away”
        “Shape it into a key, now.”  #portrait:gem_neutral
        // sfx: schlopr. Idk buttons please come up with something
        With some concentration, The Adventurer molds the lump of lead into a key. #portrait:none
        
        *“Perfect!”  #portrait:gem_excited
        	“I’ve had some clay shaping experiences in my life.”  #portrait:adv_happy
        	“Ah, you a master poterie?” #portrait:gem_excited
        	“Er, no, I mean I’ve played with mud when I was a child.” #portrait:adv_frown
        	-> shaped_key
        *“Hm. It'll do.”  #portrait:gem_neutral
        	“...Alright.” #portrait:adv_frown
        	-> shaped_key
        -
        "There sure is a lot of stuff here..."
        "This isn't even the half of it!"
    }
}
->DONE

=== shaped_key ===
“A lead key, of course, won't hold its shape when you turn it in a lock-- so allow my power to change its substance.”  #portrait:gem_excited
[TURN TO GOLD using C]
// sfx: sparkle !!! idk, turn to gold noise
~has_key = true
-> begin

=== transmute_key ===
The Adventurer watches as the dull gray shape turns gilded, and glittering in the dim, dusty light. They look surprised, but not as impressed as they REALLY ought to. #portrait:none
“Oh! Huh..”  #portrait:adv_curious
“...” #portrait:gem_neutral

*“"Huh" to the greatest alchemical achievement ever realized. You really must've hit your head.” #portrait:gem_angry
	The adventurer makes a distasteful face.
*“Well.. you'll come to see the value in it.”  #portrait:gem_neutral

- “Listen, I really just need to get out of here..” #portrait:adv_frown
  “Then let's go!”  #portrait:gem_angry
  “Please,”  #portrait:adv_frown
  -> DONE


===statue===
{
- not has_dagger:
   {stopping:
   - "I'm glad you are admiring me, but I would love to get out of here first. Would you please go find a dagger?"
   - "..."
   }
- has_dagger:
    {stopping:
        -
        It's a bit unflattering how you tumble to the ground, but you'd feel more indignant if it didn't mean a step towards freedom. #portrait:none
        //sfx: clink
        They pick you up.
        “...How're we gonna open the door anyway?” #portrait:adv_curious
        “Transmutation, wanderer. I-- I mean WE, are going to make a key.” #portrait:gem_excited
        “Like.. out of wood or something? That's gonna take a while.” #portrait:adv_frown
        “No! Didn't you hear me?” #portrait:gem_angry
        “I did-- but I don't know how to do magic, and ah.. you don't have hands,” #portrait:adv_frown
        “It’s alchemy, not magic!?” #portrait:gem_angry
        “I don’t know anything about that either!” #portrait:adv_frown
        *“...Why are you even here, then?” #portrait:gem_neutral
        	The Adventurer looks away.
        	"..."
        	“--let's just get out of here,” #portrait:adv_annoyed
        	“Fine, I'll just show you. Bring me to those bottles.” #portrait:gem_neutral
            -> collect_gem
        *“I AM A CONDUIT FOR ALCHEMY-- did you hit your head??” #portrait:gem_angry
        “I don't know! it.. sounded like a different thing than talking jewels,” #portrait:adv_confused
        “Obviously! Just-- bring me to those bottles, I’ll show you.” #portrait:gem_angry
            -> collect_gem
        -
        The statue is broken now. Your life long prison/best friend forever, shattered and gone.
    }
}
-> DONE

===collect_gem===
The adventurer collects the gem.
~has_gem = true
->DONE


===door===
{
- not has_key:
    //sfx: locked door
    The door is locked.
    -> begin
- else:
    //sfx: door unlocked!
    The door is unlocked!
    "Oh! It worked..."
    "See, I told you how reliable I can be. Now, just follow my lead..." ->END
}












