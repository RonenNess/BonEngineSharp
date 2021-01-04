using BonEngineSharp.Defs;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;
using BonEngineSharp.Utils;

namespace BonEngineSharpTest.Demos
{
    /// <summary>
    /// Music and sound effects example.
    /// </summary>
    class MusicAndSoundScene : BonEngineSharp.Scene
    {
        // assets
        private FontAsset _font;
        private FontAsset _fontBig;

        // music and sound
        private MusicAsset _music;
        private MusicAsset _altMusic;
        private SoundAsset _sound;

        private MusicFader _musicFader;

        // is the music paused?
        bool _paused;

        // load the scene
        protected override void Load()
        {
            // load fonts
            _font = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 22, false);
            _fontBig = Assets.LoadFont("gfx/OpenSans-Regular.ttf", 42, false);

            // load font and music
            _music = Assets.LoadMusic("sfx/old city theme.ogg");
            _altMusic = Assets.LoadMusic("sfx/forest.ogg");
            _sound = Assets.LoadSound("sfx/phaserUp1.mp3");

            // start playing music via the music fader
            _musicFader = new MusicFader(null, 100, _music, 100);
        }

        // on updates do animations and controls
        protected override void Update(double deltaTime)
        {
            // if user click 'exit' action, exit game
            if (Input.Down("exit"))
            {
                Game.Exit();
            }

            // play sound effects
            if (Input.PressedNow(KeyCodes.Key1)) { Sfx.PlaySound(_sound, 100, 0, 0.25f); }
            if (Input.PressedNow(KeyCodes.Key2)) { Sfx.PlaySound(_sound, 100, 0, 0.5f); }
            if (Input.PressedNow(KeyCodes.Key3)) { Sfx.PlaySound(_sound, 100, 0, 0.75f); }
            if (Input.PressedNow(KeyCodes.Key4)) { Sfx.PlaySound(_sound, 100, 0, 1f); }
            if (Input.PressedNow(KeyCodes.Key5)) { Sfx.PlaySound(_sound, 100, 0, 1.25f); }
            if (Input.PressedNow(KeyCodes.Key6)) { Sfx.PlaySound(_sound, 100, 0, 1.5f); }
            if (Input.PressedNow(KeyCodes.Key7)) { Sfx.PlaySound(_sound, 100, 0, 1.75f); }

            // do music switching
            if (Input.PressedNow(KeyCodes.KeyZ))
            {
                _musicFader = new MusicFader(_musicFader.ToTrack, _musicFader.CurrentVolume, _music, 100);
            }
            if (Input.PressedNow(KeyCodes.KeyX))
            {
                _musicFader = new MusicFader(_musicFader.ToTrack, _musicFader.CurrentVolume, _altMusic, 30);
            }

            // pause / resume music
            if (Input.PressedNow(KeyCodes.KeySpace))
            {
                _paused = !_paused;
                Sfx.PauseMusic(_paused);
            }

            // update music fader
            if (_musicFader != null && !_paused)
            {
                _musicFader.Update(deltaTime);
            }
        }

        // draw scene
        protected override void Draw()
        {
            // clear screen
            Gfx.ClearScreen(Color.Cornflower);

            // title and text
            Gfx.DrawText(_fontBig, "Music and Sounds", new PointF(80, 120), Color.White, Color.Black, 1, 42);
            Gfx.DrawText(_font, "This scene demonstrates the Sfx manager.\n" +
                "- Press 1-7 to play sound with different pitch.\n" +
                "- Press Space to pause / resume music.\n" +
                "- Press Z/X to change music with fade effect.\n" +
                "- Press Escape to exit.", new PointF(80, 210), Color.White, Color.Black, 1, 22);
        }
    }
}
