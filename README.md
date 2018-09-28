# NintendoSharp
A C# library and Loader for writing programs to interface with Nintendo products over USB/Serial ports. Currently, it should work on most Arduino boards(https://www.arduino.cc/en/Main/Products). In the future, it will also support custom I2C ports and Raspberry Pi boards.

It uses a modified version of NicoHood's "Nintendo" library (https://github.com/NicoHood/Nintendo) to interact with a console's controller port over digital I/O pins. If you want to emulate a Wii Remote or Wii U Gamepad into your Wii/WiiU, a Bluetooth card is required in your PC (USB Bluetooth cards work too).


<b>What it can do:</b>

-Re-Direct the feed from your NintendoSpy-Based input display for use as a PC Gamepad. 2MS max response time!

-Direct the feed from your Nintendo Controllers through an Arduino board, and to their consoles and other consoles. Or use them as a PC Gamepad. 1MS max response time!

^While doing that, it can also:

--Display your input on your PC.

--Record your input and export it as an Emulator TAS.

<b>TLDR:</b> Use any Nintendo Controller on any Nintendo console, or as a PC gamepad.


<b>What it will do soon:</b>

-Allow people to practice learning "tricks" for their favorite games by loading TAS saves of perfect trick inputs and compairing them against your input in real time. Then you can see exactly what you did wrong after each try!

-A script engine that you can use to make scripts for NintendoSharp, allowing you to create custom programs.
