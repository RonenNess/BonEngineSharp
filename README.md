# BonEngine Sharp

`BonEngine` is a code-based game engine designed to be simple and straightforward, with as little setup as possible. It covers 2d rendering, assets, sound effects, music, input, config files, and more.

`BonEngineSharp` is a C# bind of `BonEngine`. The APIs are nearly identical, so in this doc we'll only cover few examples and not the whole API. To view the full API you can check out the [BonEngine repo](https://github.com/RonenNess/BonEngine).

## Install

To install use nuget:

```
Install-Package BonEngineSharp
```

Or grab the latest build from releases and add reference manually.

### Important - no `Any CPU`

Since`BonEngineSharp` is a wrapper around a CPP library, your project needs to be built as either `x86` or `x64`, but it can't be `Any CPU`. Same code can be used for both platforms, there's no difference in API or how you use the engine.

### Platforms

`BonEngineSharp` is built for .net core 3.0, and it uses a CPP library compiled for Windows Desktop (x86 or x64) with VS2019 tools.
If you want to build projects for different platforms, you need to build the CPP dlls yourself (from [this repo](https://github.com/RonenNess/BonEngine)).

Note that the CPP side is built with SDL and *should* be cross platform, but it wasn't officially tested or built for non-desktop targets.

## How To Use

`BonEngine` is very easy to setup:

```cs
using BonEngineSharp;

/// <summary>
/// A basic example scene.
/// </summary>
class MyScene : Scene
{
    // called when scene loads
    protected override void Load()
    {
    }

    // called when scene unloads
    protected override void Unload()
    {
    }

    // called every frame to do updates
    protected override void Update(double deltaTime)
    {
    }
    
    // called every frame to draw scene
    protected override void Draw()
    {
    }

    // called every constant interval to update physics related stuff
    protected override void FixedUpdate(double deltaTime)
    {
    }
}

/// <summary>
/// Start the application.
/// </summary>
static void Main(string[] args)
{
    using (var scene = new MyScene()) {
        BonEngine.Start(scene);
    }
}
```

Once running, you can change your active scene:

```cs
Game.ChangeScene(newScene);
```

### Managers

`BonEngine` is divided into 7 subsystems, called `managers`. These managers implement the vast majority of the engine's APIs, and they are:

#### Game

Application and global game stuff, like changing scene, exiting game, load config from file, retrieve delta time, ect.

#### Assets

Load and create assets - images, sound effects, music, config files, ect.

#### Gfx

Everything related to graphics and rendering.

#### Sfx

Everything related to sound effects and music.

#### Input

Implements user input, either by querying keyboard and mouse states or by checking "actions" which are bound to different keys.

#### Log

Provide basic logs.

#### Diagnostics

Get diagnostics and debug data, like FPS, number of draw calls, ect.


## Some Examples

Lets review some simple examples (note: more examples can be found under the `BonEngineSharpTest` project).

### Drawing Images - Gfx.DrawImage()

```cs
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{
    // image to draw
    private ImageAsset _srcImage;
    
    // called when scene loads - load image from file
    protected override void Load()
    {
        _srcImage = Assets.LoadImage("my_image.png");
    }
    
    // called every frame to draw scene - draw image
    protected override void Draw()
    {
        Gfx.DrawImage(_srcImage, new PointI(100, 100));
    }
}
```

### Drawing Shapes - Gfx.DrawRectangle()

```cs
using BonEngineSharp;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{ 
    // called every frame to draw scene - draws a rectangle
    protected override void Draw()
    {
        Gfx.DrawRectangle(new RectangleI(50, 50, 25, 25), Color.Red, true);
    }
}
```

### Drawing Text - Gfx.DrawText()

```cs
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{ 
    // font to use
    private FontAsset _font;
    
    // called when scene loads - load font to use
    protected override void Load()
    {
        _font = Assets.LoadFont("OpenSans-Regular.ttf", 32);
    }
    
    // called every frame to draw scene - draw text
    protected override void Draw()
    {
        Gfx.DrawText(_font, "Hello BonEngine!", new PointF(50, 50));
    }
}
```

### Drawing Sprites - Gfx.DrawSprite()

```cs
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{
    // sprite to draw
    private Sprite _sprite;
    
    // called when scene loads - setup sprite
    // note: spritesheets and animations exists in the engine, but are not covered in this example
    protected override void Load()
    {
        _sprite = new Sprite()
        {
            Position = new PointF(500, 500),
            Origin = new PointF(0.5f, 1.0f),
            Image = Assets.LoadImage("sprite.png")
        };
    }
    
    // called every frame to draw scene - draw sprite
    protected override void Draw()
    {
        Gfx.DrawSprite(_sprite);
    }
}
```

### Playing Music - Sfx.PlayMusic()

```cs
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{ 
    // music to play
    private MusicAsset _music;
    
    // called when scene loads - load and starts playing music
    protected override void Load()
    {
        _music = Assets.LoadMusic("my_song.ogg");
        Sfx.PlayMusic(_music);
    }
}
```

### Playing Sounds - Sfx.PlaySound()

```cs
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{ 
    // music to play
    private SoundAsset _sound;
    
    // called when scene loads - load and plays sound effect once
    protected override void Load()
    {
        _sound = Assets.LoadSound("boom.wav");
        Sfx.PlaySound(_sound, 100, 0);
    }
}
```

### Getting Input - Input.Down() / Input.CursorPosition

```cs
using BonEngineSharp;
using BonEngineSharp.Framework;

class MyScene : BonEngineSharp.Scene
{ 
    // called every frame to control player
    protected override void Update(double deltaTime)
    {
        // check bound action
        if (Input.Down("left"))
        {
            // move left
        }
        
        // check key directly
        if (Input.Down(KeyCodes.KeySpace))
        {
            // attack
        }
        
        // get mouse position 
        var mouse = Input.CursorPosition;
    }
}
```

## License

This lib is distributed with the MIT license, so you can do pretty much anything (legal) with it :)
