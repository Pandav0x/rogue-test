# RogueTest
Just a test of a game framework using the OpenTK/OpenGL libraries.

## Structure
I will not detail all the code parts, but I will just give an overview of it.
All those files are in the ~/Pulsee1 folder. 

Folder | What it is
------- | -------
`Controls` | Handle all the control related code: physical device interpreter, key binding, event handler.
`Display` | Handle all the GUI + graphics related code: container(Window class/resolution) and the camera (inside Window).
`Game` | Contains all the game content: states / generators / MOBS etc.
`KernelContent` | Contains all the pictures and screens used by the engine itself.
`Utilities` | A bunch of useful classes to display in the console with colors, generate a random integer, use LERP, check if number is even, easy text file reader and so on...

## Infos
I know that this is maybe the messiest code you ever read, butI do...  not care for the moment AND it is actually changing while developing (planning is soooo overrated). :zzz:
