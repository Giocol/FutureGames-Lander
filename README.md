# FutureGames assignement for the Game Programming in C# course
## Lander: a game about flying, and maybe landing

### References
Given the small scope of the project, I tried to use the Unity Docs as much as possible, rather than relying too much on stackoverflow/unity forums and other sources of that kind. I of course still looked things up here and there, but nothing major. 
Even if I ended up not using a lot of it, I took inspiration and modified some code snippets from this talk about Scriptable Objects https://www.youtube.com/watch?v=raQ3iHhE_Kk. I wanted to implement an event system based on the one he demo-d in the talk, but I ended up scrapping it and now the only remains of it are in the never-merged `feature/so_events` branch.
The `Init.cs` class was lifted pretty much verbatim from one of the lectures :\)
The `Floater.cs` class started off from https://forum.unity.com/threads/how-to-make-an-object-move-up-and-down-on-a-loop.380159/

### Manual
Your ship has been critically damaged, the online online systems are your **emergency thrusters** and your **threat camera feed**. Land on a landing pad to proceed to the next section. Your **shields are offline**, your ship is not gonna be able to survive even the slightest impact with the rocky formations of the planet, and it can only take a few missles before full meltdown. Your **threat camera feed** is going to display what the nearest threat is seeing at the moment, use it to your advantage.
There are two different kinds of **pickups** you can find, they'll help you get to the landing zone in one piece.
- **Hull repair pickup** ![Hull Repair Pickup](pickup_health.png) Repairs the hull
- **Drag reduction pickup** ![Hull Repair Pickup](pickup_drag.png) Brings the drag-reduction system back online, reducing the ship's percieved drag.

#### Editor-specific notes
You can start the game from any scene, thanks to the `Init.cs` script :\)


#### Controls
- **Directional thrusters**: WASD
- **Takeoff thrusters**: spacebar
- **Yaw thrusters**: Q to yaw left, E to yaw right