namespace VKClips
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.token = new System.Windows.Forms.TextBox();
            this.Execute = new System.Windows.Forms.Button();
            this.OpenMP4 = new System.Windows.Forms.OpenFileDialog();
            this.FPath = new System.Windows.Forms.TextBox();
            this.PathL = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.TextBox();
            this.TitleL = new System.Windows.Forms.Label();
            this.DescL = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.GroupL = new System.Windows.Forms.Label();
            this.GID = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.path = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.desc = new System.Windows.Forms.ColumnHeader();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.Add = new System.Windows.Forms.Button();
            this.Fade = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "VKClips";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Access token:";
            // 
            // token
            // 
            this.token.ForeColor = System.Drawing.SystemColors.ControlText;
            this.token.HideSelection = false;
            this.token.Location = new System.Drawing.Point(121, 90);
            this.token.MaxLength = 100;
            this.token.Name = "token";
            this.token.Size = new System.Drawing.Size(500, 23);
            this.token.TabIndex = 2;
            this.token.UseSystemPasswordChar = true;
            this.token.Enter += new System.EventHandler(this.token_Enter);
            this.token.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tokenInput);
            this.token.Leave += new System.EventHandler(this.CheckToken);
            // 
            // Execute
            // 
            this.Execute.Enabled = false;
            this.Execute.Location = new System.Drawing.Point(316, 236);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(305, 34);
            this.Execute.TabIndex = 3;
            this.Execute.Text = "Загрузить всё";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // OpenMP4
            // 
            this.OpenMP4.Filter = "Видео (*.mp4)|*.mp4";
            this.OpenMP4.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // FPath
            // 
            this.FPath.Location = new System.Drawing.Point(121, 120);
            this.FPath.Name = "FPath";
            this.FPath.Size = new System.Drawing.Size(164, 23);
            this.FPath.TabIndex = 4;
            // 
            // PathL
            // 
            this.PathL.AutoSize = true;
            this.PathL.Location = new System.Drawing.Point(38, 123);
            this.PathL.Name = "PathL";
            this.PathL.Size = new System.Drawing.Size(80, 15);
            this.PathL.TabIndex = 1;
            this.PathL.Text = "Путь к видео:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(284, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(121, 149);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(189, 23);
            this.Title.TabIndex = 6;
            // 
            // TitleL
            // 
            this.TitleL.AutoSize = true;
            this.TitleL.Location = new System.Drawing.Point(20, 152);
            this.TitleL.Name = "TitleL";
            this.TitleL.Size = new System.Drawing.Size(98, 15);
            this.TitleL.TabIndex = 7;
            this.TitleL.Text = "Название клипа:";
            // 
            // DescL
            // 
            this.DescL.AutoSize = true;
            this.DescL.Location = new System.Drawing.Point(17, 181);
            this.DescL.Name = "DescL";
            this.DescL.Size = new System.Drawing.Size(101, 15);
            this.DescL.TabIndex = 7;
            this.DescL.Text = "Описание клипа:";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(121, 178);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(189, 23);
            this.Description.TabIndex = 6;
            // 
            // GroupL
            // 
            this.GroupL.AutoSize = true;
            this.GroupL.Location = new System.Drawing.Point(53, 210);
            this.GroupL.Name = "GroupL";
            this.GroupL.Size = new System.Drawing.Size(65, 15);
            this.GroupL.TabIndex = 7;
            this.GroupL.Text = "ID группы:";
            // 
            // GID
            // 
            this.GID.Location = new System.Drawing.Point(121, 207);
            this.GID.Name = "GID";
            this.GID.Size = new System.Drawing.Size(189, 23);
            this.GID.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path,
            this.name,
            this.desc,
            this.id});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(316, 119);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(305, 111);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // path
            // 
            this.path.Name = "path";
            this.path.Text = "Путь";
            // 
            // name
            // 
            this.name.Name = "name";
            this.name.Text = "Имя";
            // 
            // desc
            // 
            this.desc.Name = "desc";
            this.desc.Text = "Описание";
            this.desc.Width = 100;
            // 
            // id
            // 
            this.id.Name = "id";
            this.id.Text = "ID группы";
            this.id.Width = 80;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(121, 236);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(189, 34);
            this.Add.TabIndex = 10;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.AddTask);
            // 
            // Fade
            // 
            this.Fade.Interval = 10;
            this.Fade.Tick += new System.EventHandler(this.Fade_Tick);
            // 
            // Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 282);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.GID);
            this.Controls.Add(this.GroupL);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.DescL);
            this.Controls.Add(this.TitleL);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PathL);
            this.Controls.Add(this.FPath);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.token);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "VKClips v1.1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox token;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.OpenFileDialog OpenMP4;
        private System.Windows.Forms.TextBox FPath;
        private System.Windows.Forms.Label PathL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label TitleL;
        private System.Windows.Forms.Label DescL;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label GroupL;
        private System.Windows.Forms.TextBox GID;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader desc;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Timer Fade;
    }
}

