using System;

namespace ASP.NET_CORE_3_Chapter_15.Services
{
    public interface ITimeStamper
    {
        string TimeStamp { get; }
    }

    public class DefaultTimeStamper : ITimeStamper
    {
        public string TimeStamp
        {
            get => DateTime.Now.ToShortTimeString();
        }
    }
}
