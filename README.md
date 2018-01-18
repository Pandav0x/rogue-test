# RogueTest
Just a test of a game framework using the OpenTK/OpenGL libraries.

## Structure
I will not detail all the code parts, but I will just give an overview of it.
All those files are in the ~/Pulsee1 folder.

**Controls**
Handle all the control related code: physical device interpreter, key binding, event handler.

**Display**
Handle all the GUI related code: container(Window class/resolution) and the camera (inside Window).

**GameContent**
Contains all the game objects: Rooms/Floors and MOBS as Characters(Player/Enemies).

**GameStates**
Contains all the game states (level/lose/mainMenu/win).
Technically all the gameplay will be in here.

**Generators**
Contain all the generators needed for a Rogue-like game (such as a floor generator etc).
May include more Generators in the future.

**Graphics**
Handle all the graphics from the Texture2D class (which ultimately is just a struct with 2 constructors) to the TextureLoader from a picture.

**Pictures**
Contains all the pictures used by the engine itself and not the game (eg. window icon, startup picture, etc...).

**Startup**
Contains the Opening class which is the solution I have to 'display' the startup picture (will be removed in further versions).

**Utilities**
A bunch of useful classes to display in the console with colors, generate a random integer, use LERP, check if number is even, easy text file reader and so on...

## Infos
I know that this is maybe the messiest code you ever read, but... I do not care for the moment.
