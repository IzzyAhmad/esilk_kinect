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
    /// Interaction logic for SelecLevel.xaml
    /// </summary>
    public partial class SelecLevel : Window
    {
        public KinectSensorChooser sensorChooser;

        public SelecLevel(KinectSensorChooser sensorChooser)
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

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {
            LevelOne lo = new LevelOne(sensorChooser);
            this.sensorChooser.Stop();
            lo.Show();
            this.Close();
        }

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu(sensorChooser);
            this.sensorChooser.Stop();
            mm.Show();
            this.Close();
        }

        //void kinectSensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        //{
        //    using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
        //    {
        //        if (skeletonFrame != null)
        //        {
        //            //int skeletonSlot = 0;
        //            Skeleton[] skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];

        //            skeletonFrame.CopySkeletonDataTo(skeletonData);
        //            Skeleton playerSkeleton = (from s in skeletonData where s.TrackingState == SkeletonTrackingState.Tracked select s).FirstOrDefault();
        //            if (playerSkeleton != null)
        //            {
        //                //Joint rightHand = playerSkeleton.Joints[JointType.HandRight];
        //                Joint leftshoulder = playerSkeleton.Joints[JointType.ShoulderLeft];
        //                Joint rightshoulder = playerSkeleton.Joints[JointType.ShoulderRight];
        //                //handPosition = new Vector2((((0.5f * rightHand.Position.X) + 0.5f) * (640)), (((-0.5f * rightHand.Position.Y) + 0.5f) * (480)));

        //                if ((leftshoulder.Position.Y + 0.5f) >= rightshoulder.Position.Y && (leftshoulder.Position.Y - 0.5f) <= rightshoulder.Position.Y)
        //                {
        //                    //No Direction
        //                    MessageBox.Show("tegak!!!!!!!!"); 
        //                }
        //                else if (leftshoulder.Position.Y < rightshoulder.Position.Y)
        //                {
        //                    //leaning left
        //                    MessageBox.Show("Bersaddsadgerak!!!!!!!!"); 
        //                }
        //                else
        //                {
        //                    //leaning right
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
