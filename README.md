# NintendoSharp
A C# library and Loader for writing programs to interface with Nintendo products over USB/Serial ports. Currently, it should work on most Arduino boards(https://www.arduino.cc/en/Main/Products). In the future, it will also support custom I2C ports and Raspberry Pi boards(https://www.raspberrypi.org/products/).

It uses a modified version of NicoHood's "Nintendo" library (https://github.com/NicoHood/Nintendo) to interact with a console's controller port over an Arduino's digital I/O pins. If you want to emulate a Wii Remote or Wii U Gamepad into your Wii/WiiU, a Bluetooth card is required in your PC or Board (USB Bluetooth cards work too).


<b>What it can do:</b>

-Redirect the feed from any NintendoSpy-Based input display(https://github.com/jaburns/NintendoSpy) for use as a PC Gamepad. 2MS max response time!

-Direct the feed from any Nintendo Controller through an Arduino board, and to their consoles or other consoles. You can also use them as a PC Gamepad. 1MS max response time!

-Display your input on your PC (for streamers).

<b>TLDR:</b> It lets you use any Nintendo Controller on any Nintendo console, or as a PC gamepad. It also lets you play PC games with any NintendoSpy-compatible input display. It can also record and display your input in real-time.


<b>What it will do soon:</b>

-Allow people to record their input, and export it as an Emulator TAS. So people can playback their recordings in an emulator.

-Allow people to practice learning "tricks" for their favorite games by loading TAS saves of perfect trick inputs and compairing them against your input in real time. Then you can see exactly what you did wrong after each try!

<b>TLDR:</b> Soon you can use it to git gud at speedrunning, and show off tricks/runs to friends in an emulator.
