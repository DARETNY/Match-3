using Base.Signal_base;

namespace Signals
{
    public struct ClickExpired : ICoreSystem
    {
        private int _click;

        public int Click
        {
            get => _click;
            set => _click = value < 0 ? 0 : value;
        }

        /// <summary>
        /// how many click u want it to pass the next level
        /// </summary>
        /// <param name="desiredClick"></param>
        /// <returns></returns>
        public bool DesiredClick(int desiredClick)
        {
            return _click >= desiredClick;
        }
    }
}