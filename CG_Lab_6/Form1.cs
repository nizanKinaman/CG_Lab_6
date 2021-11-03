using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CG_Lab_6
{
    public partial class Form1 : Form
    {
        static Bitmap bmp = new Bitmap(800, 800);

        Graphics g = Graphics.FromImage(bmp);

        Pen myPen = new Pen(Color.Black);
        List<Line> lines;

        Line rotateLine;

        int size = 70;

        Point3 moving_point = new Point3(0, 0, 0);
        Point3 moving_point_line = new Point3(0, 0, 0);
        Point3 centr;

        public Form1()
        {
            InitializeComponent();
            lines = Hex(size);
            centr = new Point3(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            rotateLine = new Line(new Point3(0, 0, 0), new Point3(30, 30, 0));
        }
        public class Point3
        {
            public double X;
            public double Y;
            public double Z;

            public Point3() { X = 0; Y = 0; Z = 0; }

            public Point3(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }

        public class Line
        {
            public Point3 p1;
            public Point3 p2;

            public Line()
            {
                p1 = new Point3();
                p2 = new Point3();
            }

            public Line(Point3 p1, Point3 p2)
            {
                this.p1 = p1;
                this.p2 = p2;
            }
            
        }

        public List<Line> Hex(int size)
        {
            var hex_centr = size / 2;
            return new List<Line>
            {
                new Line(new Point3(-hex_centr, hex_centr, -hex_centr), new Point3(hex_centr, hex_centr, -hex_centr)), //1->2
                new Line(new Point3(-hex_centr, hex_centr, -hex_centr), new Point3(-hex_centr, -hex_centr, -hex_centr)), //1->4
                new Line(new Point3(-hex_centr, hex_centr, -hex_centr), new Point3(-hex_centr, hex_centr, hex_centr)), //1->5
                new Line(new Point3(-hex_centr, hex_centr, hex_centr), new Point3(hex_centr, hex_centr, hex_centr)), //5->6
                new Line(new Point3(-hex_centr, hex_centr, hex_centr), new Point3(-hex_centr, -hex_centr, hex_centr)), //5->8
                new Line(new Point3(-hex_centr, -hex_centr, hex_centr), new Point3(-hex_centr, -hex_centr, -hex_centr)), //8->4
                new Line(new Point3(-hex_centr, -hex_centr, -hex_centr), new Point3(hex_centr, -hex_centr, -hex_centr)), //4->3
                new Line(new Point3(hex_centr, -hex_centr, -hex_centr), new Point3(hex_centr, hex_centr, -hex_centr)), //3->2
                new Line(new Point3(hex_centr, -hex_centr, -hex_centr), new Point3(hex_centr, -hex_centr, hex_centr)), //3->7
                new Line(new Point3(hex_centr, hex_centr, -hex_centr), new Point3(hex_centr, hex_centr, hex_centr)), //2->6
                new Line(new Point3(hex_centr, hex_centr, hex_centr), new Point3(hex_centr, -hex_centr, hex_centr)), //6->7
                new Line(new Point3(hex_centr, -hex_centr, hex_centr), new Point3(-hex_centr, -hex_centr, hex_centr)) //7->8
            };
        }

        public List<Line> Tetr(int size)
        {
            var tetr_centr = size / 2;
            return new List<Line>
            {
                new Line(new Point3(-tetr_centr, tetr_centr, -tetr_centr), new Point3(-tetr_centr, -tetr_centr, tetr_centr)), //1->2
                new Line(new Point3(-tetr_centr, tetr_centr, -tetr_centr), new Point3(-tetr_centr, tetr_centr, tetr_centr)), //1->4
                new Line(new Point3(-tetr_centr, tetr_centr, -tetr_centr), new Point3(tetr_centr, tetr_centr, tetr_centr)), //1->3
                new Line(new Point3(-tetr_centr, -tetr_centr, tetr_centr), new Point3(-tetr_centr, tetr_centr, tetr_centr)), //2->4
                new Line(new Point3(-tetr_centr, -tetr_centr, tetr_centr), new Point3(tetr_centr, tetr_centr, tetr_centr)), //2->3
                new Line(new Point3(tetr_centr, tetr_centr, tetr_centr), new Point3(-tetr_centr, tetr_centr, tetr_centr)) //3->4
            };
        }

        public List<Line> Oct(int size)
        {
            var oct_centr = size / 2;
            return new List<Line>
            {
                new Line(new Point3(-oct_centr, 0, -oct_centr), new Point3(-oct_centr, 0, oct_centr)), //1->2
                new Line(new Point3(-oct_centr, 0, oct_centr), new Point3(oct_centr, 0, oct_centr)), //2->3
                new Line(new Point3(oct_centr, 0, oct_centr), new Point3(oct_centr, 0, -oct_centr)), //3->4
                new Line(new Point3(-oct_centr, 0, -oct_centr), new Point3(oct_centr, 0, -oct_centr)), //1->4
                new Line(new Point3(-oct_centr, 0, -oct_centr), new Point3(0, oct_centr, 0)), //1->5
                new Line(new Point3(-oct_centr, 0, oct_centr), new Point3(0, oct_centr, 0)), //2->5
                new Line(new Point3(oct_centr, 0, oct_centr), new Point3(0, oct_centr, 0)), //3->5
                new Line(new Point3(oct_centr, 0, -oct_centr), new Point3(0, oct_centr, 0)), //4->5
                new Line(new Point3(-oct_centr, 0, -oct_centr), new Point3(0, -oct_centr, 0)), //1->6
                new Line(new Point3(-oct_centr, 0, oct_centr), new Point3(0, -oct_centr, 0)), //2->6
                new Line(new Point3(oct_centr, 0, oct_centr), new Point3(0, -oct_centr, 0)), //3->6
                new Line(new Point3(oct_centr, 0, -oct_centr), new Point3(0, -oct_centr, 0)), //4->6
            };
        }
        

        Point Position2d(Point3 p)
        {  
            return new Point((int)p.X + (int)centr.X, (int)p.Y + (int)centr.Y);
        }

        public void DrawLine()
        {
            var lines = Hex(50);
            foreach (var l in lines)
                g.DrawLine(myPen, Position2d(l.p1), Position2d(l.p2));
            pictureBox1.Image = bmp;
        }

        public static double[,] MultiplyMatrix(double[,] m1, double[,] m2)
        {
            double[,] m = new double[1,4];

            for (int i = 0; i < 4; i++)
            {
                var temp = 0.0;
                for (int j = 0; j < 4; j++)
                {
                    temp += m1[0, j] * m2[j, i];
                }
                m[0, i] = temp;
            }
            return m;
        }

        

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                g.Clear(Color.White);
                lines = Tetr(size);
                foreach (var l in lines)
                    g.DrawLine(myPen, Position2d(l.p1), Position2d(l.p2));
                pictureBox1.Image = bmp;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                g.Clear(Color.White);
                lines = Hex(size);
                foreach (var l in lines)
                    g.DrawLine(myPen, Position2d(l.p1), Position2d(l.p2));
                pictureBox1.Image = bmp;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                g.Clear(Color.White);
                lines = Oct(size);
                foreach (var l in lines)
                    g.DrawLine(myPen, Position2d(l.p1), Position2d(l.p2));
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                if (!checkBox2.Checked)
                {
                    g.Clear(Color.White);
                    List<Line> newlines = new List<Line>();
                    foreach (var l in lines)
                    {
                        double[,] m = new double[1, 4];
                        m[0, 0] = l.p1.X - moving_point.X;
                        m[0, 1] = l.p1.Y - moving_point.Y;
                        m[0, 2] = l.p1.Z - moving_point.Z;
                        m[0, 3] = 1;
                        var angle = double.Parse(textBox6.Text) * Math.PI / 180;
                        double[,] matrx = new double[4, 4]
                        {   { Math.Cos(angle), 0, Math.Sin(angle), 0},
                    { 0, 1, 0, 0 },
                    {-Math.Sin(angle), 0, Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 } };

                        angle = double.Parse(textBox5.Text) * Math.PI / 180;
                        double[,] matry = new double[4, 4]
                        {  { 1, 0, 0, 0 },
                    { 0, Math.Cos(angle), -Math.Sin(angle), 0},
                    {0, Math.Sin(angle), Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 } };

                        angle = double.Parse(textBox4.Text) * Math.PI / 180;
                        double[,] matrz = new double[4, 4]
                        {  { Math.Cos(angle), -Math.Sin(angle), 0, 0},
                    { Math.Sin(angle), Math.Cos(angle), 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 } };

                        var mr = MultiplyMatrix(m, matrx);
                        mr = MultiplyMatrix(mr, matry);
                        mr = MultiplyMatrix(mr, matrz);

                        m[0, 0] = l.p2.X - moving_point.X;
                        m[0, 1] = l.p2.Y - moving_point.Y;
                        m[0, 2] = l.p2.Z - moving_point.Z;
                        m[0, 3] = 1;

                        var mr2 = MultiplyMatrix(m, matrx);
                        mr2 = MultiplyMatrix(mr2, matry);
                        mr2 = MultiplyMatrix(mr2, matrz);


                        newlines.Add(new Line(new Point3(mr[0, 0] + moving_point.X, mr[0, 1] + moving_point.Y, mr[0, 2] + moving_point.Z), new Point3(mr2[0, 0] + moving_point.X, mr2[0, 1] + moving_point.Y, mr2[0, 2] + moving_point.Z)));

                        //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0] + moving_point.X, (int)mr[0, 1] + moving_point.Y, (int)mr[0, 2] + moving_point.Z)), Position2d(new Point3((int)mr2[0, 0] + moving_point.X, (int)mr2[0, 1] + moving_point.Y, (int)mr2[0, 2] + moving_point.Z)));
                    }
                    lines = newlines;
                }
                else
                    RotateWithLine();
            }
            else
            {
                g.Clear(Color.White);
                double[,] m = new double[1, 4];
                m[0, 0] = rotateLine.p1.X - moving_point_line.X;
                m[0, 1] = rotateLine.p1.Y - moving_point_line.Y;
                m[0, 2] = rotateLine.p1.Z - moving_point_line.Z;
                m[0, 3] = 1;
                var angle = double.Parse(textBox6.Text) * Math.PI / 180;
                double[,] matrx = new double[4, 4]
                {   { Math.Cos(angle), 0, Math.Sin(angle), 0},
                    { 0, 1, 0, 0 },
                    {-Math.Sin(angle), 0, Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 } };

                angle = double.Parse(textBox5.Text) * Math.PI / 180;
                double[,] matry = new double[4, 4]
                {  { 1, 0, 0, 0 },
                    { 0, Math.Cos(angle), -Math.Sin(angle), 0},
                    {0, Math.Sin(angle), Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 } };

                angle = double.Parse(textBox4.Text) * Math.PI / 180;
                double[,] matrz = new double[4, 4]
                {  { Math.Cos(angle), -Math.Sin(angle), 0, 0},
                    { Math.Sin(angle), Math.Cos(angle), 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 } };

                var mr = MultiplyMatrix(m, matrx);
                mr = MultiplyMatrix(mr, matry);
                mr = MultiplyMatrix(mr, matrz);

                m[0, 0] = rotateLine.p2.X - moving_point_line.X;
                m[0, 1] = rotateLine.p2.Y - moving_point_line.Y;
                m[0, 2] = rotateLine.p2.Z - moving_point_line.Z;
                m[0, 3] = 1;

                var mr2 = MultiplyMatrix(m, matrx);
                mr2 = MultiplyMatrix(mr2, matry);
                mr2 = MultiplyMatrix(mr2, matrz);

                Line newline = new Line(new Point3(mr[0, 0] + moving_point_line.X, mr[0, 1] + moving_point_line.Y, mr[0, 2] + moving_point_line.Z), new Point3(mr2[0, 0] + moving_point_line.X, mr2[0, 1] + moving_point_line.Y, mr2[0, 2] + moving_point_line.Z));

                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0] + moving_point_line.X, (int)mr[0, 1] + moving_point_line.Y, (int)mr[0, 2] + moving_point_line.Z)), Position2d(new Point3((int)mr2[0, 0] + moving_point_line.X, (int)mr2[0, 1] + moving_point_line.Y, (int)mr2[0, 2] + moving_point_line.Z)));

                rotateLine = newline;
            }
            DrawAll();
            pictureBox1.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            var posx = double.Parse(textBox1.Text);
            var posy = double.Parse(textBox2.Text);
            var posz = double.Parse(textBox3.Text);
            

            if (!checkBox1.Checked)
            {
                g.Clear(Color.White);
                moving_point.X += posx;
                moving_point.Y -= posy;
                moving_point.Z += posz;
                List<Line> newlines = new List<Line>();
                foreach (var l in lines)
                {
                    double[,] m = new double[1, 4];
                    m[0, 0] = l.p1.X;
                    m[0, 1] = l.p1.Y;
                    m[0, 2] = l.p1.Z;
                    m[0, 3] = 1;

                    double[,] matr = new double[4, 4]
                    {   { 1, 0, 0, 0},
                    { 0, 1, 0, 0 },
                    {0, 0, 1, 0 },
                    { posx, -posy, posz, 1 } };

                    var mr = MultiplyMatrix(m, matr);

                    m[0, 0] = l.p2.X;
                    m[0, 1] = l.p2.Y;
                    m[0, 2] = l.p2.Z;
                    m[0, 3] = 1;

                    var mr2 = MultiplyMatrix(m, matr);

                    newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                    //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
                }
                lines = newlines;
            }
            else
            {
                g.Clear(Color.White);
                moving_point_line.X += posx;
                moving_point_line.Y -= posy;
                moving_point_line.Z += posz;
                double[,] m = new double[1, 4];
                m[0, 0] = rotateLine.p1.X;
                m[0, 1] = rotateLine.p1.Y;
                m[0, 2] = rotateLine.p1.Z;
                m[0, 3] = 1;


                double[,] matr = new double[4, 4]
                    {   { 1, 0, 0, 0},
                    { 0, 1, 0, 0 },
                    {0, 0, 1, 0 },
                    { posx, -posy, posz, 1 } };

                var mr = MultiplyMatrix(m, matr);

                m[0, 0] = rotateLine.p2.X;
                m[0, 1] = rotateLine.p2.Y;
                m[0, 2] = rotateLine.p2.Z;
                m[0, 3] = 1;

                var mr2 = MultiplyMatrix(m, matr);

                Line newline = new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2]));

                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));

                rotateLine = newline;

            }
            DrawAll();
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            List<Line> newlines = new List<Line>();
            foreach (var l in lines)
            {
                double[,] m = new double[1, 4];
                m[0, 0] = l.p1.X - moving_point.X;
                m[0, 1] = l.p1.Y - moving_point.Y;
                m[0, 2] = l.p1.Z - moving_point.Z;
                m[0, 3] = 1;
                var posx = double.Parse(textBox9.Text);
                var posy = double.Parse(textBox8.Text);
                var posz = double.Parse(textBox7.Text);
                double[,] matr = new double[4, 4]
                {   { posx, 0, 0, 0 },
                    { 0, posy, 0, 0 },
                    { 0, 0, posz, 0 },
                    { 0, 0, 0, 1 } };

                var mr = MultiplyMatrix(m, matr);

                m[0, 0] = l.p2.X - moving_point.X;
                m[0, 1] = l.p2.Y - moving_point.Y;
                m[0, 2] = l.p2.Z - moving_point.Z;
                m[0, 3] = 1;

                var mr2 = MultiplyMatrix(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0] + moving_point.X, mr[0, 1] + moving_point.Y, mr[0, 2] + moving_point.Z), new Point3(mr2[0, 0] + moving_point.X, mr2[0, 1] + moving_point.Y, mr2[0, 2] + moving_point.Z)));

                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0] + moving_point.X, (int)mr[0, 1] + moving_point.Y, (int)mr[0, 2] + moving_point.Z)), Position2d(new Point3((int)mr2[0, 0] + moving_point.X, (int)mr2[0, 1] + moving_point.Y, (int)mr2[0, 2] + moving_point.Z)));
            }
            lines = newlines;
            DrawAll();
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            List<Line> newlines = new List<Line>();
            foreach (var l in lines)
            {
                double[,] m = new double[1, 4];
                m[0, 0] = l.p1.X;
                m[0, 1] = l.p1.Y;
                m[0, 2] = l.p1.Z;
                m[0, 3] = 1;

                double[,] matr = new double[4, 4]
                {   { -1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 } };

                var mr = MultiplyMatrix(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MultiplyMatrix(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
            DrawAll();
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            List<Line> newlines = new List<Line>();
            foreach (var l in lines)
            {
                double[,] m = new double[1, 4];
                m[0, 0] = l.p1.X;
                m[0, 1] = l.p1.Y;
                m[0, 2] = l.p1.Z;
                m[0, 3] = 1;

                double[,] matr = new double[4, 4]
                {   { 1, 0, 0, 0 },
                    { 0, -1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 } };

                var mr = MultiplyMatrix(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MultiplyMatrix(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));
                
                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
            DrawAll();
            pictureBox1.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            List<Line> newlines = new List<Line>();
            foreach (var l in lines)
            {
                double[,] m = new double[1, 4];
                m[0, 0] = l.p1.X;
                m[0, 1] = l.p1.Y;
                m[0, 2] = l.p1.Z;
                m[0, 3] = 1;

                double[,] matr = new double[4, 4]
                {   { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, -1, 0 },
                    { 0, 0, 0, 1 } };

                var mr = MultiplyMatrix(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MultiplyMatrix(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));
                
                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
            DrawAll();
            pictureBox1.Image = bmp;
        }

        

        public void DrawRotateLine()
        {
            g.DrawLine(myPen, Position2d(rotateLine.p1), Position2d(rotateLine.p2));
            pictureBox1.Image = bmp;
        }

        public void RotateWithLine()
        {

            g.Clear(Color.White);
            List<Line> newlines = new List<Line>();
            foreach (var ll in lines)
            {
                double[,] mm = new double[1, 4];
                mm[0, 0] = ll.p1.X - moving_point.X;
                mm[0, 1] = ll.p1.Y - moving_point.Y;
                mm[0, 2] = ll.p1.Z - moving_point.Z;
                mm[0, 3] = 1;

                var angle = double.Parse(textBox6.Text) * Math.PI / 180;

                var p1 = rotateLine.p1;
                var p2 = rotateLine.p2;

                double l = (p2.X - p1.X) / Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
                double m = (p2.Y - p1.Y) / Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
                double n = (p2.Z - p1.Z) / Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));

                double[,] matr = new double[4, 4]
                    {   { l*l + Math.Cos(angle)*(1 - l*l), l*(1 - Math.Cos(angle))*m + n*Math.Sin(angle), l*(1 - Math.Cos(angle))*n - m*Math.Sin(angle), 0},
                    { l*(1 - Math.Cos(angle))*m - n * Math.Sin(angle), m*m + Math.Cos(angle)*(1 - m*m), m*(1 - Math.Cos(angle))*n + l*Math.Sin(angle), 0 },
                    {l*(1 - Math.Cos(angle))*n + m*Math.Sin(angle), m*(1 - Math.Cos(angle))*n - l*Math.Sin(angle), n*n + Math.Cos(angle)*(1 - n*n), 0 },
                    { 0, 0, 0, 1 } };

                var mr = MultiplyMatrix(mm, matr);

                mm[0, 0] = ll.p2.X - moving_point.X;
                mm[0, 1] = ll.p2.Y - moving_point.Y;
                mm[0, 2] = ll.p2.Z - moving_point.Z;
                mm[0, 3] = 1;

                var mr2 = MultiplyMatrix(mm, matr);
                newlines.Add(new Line(new Point3(mr[0, 0] + moving_point.X, mr[0, 1] + moving_point.Y, mr[0, 2] + moving_point.Z), new Point3(mr2[0, 0] + moving_point.X, mr2[0, 1] + moving_point.Y, mr2[0, 2] + moving_point.Z)));
                
                //g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0] + moving_point.X, (int)mr[0, 1] + moving_point.Y, (int)mr[0, 2] + moving_point.Z)), Position2d(new Point3((int)mr2[0, 0] + moving_point.X, (int)mr2[0, 1] + moving_point.Y, (int)mr2[0, 2] + moving_point.Z)));
            }
            
            lines = newlines;
            DrawAll();
            pictureBox1.Image = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DrawRotateLine();
        }
        public void DrawAll()
        {
            g.DrawLine(myPen, Position2d(rotateLine.p1), Position2d(rotateLine.p2));
            foreach (var line in lines)
            {
                g.DrawLine(myPen, Position2d(line.p1), Position2d(line.p2) );
            } 
        }
    }
}
