# Screenshots

Taking screenshots is extremely simple:

```cs
// generate an image
var screenImage = Gfx.CreateImageFromScreen();

// save screenshot to file
var filename = "screenshot_" + DateTime.Now.ToString("yy_MM_dd_HH_mm_ss_") + ".png";
screenImage.SaveToFile(filename);
```

`screenImage` is an image asset generated from everything currently presented on screen, so you want to create it at the end of your render / update call.

In this example we save it to file, but you can also use it as a regular image and draw it on screen. This is useful to create different post-render effects.