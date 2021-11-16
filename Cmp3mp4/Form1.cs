using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmp3mp4
{
    public partial class Form1 : Form
    {
        public string formatType;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("test");
            //open file
            //openFileDialog1.Filter = "ogg files (*.ogg)|*.ogg|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = "C:\\Users\\%USERPROFILE%\\Downloads";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            txtOpenFile.Text = openFileDialog1.FileName;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveTo_Click(object sender, EventArgs e)
        {
            // save file

           

            if(radioButton1.Checked)
            {
                formatType = ".mp3";
            }
            else
            {
                formatType = ".mp4";
            }

            saveFileDialog1.FileName = Regex.Replace(openFileDialog1.SafeFileName, @"\.\w+", "")+ formatType;

            saveFileDialog1.ShowDialog();

            txtSaveTo.Text = saveFileDialog1.FileName;


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //START

            string strCmdText;
            if (radioButton1.Checked)
            {
                formatType = ".mp3";
            }
            else
            {
                formatType = ".mp4";
            }

            if (openFileDialog1.FileNames.Length>1)
            {

                Console.WriteLine("you select more then one file");
                int i = 0;
                while (openFileDialog1.FileNames.Length > i)
                {
                    strCmdText = "ffmpeg -i \"" + openFileDialog1.FileNames[i] + "\" \"" + Directory.GetCurrentDirectory() + "\\FFOutput\\ " + Regex.Replace(openFileDialog1.SafeFileNames[i], @"\.\w+", "") + formatType + "\"";
                    System.Diagnostics.Process.Start("CMD.exe", "/c " + strCmdText);
                   
                    Console.WriteLine(strCmdText);
                    i++;
                }

                System.Diagnostics.Process.Start("explorer.exe", Directory.GetCurrentDirectory() + "\\FFOutput\\ ");



            }
            else
            {
                

                strCmdText = "ffmpeg -i \"" + txtOpenFile.Text + "\" \"" + txtSaveTo.Text + "\"";
                Console.WriteLine(strCmdText);
                System.Diagnostics.Process.Start("CMD.exe", "/c " + strCmdText);


               // System.Diagnostics.Process.Start("explorer.exe", saveFileDialog1.FileName);
            }


            
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Code By Ali Alhashim (ali Code) tools: C#+WindowsForms +ffmpeg ");
        }
    }
}
