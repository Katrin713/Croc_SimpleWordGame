using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Words.DictUser;

namespace Words
{
    public partial class mainForm : Form
    {
        private YandexDict yd;

        private DictItem LongWord;
        private Storage storage;

        private Stack<Button> usingLetters;

        public mainForm()
        {
            InitializeComponent();

            yd = new YandexDict();
            usingLetters = new Stack<Button>();

            storage = new Storage();
            int max = storage.LongCount();
            LongWord = storage.GetLongWord(max);
        }
        
        private void mainForm_Load(object sender, EventArgs e)
        {
            int x = 2;
            foreach (Char el in LongWord.Word)
            {
                Button button = new Button();

                button.Text = el.ToString();
                button.Width = 32;
                button.Height = 32;
                button.BackColor = ColorTranslator.FromHtml("#1DB08C");
                button.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;

                button.Location = new Point(x, 05);
                x += 37;

                button.Click += clickOnLetter;

                panelForButtons.Controls.Add(button);

            }
        }

        private void clickOnLetter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = ColorTranslator.FromHtml("#46505B");
            userWord.Text += button.Text;
            button.Enabled = false;

            usingLetters.Push(button);
        }

        private void deleteAllWord(object sender, EventArgs e)
        {
            clearUserWord();
        }

        private void DeleteOneLetter(object sender, EventArgs e)
        {          
            try
            {
                Button button = usingLetters.Pop();
                button.Enabled = true;
                button.BackColor = ColorTranslator.FromHtml("#1DB08C");
                userWord.Text = userWord.Text.Substring(0, userWord.Text.Length - 1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Строка пустая", "Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void clearUserWord()
        {
            userWord.Text = "";
            for (int i = 0; i < panelForButtons.Controls.Count; i++)
                if (panelForButtons.Controls[i] is Button)
                {
                    panelForButtons.Controls[i].Enabled = true;
                    panelForButtons.Controls[i].BackColor = ColorTranslator.FromHtml("#1DB08C");
                }
        }
       
        private void addWord(object sender, EventArgs e)
        {
            if (Worker.IsBusy)
            {
                MessageBox.Show("Поиск слова в словаре!");
            }
            else
            {
                Worker.RunWorkerAsync();
            }
        }

        private void exitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = yd.Translate(userWord.Text);          
            }
            catch (Exception ex)
            {
                e.Result = ex;              
            }
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                if (((Exception)e.Result).Message == "Пустая стока")
                     MessageBox.Show(((Exception)e.Result).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    if (WorkerUser.IsBusy)
                {
                    MessageBox.Show("Поиск слова в словаре!");
                }
                    else
                    {
                        WorkerUser.RunWorkerAsync();
                    }
               
            }
            else
            {
                if (!creatingWords.Items.Contains(e.Result))
                {
                    creatingWords.Items.Add(e.Result);
                    clearUserWord();
                }
                else
                    MessageBox.Show("Слово уже добавлено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void WorkerUser_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = storage.GetWord(userWord.Text);
        }
        private void WorkerUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                DialogResult result = MessageBox.Show(
                "Добавить слово в словарь?", 
                "Слово не найдено в словаре",         
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
                );
                if (result == DialogResult.Yes)
                {
                    storage.AddItem(userWord.Text);
                    creatingWords.Items.Add(userWord.Text.ToLower());
                    clearUserWord();
                }
            }
            else
            {
                if (!creatingWords.Items.Contains(((DictItem)e.Result).Word.ToLower()))
                {
                    creatingWords.Items.Add(e.Result);
                    clearUserWord();
                }
                else
                    MessageBox.Show("Слово уже добавлено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
