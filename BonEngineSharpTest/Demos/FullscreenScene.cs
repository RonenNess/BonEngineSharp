using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show a fullscreen scene.
    /// </summary>
    class FullscreenScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;
        private ImageAsset _cursor;

        // load the scene
        protected override void Load()
        {
            // force cache clear
            Assets.ClearCache();

            // set fullscreen
            // note: only works when there are no loaded assets.
            Gfx.SetWindowProperties("BonEngine Fullscreen", 800, 600, WindowModes.Fullscreen, false);

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
            Gfx.ClearScreen(Color.Cornflower);

            // title and text
            Gfx.DrawText(_fontBig, "Fullscreen", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene shows fullscreen mode with 800x600 resolution.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
