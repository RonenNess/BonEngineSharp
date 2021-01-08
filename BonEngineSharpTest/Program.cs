using System;
using BonEngineSharp;
using BonEngineSharp.Defs;
using System.Collections.Generic;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest
{
    class Program
    {
        /// <summary>
        /// Welcome scene to select which demo to run.
        /// </summary>
        class WelcomeScene : BonEngineSharp.Scene
        {
            // assets for welcome screen
            private ImageAsset _cursor;
            private FontAsset _fontBig;
            private FontAsset _font;

            // a demo container
            class DemoContainer
            {
                public Scene Scene;
                public string Name;
                public RectangleI Region;
            }
            List<DemoContainer> _demos = new List<DemoContainer>();

            // selected demo (demo we point on).
            DemoContainer _selected;

            /// <summary>
            /// Load scene
            /// </summary>
            protected override void Load()
            {
                // set assets root
                Assets.AssetsRoot = "../../../../TestAssets";

                // load config
                Game.LoadConfig("config.ini");

                // load assets
                _cursor = Assets.LoadImage("gfx/cursor.png", ImageFilterMode.Nearest, false);
                _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 46, false);
                _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 28, false);

                // add demos
                AddDemo("Input & Spritesheet", new Demos.InputAndSpritesheetScene());
                AddDemo("Music & Sound Effects", new Demos.MusicAndSoundScene());
                AddDemo("Drawing Texts", new Demos.TextScene());
                AddDemo("Blend Modes", new Demos.BlendScene());
                AddDemo("Fullscreen Mode", new Demos.FullscreenScene());
                AddDemo("Windowed Fullscreen", new Demos.WindowedFullscreenScene());
                AddDemo("Rendering Viewport", new Demos.ViewportScene());
                AddDemo("Performance Test", new Demos.PerformanceTestScene());
                AddDemo("Render To Texture", new Demos.RenderToTextureScene());
                AddDemo("Basic Lights", new Demos.BasicLightsScene());
                AddDemo("Custom Managers", new Demos.CustomManagerScene());
                AddDemo("Drawing Shapes", new Demos.DrawingShapesScene());
                AddDemo("UI System", new Demos.UIScene());
                AddDemo("Effects", new Demos.EffectsScene());
            }

            /// <summary>
            /// Add a demo.
            /// </summary>
            private void AddDemo(string name, Scene scene)
            {
                int i = _demos.Count;
                int j = 0;
                if (i > 6) { i -= 7; j = 1; }
                _demos.Add(new DemoContainer() { Name = name, Scene = scene, Region = new RectangleI(40 + j * 375, 180 + i * 58, 350, 48) });
            }

            /// <summary>
            /// On updates.
            /// </summary>
            protected override void Update(double deltaTime)
            {
                // if user click 'exit' action, exit game
                if (Input.Down("exit"))
                {
                    Game.Exit();
                }

                // find selected demo
                var mousePos = Input.CursorPosition;
                _selected = null;
                foreach (var demo in _demos)
                {
                    if (demo.Region.Contains(mousePos))
                    {
                        _selected = demo;
                        break;
                    }
                }

                // select demo to play
                if (Input.ReleasedNow(KeyCodes.MouseLeft) && _selected != null)
                {
                    Game.ChangeScene(_selected.Scene);
                    _cursor.Dispose();
                    _font.Dispose();
                    _fontBig.Dispose();
                    Assets.ClearCache();
                }
            }
            
            /// <summary>
            /// Draw scene.
            /// </summary>
            protected override void Draw()
            {
                // clear screen
                Gfx.ClearScreen(Color.Cornflower);

                // header and instructions
                Gfx.DrawText(_fontBig, "Welcome to BonEngine!", new PointF(50, 50), Color.White, Color.Black, outlineWidth: 2);
                Gfx.DrawText(_font, "Click on a demo to start it.", new PointF(60, 120), Color.White, Color.Black, outlineWidth: 1);

                // draw demos
                foreach (var demo in _demos)
                {
                    Gfx.DrawRectangle(demo.Region, new Color(0, 0, 0, 0.5f), true, BlendModes.AlphaBlend);
                    Gfx.DrawText(_font, demo.Name, demo.Region.Center, _selected == demo ? Color.Yellow : Color.White, 0, 0, BlendModes.AlphaBlend, PointF.Half, 0f);
                }

                // draw cursor
                Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
            }
        }


        /// <summary>
        /// Start the application.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Begin BonEngine demo..");

            using (var scene = new WelcomeScene())
            {
                BonEngine.Start(scene);
            }

            Console.WriteLine("Bye!");
        }
    }
}
