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

        int size = 70;

        Point3 centr;

        public Form1()
        {
            InitializeComponent();
            lines = Hex(size);
            centr = new Point3(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
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

        public static double[,] MatrixMult(double[,] m1, double[,] m2)
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

            g.Clear(Color.White);
            List<Line> newlines = new List<Line>();
            foreach (var l in lines)
            {
                double[,] m = new double[1, 4];
                m[0, 0] = l.p1.X;
                m[0, 1] = l.p1.Y;
                m[0, 2] = l.p1.Z;
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

                var mr = MatrixMult(m, matrx);
                mr = MatrixMult(mr, matry);
                mr = MatrixMult(mr, matrz);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;
                
                var mr2 = MatrixMult(m, matrx);
                mr2 = MatrixMult(mr2, matry);
                mr2 = MatrixMult(mr2, matrz);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
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
            //centr.X += posx;
            //centr.Y += posy;
            //centr.Z += posz;
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
                {   { 1, 0, 0, 0},
                    { 0, 1, 0, 0 },
                    {0, 0, 1, 0 },
                    { -posx, -posy, -posz, 1 } };

                var mr = MatrixMult(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MatrixMult(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
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
                var posx = double.Parse(textBox9.Text);
                var posy = double.Parse(textBox8.Text);
                var posz = double.Parse(textBox7.Text);
                double[,] matr = new double[4, 4]
                {   { posx, 0, 0, 0 },
                    { 0, posy, 0, 0 },
                    { 0, 0, posz, 0 },
                    { 0, 0, 0, 1 } };

                var mr = MatrixMult(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MatrixMult(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
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

                var mr = MatrixMult(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MatrixMult(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
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

                var mr = MatrixMult(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MatrixMult(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
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

                var mr = MatrixMult(m, matr);

                m[0, 0] = l.p2.X;
                m[0, 1] = l.p2.Y;
                m[0, 2] = l.p2.Z;
                m[0, 3] = 1;

                var mr2 = MatrixMult(m, matr);

                newlines.Add(new Line(new Point3(mr[0, 0], mr[0, 1], mr[0, 2]), new Point3(mr2[0, 0], mr2[0, 1], mr2[0, 2])));

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            lines = newlines;
            pictureBox1.Image = bmp;
        }

       
    }
}
