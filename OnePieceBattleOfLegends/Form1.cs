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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePieceBattleOfLegends
{

    public partial class Form1 : Form
    {
        //Global Variables

        //Rectangles
        Rectangle ground = new Rectangle(0, 345, 800, 30);
        Rectangle luffy = new Rectangle(30, 240, 100, 100);
        Rectangle kaido = new Rectangle(465, 240, 100, 100);

        //brushes
        SolidBrush luffyBrush = new SolidBrush(Color.Red);
        SolidBrush kaidoBrush = new SolidBrush(Color.BurlyWood);
        SolidBrush groundBrush = new SolidBrush(Color.SaddleBrown);

        //pens
        Pen luffyPen = new Pen(Color.Green, 10);
        Pen kaidoPen = new Pen(Color.Orange, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Luffy
            e.Graphics.DrawRectangle(luffyPen, luffy);

            //Kaido
            e.Graphics.DrawRectangle(kaidoPen, kaido);

            //Ground
            e.Graphics.FillRectangle(groundBrush, ground);
        }
    }
}
