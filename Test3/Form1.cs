using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Threading;
using System.Data.SqlClient;

namespace Test3
{

    public partial class Form1 : Form
    {
        public bool isPlaying = false;
        public DateTime startTime;
        public DateTime endTime;
       // string connectionString = @"Data Source=PC-PROGRAMMING\SQLEXPRESS;Initial Catalog=PlayerTest;Integrated Security=True";
        Database db = new Database();

        List<double> times = new List<double>();
        public static string PCName = Environment.MachineName;

        public Form1()
        {
            InitializeComponent();
            
        }



        private void openBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WAV|*.wav|MP4|*.mp4|WMV|*.wmv|MP3|*.mp3|MKV|*.mkv" })
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach (string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    listFile.DataSource = files;
                }

        }

        private void listFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listFile.SelectedItem as MediaFile;
            if (file != null)
            {
                wmpPlayer.URL = file.Path;
                wmpPlayer.Ctlcontrols.play();
                startTime = DateTime.Now;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listFile.ValueMember = "Path";
            listFile.DisplayMember = "FileName";
        }



        private void spacePauseEvent(object sender, AxWMPLib._WMPOCXEvents_KeyUpEvent e)
        {
            if (wmpPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                if (e.nKeyCode == 32 || e.nKeyCode == 13)
                {
                    wmpPlayer.Ctlcontrols.pause();
                    endTime = DateTime.Now;
                }
                CalculateTime(startTime, endTime);
            }

            else if (isPlaying == false)
            {
                if (e.nKeyCode == 32 || e.nKeyCode == 13)
                {
                    wmpPlayer.Ctlcontrols.play();
                    startTime = DateTime.Now;
                }
            }
        }

        private void CalculateTime(DateTime startTime, DateTime endTime)
        {
            double elapsedTime = 0;
            TimeSpan inSeconds = endTime - startTime;
            double totalTime = inSeconds.TotalSeconds;
            times.Add(totalTime);
            elapsedTime = times.Sum(x => x);

            //foreach (var item in times)
            //{
            //    MessageBox.Show(item.ToString());
            //}

            MessageBox.Show(elapsedTime.ToString());

            var cnn = db.Connect();
            TimeSpan time = TimeSpan.FromSeconds(elapsedTime);
            db.PushToBase(PCName, elapsedTime, endTime, cnn);
            inSeconds = TimeSpan.Zero;

        }

        private void speedUpDownHandler_Click(object sender, EventArgs e)
        {
            double newRate = (double)(this.speedUpDownHandler).Value;

            if (wmpPlayer.settings.get_isAvailable("Rate"))
            {
                wmpPlayer.settings.rate = newRate;
            }

        }

        private void speedUpDownHandler_ValueChanged(object sender, EventArgs e)
        {
            double newRate = (double)(this.speedUpDownHandler).Value;

            if (wmpPlayer.settings.get_isAvailable("Rate"))
            {
                wmpPlayer.settings.rate = newRate;
            }
        }

        private void wmpPlayer_Enter(object sender, EventArgs e)
        {

        }
    }
}