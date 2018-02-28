Welcome to Niko's Breakout!

First off, if you want to load between scenes in game, make sure to add the scenes
to the build settings. Else, you can just open and play Level1 & Level2 directly
(they are located in the Scenes folder).

The paddle is controlled directly by the mouse and you win when all bricks are 
broken. The red bricks just break when hit, and the green bricks give you an 
addition ball.

In this document you'll find general summaries for all classes in the game (located
in the Scripts folder). In addition, I complied a series of notes on everything
else.

=====CLASSES=====

BallController.cs
/// <summary>
/// This script defines the behavior for the breakout ball. It's functionalities include:
/// 
/// 1. Keeping track of the total number of balls on screen & RePool a off screen ball if there's 
///    one other on screen.
/// 2. Defining the speed, starting position, & spread (angle of firing on start and instantiation)
/// 3. Defining behavior when the ball interacts with the paddle.
/// 
/// The reflection of the ball off the paddle is based on which side it hit the paddle. The farther
/// the ball is from the center, the greater the angle of reflection.
/// </summary>

BallPooler.cs
/// <summary>
/// This script defines the behavior for a simple object pooler for the breakout balls.
/// It holds a max of 10 balls and the balls repool themselves only if there's at least
/// 1 other ball still on screen.
/// </summary>

BrickController.cs
/// <summary>
/// This script defines the behavior of a simple breakout brick. Functionalities include:
/// 
/// 1. Keeping track of the total number of bricks in the scene.
/// 2. Defining behavior when the brick is hit by a ball.
/// </summary>

BrickController_AddBall.cs
/// <summary>
/// This script is for the AddBall variant of a breakout brick. Additional functionalities include:
/// 
/// 1. Spawning a new ball when this brick is "destroyed."
/// </summary>

GameStateController.cs
/// <summary>
/// This script controls the "gamestate." Functionalities include:
/// 
/// 1. Checking for the win condition and spawning the menu to either restart the
///    game or go back to the main menu.
/// </summary>

LevelBuilder.cs
/// <summary>
/// This script builds out the level from an XML (text file). Functionalities include:
/// 
/// 1. Loading the file into an array of strings consisting of document lines.
/// 2. Iterating through each character in each line and instantiating the correct 
///    brick based on the brick legend (char, Transform pairs).
/// </summary>

PaddleController.cs
/// <summary>
/// This script defines the behavior of the paddle. It's functionalities include:
/// 
/// 1. Defining the range of positions over which the paddle can move.
/// 2. Managing player input by setting the x position to the mouse x position in world space.
/// </summary>

SceneLoader.cs
/// <summary>
/// Really basic script for loading scenes. Functionalities include:
/// 
/// 1. Loading a scene based on an index.
/// 
/// This script is always called by on click event triggers on the button UI
/// elements in the scene.
/// </summary>

=====EVERYTHING ELSE=====

As mentioned above, the scenes are meant to be loaded from the MainMenu, and all traversals
between scenes are made with the use of UI buttons on canvases. The SceneLoader script is
always attached to the EventManager and is called by the buttons directly.

The ball is a fully physical object (no programmatics) which bounces due to a Bouncy physics
material being applied to all colliders in the game.

The config files for level generation are stored in the LevelConfigs folder. They consist of
blank spaces (representing no brick), new lines (representing the next row of bricks), and
"brick characters." The '=' character represents a normal brick while the '+' character
represents an AddBall brick.


I sincerely hope all this information is informative and useful. Enjoy the game! 

