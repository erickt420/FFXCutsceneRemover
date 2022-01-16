# FFXCutsceneRemover w/ Randomiser
Cutscene skipping program for the Windows version of Final Fantasy X HD Remaster.
If you encounter any bugs or have any questions, please open an issue on GitHub or contact us in the cutscene-remover channel of the [FFX Speedrun Discord](https://discord.gg/X3qXHWG).

Includes a randomiser which will randomise the following aspects of the game:

* Randomises Sphere Grid including Stat, Ability, Empty and Lock nodes.

* Randomises Base stats of the 7 main characters

* Tidus will always start with Flee

### Important

* Because this mod randomises the stats of the characters it is possible for some early game fights to become impossible to complete, although this is unlikely to occur. Notable fights which may cause issues are Flan Tutorial (Besaid) and Vouivre (Luca).

* This mod is designed and tested to be used solely for Any% Speedruns. Using this mod for other speedrun categories or normal playthroughs is not currently supported and you will likely encounter game-breaking bugs.

* Using the speedup booster (F1) with this mod is not supported, and is highly likely to cause crashes when the cutscene skips occur.

### Usage:

1. Download the latest release (x64 or x86) from the [releases page here](https://github.com/erickt420/FFXCutsceneRemover/releases).

2. Extract and launch FFXCutsceneRemove.exe.

3. Launch Final Fantasy X.

The order in which you launch the mod and the game does not matter.
You do not need to start a new game in order to gain the effects of the mod, however, if you start from a save file you may find that it takes a while before the cutscenes start skipping.

### Arguments:
You can use multiple arguments by separating them with a space.
- enable debug:  
`FFXCutsceneRemover.exe true`
- change the amount of milliseconds the program sleeps between polling iterations:  
`FFXCutsceneRemover.exe 50`
