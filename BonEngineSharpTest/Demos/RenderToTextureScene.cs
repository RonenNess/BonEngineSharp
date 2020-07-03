using System;
using BonEngineSharp.Defs;
using System.Collections.Generic;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Illustrates rendering to textuer.
    /// </summary>
    class RenderToTextureScene : BonEngineSharp.Scene
    {
        // assets for this demo
        private ImageAsset _cursor;
        private ImageAsset _treeImage;
        private ImageAsset _dirtImage;
        private FontAsset _font;
        private FontAsset _fontBig;

        // texture we draw to
        private ImageAsset _targetTexture;

        // sprites list to draw
        List<Sprite> _sprites = new List<Sprite>();

        // for randomness
        Random _rand = new Random();

        // window size
        PointI _windowSize;

        // current camera offset
        PointF _cameraOffset;

        // did we draw the scene already?
        bool _wasDrawn = false;

        // if true, will not move camera around
        bool _paused;

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
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);

            // get window size
            _windowSize = Gfx.WindowSize;

            // create empty texture to draw on
            _targetTexture = Assets.CreateEmptyImage(_windowSize);

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

            // if user click 's', save image
            if (Input.ReleasedNow(KeyCodes.KeyS))
            {
                _targetTexture.SaveToFile("demo.png");
            }

            // if user click 'p', pause image movement
            if (Input.ReleasedNow(KeyCodes.KeyP))
            {
                _paused = !_paused;
            }
        }

        /// <summary>
        /// Draw scene.
        /// </summary>
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);

            // draw scene on texture once
            if (!_wasDrawn)
            {
                // set render target
                Gfx.RenderTarget = _targetTexture;

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

                // clear render target
                Gfx.RenderTarget = null;
                _wasDrawn = true;

                // allow reading pixels from texture
                _targetTexture.PrepareReadingBuffer();
            }

            // draw render target on screen, with larger size so we'll only see parts of it
            float screenScale = 1.5f;
            if (!_paused)
            {
                _cameraOffset = new PointF(-150 + (float)Math.Sin(Game.ElapsedTime / 2f) * 150f, -150 + (float)Math.Cos(Game.ElapsedTime / 2f) * 150f);
            }
            var size = Gfx.WindowSize.Multiply(screenScale);
            Gfx.DrawImage(_targetTexture, _cameraOffset, size);

            // draw minimap
            var mapSize = new PointI((int)(150 * 1.333f), 150);
            var mapPosition = Gfx.WindowSize.Substract(mapSize.Add(10));
            Gfx.DrawRectangle(new RectangleI(mapPosition.X - 5, mapPosition.Y - 5, mapSize.X + 10, mapSize.Y + 10), Color.Black, true);
            Gfx.DrawImage(_targetTexture, mapPosition, mapSize);

            // title and text
            Gfx.DrawText(_fontBig, "Render To Texture", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene demonstrates drawing to texture.\n" +
                "First we draw to texture, then we draw it on screen,\n" +
                "and finally we use the same texture as a minimap at the corner.\n" +
                "- Press S to save image to file.\n" +
                "- Press P to pause camera movement.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // write FPS and other info
            Gfx.DrawText(_font, "FPS: " + Diagnostics.FpsCount.ToString(), new PointF(10, 10), Color.White, Color.Black, 1, 22);

            // write pixel we point on

            // enable reading pixels   
            PointI pixelPosition = Input.CursorPosition.Substract(_cameraOffset).Divide(screenScale);
            Color pixel = _targetTexture.GetPixel(pixelPosition);
            Gfx.DrawText(_font, "Pixel Color: " + pixel.ToString(true), new PointF(10, Gfx.RenderableSize.Y - 40), Color.White, Color.Black, 1, 22);

            // draw cursor
            Gfx.DrawImage(_cursor, Input.CursorPosition, new PointI(42, 42));
        }
    }
}
