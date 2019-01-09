namespace Persistence
{
    public interface ITimeListener
    {
        void TimePassed();
        void HourPassed();
    }
}