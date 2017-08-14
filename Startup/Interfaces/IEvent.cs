using System;

namespace Startup.Interfaces
{
    public interface IEvent : IPosition
    {
        bool IsActive { get; }

        void TimeTrigger();

        int Activate();
    }
}