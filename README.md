# NintendoSharp
A C# library and Loader for writing programs to interface with Nintendo products over USB/Serial ports. Currently, it should work on most Arduino boards(https://www.arduino.cc/en/Main/Products). In the future, it will also support custom I2C ports and Raspberry Pi boards.

It uses a modified version of NicoHood's "Nintendo" library (https://github.com/NicoHood/Nintendo) to interact with a console's controller port over digital I/O pins. If you want to emulate a Wii Remote or Wii U Gamepad into your Wii/WiiU, a Bluetooth card is required in your PC (USB Bluetooth cards work too).

What it can do:
-Re-Direct the feed from your NintendoSpy-Based input display for use as a PC gamepad. 2MS max responce time!
-Re-Direct the feed from your Nintendo Controllers to their consoles and other consoles. 1MS max responce time!
^While doing that, it can also:
--Display your input on your PC.
--Record your input and export it as an Emulator TAS.

What it will do soon:
-Allow people to practice learning "tricks" for their favorite games loading TAS saves of perfect trick inputs and compairing them against your input in real time. Then you can see exactly what you did wrong in real time!
-A script engine that you can use to make scripts for NintendoSharp, allowing you to create custom programs.
