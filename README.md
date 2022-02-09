# GameboyScreen.shader
 A shader meant to replicate the appearance of an actual Gameboy's screen (for better or worse), using emulator output.
 Compatible with mGBA, and many variables are exposed for tuning to your personal tastes.
 
 To oversimplify how it works, the process has three steps: pixel fading, yellow grids, and blue shadows.
 This results in something that actually looks like a Gameboy.
 
 ![Screenshot of two emulators running Pokemon Red, one of which is affected by this shader](https://i.imgur.com/gdZWP0s.png)
 (The left image is affected by the shader, while the right is not. disclaimer: they are not perfectly synced)
 
 There are benefits to using this shader, besides aesthetics. Many sprites appear to be made with the effects of the console's display in mind.
 
 ![Screenshot of a menu from Pokemon Red](https://i.imgur.com/PyPCyam.png)
 
 An easy example, and the only one I care to provide, is this menu. While normally it looks a bit misshapen with a strange empty area above the text, the display's shadow makes it look more natural.

[This video](https://www.youtube.com/watch?v=Z1AjFq9Bbvw) was used as a reference for adjusting the settings. However, even with such a close 1080p view of the gameboy's screen, the reflective and somewhat holographic nature of the display means the exact colors involved are a little subjective. Tuning will be your friend.
The standard settings were made with the palette given in recommended_palette.txt, stray from that combination at your own peril.
