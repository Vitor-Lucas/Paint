using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;

namespace Paint
{
    public partial class Form1 : Form
    {

        int qtd_clicks = 0;
        int x0, y0, 
            x1, y1, 
            x2, y2,
            x3, y3,
            x4, y4,
            r,r_x,r_y,initial;

        
        

        String operation;
        String cor;
        String json;

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
            json = "{ \"Reta\": \"X1\", \"Y1\": “X2”,”Y2”:[" + x0 + "," + y0 + "," + x1 + "," + y1 + "] }";
        }
        
        void DrawPoint(PaintEventArgs e, Pen pen, int x, int y)
        {
            e.Graphics.DrawLine(pen, x, y, x+1, y);
            
        }

        void DrawArc(PaintEventArgs e, Pen pen, int x_center, int y_center, float radius, int initial_angle, int final_angle)
        {
            for (float thetha = initial_angle; thetha <= final_angle; thetha += 0.33f)
            {
                double theta_radians = thetha * Math.PI / 180;
                int x = (int)(x_center + radius * Math.Cos(theta_radians));
                int y = (int)(y_center + radius * Math.Sin(theta_radians));

                DrawPoint(e, pen, x, y);
            }

            json = "{ \"Circulo\": \"X_CENTER\", \"Y_CENTER\", “RADIUS” :[" + x_center + "," + y_center + "," + radius + "] }";
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

            json = "{ \"Elipse\": \"X_CENTER\", \"Y_CENTER\": “X_RAIO”,”Y_RAIO” : “INITIAL_ANGLE”,”FINAL_ANGLE”:[" + x_center + "," + y_center + ":" + radius_x + "," + radius_y + ":" + initial_angle + "," + final_angle + "] }";
        }

        void DrawRectangle(PaintEventArgs e, Pen pen, int x, int y, int width, int height)
        {
            e.Graphics.DrawRectangle(pen, x, y, width, height);
            json = "{ \"Retangulo\": \"X\", \"Y\": “WIDTH”,”HEIGHT”:[" + x + "," + y + "," + width + "," + height + "] }";
        }

        void DrawTriangle(PaintEventArgs e, Pen pen, int x0, int y0, int x1, int y1, int x2, int y2)
        {
            DrawLine(e, pen, x0, y0, x1, y1);
            DrawLine(e, pen, x1, y1, x2, y2);
            DrawLine(e, pen, x2, y2, x0, y0);

            json = "{ \"Triangulo\": \"X0\", \"Y0\": “X1”,”Y1”: “X2”,”Y2”[" + x0 + "," + y0 + "," + x1 + "," + y1 + "," + x2 + "," + y2 + "] }";
        }

        void DrawPentagon(PaintEventArgs e, Pen pen, int x0, int y0, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            DrawLine(e, pen, x0, y0, x1, y1);
            DrawLine(e, pen, x2, y2, x1, y1);
            DrawLine(e, pen, x2, y2, x3, y3);
            DrawLine(e, pen, x4, y4, x3, y3);
            DrawLine(e, pen, x4, y4, x0, y0);

            json = "{ \"Pentagono\": \"X0\", \"Y0\": “X1”,”Y1”: “X2”,”Y2” : “X3”,”Y3” : “X4”,”Y4”: [" + x0 + "," + y0 + "," + x1 + "," + y1 + "," + x2 + "," + y2 + "," + x3 + "," + y3 + "," + x4 + "," + y4 + "] }";
        }

        void DrawDiamond(PaintEventArgs e, Pen pen, int x0, int y0, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            DrawLine(e,pen, x0, y0, x1, y1);
            DrawLine(e,pen, x2, y2, x1, y1);
            DrawLine(e,pen, x3, y3, x2, y2);
            DrawLine(e,pen, x0, y0, x3, y3);

            json = "{ \"Diamond\": \"X0\", \"Y0\": “X1”,”Y1”: “X2”,”Y2” : “X3”,”Y3” : [" + x0 + "," + y0 + "," + x1 + "," + y1 + "," + x2 + "," + y2 + "," + x3 + "," + y3 + "] }";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            operation = "Draw Line";
            MessageBox.Show(button10.BackColor.ToString());
        }

        private void salvar_button_Click(object sender, EventArgs e)
        {
            String path = @"C:\Arquivos\dados.dat";
            StreamWriter arquivo = new StreamWriter(path);
            arquivo.WriteLine(json);
            arquivo.Close();
        }

        private void carregar_button_Click(object sender, EventArgs e)
        {
            StreamReader arquivo = new StreamReader(openFileDialog1.ShowDialog().ToString());
            MessageBox.Show(arquivo.ReadToEnd());
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            cor = "Green";
        }

        private void ColorsComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            cor = "Black";
        }

        private void pentagono_button_Click(object sender, EventArgs e)
        {
            operation = "Draw Pentagon";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String str = Interaction.InputBox("Digite o raio do circulo:", "", "");
            r = int.Parse(str);
            //MessageBox.Show(r.ToString());
            operation = "Draw circle";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String str = Interaction.InputBox("Digite o angulo inicial:", "", "");
            initial = int.Parse(str);

            String str_rx = Interaction.InputBox("Digite a altura da elipse:", "", "");
            r_x = int.Parse(str_rx);

            String str_ry = Interaction.InputBox("Digite o a largura da elipse:", "", "");
            r_y = int.Parse(str_ry);

            operation = "Draw Elipse";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            operation = "Draw Diamond";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            
            Pen pen = GetPen(0,0,0);
            switch (cor)
            {
                case "Black":
                    pen = GetPen(0,0,0); break;
                case "Green":
                    pen = GetPen(0, 255, 0); break;

            }

            switch (operation)
            {
                case "Draw Triangle":
                    DrawTriangle(e, pen, x0, y0, x1, y1, x2, y2); break;
                case "Draw Rectangle":
                    DrawRectangle(e, pen, x0, y0, (x1 - x0), (y1 - y0)); break;
                case "Draw circle":
                    DrawArc(e, pen, x0, y0, r, 0, 360); break;
                case "Draw elipse":
                    DrawArc(e, pen, x0, y0, r_x, r_y, initial, 360); break;
                case "Draw Line":
                    DrawLine(e, pen, x0, y0, x1, y1); break;
                case "Draw Diamond":
                    DrawDiamond(e, pen, x0, y0, x1, y1, x2, y2, x3, y3); break;
                case "Draw Pentagon":
                    DrawPentagon(e, pen, x0, y0, x1, y1, x2, y2, x3, y3, x4, y4); break;
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
            if(qtd_clicks == 5)
            {
                
                x4 = e.X; y4 = e.Y;
                if(operation == "Draw Pentagon")
                {
                    qtd_clicks = 0;
                    Invalidate();
                }
                
            }
            else if(qtd_clicks == 4)
            {
                x3 = e.X; y3 = e.Y;
                if(operation == "Draw Diamond")
                {
                    qtd_clicks = 0;
                    Invalidate();
                }
            }
            else if (qtd_clicks == 3)
            {
                x2 = e.X; y2 = e.Y;
                if (operation == "Draw Triangle")
                {
                    qtd_clicks = 0;
                    Invalidate();
                }                    
            }
            else if (qtd_clicks == 2)
            {
                x1 = e.X; y1 = e.Y;
                if (operation == "Draw Rectangle")
                {
                    qtd_clicks = 0;
                    Invalidate();

                }else if (operation == "Draw Line")
                {
                    qtd_clicks = 0;
                    Invalidate();
                }
                
                    
                
            }
            else if (qtd_clicks == 1)
            {
                x0 = e.X; y0 = e.Y;
                if(operation == "Draw circle")
                {
                    qtd_clicks = 0;
                    Invalidate();
                    
                }else if(operation == "Draw elipse")
                {
                    qtd_clicks = 0;
                    Invalidate();
                }
            }


        }
    }
}
