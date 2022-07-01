using Exiled.API.Features;

namespace EventAnnouncements.API.Entities
{
    public class Announcement
    {
        public string Cassie { get; set; }
        public string Subtitles { get; set; }
        public string Broadcast { get; set; }
        public string Hint { get; set; }
        public float DisplayTime { get; set; }

        public void Announce()
        {
            if (!string.IsNullOrEmpty(Cassie))
                AnnounceCassie();

            if (!string.IsNullOrEmpty(Broadcast))
                Map.Broadcast((ushort)DisplayTime, Broadcast);

            if (!string.IsNullOrEmpty(Hint))
                Map.ShowHint(Hint, DisplayTime);
        }

        private void AnnounceCassie()
        {
            if (string.IsNullOrEmpty(Subtitles))
                Exiled.API.Features.Cassie.Message(Cassie);
            else
                Exiled.API.Features.Cassie.MessageTranslated(Cassie, Subtitles);
        }
    }
}
