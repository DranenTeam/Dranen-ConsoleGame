namespace Startup.Interfaces
{
    public interface IPosition
    {
        int X { get; }
        int Y { get; }
        int GameWidth { get; }
        int GameHeight { get; }
    }
}