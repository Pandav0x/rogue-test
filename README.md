# RogueTest
Just a test of a game framework using the OpenTK/OpenGL libraries.

You can find the OpenTK project [here](https://github.com/opentk/opentk).

This project is still at its early stages, and the library I use is evolving without me doing the updates as it changes many things that can't be implemented here yet.

I have plans to make this project into a NuGet package when it'll be more complete, thus ease its use.

## How to Install

1) Clone the repo.
2) Open the `RogueTest.sln` file.

There is two project in the solution: `GamePadDetector` which is a test for the gamepads handling with OpenTK, and `RogueTest`. Be sure to open the later one and set it as the default project.

3) Go under the `Pulsee1/` folder, here lies all the framework content.
4) Install `OpenTK 2.0.0` from the NuGet Package Manager. 
5) You're good to go.

## Structure

I will not detail all the code parts here, I will just give an overview of basically what the main folders contains.
All those files are in the `~/Pulsee1/` folder. 

 Folder | Content
------- | -------
`Controls/` | Contains all the inputs related code (physical device interpreter / key binding / event handler/ etc...)
`Display/` | Contains all the GUI + graphics related code: container (Window class / resolution) and the camera (inside Window).
`Game/` | Contains all the game content (states / generators / MOBS / etc...)
`KernelContent/` | Contains all the pictures and states used by the framework itself (splash screen / initialization ...)
`Modeling/` | Will contain the modeling files (class diag...)
`Resources` | Contains 2 PDFs with documentation and/or tutorial related to OpenTK.
`Utilities/` | Contains a bunch of useful classes (display in the console with colors / generate a random integer / LERP / even number check / text file IO / etc...)