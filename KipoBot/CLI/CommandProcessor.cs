using CLI_Sharp;

namespace KipoBot
{
    public class CommandProcessor : CLI_Sharp.CommandProcessor
    {
        public override void processCommand(string cmd)
        {
            logger.info("command recieved!");
        }
    }
}