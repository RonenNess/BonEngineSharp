using System;
using System.Collections.Generic;
using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Runs a performance test by drawing lots of sprites.
    /// </summary>
    class PerformanceTestScene : BonEngineSharp.Scene
    {
        // assets for this demo
        private ImageAsset _cursor;
        private ImageAsset _perf;
        private FontAsset _font;
        private FontAsset _fontBig;

        // sprites list to draw
        List<Sprite> _sprites = new List<Sprite>();

        // for randomness
        Random _rand = new Random();

        // window size
        PointI _windowSize;

        /// <summary>
        /// On scene load.
        /// </summary>
        protected override void Load()
        {
            // set assets root and load config
            if (IsFirstScene)
            {
                Assets.AssetsRoot = "../../../../TestAssets";
                Game.LoadConfig("config.ini");
            }

            // load assets
            _cursor = Assets.LoadImage("gfx/cursor.png", ImageFilterMode.Nearest);
            _perf = Assets.LoadImage("gfx/perf.png", ImageFilterMode.Nearest);
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);

            // get window size
            _windowSize = Gfx.WindowSize;

            // create starting sprites
            for (var i = 0; i < 50000; ++i)
            {
                CreateTestSprite();
            }
        }

        /// <summary>
        /// Create a single test sprite.
        /// </summary>
        private void CreateTestSprite()
        {
            _sprites.Add(new Sprite()
            {
                Image = _perf,
                Blend = BlendModes.AlphaBlend,
                Position = new PointF(_rand.Next(_windowSize.X), _rand.Next(_windowSize.Y)),
                Origin = PointF.Half
            });
        }

        /// <summary>
        /// Do updates.
        /// </summary>
        protected override void Update(double deltaTime)
        {
            // if user click 'exit' action, exit game
            if (Input.Down("exit"))
            {
                Game.Exit();
            }

            // if user press space, add sprites
            if (Input.Down(KeyCodes.KeySpace))
            {
                for (var i = 0; i < 100; ++i)
                {
                    CreateTestSprite();
                }
            }
        }

        /// <summary>
        /// Draw scene.
        /// </summary>
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Teal);

            // draw sprites
            foreach (var sprite in _sprites)
            {
                Gfx.DrawSprite(sprite);
            }

            // title and text
            Gfx.DrawText(_fontBig, "Performance Test", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene draws a lot of sprites to see when we'll hit FPS drop.\n" +
                "- Press Space to add sprites.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // write FPS and other info
            Gfx.DrawText(_font, "FPS: " + Diagnostics.FpsCount.ToString(), new PointF(10, 10), Color.White, Color.Black, 1, 22);
            Gfx.DrawText(_font, "Sprites: " + _sprites.Count.ToString(), new PointF(10, 40), Color.White, Color.Black, 1, 22);
            Gfx.DrawText(_font, "Draw Calls: " + Diagnostics.GetCounter(DiagnosticsCounters.DrawCalls).ToString(), new PointF(10, 70), Color.White, Color.Black, 1, 22);

            // debug warning
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Gfx.DrawText(_fontBig, "Warning: debug mode [much slower]", new PointF(10, _windowSize.Y - 40), Color.Yellow, 28);
            }

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
