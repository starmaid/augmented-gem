// main.ink
// contains global variables


INCLUDE plot/1_entry.ink
INCLUDE plot/2_mission.ink
INCLUDE plot/3_exit.ink
INCLUDE locations/floor_0.ink
INCLUDE locations/floor_1.ink
INCLUDE locations/floor_3.ink

VAR paid_cover = false
VAR players_name = "Emilia"
VAR beers_drank = 0
VAR current_floor = -> floor_1


-> outside_front_door

=== home ===

You are in the house

+ wander
-> current_floor
+ take sip number {beers_drank + 1}
~ beers_drank = beers_drank + 1
-> current_floor
+ go to basement
~ current_floor = -> floor_0
-> current_floor
+ go to first floor
~ current_floor = -> floor_1
-> current_floor
+ go to attic
~ current_floor = -> floor_3
-> current_floor
+ leave
-> END