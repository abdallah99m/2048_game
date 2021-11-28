using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_ptoject
{
    public class CActor
    {
        public int X, Y;
        public int W, H,j,total,ct;
        public Color clr;
        public List<Bitmap> imgs;
        public Rectangle rcSrc;
        public Rectangle rcDst;

    }
    public partial class Form1 : Form
    {
        List<CActor> L = new List<CActor>();
        int ct = 0;
        Bitmap off;
        const int N = 4;
        CActor[,] B = new CActor[N, N];
        CActor[,] c = new CActor[N, N];
        Random rr = new Random();
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > L[0].X && e.X < L[0].X + L[0].imgs[0].Width && e.Y > L[0].Y && e.Y < L[0].Y + L[0].imgs[0].Height)
            {
                ct = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        B[i, j].j = 0;
                        B[i, j].total = 0;
                    }
                }
                int row = rr.Next(0, 4);
                int column = rr.Next(0, 4);
                B[row, column].j = 1;
                B[row, column].total = 2;
                int row1;
                int column1;
                while (true)
                {
                     row1 = rr.Next(0, 4);
                     column1 = rr.Next(0, 4);
                    if(row1!=row||column!=column)
                    { break;
                    }
                        
                }
                B[row1, column1].j = 1;
                B[row1, column1].total = 2;

            }

            if (e.X > L[1].X && e.X < L[1].X + L[1].imgs[0].Width && e.Y > L[1].Y && e.Y < L[1].Y + L[1].imgs[0].Height)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        B[i, j].Y = c[i, j].Y;
                        B[i, j].X = c[i, j].X;
                        B[i, j].W = c[i, j].W;
                        B[i, j].H = c[i, j].H;
                        B[i, j].j = c[i, j].j;
                        B[i, j].total = c[i, j].total;
                        B[i, j].rcDst = c[i, j].rcDst;
                        B[i, j].rcSrc = c[i, j].rcSrc;

                    }
                }
                ct = c[1, 1].ct;
            }

                DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                { c[i, j].X = B[i, j].X;
                    c[i, j].Y = B[i, j].Y;
                    c[i, j].W = B[i, j].W;
                    c[i, j].H = B[i, j].H;
                    c[i, j].j = B[i, j].j;
                    c[i, j].total = B[i, j].total;
                    c[i, j].rcDst = B[i, j].rcDst;
                    c[i, j].rcSrc = B[i, j].rcSrc;
                    c[i, j].ct = ct;
                   
                }
            }
            if (e.KeyCode == Keys.Right)
            {  /////////adddddddddddddddd//////
                for (int r = 0; r < 4; r++)
                {
                    for (int c = 2; c >= 0; c--)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r, c + 1].j)
                            {
                                B[r, c + 1].j += 1;
                                B[r, c].j = 0;
                                B[r, c + 1].total *= 2;
                                ct += B[r, c + 1].total;
                                B[r, c].total = 0;
                            }


                        }
                    }
                }
                /////move/////

                for (int r = 0; r < 4; r++)
                {
                    for (int c = 2; c >= 0; c--)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;

                            for (int c1 = c + 1; c1 < 4; c1++)
                            {
                                if (B[r, c1].j == 0)
                                {
                                    row = r;
                                    column = c1;
                                }
                            }
                            if (column != c)
                            {
                                B[row, column].j = B[r, c].j;
                                B[r, c].j = 0;
                                B[row, column].total = B[r, c].total;
                                B[r, c].total = 0;


                            }
                        }
                    }
                }
                /////////adddddddddddddddd//////
                for (int r = 0; r < 4; r++)
                {
                    for (int c = 2; c >= 0; c--)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r, c + 1].j)
                            {
                                B[r, c + 1].j += 1;
                                B[r, c].j = 0;
                                B[r, c + 1].total *= 2;
                                ct += B[r, c + 1].total;

                                B[r, c].total = 0;
                            }


                        }
                    }
                }

            }

            if (e.KeyCode == Keys.Left)
            {  ////////addddddddddddddd/////////////
                for (int r = 0; r < 4; r++)
                {
                    for (int c = 1; c < 4; c++)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r, c - 1].j)
                            {
                                B[r, c - 1].j += 1;
                                B[r, c].j = 0;
                                B[r, c - 1].total *= 2;
                                ct += B[r, c - 1].total;

                                B[r, c].total = 0;
                            }

                        }
                    }
                }
                /////////move//////////////
                for (int r = 0; r < 4; r++)
                {
                    for (int c = 1; c < 4; c++)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;

                            for (int c1 = c - 1; c1 > -1; c1--)
                            {
                                if (B[r, c1].j == 0)
                                {
                                    row = r;
                                    column = c1;
                                }
                            }
                            if (column != c)
                            {
                                B[row, column].j = B[r, c].j;
                                B[r, c].j = 0;
                                B[row, column].total = B[r, c].total;
                                B[r, c].total = 0;
                            }

                        }
                    }
                }
                ////////addddddddddddddd/////////////
                for (int r = 0; r < 4; r++)
                {
                    for (int c = 1; c < 4; c++)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r, c - 1].j)
                            {
                                B[r, c - 1].j += 1;
                                B[r, c].j = 0;
                                B[r, c - 1].total *= 2;
                                ct += B[r, c - 1].total;

                                B[r, c].total = 0;
                            }

                        }
                    }
                }


            }


            if (e.KeyCode == Keys.Down)
            { ///////////////adddddddddddddddd/////////////////
                for (int c = 0; c < 4; c++)
                {
                    for (int r = 2; r >= 0; r--)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r + 1, c].j)
                            {
                                B[r + 1, c].j += 1;
                                B[r, c].j = 0;
                                B[r + 1, c].total *= 2;
                                ct += B[r+1, c].total;

                                B[r, c].total = 0;
                            }

                        }
                    }
                }
                for (int c = 0; c < 4; c++)
                {
                    for (int r = 2; r >= 0; r--)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;

                            for (int r1 = r + 1; r1 < 4; r1++)
                            {
                                if (B[r1, c].j == 0)
                                {
                                    row = r1;
                                    column = c;
                                }
                            }
                            if (row != r)
                            {
                                B[row, column].j = B[r, c].j;
                                B[r, c].j = 0;
                                B[row, column].total = B[r, c].total;
                                B[r, c].total = 0;
                            }

                        }
                    }
                }

                ///////////////adddddddddddddddd/////////////////
                for (int c = 0; c < 4; c++)
                {
                    for (int r = 2; r >= 0; r--)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r + 1, c].j)
                            {
                                B[r + 1, c].j += 1;
                                B[r, c].j = 0;
                                B[r + 1, c].total *= 2;
                                ct += B[r+1, c ].total;

                                B[r, c].total = 0;
                            }

                        }
                    }
                }
            }



            if (e.KeyCode == Keys.Up)
            { /////////addddddddddddddd/////////
                for (int c = 0; c < 4; c++)
                {
                    for (int r = 1; r < 4; r++)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r - 1, c].j)
                            {
                                B[r - 1, c].j += 1;
                                B[r, c].j = 0;
                                B[r - 1, c].total *= 2;
                                ct += B[r-1, c ].total;

                                B[r, c].total = 0;
                            }
                        }
                    }
                }
                for (int c = 0; c < 4; c++)
                {
                    for (int r = 1; r < 4; r++)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;

                            for (int r1 = r - 1; r1 >= 0; r1--)
                            {
                                if (B[r1, c].j == 0)
                                {
                                    row = r1;
                                    column = c;
                                }
                            }
                            if (row != r)
                            {
                                B[row, column].j = B[r, c].j;
                                B[r, c].j = 0;
                                B[row, column].total = B[r, c].total;
                                B[r, c].total = 0;
                            }

                        }
                    }
                }

                /////////addddddddddddddd/////////
                for (int c = 0; c < 4; c++)
                {
                    for (int r = 1; r < 4; r++)
                    {
                        if (B[r, c].j != 0)
                        {
                            int row = r;
                            int column = c;
                            if (B[r, c].j == B[r - 1, c].j)
                            {
                                B[r - 1, c].j += 1;
                                B[r, c].j = 0;
                                B[r - 1, c].total *= 2;
                                ct += B[r-1, c ].total;

                                B[r, c].total = 0;
                            }
                        }
                    }
                }
            }


            while (true)
            {
                Random rr = new Random();
                int row1 = rr.Next(0, 4);
                int column1 = rr.Next(0, 4);
                int flage = 0;
                for (int r = 0; r < 4; r++)
                {
                    for (int c = 0; c < 4; c++)
                    {
                        if (B[row1, column1].j != 0)
                        { flage = 1; }

                    }
                }
                if (flage == 0)
                {
                    B[row1, column1].j = 1;
                    B[row1, column1].total = 2;
                    break;
                }

            }


            DrawDubb(this.CreateGraphics());


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            Create();
            DrawDubb(this.CreateGraphics());
        }
        CActor pnn;
        Bitmap z;
        void Create()
        {
            int ax = 50;
            int ay = 50;
            int j;
            Random RR = new Random();
           
            for (int r = 0; r < N; r++)
            {
                ax = 50;
                for (int c = 0; c < N; c++)
                {
                     pnn = new CActor();
                    pnn.X = ax;
                    pnn.Y = ay;
                    pnn.W = 50;
                    pnn.H = 50;
                    pnn.imgs = new List<Bitmap>();
                    int a = 0;
                    for (int i = 0; i < 14; i++)
                    {
                         z = new Bitmap(a + ".jpg");
                        pnn.imgs.Add(z);
                        z.MakeTransparent(z.GetPixel(0, 0));
                        if (i == 0)
                        { a = 2; }
                        else { a *= 2;
                        }
                    }
                    pnn.j = 0;
                    pnn.total = 0;
                    pnn.rcSrc = new Rectangle(0, 0, pnn.imgs[0].Width, pnn.imgs[0].Height);
                    pnn.rcDst = new Rectangle(ax, ay, 50, 50);

                    ax += pnn.W;
                    B[r, c] = pnn;
                }
                ay += 50;
            }
            for (int i = 0; i < N; i++)
            {
                ax = 50;
                for (int x = 0; x < N; x++)
                {
                    pnn = new CActor();
                    pnn.X = ax;
                    pnn.Y = ay;
                    pnn.W = 50;
                    pnn.H = 50;
                    pnn.imgs = new List<Bitmap>();
                    int a = 0;
                    for (int k = 0; k < 14; k++)
                    {
                        z = new Bitmap(a + ".jpg");
                        pnn.imgs.Add(z);
                        z.MakeTransparent(z.GetPixel(0, 0));
                        if (k == 0)
                        { a = 2; }
                        else
                        {
                            a *= 2;
                        }
                    }
                    pnn.j = 0;
                    pnn.total = 0;
                    pnn.rcSrc = new Rectangle(0, 0, pnn.imgs[0].Width, pnn.imgs[0].Height);
                    pnn.rcDst = new Rectangle(ax, ay, 50, 50);

                    ax += pnn.W;
                    c[i, x] = pnn;
                }
                ay += 50;
            }
            int row = RR.Next(0, 4);
            int  column = RR.Next(0, 4);
            B[row, column].j = 1;
            B[row, column].total = 2;
             row = RR.Next(0, 4);
             column = RR.Next(0, 4);
            B[row, column].j = 1;
            B[row, column].total = 2;


             pnn = new CActor();
            pnn.X = 700;
            pnn.Y = 300;
            pnn.W = 50;
            pnn.H = 50;
            pnn.imgs = new List<Bitmap>();
            z = new Bitmap( "rec.jpg");
                pnn.imgs.Add(z);
                z.MakeTransparent(z.GetPixel(0, 0));
                 pnn.j = 0;
            ax += pnn.W;
           L.Add(pnn);

            pnn = new CActor();
            pnn.X = 900;
            pnn.Y = 300;
            pnn.W = 50;
            pnn.H = 50;
            pnn.imgs = new List<Bitmap>();
              z = new Bitmap("back.png");
            pnn.imgs.Add(z);
            z.MakeTransparent(z.GetPixel(0, 0));
            pnn.j = 0;
            ax += pnn.W;
            L.Add(pnn);


        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);

        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    g.DrawRectangle(new Pen(Color.Green, 5),
                                      B[r, c].X, B[r, c].Y, B[r, c].W, B[r, c].H);
                    g.DrawImage(B[r,c].imgs[B[r,c].j], B[r,c].rcDst, B[r,c].rcSrc, GraphicsUnit.Pixel);
                }
            }
            for (int i = 0; i < L.Count; i++)
            {
                g.DrawImage(L[i].imgs[L[i].j], L[i].X, L[i].Y);
            }
            string drawString = "score:" + ct;
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x = 700.0F;
            float y = 100.0F;
            StringFormat drawFormat = new StringFormat();
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);




            drawFont.Dispose();
            drawBrush.Dispose();
        }
    }
}