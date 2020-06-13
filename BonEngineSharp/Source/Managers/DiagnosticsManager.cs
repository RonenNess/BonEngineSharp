using BonEngineSharp.Defs;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Diagnostics manager.
    /// Used to query diagnostics and debug data like draw calls count, FPS, ect.
    /// </summary>
    public class DiagnosticsManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "diagnostics";

        /// <summary>
        /// Get FPS count.
        /// </summary>
        public int FpsCount => _BonEngineBind.BON_Diagnostics_FpsCounter();

        /// <summary>
        /// Get counter value.
        /// </summary>
        /// <param name="counter">Counter id to get.</param>
        /// <returns>Counter value.</returns>
        public long GetCounter(DiagnosticsCounters counter)
        {
            return GetCounter((int)counter);
        }

        /// <summary>
        /// Get counter value.
        /// </summary>
        /// <param name="counter">Counter id to get.</param>
        /// <returns>Counter value.</returns>
        public long GetCounter(int counter)
        {
            return _BonEngineBind.BON_Diagnostics_GetCounter(counter);
        }

        /// <summary>
        /// Increase counter.
        /// </summary>
        /// <param name="counter">Counter id to increase.</param>
        /// <param name="amount">How much to increase counter.</param>
        public void IncreaseCounter(DiagnosticsCounters counter, int amount = 1)
        {
            IncreaseCounter((int)counter, amount);
        }

        /// <summary>
        /// Increase counter.
        /// </summary>
        /// <param name="counter">Counter id to increase.</param>
        /// <param name="amount">How much to increase counter.</param>
        public void IncreaseCounter(int counter, int amount = 1)
        {
            _BonEngineBind.BON_Diagnostics_IncreaseCounter(counter, amount);
        }

        /// <summary>
        /// Reset a counter.
        /// </summary>
        /// <param name="counter">Counter id to reset.</param>
        public void ResetCounter(DiagnosticsCounters counter)
        {
            ResetCounter((int)counter);
        }

        /// <summary>
        /// Reset a counter.
        /// </summary>
        /// <param name="counter">Counter id to reset.</param>
        public void ResetCounter(int counter)
        {
            _BonEngineBind.BON_Diagnostics_ResetCounter(counter);
        }
    }
}
