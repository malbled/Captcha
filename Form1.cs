using Captcha.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Captcha
{
    public partial class Form1 : Form
    {
        public int id;
        public FileInfo fileInfo;
        public Random rnd;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            id = rnd.Next(0, pathFiles.Length);
            picBox.Image = new Bitmap(pathFiles[id]);
            fileInfo = new FileInfo(pathFiles[id]);


        }

        string[] pathFiles = Directory.GetFiles("../../Res/", "*.png", SearchOption.AllDirectories);

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassw.UseSystemPasswordChar = true;
        }


        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtLogin.Text = System.Text.RegularExpressions.Regex.Replace
                            (txtLogin.Text, @"[^a-zA-Z]", "");
        }


        private void button_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" &&
                txtPassw.Text != "" &&
                txtLogin.Text != "" &&
                txtLogin.TextLength >= 4 &&
                txtCaptcha.Text == Convert.ToString(fileInfo.Name.Replace(".png", "")))
            {
                id = rnd.Next(0, pathFiles.Length);
                picBox.Image = new Bitmap(pathFiles[id]);
                fileInfo = new FileInfo(pathFiles[id]);
                txtCaptcha.Text = "";
                txtLogin.Text = "";
                txtName.Text = "";
                txtPassw.Text = "";

                MessageBox.Show(
            "Спасибо за регистрацию на сайте ☺",
            "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            if (txtLogin.TextLength <= 4)
            {
                MessageBox.Show(
                           "Логин должен содержать более 4х символов",
                           "!!!",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show(
                           "Заполните все поля",
                           "!!!",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassw.PasswordChar == '●')
            {
                txtPassw.UseSystemPasswordChar = false;
                button1.Image = Image.FromFile("C:/Users/leksa/OneDrive/Документы/3 КУРС/МДК 02.01 Силахина/Captcha/Resources/close.png");
            }
            else
            {
                button1.Image = Image.FromFile("C:/Users/leksa/OneDrive/Документы/3 КУРС/МДК 02.01 Силахина/Captcha/Resources/open.png");
                txtPassw.UseSystemPasswordChar = true;
            }

        }


    }
}