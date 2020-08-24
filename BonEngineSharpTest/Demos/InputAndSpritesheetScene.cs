using System;
using BonEngineSharp;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Show how to use the input manager / basic player controls.
    /// </summary>
    class InputAndSpritesheetScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;
        private SpriteSheet _spritesheet;

        // player sprite and animation progress
        Sprite _player;
        double _animationProgress = 0.0;

        // load the scene
        protected override void Load()
        {
            // init player sprite
            _player = new Sprite()
            {
                Position = new PointF(500, 500),
                Origin = new PointF(0.5f, 1.0f),
                Image = Assets.LoadImage("gfx/player.png")
            };

            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);

            // load spritesheet from file
            _spritesheet = new SpriteSheet(Assets.LoadConfig("gfx/player_spritesheet.ini"));
        }

        // on updates do animations and controls
        protected override void Update(double deltaTime)
        {
            // if user click 'exit' action, exit game
            if (Input.Down("exit"))
            {
                Game.Exit();
            }

            // is player currently walking + movement speed
            bool isWalking = false;
            double moveSpeed = deltaTime * 175f;

            // should we flip player direction?
            bool _flipSprite = _player.Size.X < 0;

            // player walks up
            if (Input.Down("up"))
            {
                isWalking = true;
                _player.Position.Y -= (float)moveSpeed;
            }
            // player walks down
            if (Input.Down("down"))
            {
                isWalking = true;
                _player.Position.Y += (float)moveSpeed;
            }
            // player walks left
            if (Input.Down("left"))
            {
                isWalking = true;
                _player.Position.X -= (float)moveSpeed;
                _flipSprite = true;
            }
            // player walks right
            if (Input.Down("right"))
            {
                isWalking = true;
                _player.Position.X += (float)moveSpeed;
                _flipSprite = false;
            }

            // animate player
            _spritesheet.Animate(_player, isWalking ? "walk" : "stand", ref _animationProgress, deltaTime, 5f);
        
            // flip sprite
            if (_flipSprite)
            {
                _player.Size.X *= -1;
            }
        }

        // draw scene
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);

            // title and text
            Gfx.DrawText(_fontBig, "Input & Spritesheet", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene renders and control a player sprite.\n" +
                "- Use Arrows or WASD to move.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // draw player
            Gfx.DrawSprite(_player);
            Gfx.DrawSprite(_player);
        }
    }
}
