﻿using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show a fullscreen scene.
    /// </summary>
    class WindowedFullscreenScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;
        private ImageAsset _cursor;

        // load the scene
        protected override void Load()
        {
            // set fullscreen
            // note: only works when there are no loaded assets.
            Gfx.SetWindowProperties("BonEngine Windowed Fullscreen", 0, 0, WindowModes.WindowedBorderless, false);

            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);
            _cursor = Assets.LoadImage("gfx/cursor.png", ImageFilterMode.Nearest);
        }

        // on updates do animations and controls
        protected override void Update(double deltaTime)
        {
            // if user click 'exit' action, exit game
            if (Input.Down("exit"))
            {
                Game.Exit();
            }
        }

        // draw scene
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.FromBytes(32, 150, 242));

            // title and text
            Gfx.DrawText(_fontBig, "Windowed Fullscreen", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene shows 'fake' fullscreen in windowed mode.\n" +
                "This is not really fullscreen, its just a borderless window covers the whole screen.\n" +
                "The advantage of this method is that we don't change the desktop resolution.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
