# GameboyScreen.shader
 A shader meant to replicate the appearance of an actual Gameboy's screen (for better or worse), using emulator output.
 Compatible with mGBA, and many variables are exposed for tuning to your personal tastes.
 
 To oversimplify how it works, the process has three steps: pixel fading, yellow grids, and blue shadows.
 This results in something that actually looks like a Gameboy.
 
 ![Screenshot of two emulators running Pokemon Red, one of which is affected by this shader](https://i.imgur.com/gdZWP0s.png)
 (The left image is affected by the shader, while the right is not. disclaimer: they are not perfectly synced)
 
 There are benefit to using this shader, besides aesthetics. Many sprites appear to be made with the affects of the console's display in mind.
 
 ![Screenshot of a menu from Pokemon Red](https://i.imgur.com/PyPCyam.png)
 
 This menu normally looks a bit misshapen, having a strange amount of space between the top of the box and the text. But having the display's shadow helps make it look more natural.
