namespace Words
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.userWord = new System.Windows.Forms.TextBox();
            this.panelForButtons = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.creatingWords = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.WorkerUser = new System.ComponentModel.BackgroundWorker();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // userWord
            // 
            resources.ApplyResources(this.userWord, "userWord");
            this.userWord.ForeColor = System.Drawing.Color.Black;
            this.userWord.Name = "userWord";
            // 
            // panelForButtons
            // 
            resources.ApplyResources(this.panelForButtons, "panelForButtons");
            this.panelForButtons.Name = "panelForButtons";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(176)))), ((int)(((byte)(140)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.DeleteOneLetter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(176)))), ((int)(((byte)(140)))));
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.deleteAllWord);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(176)))), ((int)(((byte)(140)))));
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.addWord);
            // 
            // creatingWords
            // 
            resources.ApplyResources(this.creatingWords, "creatingWords");
            this.creatingWords.FormattingEnabled = true;
            this.creatingWords.Name = "creatingWords";
            this.creatingWords.Sorted = true;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file});
            resources.ApplyResources(this.menu, "menu");
            this.menu.Name = "menu";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit});
            this.file.Name = "file";
            resources.ApplyResources(this.file, "file");
            // 
            // exit
            // 
            this.exit.Name = "exit";
            resources.ApplyResources(this.exit, "exit");
            this.exit.Click += new System.EventHandler(this.exitClick);
            // 
            // Worker
            // 
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // WorkerUser
            // 
            this.WorkerUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerUser_DoWork);
            this.WorkerUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerUser_RunWorkerCompleted);
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.creatingWords);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelForButtons);
            this.Controls.Add(this.userWord);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userWord;
        private System.Windows.Forms.Panel panelForButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox creatingWords;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.ComponentModel.BackgroundWorker WorkerUser;
    }
}

