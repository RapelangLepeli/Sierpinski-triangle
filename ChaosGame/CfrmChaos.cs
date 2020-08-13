using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaosGame
{
    public partial class CfrmChaos : Form
    {
        static Point PointA;
        static Point PointB;
        static Point PointC;
        static Point StartPoint;

        static Graphics draw;

        SolidBrush BlackSolidBrush;
        SolidBrush RedSolidBrush;

        static Random Die;

        public CfrmChaos()
        {
            InitializeComponent();
            draw = pnlDraw.CreateGraphics();

            PointA.X = pnlDraw.Width / 2;
            PointA.Y = pnlDraw.Top + 3;

            PointB.X = pnlDraw.Width * 10 / 100;
            PointB.Y = pnlDraw.Height * 90 / 100;

            PointC.X = pnlDraw.Width * 90 / 100;
            PointC.Y = pnlDraw.Height * 90 / 100;

            StartPoint.X = PointA.X;
            StartPoint.Y = PointA.Y + 60;

            BlackSolidBrush = new SolidBrush(Color.Black);
            RedSolidBrush = new SolidBrush(Color.Red);

            Die = new Random((int)DateTime.Now.Ticks);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawPoints();
            for (int i = 0; i < 100; i++)
            {
                int DieNumber = Die.Next(1,7);
                draw.FillEllipse(RedSolidBrush,StartPoint.X,StartPoint.Y,4,4);
                if (DieNumber == 1 || DieNumber == 2)
                {
                    StartPoint.X = (StartPoint.X + PointA.X)/2;
                    StartPoint.Y = (StartPoint.Y + PointA.Y) / 2;
                }
                else if (DieNumber == 3 || DieNumber == 4)
                {
                    StartPoint.X = (StartPoint.X + PointB.X) / 2;
                    StartPoint.Y = (StartPoint.Y + PointB.Y) / 2;

                }
                else
                {
                    StartPoint.X = (StartPoint.X + PointC.X) / 2;
                    StartPoint.Y = (StartPoint.Y + PointC.Y) / 2;

                }
            }
        }
        private void DrawPoints()
        {
            draw.FillEllipse(BlackSolidBrush,PointA.X,PointA.Y,6,6);
            draw.FillEllipse(BlackSolidBrush, PointB.X, PointB.Y, 6, 6);
            draw.FillEllipse(BlackSolidBrush, PointC.X, PointC.Y, 6, 6);
            draw.FillEllipse(RedSolidBrush,StartPoint.X,StartPoint.Y,4,4);
        }
    }
}
