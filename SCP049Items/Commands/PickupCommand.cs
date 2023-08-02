using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using InventorySystem.Items.Pickups;
using PlayerRoles;
using UnityEngine;

namespace SCP049Items.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class PickupCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (player.Role != RoleTypeId.Scp049)
            {
                response = "You need to be SCP-049 first";
                return false;
            }
            
            // Creating ray. Endpoint is in `hit`
            Physics.Raycast(new Ray(player.CameraTransform.position, player.CameraTransform.forward), 
                out RaycastHit hit, 5);

            // Checking if an endpoint is a pickup
            if (!hit.transform.name.Contains("Pickup") && hit.transform.gameObject.layer != 9)
            {
                response = "You need to look at the object first";
                return false;
            }
            
            // Getting pickup from `hit`
            Pickup pickup = Pickup.Get(hit.transform.GetComponentInParent<ItemPickupBase>());
            if (pickup == null)
            {
                response = "pickup null";
                return false;
            }
            
            player.AddItem(pickup:pickup);
            pickup.Destroy();

            response = "You picked up " + pickup.Type + "\nType .items to show your inventory.";
            return true;
        }

        public string Command { get; } = "Pickup";
        public string[] Aliases { get; }
        public string Description { get; }
    }
}