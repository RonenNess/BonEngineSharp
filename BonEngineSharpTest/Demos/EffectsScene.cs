using System;
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show how to use custom effects.
    /// </summary>
    class EffectsScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;

        // sprite to draw
        private ImageAsset _background;
        private ImageAsset _cursor;

        // effect to use
        EffectAsset _currEffect;
        bool _updateTimeUniform;

        // load the scene
        protected override void Load()
        {
            // init sprites
            _background = Assets.LoadImage("gfx/forest_scene.png");
            _cursor = Assets.LoadImage("gfx/cursor.png");

            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
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

            // load effects
            if (Input.PressedNow(BonEngineSharp.Defs.KeyCodes.Key1))
            {
                _currEffect = null;
                _updateTimeUniform = false;
            }
            else if (Input.PressedNow(BonEngineSharp.Defs.KeyCodes.Key2))
            {
                _currEffect = Assets.LoadEffect("effects/grayscale/effect.ini");
                _updateTimeUniform = false;
            }
            else if (Input.PressedNow(BonEngineSharp.Defs.KeyCodes.Key3))
            {
                _currEffect = Assets.LoadEffect("effects/wavey/effect.ini");
                _updateTimeUniform = true;
            }
            else if (Input.PressedNow(BonEngineSharp.Defs.KeyCodes.Key4))
            {
                _currEffect = Assets.LoadEffect("effects/cel/effect.ini");
                _updateTimeUniform = false;
            }
        }

        // draw scene
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);
            
            // set effect
            Gfx.UseEffect(_currEffect);

            // update wavey effect time
            if (_updateTimeUniform)
            {
                _currEffect.SetUniform("time", (float)Game.ElapsedTime);
            }

            // draw scene and reset effect
            Gfx.DrawImage(_background, PointF.Zero, new PointF(Gfx.RenderableSize.X, Gfx.RenderableSize.Y), BonEngineSharp.Defs.BlendModes.Opaque);
            Gfx.UseEffect(null);

            // title and text
            if (!Input.Down(BonEngineSharp.Defs.KeyCodes.KeySpace))
            {
                Gfx.DrawRectangle(new RectangleI(60, 120, 330, 320), new Color(0, 0, 0, 0.5f), true);
                Gfx.DrawText(_fontBig, "Effects", new PointF(80, 120), Color.White, Color.Black, 1, 42);
                Gfx.DrawText(_font, "This scene illustrate effects.\n" +
                    "- 1 = no effects.\n" +
                    "- 2 = grayscale.\n" +
                    "- 3 = wavey effect.\n" +
                    "- 4 = cel effect.\n" +
                    "- Hold Space = hide this text.\n" +
                    "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);
            }

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
