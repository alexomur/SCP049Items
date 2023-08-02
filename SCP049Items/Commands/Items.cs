using System;
using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using InventorySystem.Items.Pickups;
using PlayerRoles;
using UnityEngine;

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

            response = "";
            for (int i = 1; i <= items.Count; i++)
            {
                response += "\n[" + i + "] " + items[i-1].Type;
            }

            return true;

        }

        public string Command { get; } = "Items";
        public string[] Aliases { get; }
        public string Description { get; }
    }
}