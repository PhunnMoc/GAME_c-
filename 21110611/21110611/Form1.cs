using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110611
{

    public partial class Form1 : Form
    {
        //Graphics gp;
        SolidBrush myBrush;
        Color myColor;
        Point pos;
        int r;
        //int way = 0;
        DateTime startTime;
        bool isSpace = true;
        bool isWalk = false;
        bool way = true;
        Image image;

        private void walk()
        {
            image = (Image)Properties.Resources.ResourceManager.GetObject("walk");
            charac.SizeMode = PictureBoxSizeMode.AutoSize;
            charac.Image = image;
        }
        private void fly()
        {
            image = (Image)Properties.Resources.ResourceManager.GetObject("kirbyfly11");
            charac.SizeMode = PictureBoxSizeMode.AutoSize;
            charac.Image = image;
        }
        private void stand()
        {
            image = (Image)Properties.Resources.ResourceManager.GetObject("standd");
            charac.SizeMode = PictureBoxSizeMode.AutoSize;
            charac.Image = image;
        }
        public Form1()
        {
            InitializeComponent();
            this.panel1.SetDoubleBuffered();
            //gp = this.panel1.CreateGraphics();
            /*myColor = Color.Blue;
            myBrush = new SolidBrush(myColor);*/
            Console.SetWindowSize(200, 200);
            walk();
            pos.X = 100;
            pos.Y = 100;
            r = 50;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            //e.Graphics.FillEllipse(myBrush, pos.X, pos.Y,r,r);
            charac.Location = pos;
            this.panel1.Focus();
        }


        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        /*if(isWalk==false)
                        {
                            walk();
                            isSpace= true;
                        }  */
                        way = false;
                        this.pos.X = this.pos.X - 5;
                    }
                    break;
                case Keys.Right:
                    {
                        /*if (isWalk == false)
                        {
                            walk();
                            isSpace = true;
                        }*/
                        way = true;
                        this.pos.X = this.pos.X + 5;
                    }
                    break;
                case Keys.Space:
                    {
                        fly();
                        if (this.isSpace)
                        {
                            startTime = DateTime.Now;
                            this.timer1.Interval = 1;
                            this.timer1.Start();
                            isSpace = false;
                        }
                    }
                    break;
                case Keys.Down:
                    this.pos.Y = this.pos.Y + 5;
                    break;
                case Keys.N:
                    if (this.r > 5)
                        this.r = this.r - 50;
                    break;
                case Keys.L:
                    this.r = this.r + 50;
                    break;
                case Keys.C:
                    if (this.myColor == Color.Blue)
                    {
                        this.myColor = Color.Red;
                        myBrush = new SolidBrush(myColor);
                    }

                    else
                    {
                        this.myColor = Color.Blue;
                        myBrush = new SolidBrush(myColor);
                    }
                    break;
                default:
                    break;
            }
            
            this.panel1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan time = DateTime.Now - startTime;
            //TimeSpan c = new TimeSpan(0, 0, 0, 0, 100);
            TimeSpan a = new TimeSpan( 0, 0, 0, 0, 1000);
            TimeSpan b = new TimeSpan(0, 0, 0, 0, 2000);
             if (time <= a) { 
               this.pos.Y = this.pos.Y - 10;
            }
            else if (time <= b) {
                this.pos.Y = this.pos.Y + 10;
            }
            
            else
            {
                
                walk();
                timer1.Stop();
                this.isSpace = true;
                
            }
            this.panel1.Refresh();



            /*if (way == 1)
            {
                
            }
            else
            {
                
            }
            this.panel1.Refresh();*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
