using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dodgeGame
{
    public partial class Form1 : Form
    {

        Rectangle hero = new Rectangle(25, 100, 20, 20);

        int heroSpeed = 6;
        int stopSpeed = 0;

        List<Rectangle> leftRectangle = new List<Rectangle>();

        List<Rectangle> rightRectangle = new List<Rectangle>();


      

        int obstacleHeight = 70;
        int obstacleWidth = 25;
        int obstacleLX = 200;
        int obstacleRX = 300;

        int obstacleLSpeed = 8;
        int obstacleRSpeed = -8;

        int leftSpeed = 8;
        int rightSpeed = 8;

        int leftCounter = 0;
        int rightCounter = 0;

        bool track1;
        bool track2;
        bool track3;
        bool track4;

        SolidBrush heroBrush = new SolidBrush(Color.AliceBlue);
        SolidBrush obstacleBrush = new SolidBrush(Color.LightYellow);

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftDown = false;
        bool rightDown = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Up:
                    upArrowDown = false;
                     break;
                case Keys.Down:
                    downArrowDown = false;
                     break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;

        }
    }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            // paint hero
            e.Graphics.FillRectangle(heroBrush, hero);

            // paint obstacles
           for (int i = 0; i < leftRectangle.Count(); i++)
            {

                e.Graphics.FillRectangle(obstacleBrush, leftRectangle[i]);
            }

            for (int i = 0; i < rightRectangle.Count(); i++)
            {

                e.Graphics.FillRectangle(obstacleBrush, rightRectangle[i]);
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
           
            // move hero
            if (upArrowDown== true)
            {
               
                hero.Y -= heroSpeed;

            }
            if (downArrowDown == true)
            {

                hero.Y += heroSpeed;

            }
            if (leftDown == true)
            {

                hero.X -= heroSpeed;

            }
            if (rightDown == true)
            {

                hero.X += heroSpeed;

            }

            // move rectangles
            for (int i = 0; i < leftRectangle.Count(); i++)
            {
                int y = leftRectangle[i].Y + obstacleLSpeed;

               leftRectangle[i] = new Rectangle(leftRectangle[i].X, y, obstacleWidth, obstacleHeight);
            }

            for (int i = 0; i < rightRectangle.Count(); i++)
            {
                int y = rightRectangle[i].Y + obstacleRSpeed;



                rightRectangle[i] = new Rectangle(rightRectangle[i].X, y, obstacleWidth, obstacleHeight);
            }

            // add more obstacles
            leftCounter++;

            if (leftCounter % 22 == 0)
            {
                leftRectangle.Add(new Rectangle(obstacleLX, 0 - obstacleHeight, obstacleWidth, obstacleHeight));
            }

            rightCounter++;

            if (rightCounter % 22== 0)
            {
                rightRectangle.Add(new Rectangle(obstacleRX, 0 - obstacleHeight, obstacleWidth, obstacleHeight));
            }

            // stop when collision occurs
            for (int i = 0; i < leftRectangle.Count(); i++)
            {
                if (hero.IntersectsWith(leftRectangle[i]))
                {
                    gameTimer.Enabled = false;
                }

            }
            for (int i = 0; i < rightRectangle.Count(); i++)
            {
                if (hero.IntersectsWith(rightRectangle[i]))
                {
                    gameTimer.Enabled = false;
                }

            }
            Refresh();
        }

       
    }

}
