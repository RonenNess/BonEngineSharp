using System;
using System.Collections.Generic;
using BonEngineSharp.Assets;

namespace BonEngineSharp.Framework
{
    /// <summary>
    /// A single step in a spritesheet animation.
    /// </summary>
    public struct SpriteAnimationStep
	{
        /// <summary>
        /// For how long, in seconds, we need to display this animation step.
        /// </summary>
        public float Duration;

        /// <summary>
        /// The index of the sprite in the spritesheet during this animation step.
        /// </summary>
        public PointI Index;

        /// <summary>
        /// Animation step optional tag.
        /// </summary>
        public string Tag;
    };

    /// <summary>
    /// Represent an animation inside a spritesheet.
    /// </summary>
    public class SpriteAnimation
    {
        /// <summary>
        /// Animation identifier.
        /// </summary>
        public string Identifier { get; private set; }

        // animation steps.
        private List<SpriteAnimationStep> _steps = new List<SpriteAnimationStep>();

        /// <summary>
        /// Is this animation repeating itself when done? Or just remain stuck on last frame?
        /// </summary>
        public bool Repeats { get; set; }

        /// <summary>
        /// Get animation steps count.
        /// </summary>
        public int StepsCount => _steps.Count;

        /// <summary>
        /// Get animation duration.
        /// </summary>
        public float Duration
        {
            get
            {
                float ret = 0f;
                foreach (var step in _steps)
                {
                    ret += step.Duration;
                }
                return ret;
            }
        }

        /// <summary>
        /// Create empty sprite animation.
        /// </summary>
        /// <param name="identifier">Animation identifier.</param>
        public SpriteAnimation(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Load animation from config asset, based on animation identifier.
        /// </summary>
        /// <param name="identifier">Animation identifier.</param>
        /// <param name="config">Config asset to load from.</param>
        /// <remarks>Config must contain a section called 'anim_xxx', where xxx is this animation's unique identifier.
        /// Under this section, we should have the following keys:
        ///     - repeats = true / false - does this animation loops, or remain stuck on last step after done?
        ///     - steps_count = how many steps we have in this animation.
        ///     - setp_x_duration [x is step index] = duration, in seconds, of this animation step.
        ///     - setp_x_source [x is step index] = index in spritesheet file, format is: "x,y".
        ///     - step_x_tag [x is step index] = optional tag to attach to this step.
        /// For more info, check out demo_spritesheet.ini in test assets folder.</remarks>
        public SpriteAnimation(string identifier, ConfigAsset config)
        {
            // set identifier
            Identifier = identifier;

            // get general stuff
            string section = "anim_" + identifier;
            Repeats = config.GetBool(section, "repeats");
            int steps = config.GetInt(section, "steps_count", -1);

            // sanity
            if (steps < 0) { throw new Exception($"Missing animation {identifier} section in config file, or missing 'steps_count' key!"); }

            // load all steps
            for (int i = 0; i < steps; ++i)
            {
                string prefix = "step_" + i.ToString();
                float duration = config.GetFloat(section, prefix + "_duration");
                PointI index = PointI.FromString(config.GetStr(section, prefix + "_source"));
                string tag = config.GetStr(section, prefix + "_tag", null);
                AddStep(new SpriteAnimationStep() { Duration = duration, Index = index, Tag = tag });
            }
        }

        /// <summary>
        /// Get step tag.
        /// </summary>
        /// <param name="stepIndex">Step index to get tag from.</param>
        /// <returns>Step tag or null if not set.</returns>
        public string GetTag(int stepIndex)
        {
            return _steps[stepIndex].Tag;
        }

        /// <summary>
        /// Animate based on progress and return index in spritesheet.
        /// </summary>
        /// <param name="progress">Animation total progress, in seconds. This param is updated every call so you need to preserve it between calls.</param>
        /// <param name="deltaTime">How much to advance animation in current call.</param>
        /// <returns>Index to set in spritesheet.</returns>
        public PointI Animate(ref double progress, double deltaTime)
        {
            return Animate(ref progress, deltaTime, out int step, out bool finish);
        }

        /// <summary>
        /// Animate based on progress and return index in spritesheet.
        /// </summary>
        /// <param name="progress">Animation total progress, in seconds. This param is updated every call so you need to preserve it between calls.</param>
        /// <param name="deltaTime">How much to advance animation in current call.</param>
        /// <param name="currStep">Will contain current animation step index.</param>
        /// <param name="didFinish">Will be set to true if animation ended (for repeating animations, will be true during the frame it reset back to step 0).</param>
        /// <returns>Index to set in spritesheet.</returns>
        public PointI Animate(ref double progress, double deltaTime, out int currStep, out bool didFinish)
        {
            // get previous step
            int prevStep = (int)Math.Floor(progress);

            // did finish animation?
            if (prevStep >= (int)_steps.Count)
            {
                // if on repeat mode, reset progress
                if (Repeats)
                {
                    prevStep = (int)_steps.Count - 1;
                    progress = 0f;
                }
                // if not on repeat, means we finished animation and should stay stuck here
                else
                {
                    prevStep = (int)_steps.Count - 1;
                    currStep = prevStep;
                    didFinish = true;
                    return _steps[prevStep].Index;
                }
            }

            // set as didn't finish
            didFinish = false;

            // increase progress and get current step
            progress += deltaTime / _steps[prevStep].Duration;
            int newStep = (int)Math.Floor(progress);

            // did step change?
            if (prevStep != newStep)
            {
                // did finish animation?
                if (newStep >= (int)_steps.Count)
                {
                    // set new step to either start of animation, or last step
                    newStep = Repeats ? 0 : (int)_steps.Count - 1;

                    // set as finished
                    didFinish = true;
                }
            }

            // set curr step out param
            currStep = newStep;

            // lastly, set out index
            return _steps[newStep].Index;
        }

        /// <summary>
        /// Add step to animation.
        /// </summary>
        /// <param name="step">Step to add.</param>
        public void AddStep(SpriteAnimationStep step)
        {
            _steps.Add(step);
        }
    }

    /// <summary>
    /// Define the properties of a spritesheet, which sprites we have in it, and sprite animations.
    /// </summary>
    public class SpriteSheet
    {
        // spritesheet animations
        private Dictionary<string, SpriteAnimation> _animations = new Dictionary<string, SpriteAnimation>();

        // spritesheet bookmarks.
        private Dictionary<string, PointI> _bookmarks = new Dictionary<string, PointI>();

        /// <summary>
        /// How many sprites we have on X and Y axis inside the spritesheet.
        /// This defines how we calculate the size and position of a specific sprite in sheet.
        /// </summary>
        public PointI SpritesCount { get; set; }

        /// <summary>
        /// Create empty spritesheet.
        /// </summary>
        public SpriteSheet() { }

        /// <summary>
        /// Create the spritesheet from config file.
        /// </summary>
        /// <param name="config">Config asset to load spritesheet from.</param>
        public SpriteSheet(ConfigAsset config)
        {
            LoadFromConfig(config);
        }

        /// <summary>
        /// Load spritesheet properties from config asset.
        /// Note: this will replace all existing settings.
        /// </summary>
        /// <param name="config">Config file to load from.</param>
        /// <remarks>Config must contain the following section:
        /// [general]
        ///     - sprites_count = how many sprites there are in this spritesheet, format is: "x,y".
        ///     - animations = list of comma-separated animations found in this spritesheet config. 
        ///                     for every animation listed here, you need to also include a section with animation data.
        ///                     check out 'SpriteAnimation' constructor for more info.
        ///                     
        /// [bookmarks]
        ///     - optional, contains a list of values where every key is a bookmark identifier and value is sprite index "x,y".
        ///         later, you can use this to set sprites from spritesheet by names. for example: sheet.SetSprite(sprite, "item_sword");
        ///         
        /// For more info, check out demo_spritesheet.ini in test assets folder.
        /// </remarks>
        public void LoadFromConfig(ConfigAsset config)
        {
            // load general settings
            SpritesCount = PointI.FromString(config.GetStr("general", "sprites_count", "0,0"));

            // load bookmarks
            var bookmarks = config.Keys("bookmarks");
            foreach (var book in bookmarks)
            {
                var value = PointI.FromString(config.GetStr("bookmarks", book, "0,0"));
                _bookmarks.Add(book, value);
            }

            // load animations
            var animations = config.GetStr("general", "animations", "").Split(',');
            foreach (var anim in animations)
            {
                var animationName = anim.Trim();
                var spriteAnimation = new SpriteAnimation(animationName, config);
                _animations.Add(animationName, spriteAnimation);
            }
        }

        /// <summary>
        /// Set a sprite's source rectangle from index in spritesheet.
        /// </summary>
        /// <param name="sprite">Sprite to set.</param>
        /// <param name="indexInSheet">Index in spritesheet.</param>
        /// <param name="sizeFactor">Set the size of the sprite to be the spritesheet's single sprite size, multiplied by this value. If set to 0, will not change sprite size.</param>
        public void SetSprite(Sprite sprite, PointI indexInSheet, float sizeFactor = 1.0f)
        {
            // set source rect
            sprite.SourceRect.Width = (int)(sprite.Image.Width * (1f / (float)SpritesCount.X));
            sprite.SourceRect.Height = (int)(sprite.Image.Height * (1f / (float)SpritesCount.Y));
            sprite.SourceRect.X = indexInSheet.X * sprite.SourceRect.Width;
            sprite.SourceRect.Y = indexInSheet.Y * sprite.SourceRect.Height;

            // set size
            if (sizeFactor != 0f)
            {
                sprite.Size.X = (int)(sprite.SourceRect.Width * sizeFactor);
                sprite.Size.Y = (int)(sprite.SourceRect.Height * sizeFactor);
            }
        }

        /// <summary>
        /// Set a sprite's source rectangle from bookmark in spritesheet.
        /// </summary>
        /// <param name="sprite">Sprite to set.</param>
        /// <param name="bookmarkId">Bookmark id to set.</param>
        /// <param name="sizeFactor">Set the size of the sprite to be the spritesheet's single sprite size, multiplied by this value. If set to 0, will not change sprite size.</param>
        public void SetSprite(Sprite sprite, string bookmarkId, float sizeFactor = 1.0f)
        {
            SetSprite(sprite, _bookmarks[bookmarkId], sizeFactor);
        }

        /// <summary>
        /// Get animation by id.
        /// </summary>
        /// <param name="identifier">Animation id to get.</param>
        /// <returns>Animation instance.</returns>
        public SpriteAnimation GetAnimation(string identifier)
        {
            return _animations[identifier];
        }

        /// <summary>
        /// Add animation to spritesheet.
        /// Can override existing keys.
        /// </summary>
        /// <param name="animation">Animation to set.</param>
        public void AddAnimation(SpriteAnimation animation)
        {
            _animations[animation.Identifier] = animation;
        }

        /// <summary>
        /// Set a new bookmark in spritesheet.
        /// Can override existing keys.
        /// </summary>
        /// <param name="bookmarkId">Bookmark id to set.</param>
        /// <param name="spriteIndex">Bookmark index in spritesheet.</param>
        public void AddBookmark(string bookmarkId, PointI spriteIndex)
        {
            _bookmarks[bookmarkId] = spriteIndex;
        }

        /// <summary>
        /// Get bookmark value from id.
        /// </summary>
        /// <param name="bookmarkId">Bookmark id.</param>
        /// <returns>Bookmark value, as index in spritesheet.</returns>
        public PointI GetBookmark(string bookmarkId)
        {
            return _bookmarks[bookmarkId];
        }

        /// <summary>
        /// Animate sprite based on animation id and progress.
        /// </summary>
        /// <param name="sprite">Sprite to animate.</param>
        /// <param name="animation">Animation id.</param>
        /// <param name="progress">Animation total progress, in seconds. This param is updated every call so you need to preserve it between calls.</param>
        /// <param name="deltaTime">How much to advance animation in current call.</param>
        /// <param name="sizeFactor">Set the size of the sprite to be the spritesheet's single sprite size, multiplied by this value. If set to 0, will not change sprite size.</param>
        /// <returns>Index to set in spritesheet.</returns>
        public void Animate(Sprite sprite, string animation, ref double progress, double deltaTime, float sizeFactor = 1.0f)
        {
            Animate(sprite, animation, ref progress, deltaTime, out int step, out bool finish, sizeFactor);
        }

        /// <summary>
        /// Animate sprite based on animation id and progress.
        /// </summary>
        /// <param name="sprite">Sprite to animate.</param>
        /// <param name="animation">Animation id.</param>
        /// <param name="progress">Animation total progress, in seconds. This param is updated every call so you need to preserve it between calls.</param>
        /// <param name="deltaTime">How much to advance animation in current call.</param>
        /// <param name="currStep">Will contain current animation step index.</param>
        /// <param name="didFinish">Will be set to true if animation ended (for repeating animations, will be true during the frame it reset back to step 0).</param>
        /// <param name="sizeFactor">Set the size of the sprite to be the spritesheet's single sprite size, multiplied by this value. If set to 0, will not change sprite size.</param>
        /// <returns>Index to set in spritesheet.</returns>
        public void Animate(Sprite sprite, string animation, ref double progress, double deltaTime, out int currStep, out bool didFinish, float sizeFactor = 1.0f)
        {
            var index = _animations[animation].Animate(ref progress, deltaTime, out currStep, out didFinish);
            SetSprite(sprite, index, sizeFactor);
        }

        /// <summary>
        /// Return if spritesheet contains an animation.
        /// </summary>
        /// <param name="animation">Animation id to check.</param>
        /// <returns>True if animation exists in spritesheet.</returns>
        public bool ContainsAnimation(string animation)
        {
            return _animations.ContainsKey(animation);
        }

        /// <summary>
        /// Return if spritesheet contains a bookmark.
        /// </summary>
        /// <param name="bookmark">Bookmark id to check.</param>
        /// <returns>True if bookmark exists in spritesheet.</returns>
        public bool ContainsBookmark(string bookmark)
        {
            return _bookmarks.ContainsKey(bookmark);
        }
    }
}
