/*


 -----------------------------------------------------------------------------------------------------
|Created by: Om Patel                                                                                 |
|Date: 2025-01-12                                                                                     |
|Description: This is a simple One Piece 2D game inspired from One Piece Anime                        |
 -----------------------------------------------------------------------------------------------------



 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePieceBattleOfLegends
{

    public partial class Form1 : Form
    {
        //Global Variables
        int luffyHP = 4000;
        int kaidoHP = 5000;
        int luffyMoveHP = 250;
        int kaidoMoveHP = 300;
        int luffyUltimateHP = 900;
        int kaidoUltimateHP = 1000;
        int luffyhealthBar = 100;
        int kaidohealthBar = 100;
        int turn = 0;
        bool zPressed;
        bool xPressed;
        bool yourTurn;

        //random
        Random hit = new Random();

        //Rectangles
        Rectangle luffyBody = new Rectangle(120, 260, 15, 35);
        Rectangle kaidoBody = new Rectangle(620, 175, 25, 95);

        //Triangles
        PointF point;
        PointF point1;
        PointF point2;
        PointF point3;

        //brushes
        SolidBrush luffyBrush = new SolidBrush(Color.Red);
        SolidBrush kaidoBrush = new SolidBrush(Color.BurlyWood);
        SolidBrush fontBrush = new SolidBrush(Color.White);

        //pens
        Pen luffyPen = new Pen(Color.Green, 10);
        Pen kaidoPen = new Pen(Color.Orange, 10);

        //font
        Font newFont = new Font("ONE PIECE", 28);

        //pointf
        PointF fontPoint = new PointF(5, 50);

        public Form1()
        {
            InitializeComponent();
            point = new PointF(kaidoBody.X+25, kaidoBody.Y + 145);
            point1 = new PointF(kaidoBody.X+100, kaidoBody.Y + 150);
            point2 = new PointF(kaidoBody.X+100, kaidoBody.Y + 160);
            point3 = new PointF(kaidoBody.X+25, kaidoBody.Y + 170);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Z:
                    zPressed = true;
                    break;
                case Keys.X:
                    xPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (turn % 2 == 0)
            {
                yourTurn = true;
                if (yourTurn == true)
                {
                    int hitValue = hit.Next(0, 3);
                    switch (hitValue)
                    {
                        case 0:
                            if (zPressed == true)
                            {
                                kaidoHP -= luffyMoveHP;
                                kaidohealthBar -= 6;
                            }
                            break;
                        case 1:
                            if (zPressed == true)
                            {
                                kaidoHP -= luffyMoveHP;
                                kaidohealthBar -= 3;
                            }
                            break;
                        case 2:
                            if (zPressed == true)
                            {
                                kaidoHP -= luffyMoveHP;
                                kaidohealthBar -= 0;
                            }
                            break;
                        default:
                            break;
                    }
                    turn++;
                }
            }

            if (turn % 2 != 0)
            {
                yourTurn = false;
                if (yourTurn == false)
                {
                    int hitValue = hit.Next(0, 3);
                    switch (hitValue)
                    {
                        case 0:
                            luffyHP -= kaidoMoveHP;
                            luffyhealthBar -= 6;
                            break;
                        case 1:
                            luffyHP -= kaidoMoveHP;
                            luffyhealthBar -= 3;
                            break;
                        case 2:
                            luffyHP -= kaidoMoveHP;
                            luffyhealthBar -= 0;
                            break;
                        default:
                            break;
                    }
                    turn++;
                }
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //instructions
            e.Graphics.DrawString("For your move, press k. For your ultimate move, press spacebar", newFont, fontBrush, fontPoint);
            //Thread.Sleep(3000);
            //clearing the instructions
            e.Graphics.Clear(Color.White);

            //Kaido
            kaidoPen.Width = 1;

            // Create image.
            Image newImage = Properties.Resources.bg;
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, 0, 0);

            //Luffy
            //luffy rectangle
            luffyPen.Width = 1;
            luffyPen.Color = Color.Transparent;
            e.Graphics.DrawRectangle(luffyPen, luffyBody.X - 13, luffyBody.Y-36, luffyBody.Width+40, luffyBody.Height+73);
            //sleeve-left
            luffyPen.Width = 10;
            luffyPen.Color = Color.FromArgb(255, 192, 51, 60);
            e.Graphics.DrawLine(luffyPen, luffyBody.X+luffyBody.Width-3, luffyBody.Y + 7, luffyBody.X+luffyBody.Width+10, luffyBody.Y + 20);
            //body
            luffyBrush.Color = Color.FromArgb(255, 238, 184, 146);
            e.Graphics.FillRectangle(luffyBrush, luffyBody);
            //legs
            luffyPen.Color = Color.FromArgb(255, 238, 184, 146);
            luffyPen.Width = 5;
            //right
            e.Graphics.DrawLine(luffyPen, 118, 310, 112, 330);  
            e.Graphics.DrawLine(luffyPen, 110, 330, 120, 330);
            //left
            e.Graphics.DrawLine(luffyPen, 135, 310, 141, 330);
            e.Graphics.DrawLine(luffyPen, 140, 330, 150, 330);
            //pant
            luffyPen.Width = 7;
            luffyPen.Color = Color.FromArgb(255, 228, 228, 228);
            e.Graphics.DrawLine(luffyPen, 125, 290, luffyBody.X-5, luffyBody.Y+60);
            e.Graphics.DrawLine(luffyPen, 130, 290, luffyBody.X+19, luffyBody.Y+60);
            //hat
            luffyBrush.Color = Color.FromArgb(255, 235, 200, 95);
            e.Graphics.FillEllipse(luffyBrush, luffyBody.X-3, luffyBody.Y - 35, luffyBody.Width+10, luffyBody.Height - 10);
            //pant overlay
            luffyPen.Width = 10;
            luffyPen.Color = Color.FromArgb(255, 80, 108, 181);
            e.Graphics.DrawLine(luffyPen, 125, 290, luffyBody.X-3, luffyBody.Y+55);
            e.Graphics.DrawLine(luffyPen, 130, 290, luffyBody.X+17, luffyBody.Y+55);
            //shirt
            luffyBrush.Color = Color.FromArgb(255, 192, 51, 60);
            e.Graphics.FillRectangle(luffyBrush, luffyBody.X, luffyBody.Y, luffyBody.Width - 5, luffyBody.Height + 2);
            luffyBrush.Color = Color.FromArgb(255, 236, 209, 75);
            e.Graphics.FillRectangle(luffyBrush, luffyBody.X, luffyBody.Y+30, luffyBody.Width+2, luffyBody.Height - 28);
            //sleeves
            luffyPen.Color = Color.FromArgb(255, 192, 51, 60);
            luffyPen.Width = 7;
            //right
            e.Graphics.DrawLine(luffyPen, luffyBody.X+3, luffyBody.Y + 7, luffyBody.X - 7, luffyBody.Y + 30);
            //hand
            luffyPen.Width = 5;
            //right
            luffyBrush.Color = Color.FromArgb(255, 238, 184, 146);
            luffyPen.Color = Color.FromArgb(255, 238, 184, 146);
            e.Graphics.DrawLine(luffyPen, luffyBody.X-7, luffyBody.Y + 30, luffyBody.X - 10, luffyBody.Y + 35);
            e.Graphics.DrawLine(luffyPen, luffyBody.X - 12, luffyBody.Y + 35, luffyBody.X-7, luffyBody.Y + 38);
            //left
            e.Graphics.DrawLine(luffyPen, luffyBody.X+luffyBody.Width+10, luffyBody.Y + 20, luffyBody.X+luffyBody.Width+15, luffyBody.Y + 25);
            e.Graphics.DrawLine(luffyPen, luffyBody.X+luffyBody.Width+13, luffyBody.Y + 27, luffyBody.X+luffyBody.Width+20, luffyBody.Y + 17);
            e.Graphics.DrawLine(luffyPen, luffyBody.X + luffyBody.Width + 18, luffyBody.Y + 15, luffyBody.X + luffyBody.Width + 25, luffyBody.Y + 18);
            //head
            luffyPen.Color = Color.FromArgb(100, 50, 50, 50);
            luffyPen.Width = 20;
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 7, luffyBody.Y - 25, 10, 15, 80, 105);
            luffyPen.Color = Color.FromArgb(255, 238, 184, 146);
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 17, luffyBody.Y - 25, 7, 15, 85+5, 95);
            //hair
            luffyPen.Color = Color.Black;
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 7, luffyBody.Y - 18, 3, 1, -300, 200);
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 5, luffyBody.Y - 20, 1, 5, 20, 70);
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 10, luffyBody.Y - 23, 1, 5, 20, 70);
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 15, luffyBody.Y - 18, 1, 3, 20, 70);
            //whiteout
            luffyBrush.Color = Color.Transparent;
            e.Graphics.FillRectangle(luffyBrush, luffyBody.X - 15, luffyBody.Y - 35, luffyBody.Width-1, luffyBody.Height - 10);
            //hat
            luffyBrush.Color = Color.FromArgb(255, 235, 200, 95);
            e.Graphics.FillEllipse(luffyBrush, luffyBody.X - 7, luffyBody.Y - 25, luffyBody.Width + 20, luffyBody.Height - 25);
            luffyBrush.Color = Color.FromArgb(255, 192, 51, 60);
            e.Graphics.FillRectangle(luffyBrush, luffyBody.X-1, luffyBody.Y - 27, luffyBody.Width + 7, luffyBody.Height - 30);
            //footwear
            luffyBrush.Color = Color.FromArgb(255, 215, 190, 149);
            luffyPen.Color = Color.Black;
            luffyPen.Width = 1;
            e.Graphics.FillRectangle(luffyBrush, 108, 330, 14, 3);
            e.Graphics.DrawRectangle(luffyPen, 108, 330, 14, 3);
            e.Graphics.FillRectangle(luffyBrush, 138, 330, 14, 3);
            e.Graphics.DrawRectangle(luffyPen, 138, 330, 14, 3);

            //kaido (main)
            kaidoBrush.Color = Color.FromArgb(255, 41, 131, 181);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X - 8, kaidoBody.Y + 10, kaidoBody.Width + 15, kaidoBody.Height, 60, 45);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X, kaidoBody.Y + 43, kaidoBody.Width + 30, kaidoBody.Height - 40, 90, 45);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X+20, kaidoBody.Y + 80, kaidoBody.Width + 30, kaidoBody.Width);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X+40, kaidoBody.Y + 80, kaidoBody.Width + 30, kaidoBody.Height - 35, -90, 90);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X+40, kaidoBody.Y + 90, kaidoBody.Width + 30, kaidoBody.Height - 45, 90, -90);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X+70, kaidoBody.Y + 100, kaidoBody.Width, kaidoBody.Height - 80);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X+20, kaidoBody.Y + 115, kaidoBody.Width + 30, kaidoBody.Width);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X-3, kaidoBody.Y + 115, kaidoBody.Width + 30, kaidoBody.Height - 45, -90, -90);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X, kaidoBody.Y + 120, kaidoBody.Width + 30, kaidoBody.Height - 45, 90, 90);
            //tail
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X, kaidoBody.Y + 130, kaidoBody.Width+5, kaidoBody.Height - 80);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3});
            kaidoBrush.Color = Color.Black;
            e.Graphics.FillEllipse(kaidoBrush, kaidoBody.X + 95, kaidoBody.Y + 148, 25, 15);
            point = new PointF(kaidoBody.X + 113, kaidoBody.Y + 148);
            point1 = new PointF(kaidoBody.X + 113, kaidoBody.Y + 160);
            point2= new PointF(kaidoBody.X + 135, kaidoBody.Y + 155);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2 });
            //scales
            kaidoBrush.Color = Color.FromArgb(255, 250, 223, 155);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X, kaidoBody.Y, kaidoBody.Width - 10, kaidoBody.Height);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X - 8, kaidoBody.Y + 10, kaidoBody.Width, kaidoBody.Height, 60, 45);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X + 5, kaidoBody.Y + 90, kaidoBody.Width + 40, kaidoBody.Width-10);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X + 40, kaidoBody.Y + 90, kaidoBody.Width + 20, kaidoBody.Height - 45, -90, 90);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X + 40, kaidoBody.Y + 90, kaidoBody.Width + 20, kaidoBody.Height - 55, 90, -90);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X + 20, kaidoBody.Y + 115, kaidoBody.Width + 30, kaidoBody.Width-10);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X - 3, kaidoBody.Y + 115, kaidoBody.Width + 20, kaidoBody.Height - 45, -90, -90);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X, kaidoBody.Y + 130, kaidoBody.Width + 20, kaidoBody.Height - 55, 90, 90);
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X, kaidoBody.Y + 130, kaidoBody.Width-5, kaidoBody.Height - 70);
            point = new PointF(kaidoBody.X + 20, kaidoBody.Y + 155);
            point1 = new PointF(kaidoBody.X + 95, kaidoBody.Y + 155);
            point2 = new PointF(kaidoBody.X + 95, kaidoBody.Y + 160);
            point3 = new PointF(kaidoBody.X + 20, kaidoBody.Y + 170);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            //face
            kaidoBrush.Color = Color.FromArgb(255, 41, 131, 181);
            point2 = new PointF(kaidoBody.X + 15, kaidoBody.Y + 10);
            point1 = new PointF(kaidoBody.X - 40, kaidoBody.Y);
            point = new PointF(kaidoBody.X - 40, kaidoBody.Y - 15);
            point3 = new PointF(kaidoBody.X + 15, kaidoBody.Y - 50);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            e.Graphics.FillEllipse(kaidoBrush, kaidoBody.X - 40, kaidoBody.Y - 25, kaidoBody.Width - 10, 15);
            //hair
            kaidoBrush.Color = Color.Black;
            point2 = new PointF(kaidoBody.X + 15, kaidoBody.Y - 50);
            point1 = new PointF(kaidoBody.X + 5, kaidoBody.Y - 50);
            point = new PointF(kaidoBody.X + 5, kaidoBody.Y + 10);
            point3 = new PointF(kaidoBody.X + 30, kaidoBody.Y + 10);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            //
            point2 = new PointF(kaidoBody.X + 40, kaidoBody.Y + 50);
            point1 = new PointF(kaidoBody.X + 15, kaidoBody.Y + 50);
            point = new PointF(kaidoBody.X + 5, kaidoBody.Y + 10);
            point3 = new PointF(kaidoBody.X + 30, kaidoBody.Y + 10);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            //
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X + 15, kaidoBody.Y + 50, 25, 40);
            //
            point2 = new PointF(kaidoBody.X + 40, kaidoBody.Y + 85);
            point1 = new PointF(kaidoBody.X + 35, kaidoBody.Y + 125);
            point = new PointF(kaidoBody.X + 15, kaidoBody.Y + 85);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2});
            //mouth
            kaidoBrush.Color = Color.Red;
            point2 = new PointF(kaidoBody.X - 15, kaidoBody.Y);
            point1 = new PointF(kaidoBody.X - 40, kaidoBody.Y);
            point = new PointF(kaidoBody.X - 40, kaidoBody.Y - 15);
            point3 = new PointF(kaidoBody.X - 15, kaidoBody.Y - 10);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            e.Graphics.FillEllipse(kaidoBrush, kaidoBody.X - 18, kaidoBody.Y - 11, 10, 10);
            //teeth
            kaidoBrush.Color = Color.AntiqueWhite;
            //upper
            point2 = new PointF(kaidoBody.X - 10, kaidoBody.Y - 5);
            point1 = new PointF(kaidoBody.X - 40, kaidoBody.Y - 10);
            point = new PointF(kaidoBody.X - 40, kaidoBody.Y - 15);
            point3 = new PointF(kaidoBody.X - 10, kaidoBody.Y - 10);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            //lower
            point2 = new PointF(kaidoBody.X - 10, kaidoBody.Y + 5 - 12);
            point1 = new PointF(kaidoBody.X - 40, kaidoBody.Y + 10 - 12);
            point = new PointF(kaidoBody.X - 40, kaidoBody.Y + 15 - 12);
            point3 = new PointF(kaidoBody.X - 10, kaidoBody.Y + 10 - 12);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3 });
            //horns
            //top horn
            point2 = new PointF(kaidoBody.X + 15, kaidoBody.Y - 57);
            point1 = new PointF(kaidoBody.X + 10, kaidoBody.Y - 40);
            point = new PointF(kaidoBody.X , kaidoBody.Y  - 40);
            point3 = new PointF(kaidoBody.X + 10, kaidoBody.Y - 60);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2, point3});
            point2 = new PointF(kaidoBody.X + 15, kaidoBody.Y - 57);
            point1 = new PointF(kaidoBody.X + 23, kaidoBody.Y - 70);
            point = new PointF(kaidoBody.X + 7, kaidoBody.Y  - 57);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2});
            //side horn
            point2 = new PointF(kaidoBody.X + 50, kaidoBody.Y - 20);
            point1 = new PointF(kaidoBody.X + 10, kaidoBody.Y - 35);
            point = new PointF(kaidoBody.X + 10, kaidoBody.Y  - 25);
            e.Graphics.FillPolygon(kaidoBrush, new PointF[] { point, point1, point2});
            //eye
            kaidoBrush.Color = Color.FromArgb(255, 255, 0, 0);
            e.Graphics.FillPie(kaidoBrush, kaidoBody.X - 20, kaidoBody.Y - 35, 15, 15, 150, -180);
            //moustache
            kaidoPen.Color = Color.Black;
            kaidoPen.Width = 3;
            e.Graphics.DrawLine(kaidoPen, kaidoBody.X - 30, kaidoBody.Y - 20, kaidoBody.X - 5, kaidoBody.Y + 5);

            //name
            newFont = new Font("ONE PIECE", 20);
            //luffy
            e.Graphics.DrawString("Luffy", newFont, fontBrush, 5, 5);
            //kaido
            e.Graphics.DrawString("Kaido", newFont, fontBrush, 730, 5);

            //health bar
            kaidoPen.Color = Color.White;
            kaidoPen.Width = 3;
            kaidoBrush.Color = Color.YellowGreen;
            //luffy
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X - 610, kaidoBody.Y - 135, luffyhealthBar, 10);
            e.Graphics.DrawRectangle(kaidoPen, kaidoBody.X - 610, kaidoBody.Y - 135, 100, 10);
            //kaido
            e.Graphics.FillRectangle(kaidoBrush, kaidoBody.X + 65, kaidoBody.Y - 135, kaidohealthBar, 10);
            e.Graphics.DrawRectangle(kaidoPen, kaidoBody.X + 65, kaidoBody.Y - 135, 100, 10);
        }

    }
}   