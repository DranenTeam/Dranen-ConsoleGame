using Startup.Core.Arguments;

namespace Startup.Interfaces
{
    public interface IHostile : IDynamic, ISoundable
    {
        int Slowliness { get; }

        void RandomReset();

        void OnOverlap(object sender, OverlapArgs e);
    }
}