using System;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Game manager.
    /// Controls the general game flow / application. This includes exiting the application, changing scene, querying total delta time, ect.
    /// </summary>
    public class GameManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "game";

        /// <summary>
        /// Currently active scene.
        /// </summary>
        private Scene _activeScene;

        /// <summary>
        /// Exit application.
        /// </summary>
        public void Exit()
        {
            _BonEngineBind.BON_Game_Exit();
        }

        /// <summary>
        /// Change the active scene.
        /// </summary>
        /// <param name="scene">Scene to switch to.</param>
        public void ChangeScene(Scene scene)
        {
            // store the currently active scene to make sure it won't get collected by the GC by accident.
            _activeScene = scene;
            _BonEngineBind.BON_Game_ChangeScene(scene.GetOrCreateHandle());
        }

        /// <summary>
        /// Load game config from file.
        /// </summary>
        /// <param name="path">Path of config file to load.</param>
        public void LoadConfig(string path) 
        {
            path = BonEngine._Engine.Assets.ToAssetsPath(path, true);
            _BonEngineBind.BON_Game_LoadConfig(path);
        }

        /// <summary>
        /// Get total game elapsed time, in seconds.
        /// </summary>
        /// <returns>Elapsed time.</returns>
        public double ElapsedTime => _BonEngineBind.BON_Game_ElapsedTime();

        /// <summary>
        /// Get current frame delta time, in seconds.
        /// </summary>
        /// <returns>Delta time.</returns>
        public double DeltaTime => _BonEngineBind.BON_Game_DeltaTime();
    }
}
