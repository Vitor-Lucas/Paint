using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {

        int qtd_clicks = 0;
        int x0, y0, x1, y1, x2, y2;

        String operation;

        public Form1()
        {
            InitializeComponent();
        }
        Pen GetPen(int r, int g, int b)
        {
            Pen pen = new Pen(Color.FromArgb(r, g, b));
            //pen.DashPattern = pattern;

            return pen;
        }
        void DrawLine(PaintEventArgs e, Pen pen, int x0, int y0, int x1, int y1)
        {
            e.Graphics.DrawLine(pen, x0, y0, x1, y1);
        }
        
        void DrawPoint(PaintEventArgs e, Pen pen, int x, int y)
        {
            e.Graphics.DrawLine(pen, x, y, x+1, y);
        }

        void DrawArc(PaintEventArgs e, Pen pen, int x_center, int y_center, int radius, int initial_angle, int final_angle)
        {
            for(float thetha = initial_angle; thetha <= final_angle; thetha+= 0.33f)
            {
                double theta_radians = thetha * Math.PI / 180;
                int x = (int) (x_center + radius * Math.Cos(theta_radians));
                int y = (int) (y_center + radius * Math.Sin(theta_radians));

                DrawPoint(e, pen, x, y);
            }
        }

        void DrawArc(PaintEventArgs e, Pen pen, int x_center, int y_center, int radius_x, int radius_y, int initial_angle, int final_angle)
        {
            for (float thetha = initial_angle; thetha <= final_angle; thetha += 0.33f)
            {
                double theta_radians = thetha * Math.PI / 180;
                int x = (int)(x_center + radius_y * Math.Cos(theta_radians));
                int y = (int)(y_center + radius_x * Math.Sin(theta_radians));

                DrawPoint(e, pen, x, y);
            }
        }

        void DrawRectangle(PaintEventArgs e, Pen pen, int x, int y, int width, int height)
        {
            e.Graphics.DrawRectangle(pen, x, y, width, height);
        }

        void DrawTriangle(PaintEventArgs e, Pen pen, int x0, int y0, int x1, int y1, int x2, int y2)
        {
            DrawLine(e, pen, x0, y0, x1, y1);
            DrawLine(e, pen, x1, y1, x2, y2);
            DrawLine(e, pen, x2, y2, x0, y0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //operation = "Draw circle";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //operation = "Draw elipse";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //operation = "Draw losangle";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //operation = "Draw pentagono";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = GetPen(0, 0, 0);

           //DrawArc(e, pen, 100, 100, 100, 200, 0, 360);


            switch (operation)
            {
                case "Draw Triangle":
                    DrawTriangle(e, pen, x0, y0, x1, y1, x2, y2); break;
                case "Draw Rectangle":
                    DrawRectangle(e, pen, x0, y0, (x1 - x0), (y1 - y0)); break;
               /* case "Draw Circle":
                    DrawArc(e, pen, x0, y0, r,0,360); break;
                case "Draw elipse":
                    DrawArc(e, pen, x0, y0, r_x, r_y, 0, 360); break;
               case "Draw losangle":
                    DrawLosangle(); break;
               case "Draw pentagono":
                    DrawPentagono(); break;
                
                */


            }
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            operation = "Draw Triangle";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operation = "Draw Rectangle";
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            qtd_clicks++;
            if (qtd_clicks == 3)
            {
                qtd_clicks = 0;
                x2 = e.X; y2 = e.Y;
                if (operation == "Draw Triangle")
                    Invalidate();
                
                    
            }
            else if (qtd_clicks == 2)
            {
                x1 = e.X; y1 = e.Y;
                if (operation == "Draw Rectangle")
                {
                    qtd_clicks = 0;
                    Invalidate();
                }
                    
                
            }
            else if (qtd_clicks == 1)
            {
                x0 = e.X; y0 = e.Y;
                
            }

        }
    }
}
