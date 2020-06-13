# BonEngine Sharp

`BonEngine` is a code-based game engine designed to be simple and straightforward, with as little setup as possible. 
It covers 2d rendering, assets, sound effects, music, input, config files, and more.

`BonEngineSharp` is a C# bind for the CPP `BonEngine` library. 

* [BonEngineSharp repo](https://github.com/RonenNess/BonEngineSharp)
* [BonEngine repo](https://github.com/RonenNess/BonEngine).


## Quick Start

After you install `BonEngineSharp` via NuGet:

```
Install-Package BonEngineSharp
```

The engine is really easy to setup:

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

Refer to the `Managers` section of the API to see the main functions you can access.

Note: you must build your project as either x86 or x64; Any CPU won't work.


## License

`BonEngineSharp` is distributed with the permissive MIT license, so you can do pretty much anything (legal) with it.

