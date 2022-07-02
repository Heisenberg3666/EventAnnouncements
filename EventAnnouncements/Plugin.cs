using EventAnnouncements.API;
using Exiled.API.Features;
using System;

namespace EventAnnouncements
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        public override string Name => "EventAnnouncements";
        public override string Author => "Heisenberg3666";
        public override Version Version => new Version(1, 1, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 2, 2);

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

        public void RegisterEvents()
        {
            foreach (string eventName in Config.Announcements.Keys)
                DynamicConnection.CreateConnection(eventName);
        }

        public void UnregisterEvents()
        {
            foreach (string eventName in Config.Announcements.Keys)
                DynamicConnection.DisconnectFromEvent(eventName);
        }
    }
}
