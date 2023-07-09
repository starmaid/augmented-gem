// 1_entry.ink
// this file defines entry scenarios
// created by Star

=== outside_front_door ===

You walk up to the front door.

GUY: How are things going man?
* wassup
    GUY: Oh yknow its alright
    ** i get that 
    -> home
    ** Sure. 
    -> home
* whats going on
    GUY: Nothin.
    -> home
+ go to window
-> in_bushes_outside_broken_window


=== in_bushes_outside_broken_window ===

This window is broken. You might be able to climb inside.

* climb in
-> home
+ go to door
-> outside_front_door