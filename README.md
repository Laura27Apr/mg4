# HW4
## Devlog
In this game, the Player doesn't control the game as a Controller. I only have it show event states during important actions, without dealing with the results of those actions. I defined two events within Player: - When the player collides with a pipe, the failure event is triggered via PlayerLost?.Invoke(). When the player successfully passes through the gap in the pipe, the scoring event is triggered. Both events are defined within the Player class. They are invoked within collision detection logic (OnCollisionEnter2D()) and scoring logic (OnTriggerEnter2D()). The player is responsible for emitting state information like "PlayerLost" or "PlayerScored," and nothing else.


GameController is in charge of controlling the game. In the Start() method of GameController, I subscribe to the player's failure event using the following code:
When the player triggers the "PlayerLost" event, the "GameStopped" method is invoked, setting the "_gameStopped" variable to true. Then, in the Update() method of GameController, it first checks the _gameStopped variable. When the player triggers the PlayerLost event, the GameStopped() method is invoked, setting the _gameStopped variable to true. Then, in the GameController's Update() method, we check the state of _gameStopped. If that's true, the method stops early, so SpawnPipe isn't called anymore and doesn't generate any more pipes. This approach makes sure that the GameController is the only one deciding if the game should keep going.


The View layer has scripts like UI, GameAudio, and Pipe. The UI script is connected to the PlayerScored and PlayerLost events. This means that when something happens in the game, like a player scoring or losing, the score text is updated or the "Game Over" message is displayed. GameAudio also uses these events to play the right sound effects when something goes wrong. The Pipe script only handles its own display and movement logic. For example, it determines whether to continue moving left in Update() based on the current game state. These scripts don't control the game flow. They just give the player visual or auditory feedback about changes in the game.


To keep these systems separate, I mostly use events to "communicate" with them. The Player doesn't directly call any methods in UI, GameAudio, or GameController. It only triggers events via Invoke(). Whether other components listen for and respond to these events depends on their code. This approach makes the Player not directly dependent on the View or Controller.


I also use a Singleton Locator class to manage access to important objects. This lets me retrieve references through things like Locator.Instance.Player and Locator.Instance.GameController. This approach eliminates the need for manual reference passing or lookup methods between scripts while preventing the Player from directly depending on specific View or Controller implementations.



## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites