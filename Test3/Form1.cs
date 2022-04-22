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

namespace Test3
{

    public static class Status
    {

        public static bool playingStatus;
    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool isPlaying = false;

        public DateTime firstPlayTimeHours = DateTime.MinValue;
        public DateTime firstPlayTimeDate = DateTime.MinValue;

        public int parsedfPlayTime;
        public int 

        private void openBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "MP4|*.mp4|WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MKV|*.mkv" })
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
                isPlaying = true;

                firstPlayTimeHours = DateTime.Now;
                firstPlayTimeDate = DateTime.Now;

                parsedfPlayTime = int.Parse(firstPlayTimeHours.ToString("hhmmss"));
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listFile.ValueMember = "Path";
            listFile.DisplayMember = "FileName";

            if (wmpPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                Status.playingStatus = true;
            }
            else
            {
                Status.playingStatus = false;
            }

            if(Status.playingStatus == true)
            {
                
            }

        }



        private void spacePauseEvent(object sender, AxWMPLib._WMPOCXEvents_KeyUpEvent e)
        {
            if (isPlaying == true)
            {
                if (e.nKeyCode == 32 || e.nKeyCode == 13)
                {
                    wmpPlayer.Ctlcontrols.pause();
                    isPlaying = false;
                }
            }
            else if (isPlaying == false)
            {
                if (e.nKeyCode == 32 || e.nKeyCode == 13)
                {
                    wmpPlayer.Ctlcontrols.play();
                    isPlaying = true;
                }
            }

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