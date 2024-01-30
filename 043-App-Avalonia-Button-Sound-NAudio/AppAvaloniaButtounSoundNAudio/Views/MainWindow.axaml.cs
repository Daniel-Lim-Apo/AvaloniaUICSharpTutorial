using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using NAudio.Wave;
using System.IO;
using System.Reflection;
using Avalonia.Platform;

namespace AppAvaloniaButtounSoundNAudio.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnPlaySoundClicked(object sender, RoutedEventArgs e)
    {
        PlayAudioFromAsset("sound.mp3");
    }

    private void OnPlaySoundInvadersClicked(object sender, RoutedEventArgs e)
    {
        PlayAudioFromAsset("invaders.mp3");
    }

    private IWavePlayer wavePlayer;
    private AudioFileReader audioFileReader;

    public void PlayAudioFromAsset(string assetName)
    {
        using (var stream = AssetLoader.Open(new Uri($"avares://AppAvaloniaButtounSoundNAudio/Assets/{assetName}")))
        {
            if (stream == null)
                throw new InvalidOperationException("Resource not found.");

            // Create a temporary file
            var tempFile = Path.GetTempFileName();
            using (var fileStream = File.Create(tempFile))
            {
                stream.CopyTo(fileStream);
            }

            // Play the audio file
            wavePlayer = new WaveOutEvent();
            audioFileReader = new AudioFileReader(tempFile);
            wavePlayer.Init(audioFileReader);
            wavePlayer.Play();

            // Cleanup after playback is complete
            wavePlayer.PlaybackStopped += (sender, args) =>
            {
                audioFileReader.Dispose();
                wavePlayer.Dispose();
                File.Delete(tempFile);
            };
        }
    }
}