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
            size /= 2;
            return new List<Line>
            {
                new Line(new Point3(-size, size, -size), new Point3(size, size, -size)), //1->2
                new Line(new Point3(-size, size, -size), new Point3(-size, -size, -size)), //1->4
                new Line(new Point3(-size, size, -size), new Point3(-size, size, size)), //1->5
                new Line(new Point3(-size, size, size), new Point3(size, size, size)), //5->6
                new Line(new Point3(-size, size, size), new Point3(-size, -size, size)), //5->8
                new Line(new Point3(-size, -size, size), new Point3(-size, -size, -size)), //8->4
                new Line(new Point3(-size, -size, -size), new Point3(size, -size, -size)), //4->3
                new Line(new Point3(size, -size, -size), new Point3(size, size, -size)), //3->2
                new Line(new Point3(size, -size, -size), new Point3(size, -size, size)), //3->7
                new Line(new Point3(size, size, -size), new Point3(size, size, size)), //2->6
                new Line(new Point3(size, size, size), new Point3(size, -size, size)), //6->7
                new Line(new Point3(size, -size, size), new Point3(-size, -size, size)), //7->8
            };
        }

        Point Position2d(Point3 p)
        {
            var centr = new Point3(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
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

        public Form1()
        {
            InitializeComponent();
            lines = Hex(size);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            lines = Hex(size);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DrawLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
            foreach (var l in lines)
            {
                double[,] m = new double[1, 4];
                m[0, 0] = l.p1.X;
                m[0, 1] = l.p1.Y;
                m[0, 2] = l.p1.Z;
                m[0, 3] = 1;
                var angle = double.Parse(textBox6.Text);
                double[,] matrx = new double[4, 4]
                {   { Math.Cos(angle), 0, Math.Sin(angle), 0},
                    { 0, 1, 0, 0 },
                    {-Math.Sin(angle), 0, Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 } };

                angle = double.Parse(textBox5.Text);
                double[,] matry = new double[4, 4]
                {  { 1, 0, 0, 0 },
                    { 0, Math.Cos(angle), -Math.Sin(angle), 0},
                    {0, Math.Sin(angle), Math.Cos(angle), 0 },
                    { 0, 0, 0, 1 } };

                angle = double.Parse(textBox4.Text);
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

                g.DrawLine(myPen, Position2d(new Point3((int)mr[0, 0], (int)mr[0, 1], (int)mr[0, 2])), Position2d(new Point3((int)mr2[0, 0], (int)mr2[0, 1], (int)mr2[0, 2])));
            }
            pictureBox1.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }
    }
}
