using System;
using BonEngineSharp;
using BonEngineSharp.Defs;
using System.Collections.Generic;
using BonEngineSharp.Assets;
using BonEngineSharp.Managers;
using BonEngineSharp.Framework;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Create a custom manager to handle collision.
    /// </summary>
    class CollisionManager : CustomManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "collision";

        // sprites we test collision on
        List<Sprite> _targets;

        // player sprite
        Sprite _player;

        // collision callback
        Action<Sprite> _onCollide;

        /// <summary>
        /// Set the sprites list this collision manager checks.
        /// </summary>
        public void Init(Sprite player, List<Sprite> targets, Action<Sprite> collisionCallback)
        {
            _player = player;
            _targets = targets;
            _onCollide = collisionCallback;
        }

        /// <summary>
        /// Called every frame to test collision.
        /// </summary>
        /// <param name="deltaTime">Delta time since last frame.</param>
        protected override void _Update(double deltaTime) 
        {
            var playerDest = _player.LooseDestRect;
            foreach (Sprite target in _targets.ToArray())
            {
                if (playerDest.Overlaps(target.LooseDestRect))
                {
                    _onCollide(target);
                }
            }
        }
    }

    /// <summary>
    /// Show how to use a custom manager.
    /// </summary>
    class CustomManagerScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;
        private SpriteSheet _spritesheet;
        private ImageAsset _targetImage;

        // player sprite and animation progress
        Sprite _player;
        double _animationProgress = 0.0;

        // targets list
        List<Sprite> _targets = new List<Sprite>();

        // custom collision manager
        CollisionManager _collision;

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

            // create and register the custom manager
            _collision = new CollisionManager();
            _collision.Init(_player, _targets, OnCollision);
            BonEngine.RegisterCustomManager(_collision);

            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);

            // load spritesheet from file
            _spritesheet = new SpriteSheet(Assets.LoadConfig("gfx/player_spritesheet.ini"));

            // load target image
            _targetImage = Assets.LoadImage("gfx/apple.png");

            // create random targets
            var windowSize = Gfx.WindowSize;
            Random rand = new Random();
            for (var i = 0; i < 100; ++i)
            {
                _targets.Add(new Sprite()
                {
                    Image = _targetImage,
                    Blend = BlendModes.AlphaBlend,
                    Position = new PointF(rand.Next(windowSize.X), rand.Next(windowSize.Y)),
                    Origin = PointF.Half
                });
            }
        }

        // called when player hit a target
        private void OnCollision(Sprite target)
        {
            // since player got extra transparent sides in its sprite, test more accurate collision here
            if (Math.Abs(target.Position.X - _player.Position.X) > 32 || Math.Abs(target.Position.Y - _player.Position.Y) > 62) 
            { 
                return; 
            }

            // remove target we hit
            _targets.Remove(target);
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
            Gfx.DrawText(_fontBig, "Custom Manager", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene shows a simple custom manager. " +
                "Custom managers run\n in the engine's main loop and extends its functionality.\n\nIn this case, we creates a simple collision detection manager.\n" +
                "- Use Arrows or WASD to move.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);

            // draw targets
            foreach (Sprite sprite in _targets)
            {
                Gfx.DrawSprite(sprite);
            }

            // draw player
            Gfx.DrawSprite(_player);
        }
    }
}
