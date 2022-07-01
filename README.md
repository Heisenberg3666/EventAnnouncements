# EventAnnouncements


![GitHub release (latest by date)](https://img.shields.io/github/downloads/Heisenberg3666/EventAnnouncements/total?style=for-the-badge)


EventAnnouncements is a plugin for the game SCP: SL using the Exiled framework. It give server owners (who cannot code) the tools to automattically announce things when certain events are fired.


## Default config:


```yaml

event_announcements:

  is_enabled: true

  # These are all the announcements that will be made for the server events.

  server_announcements:

    RoundStarted:

      cassie: ''

      subtitles: ''

      broadcast: The round is starting!

      hint: Have fun!

      display_time: 5

    RoundEnded:

      cassie: ''

      subtitles: ''

      broadcast: The round has ended.

      hint: GG!

      display_time: 5

  # These are all the announcements that will be made for the player events.

  player_announcements:

    ActivatingGenerator:

      cassie: ''

      subtitles: ''

      broadcast: A player has activated a generator!

      hint: ''

      display_time: 5

    ActivatingWarheadPanel:

      cassie: ''

      subtitles: ''

      broadcast: ''

      hint: A player has activated the warhead panel.

      display_time: 5

```