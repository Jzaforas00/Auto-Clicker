# Auto-Clicker
A simple auto-clicker tool developed in **C#** using **Visual Studio**.  
It allows you to automate mouse clicks with customizable settings, ideal for repetitive tasks that require precise and consistent clicking.

Status: In development

## Features

- Automates mouse clicks repeatedly. ✅
- Allows setting the time interval between clicks (hours, minutes, seconds, milliseconds). ✅
- Can be started or stopped using the **Start/Stop** button or a configurable hotkey (default: **F6**). ✅
- Supports repeating clicks infinitely until manually stopped, or a specified number of times. ✅
- Allows choosing between the **left** or **right** mouse button. ✅
- Supports **single** or **double** click options. ✅

## Technologies
- **Language:** C#
- **IDE:** Visual Studio
- **Version control:** Git & GitHub
- **NuGet packages:**
  - `Gma.System.MouseKeyHook`: For global mouse and keyboard hooks to listen for hotkeys.
- **Windows API (P/Invoke):**
  - Uses `user32.dll` for simulating mouse clicks via `mouse_event`.

## Usage
Download the Installer folder and run the `.exe` file inside to start the AutoClicker.
There is no installation process, so it is recommended to create a shortcut for easier access.
