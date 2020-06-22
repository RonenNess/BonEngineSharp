using BonEngineSharp.Managers;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Provide API to get all built in managers.
    /// Inherit from this class to get API similar to a Scene where you can just call Gfx.DrawImage(..) or Input.Down(..).
    /// </summary>
    public class ManagerGetters
    {
        /// <summary>
        /// Get manager of generic type by id.
        /// </summary>
        public T GetManager<T>(string id) where T : IManager
        {
            return BonEngine._Engine.GetManager<T>(id);
        }

        /// <summary>
        /// Get Gfx manager.
        /// </summary>
        public GfxManager Gfx => BonEngine._Engine.Gfx;

        /// <summary>
        /// Get Sfx manager.
        /// </summary>
        public SfxManager Sfx => BonEngine._Engine.Sfx;

        /// <summary>
        /// Get Input manager.
        /// </summary>
        public InputManager Input => BonEngine._Engine.Input;

        /// <summary>
        /// Get Assets manager.
        /// </summary>
        public AssetsManager Assets => BonEngine._Engine.Assets;

        /// <summary>
        /// Get Game manager.
        /// </summary>
        public GameManager Game => BonEngine._Engine.Game;

        /// <summary>
        /// Get Diagnostics manager.
        /// </summary>
        public DiagnosticsManager Diagnostics => BonEngine._Engine.Diagnostics;

        /// <summary>
        /// Get Log manager.
        /// </summary>
        public LogManager Log => BonEngine._Engine.Log;

        /// <summary>
        /// Get UI manager.
        /// </summary>
        public UIManager UI => BonEngine._Engine.UI;
    }
}
