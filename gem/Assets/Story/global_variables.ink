INCLUDE sections/1_office.ink
INCLUDE sections/2_spooky_hallway.ink
INCLUDE sections/3_tut_puzzle_room.ink
INCLUDE sections/4_south_hall.ink
INCLUDE sections/5_spooky_lab.ink
INCLUDE sections/6_south_puzzle_room.ink
INCLUDE sections/7_library.ink
INCLUDE sections/8_west_hall.ink
INCLUDE sections/9_bedroom.ink
INCLUDE sections/10_bathroom.ink
INCLUDE sections/11_west_puzzle_room.ink
INCLUDE sections/12_east_hall.ink
INCLUDE sections/13_dining_hall.ink
INCLUDE sections/14_kitchen.ink
INCLUDE sections/15_cellar.ink
INCLUDE sections/16_east_puzzle_room.ink
INCLUDE sections/17_getting_outta_here.ink
INCLUDE sections/18_getting_outta_here.ink


EXTERNAL pauseForCutscene()
EXTERNAL callSignal(signalName)
EXTERNAL goToNext(delayTime)
EXTERNAL startBackgroundAudio()

// main.ink
// contains global variables
VAR friendship = 0

// arrays
// must list all possible values
// values in paren start out as present

// world status do we need these?
VAR w_current_level = "Lab"
VAR w_secrets_found = 0