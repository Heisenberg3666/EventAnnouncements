using EventAnnouncements.API.Entities;
using System.Collections.Generic;

namespace EventAnnouncements.API
{
    public static class Extensions
    {
        public static void TryAnnounce(this Dictionary<string, Announcement> announcements, string eventType)
        {
            if (announcements.TryGetValue(eventType, out Announcement announcement))
                announcement.Announce();
        }
    }
}
