using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaPlayer = LibVLCSharp.Shared.MediaPlayer;

namespace VLCTest
{
    /// <summary>
    /// Interaction logic for Controls.xaml
    /// </summary>
    public partial class Controls : UserControl
    {
       readonly Example1 parent;
        LibVLC _libVLC;
        MediaPlayer _mediaPlayer;

        public Controls(Example1 Parent)
        {
            parent = Parent;

            InitializeComponent();

            // we need the VideoView to be fully loaded before setting a MediaPlayer on it.
            parent.VideoView.Loaded += VideoView_Loaded;
            PlayButton.Click += PlayButton_Click;
            StopButton.Click += StopButton_Click;
            Unloaded += Controls_Unloaded;
        }

        private void Controls_Unloaded(object sender, RoutedEventArgs e)
        {
            if( _mediaPlayer != null )
            { 
            _mediaPlayer.Stop();
            _mediaPlayer.Dispose();
            }
            _libVLC.Dispose();
        }

        private void VideoView_Loaded(object sender, RoutedEventArgs e)
        {
            
           
        }

        void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (parent.VideoView.MediaPlayer.IsPlaying)
            {
                parent.VideoView.MediaPlayer.Stop();
            }
        }

        void PlayButton_Click(object sender, RoutedEventArgs e)
        {
string userName = "admin";
            string password = "";

           Core.Initialize();
           _libVLC = new LibVLC("--no-audio", "--no-spu", "--intf=dummy", $"--rtsp-user={userName}", $"--rtsp-pwd={password}");


            var mp = new MediaPlayer(_libVLC)
            {
                Media = new Media(_libVLC, "rtsp://192.168.0.21:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif&user=admin&password=", FromType.FromLocation )
            };
             parent.VideoView.MediaPlayer = _mediaPlayer;
            mp.Play();
        }

        private void UserControl_Loaded( object sender, RoutedEventArgs e )
        {

        }
    }
}
