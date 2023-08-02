using System;
using CommandSystem;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using PlayerRoles;

namespace SCP049Items.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Items : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player.Role != RoleTypeId.Scp049)
            {
                response = "You need to be SCP-049 first";
                return false;
            }

            List<Item> items = player.Items.ToList();

            if (items.Count == 0)
            {
                response = "You have no items in your inventory!";
                return true;
            }

            response = "";
            for (int i = 1; i <= items.Count; i++)
            {
                response += "\n[" + i + "] " + items[i-1].Type;
            }

            response += "\nYou can take your items via hotkeys or .take command\nYou can drop your items via hotkey or .drop command";
            return true;

        }

        public string Command { get; } = "Items";
        public string[] Aliases { get; }
        public string Description { get; }
    }
}