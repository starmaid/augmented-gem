// main.ink
// contains global variables


INCLUDE plot/1_entry.ink
INCLUDE plot/2_mission.ink
INCLUDE plot/3_exit.ink
INCLUDE locations/floor_0.ink
INCLUDE locations/floor_3.ink

VAR myNumber = 5
VAR knowledge_of_the_cure = false
VAR players_name = "Emilia"
VAR number_of_infected_people = 521
VAR current_floor = -> floor_0


-> outside_front_door

=== home ===

You are in the house

+ wander
-> current_floor
+ go to basement
~ current_floor = -> floor_0
-> current_floor
+ go to attic
~ current_floor = -> floor_3
-> current_floor
+ leave
-> END