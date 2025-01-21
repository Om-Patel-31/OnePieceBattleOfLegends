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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePieceBattleOfLegends
{

    public partial class Form1 : Form
    {
        //Global Variables

        //Rectangles
        Rectangle ground = new Rectangle(0, 333, 800, 30);
        Rectangle luffyBody = new Rectangle(120, 260, 15, 35);

        //brushes
        SolidBrush luffyBrush = new SolidBrush(Color.Red);
        SolidBrush kaidoBrush = new SolidBrush(Color.BurlyWood);
        SolidBrush groundBrush = new SolidBrush(Color.SaddleBrown);
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
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {

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

            //Ground
            e.Graphics.FillRectangle(groundBrush, ground);

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
            luffyPen.Color = Color.FromArgb(255, 238, 184, 146);
            luffyPen.Width = 20;
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 7, luffyBody.Y - 25, 10, 15, 80, 105);
            e.Graphics.DrawArc(luffyPen, luffyBody.X + 17, luffyBody.Y - 25, 7, 15, 85+5, 95);
            //hair
            luffyPen.Color = Color.Black;
            e.Graphics.DrawArc(luffyPen, luffyBody.X - 8, luffyBody.Y - 25, 7, 1, 45, 80);
            e.Graphics.DrawArc(luffyPen, luffyBody.X - 1, luffyBody.Y - 25, 3, 3, 20, 70);
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
            e.Graphics.FillRectangle(luffyBrush, luffyBody.X-1, luffyBody.Y - 26, luffyBody.Width + 7, luffyBody.Height - 30);
        }
    }
}   