using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace VKClips
{
    public partial class Form : System.Windows.Forms.Form
    {
        string access_token = "";
        int ticks = 0;
        Color start;
        Color end;
        double offR;
        double offG;
        double offB;
        public Form()
        {
            InitializeComponent();
        }
        private string UploadApi(Dictionary<string, string> param = null)
        {
            param ??= new Dictionary<string, string>();
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Safari/537.36");
            webClient.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            webClient.QueryString.Add("v", "5.130");
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
            string uploadURL = "";
            try
            {
                uploadURL = jObject.SelectToken("$.response.upload_url").Value<string>();
            }
            catch (Exception)
            {
                int error = jObject.SelectToken("$.error.error_code").Value<int>();
                switch (error)
                {
                    case 15:
                        MessageBox.Show("Ошибка доступа.");
                        break;
                    default:
                        MessageBox.Show("Неизвестная ошибка: " + jObject.SelectToken("$.error").Value<string>());
                        break;
                }
                return;
            }
            WebClient webClient = new WebClient();
            webClient.UploadFile(uploadURL, file);
        }
        private void TestApi()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Safari/537.36");
            webClient.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            webClient.QueryString.Add("v", "5.130");
            webClient.QueryString.Add("access_token", access_token);
            ChangeColor(!webClient.DownloadString("https://api.vk.com/method/execute").Contains("{\"response\":null}"));

        }
        private void tokenInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
        private void ChangeColor(bool test)
        {
            if (test)
            {
                start = token.BackColor;
                end = Color.Red;
                offR = (double)(start.R - end.R) / 50;
                offG = (double)(start.G - end.G) / 50;
                offB = (double)(start.B - end.B) / 50;
                ticks = 0;
                Execute.Enabled = false;
                Fade.Enabled = true;
            }
            else { token.BackColor = Color.White; Execute.Enabled = true; }
        }

        private void CheckToken(object sender, EventArgs e)
        {
            if (token.TextLength != 85)
            {
                ChangeColor(true);
            }
            else
            {
                access_token = token.Text;
                TestApi();
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FPath.Text = OpenMP4.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenMP4.ShowDialog();
        }
        private void Execute_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                if (File.Exists(item.SubItems[0].Text))
                {
                    string file = item.SubItems[0].Text;
                    if (item.SubItems.ContainsKey("title"))
                    {
                        param.Add("title", item.SubItems["title"].Text);
                    }
                    if (item.SubItems.ContainsKey("title"))
                    {
                        param.Add("description", item.SubItems["title"].Text);
                    }
                    if (item.SubItems.ContainsKey("title"))
                    {
                        param.Add("group_id", item.SubItems["title"].Text);
                    }
                    param.Add("file_size", new FileInfo(file).Length.ToString());
                    UploadClip(file, param);
                    listView1.Items.Remove(item);
                }
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

        private void AddTask(object sender, EventArgs e)
        {
            if (File.Exists(FPath.Text))
            {
                ListViewItem item = new ListViewItem(FPath.Text);
                var b = new ListViewItem.ListViewSubItem();
                var c = new ListViewItem.ListViewSubItem();
                var d = new ListViewItem.ListViewSubItem();
                b.Name = "title";
                b.Text = Title.Text;
                item.SubItems.Add(b);
                c.Name = "desc";
                c.Text = Description.Text;
                item.SubItems.Add(c);
                d.Name = "gid";
                d.Text = GID.Text;
                item.SubItems.Add(d);
                listView1.Items.Add(item);
            }
        }

        private void token_Enter(object sender, EventArgs e)
        {
            if (ticks == 100)
            {
                start = Color.Red;
                end = Color.White;
                offR = (double)(start.R - end.R) / 50;
                offG = (double)(start.G - end.G) / 50;
                offB = (double)(start.B - end.B) / 50;
                ticks = 0;
                Fade.Enabled = true;
            }
        }

        private void Fade_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks == 100)
            {
                token.BackColor = end;
                Fade.Enabled = false;
            }
            else if (ticks <= 50)
            {
                token.BackColor = Color.FromArgb(255,
                    (byte)(start.R - Math.Truncate(offR * ticks)),
                    (byte)(start.G - Math.Truncate(offG * ticks)),
                    (byte)(start.B - Math.Truncate(offB * ticks)));
            }
        }

        private void listView1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                    e.Handled = true;
                }
            }
        }
    }
}
