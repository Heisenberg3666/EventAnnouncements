using EventAnnouncements.API.Entities;
using EventAnnouncements.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventAnnouncements
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("These are all the announcements that will be made for the server events.")]
        public Dictionary<ServerEventType, Announcement> ServerAnnouncements { get; set; } = new Dictionary<ServerEventType, Announcement>()
        {
            [ServerEventType.RoundStarted] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "The round is starting!",
                Hint = "Have fun!",
                DisplayTime = 5f
            },
            [ServerEventType.RoundEnded] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "The round has ended.",
                Hint = "GG!",
                DisplayTime = 5f
            }
        };

        [Description("These are all the announcements that will be made for the player events.")]
        public Dictionary<PlayerEventType, Announcement> PlayerAnnouncements { get; set; } = new Dictionary<PlayerEventType, Announcement>()
        {
            [PlayerEventType.ActivatingGenerator] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "A player has activated a generator!",
                Hint = "",
                DisplayTime = 5f
            },
            [PlayerEventType.ActivatingWarheadPanel] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "",
                Hint = "A player has activated the warhead panel.",
                DisplayTime = 5f
            }
        };
    }
}
