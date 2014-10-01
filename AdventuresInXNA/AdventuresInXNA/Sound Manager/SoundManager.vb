

Public Class SoundManager

    Public Shared soundOn As Boolean = True


    'Used to enable all sounds
    Public Shared Sub play()
        MediaPlayer.Play(Sounds.ambientMusic)
    End Sub

    'Used to disable all sounds
    Public Shared Sub pause()
        MediaPlayer.Pause()
    End Sub


End Class
