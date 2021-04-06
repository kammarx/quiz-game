using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Media;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
       
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        StreamReader sr = new StreamReader("Sample.txt");
       
        int i, r1, r2 = 0; // i - номер вопроса, связан с очками, r1, r2 - рандомные числа для рандомизации расположения ответов между кнопками
        int h = 0,numOfСlicks=0;
        int m = 8; // кол-во вопросов минус 1 , используется для рандомизации выдачи вопросов 
        int c = 1; // счетчик номера вопроса
        int imax = 9; // сколько всего вопросов 
        int timeLeft = 30; // Для таймера
        Random r = new Random(DateTime.Now.Millisecond); // подключаем рандом для r
        string[] q = { "5+1", "4+4", "5-2", "3*5", "6*7", "4*9", "144/12", "10^2", "2*2" }; // массив с вопросами
        string[] a1 = { "6", "8", "3", "15", "42", "36", "12", "100", "4" };   // массив правильных ответов
        string[] a2 = { "23", "33", "123", "17", "49", "22", "11", "1024", "5" };   // массив неправильных ответов
        string[] a3 = { "58", "31", "44", "21", "32", "51", "14", "1000", "6" };   // массив неправильных ответов

        void Endgame(int e)
        {
            if (e == 0)
                label1.Text = "конец игры";
            else
            {
                label2.Text = (c).ToString(); c++;
                label1.Text = "игра пройдена";
            }
            timeLeft = 0;
            label6.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
        private object Otvet(int o)     //запускается при нажатии кнопок
        {
            Button[] b1 = { button1, button2, button3 };
            if (c != imax) // проверка не кончились ли вопросы
            {
                if (b1[o].Text == a1[i]) // если выбран правильный ответ 
                {
                    timeLeft = 31;
                    label4.Text = "Вопрос №"; c++;
                    label5.Text = c.ToString();
                    label2.Text = (c - 1).ToString();
                    q[i] = q[m];  // на место i-ого вопроса записывается вопрос с конца, i-ый пропадает 
                    a1[i] = a1[m]; // то же самое с ответами
                    a2[i] = a2[m];
                    a3[i] = a3[m];
                    m--;
                    i = r.Next(0, m); // рандомизируем i от 0 до текущего m невключительно
                    label1.Text = q[i];
                    string[][] a = { a1, a2, a3 };
                    r1 = r.Next(0, 3);
                    r2 = r.Next(0, 2);
                    for (int j = 0; j < 3; j++)
                    {
                        b1[j].Text = a[(r1 == j) ? 2 : ++r2 % 2][i];
                    }
                }
                else
                    Endgame(0);
            }
            else
            {
                if (b1[o].Text == a1[i])
                    Endgame(1);
                else
                    Endgame(0);
            }
            return 0;
        }
        public Form2(Form1 f1)
        {
            InitializeComponent(); //  связь 1-ой и 2-ой форм
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            Button[] b = { button1, button2, button3 };
            label7.Text = h.ToString();
            string[][] a = { a1, a2, a3 };
            i = r.Next(0, m - 1); // рандомизируем i
            label1.Text = q[i];  // в надпись для вопроса записывается i-ый вопроc
            r1 = r.Next(0, 3);
            r2 = r.Next(0, 2);
            for (int j = 0; j < 3; j++)
            {
                b[j].Text = a[(r1 == j) ? 2 : ++r2 % 2][i];
            }
        }
        private void button4_Click(object sender, EventArgs e)

        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Otvet(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Otvet(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numOfСlicks++;
            SoundPlayer s = new SoundPlayer();
            s.SoundLocation = @".\Background_music.wav";
            if (numOfСlicks % 2 != 0) s.Stop();
            else s.PlayLooping();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Otvet(2);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                label6.Text = timeLeft + "";
            }
            else
            {
                timer1.Stop();
                Endgame(0);
            }
        }
    }
}

        
    

