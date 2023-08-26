INCLUDE plot/1_Intro.ink
INCLUDE locations/Lab.ink


// main.ink
// contains global variables

EXTERNAL callSignal(signalName)


// character attributes
VAR c_vitality = 100
VAR c_haste = 5
VAR c_prowess = 5
VAR c_fortitude = 5

// arrays
// must list all possible values
// values in paren start out as present
LIST inventory = (torch), sword, cool_rock, ancient_scroll

// world status
VAR w_current_level = "Lab"
VAR w_secrets_found = 0

