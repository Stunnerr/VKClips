using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace VKClips
{
    public partial class Form : System.Windows.Forms.Form
    {
        string access_token = "";
        public Form()
        {
            InitializeComponent();
        }
        private string UploadApi(Dictionary<string, string> param = null)
        {
            param ??= new Dictionary<string, string>();
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Safari/537.36");
            webClient.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            webClient.QueryString.Add("v", "5.107");
            webClient.QueryString.Add("access_token", access_token);
            foreach (var i in param)
            {
                webClient.QueryString.Add(i.Key, i.Value);
            }
            return webClient.DownloadString("https://api.vk.com/method/shortVideo.create");

        }
        private void UploadClip(string file, Dictionary<string, string> param)
        {
            string link = UploadApi(param);
            JObject jObject = JObject.Parse(link);
            string uploadURL = jObject.SelectToken("$.response.upload_url").Value<string>();
            WebClient webClient = new WebClient();
            webClient.UploadFile(uploadURL, file);

        }
        private void TestApi()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Safari/537.36");
            webClient.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            webClient.QueryString.Add("v", "5.107");
            webClient.QueryString.Add("access_token", access_token);
            ChangeColor(webClient.DownloadString("https://api.vk.com/method/execute").Contains("\"error_code\":5"));

        }
        private void tokenInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
        private void ChangeColor(bool test)
        {
            if (test)
            {
                token.BackColor = Color.Red;
                Execute.Enabled = false;
            }
            else { token.BackColor = Color.White; Execute.Enabled = true; }
        }
        private void CheckToken(object sender, EventArgs e)
        {
            if (token.TextLength < 60)
            {
                ChangeColor(true);
            }
            else
            {
                access_token = token.Text;
                TestApi();
            }
        }
        string realfile = "";
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FPath.Text = OpenMP4.FileName;
            realfile = OpenMP4.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenMP4.ShowDialog();
        }

        private void GIDCheck(object sender, EventArgs e)
        {
            GID.Enabled = checkBox1.Checked;
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (File.Exists(FPath.Text))
            {
                string file = FPath.Text;
                if (Title.Text.Length > 1)
                {
                    param.Add("title", Title.Text);
                }
                if (Description.Text.Length > 1)
                {
                    param.Add("description", Description.Text);
                }
                if (checkBox1.Checked && GID.Text.Length > 2)
                {
                    param.Add("group_id", GID.Text);
                }
                param.Add("file_size", new FileInfo(file).Length.ToString());
                UploadClip(file, param);
            }
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string s = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (new FileInfo(s).Exists) if (new FileInfo(s).Extension == ".mp4") FPath.Text = s;
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (new FileInfo(((string[])e.Data.GetData(DataFormats.FileDrop, false))[0]).Extension == ".mp4")
                    e.Effect = DragDropEffects.All;
                else e.Effect = DragDropEffects.None;
            }
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
