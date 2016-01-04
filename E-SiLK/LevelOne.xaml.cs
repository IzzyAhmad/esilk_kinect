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
using System.Windows.Threading;

namespace E_SiLK
{
    /// <summary>
    /// Interaction logic for LevelOne.xaml
    /// </summary>
    public partial class LevelOne : Window
    {
        public KinectSensorChooser sensorChooser;
        long busapos, busbpos, buscpos, carapos, carbpos, playerpos, carapost, playerpost;
        int score = 0;

        public static readonly DependencyProperty MyProperty1Property =
        DependencyProperty.Register("MyProperty1", typeof(string), typeof(LevelOne), new UIPropertyMetadata(string.Empty));

        public string MyProperty1
        {
            get { return (string)GetValue(MyProperty1Property); }
            set { SetValue(MyProperty1Property, value); }
        }


        public LevelOne(KinectSensorChooser sensorChooser)
        {
            InitializeComponent();
            sensorChooser = this.sensorChooser;
            Loaded += OnLoaded;
            long playerpos = Convert.ToInt64(player.GetValue(Canvas.LeftProperty));
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();       
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.busapos = Convert.ToInt64(busa.GetValue(Canvas.LeftProperty));
            this.busbpos = Convert.ToInt64(busb.GetValue(Canvas.LeftProperty));
            this.buscpos = Convert.ToInt64(busc.GetValue(Canvas.LeftProperty));
            this.carapos = Convert.ToInt64(cara.GetValue(Canvas.LeftProperty));
            this.carbpos = Convert.ToInt64(carb.GetValue(Canvas.LeftProperty));
            this.playerpos = Convert.ToInt64(player.GetValue(Canvas.LeftProperty));
            this.carapost = Convert.ToInt64(cara.GetValue(Canvas.TopProperty));
            this.playerpost = Convert.ToInt64(player.GetValue(Canvas.TopProperty));
            
            if (busapos >= 1024)
            {
                Canvas.SetLeft(busa, -6);
                Canvas.SetLeft(busb, -6);
                Canvas.SetLeft(busc, -6);
                Canvas.SetLeft(cara, -12);
                Canvas.SetLeft(carb, -12);
            }
            else
            {
                Canvas.SetLeft(busa, busapos - 5);
                Canvas.SetLeft(busb, busbpos - 5);
                Canvas.SetLeft(busc, buscpos - 5);
                Canvas.SetLeft(cara, carapos - 10);
                Canvas.SetLeft(carb, carbpos - 10);

                //MessageBox.Show("" + carapos);
                if (this.carapos.Equals(this.playerpos + 100) && this.carapost.Equals(this.playerpost))
                {
                    MessageBox.Show("Aww! Your score is " + score +"! Try Again!");
                    LeaderBoard lb = new LeaderBoard(sensorChooser);
                    this.sensorChooser.Stop();
                    lb.Show();
                    this.Close();
                }
            }
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
           this.playerpos = Convert.ToInt64(player.GetValue(Canvas.LeftProperty));
            Canvas.SetLeft(player, playerpos + 50);
            
        }

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.playerpos = Convert.ToInt64(player.GetValue(Canvas.LeftProperty));
            //Canvas.SetLeft(player, playerpos - 50);
            Canvas.SetTop(player, playerpos + 100);
        }

        private void KinectTileButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.playerpos = Convert.ToInt64(player.GetValue(Canvas.TopProperty));
            this.busapos = Convert.ToInt64(busa.GetValue(Canvas.TopProperty));
            Canvas.SetTop(player, playerpos - 100);

            score += 10;
            this.MyProperty1 = score.ToString();

            //MessageBox.Show(""+score);

            if (playerpos == 21){
                MessageBox.Show("Congratulation! Your score is "+score);
                SelecLevel sl = new SelecLevel(sensorChooser);
                this.sensorChooser.Stop();
                sl.Show();
                this.Close();
            }
        }
    }
}
