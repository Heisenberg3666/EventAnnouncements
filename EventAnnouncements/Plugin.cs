using EventAnnouncements.Events;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAnnouncements
{
    public class Plugin : Plugin<Config>
    {
        private ServerEvents _serverEvents;
        private PlayerEvents _playerEvents;

        public static Plugin Instance;

        public override string Name { get; } = "EventAnnouncements";
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(1, 0, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 2);

        public override void OnEnabled()
        {
            Instance = this;
            _serverEvents = new ServerEvents(Config.ServerAnnouncements);
            _playerEvents = new PlayerEvents(Config.PlayerAnnouncements);

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            _playerEvents = null;
            _serverEvents = null;
            Instance = null;

            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            _serverEvents.RegisterEvents();
            _playerEvents.RegisterEvents();
        }

        public void UnregisterEvents()
        {
            _serverEvents.UnregisterEvents();
            _playerEvents.UnregisterEvents();
        }
    }
}
