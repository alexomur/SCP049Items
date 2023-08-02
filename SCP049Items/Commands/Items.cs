using System;
using CommandSystem;

namespace SCP049Items.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Items : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }

        public string Command { get; } = "Items";
        public string[] Aliases { get; }
        public string Description { get; }
    }
}