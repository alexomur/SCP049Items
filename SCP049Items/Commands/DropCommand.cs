using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Extensions;
using PlayerRoles;
using UnityEngine;

namespace SCP049Items.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class DropCommand : ICommand
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
                return false;
            }

            if (arguments.Array == null)
            {
                response = "arguments.Array null";
                return false;
            }

            if (arguments.Array.Length == 1)
            {
                if (player.CurrentItem == null)
                {
                    response = "You have no item in your hands";
                    return false;
                }
                player.DropItem(player.CurrentItem);
                player.CurrentItem = null;
                response = "You dropped the item out of your hands!";
                return true;
            }
            
            player.SendConsoleMessage("1", "green");

            int index = Convert.ToInt32(arguments.Array[1]) - 1;
            
            player.SendConsoleMessage("2", "green");
            if (index > items.Count - 1)
            {
                response = "There is no such item in your inventory!\nType .items to show your inventory.";
                return false;
            }
            
            player.SendConsoleMessage("3", "green");

            response = "You've dropped " + items[index].Type;
            player.DropItem(items[index]);
            
            player.SendConsoleMessage("4", "green");

            return true;

        }

        public string Command { get; } = "Drop";
        public string[] Aliases { get; }
        public string Description { get; }
    }
}