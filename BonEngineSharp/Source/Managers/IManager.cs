using System;


namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Base interface for all managers.
    /// </summary>
    public abstract class IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public abstract string Id { get; }
    }
}
