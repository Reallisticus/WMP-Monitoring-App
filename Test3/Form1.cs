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

namespace Test3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool isPlaying = false;

        public DateTime startTime;
        public DateTime endTime;

        List<double> times = new List<double>();


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
            double totalTime = 0;
            TimeSpan inSeconds = endTime - startTime;
            double elapsedTime = inSeconds.TotalSeconds;
            times.Add(elapsedTime);


            for (int i = 0; i < times.Count; i++)
            {
                totalTime += times[i];
            }

            TimeSpan time = TimeSpan.FromSeconds(totalTime);

            MessageBox.Show(time.ToString("HH"));
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

    }
}