using EventAnnouncements.API.Entities;
using EventAnnouncements.API.Enums;
using System.Collections.Generic;

namespace EventAnnouncements.API
{
    public static class Extensions
    {
        public static void TryAnnounceServer(this Dictionary<ServerEventType, Announcement> announcements, ServerEventType eventType)
        {
            if (announcements.TryGetValue(eventType, out Announcement announcement))
                announcement.Announce();
        }
        
        public static void TryAnnouncePlayer(this Dictionary<PlayerEventType, Announcement> announcements, PlayerEventType eventType)
        {
            if (announcements.TryGetValue(eventType, out Announcement announcement))
                announcement.Announce();
        }
    }
}
