using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
   [Serializable()]
    public class igra
    {
        public int[,] cifrovoe_pole;
        public int score;
        public int rang;
        public int X_start;
        public int Y_start;
        public int Rarmer_polq;

        public igra(int rang, int X_start, int Y_start, int Rarmer_polq)
        {
            this.rang = rang;
            this.X_start = X_start;
            this.Y_start = Y_start;
            this.Rarmer_polq = Rarmer_polq;
            this.cifrovoe_pole = new int[Rarmer_polq,Rarmer_polq];
          
            this.score = 0;

            this.cifrovoe_pole[0, 2] = 2;
            this.cifrovoe_pole[1, 2] = 2;
            this.cifrovoe_pole[2, 2] = 2;
            this.cifrovoe_pole[3, 2] = 2;
            this.cifrovoe_pole[4, 2] = 2;
            this.cifrovoe_pole[5, 2] = 2;

            this.cifrovoe_pole[1, 3] = 4;
            this.cifrovoe_pole[4, 3] = 2;
            
       
            


            Restart();
        }

        public void Analiz_pole_left()
        {

            for (int j = 0; j < rang; j++)
            {


                for (int k = 0; k < rang; k++)
                {
                    for (int i = rang - 2; i >= 0; i--)
                    {
                        if (cifrovoe_pole[i, j] > 0)
                        {
                            if (cifrovoe_pole[i + 1, j] == 0) { cifrovoe_pole[i + 1, j] = cifrovoe_pole[i, j]; cifrovoe_pole[i, j] = 0; }
                            if (cifrovoe_pole[i + 1, j] == cifrovoe_pole[i, j]) 
                            {
                                cifrovoe_pole[i + 1, j] = cifrovoe_pole[i + 1, j] + cifrovoe_pole[i, j];
                               
                                cifrovoe_pole[i, j] = 0;

                                score += cifrovoe_pole[i + 1, j];

                            }


                        }
                    }
                }
            }
        }

        public void Analiz_pole_right()
        {

            for (int j = 0; j < rang; j++)
            {
                for (int k = 0; k < rang; k++)
                {
                    for (int i = 1; i < rang; i++)
                    {
                        if (cifrovoe_pole[i, j] > 0)
                        {
                            if (cifrovoe_pole[i - 1, j] == 0) { cifrovoe_pole[i - 1, j] = cifrovoe_pole[i, j]; cifrovoe_pole[i, j] = 0; }
                            if (cifrovoe_pole[i - 1, j] == cifrovoe_pole[i, j])
                            {
                                cifrovoe_pole[i - 1, j] = cifrovoe_pole[i - 1, j] + cifrovoe_pole[i, j]; 
                                cifrovoe_pole[i, j] = 0;
                                score += cifrovoe_pole[i - 1, j];
                            }


                        }
                    }
                }
            }
        }
        public void Analiz_pole_up()
        {

            for (int i = 0; i < rang; i++)
            {
                for (int k = 0; k < rang; k++)
                {
                    for (int j = 1; j < rang; j++)
                    {
                        if (cifrovoe_pole[i, j] > 0)
                        {
                            if (cifrovoe_pole[i , j - 1] == 0) { cifrovoe_pole[i, j - 1] = cifrovoe_pole[i, j]; cifrovoe_pole[i, j] = 0; }
                            if (cifrovoe_pole[i , j - 1] == cifrovoe_pole[i, j]) 
                            {
                                cifrovoe_pole[i, j - 1] = cifrovoe_pole[i, j - 1] + cifrovoe_pole[i, j];
                                cifrovoe_pole[i, j] = 0;
                                score += cifrovoe_pole[i , j-1];
                            }


                        }
                    }
                }
            }
        }

        public void Analiz_pole_down()
        {

            for (int i = 0; i < rang; i++)
            {
                for (int k = 0; k < rang; k++)
                {
                   for (int j = rang - 2; j >= 0; j--)
                    {
                        if (cifrovoe_pole[i, j] > 0)
                        {
                            if (cifrovoe_pole[i, j + 1] == 0) { cifrovoe_pole[i, j + 1] = cifrovoe_pole[i, j]; cifrovoe_pole[i, j] = 0; }
                           
                            if (cifrovoe_pole[i, j + 1] == cifrovoe_pole[i, j]) 
                            { 
                                cifrovoe_pole[i, j + 1] = cifrovoe_pole[i, j + 1] + cifrovoe_pole[i, j]; 
                                cifrovoe_pole[i, j] = 0;
                                score += cifrovoe_pole[i , j + 1];
                            }


                        }
                    }
                }
            }
        }



        public void Restart()
        {
            for (int j = 0; j < rang; j++) for (int i = 0; i < rang; i++) cifrovoe_pole[i, j] = 0;
             for (int i = 0; i < rang - 3; i++) Random_pole();
        }


        public int Random_pole()
        {
            Random rand = new Random();
            int rnd = rand.Next(0, rang * rang-1);
            
            for (int i = rnd; i < rang * rang; i++)
            {
                int stroka = i / rang;
                int stolbec = i % rang;
                if (cifrovoe_pole[stroka, stolbec] == 0)
                {
                    cifrovoe_pole[stroka, stolbec] = 2;
                    return 0;
                }
            }
            for (int i = rnd; i >= 0; i--)
            {
                int stroka = i / rang;
                int stolbec = i % rang;
                if (cifrovoe_pole[stroka, stolbec] == 0)
                {
                    cifrovoe_pole[stroka, stolbec] = 2;
                    return 0;
                }
            }


            return 1;
        }

        public void Draw_pole(PaintEventArgs e)
        {







           Brush[] m_backBrush;
            m_backBrush = new Brush[10];
            m_backBrush[0] = new SolidBrush(Color.FromArgb(250, 0, 0));
            m_backBrush[1] = new SolidBrush(Color.FromArgb(0, 250, 0));
            m_backBrush[2] = new SolidBrush(Color.FromArgb(0, 0, 250));
            m_backBrush[3] = new SolidBrush(Color.FromArgb(120, 0, 0));
            m_backBrush[4] = new SolidBrush(Color.FromArgb(0, 120, 0));
            m_backBrush[5] = new SolidBrush(Color.FromArgb(0, 0, 120));
            m_backBrush[6] = new SolidBrush(Color.FromArgb(60, 0, 0));
            m_backBrush[7] = new SolidBrush(Color.FromArgb(0, 60, 0));
            m_backBrush[8] = new SolidBrush(Color.FromArgb(0, 0, 60));





            Graphics dc = e.Graphics;
            Pen BluePen = new Pen(Color.Blue, 3);
            SolidBrush S = new SolidBrush(Color.Black);


            int H_srift = Rarmer_polq / 4;

            for (int i = 0; i < rang; i++)
            {
                    for (int j = 0; j < rang; j++)
                    {

                    int cvet = 0;
                    if (this.cifrovoe_pole[i, j] == 4)   cvet = 1;
                    if (this.cifrovoe_pole[i, j] == 8)   cvet = 2;
                    if (this.cifrovoe_pole[i, j] == 16)  cvet = 3;
                    if (this.cifrovoe_pole[i, j] == 32)  cvet = 4;
                    if (this.cifrovoe_pole[i, j] == 64)  cvet = 5;
                    if (this.cifrovoe_pole[i, j] == 128) cvet = 6;
                    if (this.cifrovoe_pole[i, j] == 256) cvet = 7;
                    if (this.cifrovoe_pole[i, j] == 512) cvet = 8;

                    if (this.cifrovoe_pole[i, j] > 0) dc.FillRectangle(m_backBrush[cvet], X_start + i * Rarmer_polq, Y_start + j * Rarmer_polq, Rarmer_polq, Rarmer_polq);

                        dc.DrawRectangle(BluePen, X_start + i * Rarmer_polq, Y_start + j * Rarmer_polq, Rarmer_polq, Rarmer_polq);

                        if (this.cifrovoe_pole[i, j] > 0)
                        {
                        int count_cifry = 1;
                        if (this.cifrovoe_pole[i, j] > 10) count_cifry = 2;
                        if (this.cifrovoe_pole[i, j] > 100) count_cifry = 3;

                        dc.DrawString(this.cifrovoe_pole[i, j].ToString(), new Font("Times New Roman", H_srift, FontStyle.Regular), S,
                            new PointF(X_start + i * Rarmer_polq + (Rarmer_polq - count_cifry * H_srift) / 2, Y_start + j * Rarmer_polq + (Rarmer_polq - H_srift) / 2));
                        dc.DrawString("Score: " + this.score.ToString(), new Font("Times New Roman", H_srift, FontStyle.Regular), S,
                            new PointF(X_start+20, Y_start - 30));
                    }
                    }


            }
        }

        }
    

    public partial class Form1 : Form
    {


      
      
        igra Igrushka1;

       List<igra> Igrushka = null;
        
        
        public Form1()
        {




            Igrushka = new List<igra>()
            {
               new igra(4, 100, 100, 50),
             
            };

          //  Igrushka.Clear();

           // Stream str;
           // str = File.OpenRead("kek.txt");
           // var deserialzer = new BinaryFormatter();
         //   Igrushka = deserialzer.Deserialize(str) as List<igra>;
          //  str.Close();

            //  Igrushka = new igra(4, 100, 100, 50);
            InitializeComponent();
        }

      
        protected override void OnKeyDown(KeyEventArgs e)
        {
            int kk = e.KeyValue;
            if (e.KeyValue == 39) foreach (var ij in Igrushka) ij.Analiz_pole_left();
            if (e.KeyValue == 37) foreach (var ij in Igrushka) ij.Analiz_pole_right();

            if (e.KeyValue == 38) foreach (var ij in Igrushka) ij.Analiz_pole_up();
            if (e.KeyValue == 40) foreach (var ij in Igrushka) ij.Analiz_pole_down();

            int end_game = 0 ; 

            if (e.KeyValue >= 37 && e.KeyValue <= 40) {
              foreach(var ig in Igrushka) end_game  = ig.Random_pole() ;
                
                if(end_game == 1)
                {

                    MessageBox.Show("Игра" +
                        " закончена");
                    foreach(var ig in Igrushka) ig.Restart();
 
                }
                
                this.Invalidate();
        }




            base.OnKeyDown(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
           foreach(var ig in Igrushka) ig.Draw_pole(e);

            base.OnPaint(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
          
            Stream str;
            str = File.OpenWrite("kek.txt");
            var serialzer = new BinaryFormatter();
            serialzer.Serialize(str, Igrushka);

            str.Close();


        }

     





    }







}
