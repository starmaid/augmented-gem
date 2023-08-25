INCLUDE sections/office.ink
INCLUDE sections/mansion_1.ink
INCLUDE sections/mansion_2.ink
INCLUDE sections/mansion_3.ink
INCLUDE sections/library.ink

// main.ink
// contains global variables
VAR friendship = 0

// office
VAR has_gem = false
VAR has_dagger = false
VAR has_key = false
VAR has_gold_key = false

// arrays
// must list all possible values
// values in paren start out as present
LIST inventory = (torch), sword, cool_rock, ancient_scroll

// world status do we need these?
VAR w_current_level = "Lab"
VAR w_secrets_found = 0