using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace SCP049Items
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "DrBright";

        public override string Name => "SCP049Items";

        public override string Prefix => Name;

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;

            base.OnDisabled();
        }
    }
}