using System;
using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show text effects.
    /// </summary>
    class TextScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;

        // rotate animation
        double _rotateAnim;

        // load the scene
        protected override void Load()
        {
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

            // update animations
            _rotateAnim += deltaTime * 100;
        }

        // draw scene
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);

            // title and text
            Gfx.DrawText(_fontBig, "Drawing Texts", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene shows some text rendering options.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // rotating text
            Gfx.DrawText(_font, "Rotating Text", new PointF(100, 400), Color.Red, 0, 0, BlendModes.AlphaBlend, PointF.Half, (float)_rotateAnim);

            // text anchors
            var anchoredRotation = (float)Math.Sin(_rotateAnim / 50f) * 8f;
            Gfx.DrawText(_font, "Anchored left", new PointF(400, 300), Color.Yellow, 0, 0, BlendModes.AlphaBlend, new PointF(0f, 0.5f), anchoredRotation);
            Gfx.DrawText(_font, "Anchored center", new PointF(400, 350), Color.Yellow, 0, 0, BlendModes.AlphaBlend, new PointF(0.5f, 0.5f), anchoredRotation);
            Gfx.DrawText(_font, "Anchored right", new PointF(400, 400), Color.Yellow, 0, 0, BlendModes.AlphaBlend, new PointF(1f, 0.5f), anchoredRotation);

            // additive
            Gfx.DrawText(_fontBig, "Additive Blend", new PointF(550, 500), Color.Green, 0, 0, BlendModes.Additive, new PointF(1f, 0.5f), 0f);
            Gfx.DrawText(_fontBig, "Additive Blend", new PointF(550 - 10, 500 - 10), Color.Red, 0, 0, BlendModes.Additive, new PointF(1f, 0.5f), 0f);

            // text max width
            Gfx.DrawText(_font, "This text have limited line width. It will wrap automatically.", new PointF(600, 400), Color.White, 0, 150);
        }
    }
}
