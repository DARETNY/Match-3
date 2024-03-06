using Base.Signal_base;

namespace Signals
{
    public struct ClickExpired : IBoardSignals
    {
        //todo:wrong this section fix it
        public int Click { get; set; }

        /// <summary>
        /// how many click u want it to pass the next level
        /// </summary>
        /// <param name="desiredClick"></param>
        /// <returns></returns>
        public bool DesiredClick(int desiredClick)
        {
            return Click > desiredClick;
        }
    }
}