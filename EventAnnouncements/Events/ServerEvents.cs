using EventAnnouncements.API;
using EventAnnouncements.API.Entities;
using EventAnnouncements.API.Enums;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using System.Collections.Generic;

namespace EventAnnouncements.Events
{
    internal class ServerEvents
    {
        private readonly Dictionary<ServerEventType, Announcement> _announcements;

        public ServerEvents(Dictionary<ServerEventType, Announcement> announcements)
        {
            _announcements = announcements;
        }

        public void RegisterEvents()
        {
            Server.EndingRound += OnEndingRound;
            Server.LocalReporting += OnLocalReporting;
            Server.ReloadedConfigs += OnReloadedConfigs;
            Server.ReloadedGameplay += OnReloadedGameplay;
            Server.ReloadedRA += OnReloadedRA;
            Server.ReloadedTranslations += OnReloadedTranslations;
            Server.ReportingCheater += OnReportingCheater;
            Server.RespawningTeam += OnRespawningTeam;
            Server.RestartingRound += OnRestartingRound;
            Server.RoundEnded += OnRoundEnded;
            Server.RoundStarted += OnRoundStarted;
            Server.WaitingForPlayers += OnWaitingForPlayers;
        }

        public void UnregisterEvents()
        {
            Server.EndingRound -= OnEndingRound;
            Server.LocalReporting -= OnLocalReporting;
            Server.ReloadedConfigs -= OnReloadedConfigs;
            Server.ReloadedGameplay -= OnReloadedGameplay;
            Server.ReloadedRA -= OnReloadedRA;
            Server.ReloadedTranslations -= OnReloadedTranslations;
            Server.ReportingCheater -= OnReportingCheater;
            Server.RespawningTeam -= OnRespawningTeam;
            Server.RestartingRound -= OnRestartingRound;
            Server.RoundEnded -= OnRoundEnded;
            Server.RoundStarted -= OnRoundStarted;
            Server.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private void OnEndingRound(EndingRoundEventArgs e) => _announcements.TryAnnounceServer(ServerEventType.EndingRound);
        private void OnLocalReporting(LocalReportingEventArgs e) => _announcements.TryAnnounceServer(ServerEventType.LocalReporting);
        private void OnReloadedConfigs() => _announcements.TryAnnounceServer(ServerEventType.ReloadedConfigs);
        private void OnReloadedGameplay() => _announcements.TryAnnounceServer(ServerEventType.ReloadedGameplay);
        private void OnReloadedRA() => _announcements.TryAnnounceServer(ServerEventType.ReloadedRA);
        private void OnReloadedTranslations() => _announcements.TryAnnounceServer(ServerEventType.ReloadedTranslations);
        private void OnReportingCheater(ReportingCheaterEventArgs e) => _announcements.TryAnnounceServer(ServerEventType.ReportingCheater);
        private void OnRespawningTeam(RespawningTeamEventArgs e) => _announcements.TryAnnounceServer(ServerEventType.RespawningTeam);
        private void OnRestartingRound() => _announcements.TryAnnounceServer(ServerEventType.RestartingRound);
        private void OnRoundEnded(RoundEndedEventArgs e) => _announcements.TryAnnounceServer(ServerEventType.RoundEnded);
        private void OnRoundStarted() => _announcements.TryAnnounceServer(ServerEventType.RoundStarted);
        private void OnWaitingForPlayers() => _announcements.TryAnnounceServer(ServerEventType.WaitingForPlayers);
    }
}
