using Exiled.API.Features;

namespace SCP049Items
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "Your name";

        public override string Name => "Exiled.Template";

        public override string Prefix => Name;

        public static Plugin Instance;

        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();
        }

        private void UnregisterEvents()
        {
            _handlers = null;
        }
    }
}