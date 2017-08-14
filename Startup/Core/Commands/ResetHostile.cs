namespace Startup.Commands
{
    public class ResetHostile
    {
        public static void Execute(Hostile hostile)
        {
            hostile.RandomReset();
        }
    }
}
