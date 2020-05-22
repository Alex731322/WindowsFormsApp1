using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public class B : Button
        {
            public Form frnn;
            public void CreateMyButton(Button btn, Form frn, string str, int x, int y, int w, int h, EventHandler evh)
            {
                btn = new Button();
                btn.Text = str;
                btn.Location = new Point(x, y);
                btn.Size = new Size(w, h);
                btn.Click += evh;

                frn.Controls.Add(btn);
                frnn = frn;
            }
          
        }

        Button btn1;
        B b1 = new B();
        public Form2()
        {


            b1.CreateMyButton(btn1, this, "Play", 250, 50,  320, 50, Click_My_Button1);
            b1.CreateMyButton(btn1, this, "Info", 250, 150, 320, 50, Click_My_Button3);
            b1.CreateMyButton(btn1, this, "Exit", 250, 250, 320, 50, Click_My_Button2);
            InitializeComponent();
        }
        public void Click_My_Button1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }
        public void Click_My_Button2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Click_My_Button3(object sender, EventArgs e)
        {
            MessageBox.Show("Программа - Игра “2048”, сделано студентом группы Э-57 Данилюком Александром. В данной ире у геймплей заключается в передвижении плит " +
                "при помощи клавиш “вправо”, “влево”, “вниз”, “вверх”, в случае если ты заполнишь плитами все секции - ты проиграешь.GL HF :))) ");

        }
    }
}
