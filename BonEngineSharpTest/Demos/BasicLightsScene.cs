using System;
using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using System.Collections.Generic;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show basic lights scene.
    /// </summary>
    class BasicLightsScene : BonEngineSharp.Scene
    {
        // assets for this demo
        private ImageAsset _cursor;
        private ImageAsset _treeImage;
        private ImageAsset _dirtImage;
        private FontAsset _font;
        private FontAsset _fontBig;

        // lights map and single light texture
        private ImageAsset _lightsMapTexture;
        private ImageAsset _lightImage;

        // sprites list to draw
        List<Sprite> _sprites = new List<Sprite>();

        // for randomness
        Random _rand = new Random();

        // window size
        PointI _windowSize;

        // is viewport set?
        bool _gotViewport;

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
            _treeImage = Assets.LoadImage("gfx/tree.png", ImageFilterMode.Nearest);
            _dirtImage = Assets.LoadImage("gfx/dirt.png", ImageFilterMode.Nearest);
            _lightImage = Assets.LoadImage("gfx/light.png", ImageFilterMode.Nearest);
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);

            // get window size
            _windowSize = Gfx.WindowSize;

            // create empty texture to draw on
            _lightsMapTexture = Assets.CreateEmptyImage(_windowSize);

            // create trees
            for (var i = 0; i < 55; ++i)
            {
                CreateTestSprite();
            }

            // sort trees by y position so it will look like there's depth
            _sprites.Sort((Sprite a, Sprite b) => (int)(a.Position.Y - b.Position.Y));
        }

        /// <summary>
        /// Create a single test sprite.
        /// </summary>
        private void CreateTestSprite()
        {
            _sprites.Add(new Sprite()
            {
                Image = _treeImage,
                Blend = BlendModes.AlphaBlend,
                Position = new PointF(_rand.Next(-50, _windowSize.X + 50), _rand.Next(-50, _windowSize.Y + 50)),
                Origin = new PointF(0.5f, 1f),
                Size = new PointI(_treeImage.Width, _treeImage.Height).MultiplySelf(2)
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

            // toggle viewport
            if (Input.ReleasedNow(KeyCodes.KeySpace))
            {
                _gotViewport = !_gotViewport;
                Gfx.Viewport = _gotViewport ? new RectangleI(150, 150, 350, 350) : RectangleI.Empty;
            }
        }

        /// <summary>
        /// Draw scene.
        /// </summary>
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);

            // draw background dirt
            var backgroundSize = new PointI(_dirtImage.Width * 2, _dirtImage.Height * 2);
            for (int i = 0; i < Gfx.WindowSize.X / backgroundSize.X + 1; ++i)
            {
                for (int j = 0; j < Gfx.WindowSize.Y / backgroundSize.Y + 1; ++j)
                {
                    Gfx.DrawImage(_dirtImage, new PointF(i, j).Multiply(backgroundSize), backgroundSize, BlendModes.Opaque);
                }
            }

            // draw sprites
            foreach (var sprite in _sprites)
            {
                Gfx.DrawSprite(sprite);
            }

            // title and text
            Gfx.DrawText(_fontBig, "Basic Lights Scene", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene demonstrates basic lighting.\n" +
                "In this technique we draw additive lights on a black texture, then\n" +
                "we draw that texture on screen with multiply. This creates a nice\n" +
                "looking, easy to implement and cheap lighting effects.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // write FPS and other info
            Gfx.DrawText(_font, "FPS: " + Diagnostics.FpsCount.ToString(), new PointF(10, 10), Color.White, Color.Black, 1, 22);

            // draw lightmap
            Gfx.RenderTarget = _lightsMapTexture;
            Gfx.ClearScreen(Color.Black);
            Gfx.DrawImage(_lightImage, Input.CursorPosition, new PointI(500, 500), BlendModes.Additive, RectangleI.Empty, PointF.Half);
            Gfx.RenderTarget = null;

            // draw lightsmap on screen
            Gfx.DrawImage(_lightsMapTexture, PointF.Zero, BlendModes.Multiply);

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
