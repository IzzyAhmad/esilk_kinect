﻿using System;
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
using System.Windows.Shapes;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit.Interaction;

namespace E_SiLK
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public KinectSensorChooser sensorChooser;
        public MainMenu(KinectSensorChooser sensorChooser)
        {
            InitializeComponent();
            sensorChooser = this.sensorChooser;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();
        }

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            bool error = false;
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                    error = true;
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();
                }
                catch (InvalidOperationException)
                {
                    error = true;
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (!error)
                kinectRegion.KinectSensor = args.NewSensor;
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {
            SelecLevel sl = new SelecLevel(sensorChooser);
            this.sensorChooser.Stop();
            sl.Show();
            this.Close();
        }

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            LeaderBoard lb = new LeaderBoard(sensorChooser);
            this.sensorChooser.Stop();
            lb.Show();
            this.Close();
        }

        private void KinectTileButton_Click2(object sender, RoutedEventArgs e)
        {
            
            Learn lr = new Learn(sensorChooser);
            this.sensorChooser.Stop();
            lr.Show();
            this.Close();
        }

        private void KinectTileButton_Click_2(object sender, RoutedEventArgs e)
        {
            Market mk = new Market(sensorChooser);
            this.sensorChooser.Stop();
            mk.Show();
            this.Close();
        }

        private void KinectTileButton_Click_3(object sender, RoutedEventArgs e)
        {
            About a = new About(sensorChooser);
            this.sensorChooser.Stop();
            a.Show();
            this.Close();
        }

 

    }
}