using System;
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;
using System.Linq;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show all blend modes.
    /// </summary>
    class BlendScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;

        // background and cursor images to draw
        private ImageAsset _background;
        private ImageAsset _cursor;

        // sprites to show blend modes
        private ImageAsset _sprite;

        // load the scene
        protected override void Load()
        {
            // init sprites
            _background = Assets.LoadImage("gfx/forest_scene.png");
            _cursor = Assets.LoadImage("gfx/cursor.png");
            _sprite = Assets.LoadImage("gfx/wizard.png");

            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 18, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);
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
            
            // draw background
            Gfx.DrawImage(_background, PointF.Zero, new PointF(Gfx.RenderableSize.X, Gfx.RenderableSize.Y), BonEngineSharp.Defs.BlendModes.Opaque);

            // title and text
            Gfx.DrawText(_fontBig, "Blend Modes", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene illustrate different blend modes.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 0);

            // draw blend modes
            var values = Enum.GetValues(typeof(BonEngineSharp.Defs.BlendModes)).Cast<BonEngineSharp.Defs.BlendModes>();
            int posX = 0;
            int width = _sprite.Width * 4;
            int height = _sprite.Height * 4;
            int posY = Gfx.RenderableSize.Y - height;
            foreach (var blend in values)
            {
                if (blend == BonEngineSharp.Defs.BlendModes._Count) { continue; }

                // draw image and label
                Gfx.DrawImage(_sprite, new PointF(posX, posY), new PointI(width, height), blend);
                Gfx.DrawText(_font, blend.ToString(), new PointF(posX, posY), Color.White, Color.Black, 1, 18);

                // update position
                posX += width;
                if (posX + width > Gfx.RenderableSize.X)
                {
                    posX = 0;
                    posY -= height;
                }
            }

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
