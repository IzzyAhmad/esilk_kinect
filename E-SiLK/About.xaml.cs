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
using System.Windows.Shapes;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Kinect.Toolkit.Interaction;

namespace E_SiLK
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public KinectSensorChooser sensorChooser;
        public About(KinectSensorChooser sensorChooser)
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
            // Color stream
            //kinectSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            //kinectSensor.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(kinectSensor_ColorFrameReady);



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

                    //// Skeleton Stream
                    //kinectSensor.SkeletonStream.Enable(new TransformSmoothParameters()
                    //{
                    //    Smoothing = 0.5f,
                    //    Correction = 0.5f,
                    //    Prediction = 0.5f,
                    //    JitterRadius = 0.05f,
                    //    MaxDeviationRadius = 0.04f
                    //});
                    //args.NewSensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(kinectSensor_SkeletonFrameReady);

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

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(sensorChooser);
            this.sensorChooser.Stop();
            mm.Show();
            this.Close();
        }
    }
}
