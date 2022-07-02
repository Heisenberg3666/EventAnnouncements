using EventAnnouncements.API.Entities;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace EventAnnouncements
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("These are all the announcements that will be made for each event assigned.")]
        public Dictionary<string, Announcement> Announcements { get; set; } = new Dictionary<string, Announcement>()
        {
            ["RoundStarted"] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "The round is starting!",
                Hint = "Have fun!",
                DisplayTime = 5f
            },
            ["RoundEnded"] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "The round has ended.",
                Hint = "GG!",
                DisplayTime = 5f
            },
            ["ActivatingGenerator"] = new Announcement()
            {
                Cassie = "",
                Subtitles = "",
                Broadcast = "A player has activated a generator!",
                Hint = "",
                DisplayTime = 5f
            },
            ["RoundEnded"] = new Announcement()
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
