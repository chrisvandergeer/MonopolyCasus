﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
//using System.Windows.Media.Animation.PointAnimation;

namespace CRMonopolyView
{
    public partial class SpeelBordUI : Form
    {
        private Point _point = new Point(50, 20);
        private Size _horLabelSize = new Size(100, 50);
        private Size _verLabelSize = new Size(50, 100);
        private Size _cornerLabelSize = new Size(100, 100);

        private int currentPosition = -1;

        private Label[] _label = new Label[40];
        private PictureBox _pic = null;
        private int _waitTime = 1000;

        public SpeelBordUI()
        {
            InitializeComponent();

            _point.X = 20 + _cornerLabelSize.Width + (9 * _verLabelSize.Width);
            _point.Y = 20 + _cornerLabelSize.Height + (9 * _horLabelSize.Height);

            for (int _teller = 0; _teller < _label.Length; _teller++)
            {
                _label[_teller] = createLabel(String.Format("V{0}", _teller), _teller);
            }

            _pic = new PictureBox();
            Image img = (Image)Properties.Resources.ResourceManager.GetObject("PawnWhite_Small");
            _pic.Image = img;
            _pic.Name = "Pawn";
            _pic.Location = new Point(250, 250);
            _pic.Size = img.Size; ; // new Size(150, 100);
            _pic.BringToFront();

            this.Controls.Add(_pic);

            tbStappen.Text = "1";
        }

        private Label createLabel(String txt, int number)
        {
            Label myLabel = new Label();
            myLabel.Text = txt;
            myLabel.Size = getLabelSize(number);
            myLabel.Visible = true;
            myLabel.BorderStyle = BorderStyle.FixedSingle;
            myLabel.Location = getLocation(number);
            this.Controls.Add(myLabel);

            return myLabel;
        }
        private Point getLocation(int number)
        {
            Point point = new Point(_point.X, _point.Y);
            if (number < 9)
            {   // Bottom row
                _point.X -= _verLabelSize.Width;
            }
            else if (number == 9)
            {
                _point.X -= _cornerLabelSize.Width;
            }
            else if (number < 19)
            {   // Left row
                _point.Y -= _horLabelSize.Height;
            }
            else if (number == 19)
            {
                _point.Y -= _cornerLabelSize.Height;
            }
            else if (number == 20)
            {
                _point.X += _cornerLabelSize.Width;
            }
            else if (number < 30)
            {   // Top row
                _point.X += _verLabelSize.Width;
            }
            else if (number == 30)
            {
                _point.Y += _cornerLabelSize.Height;
            }
            else 
            {
                _point.Y += _horLabelSize.Height;
            }
            return point;
        }
        private Size getLabelSize(int number)
        {
            if ((number % 10) == 0)
            {
                return _cornerLabelSize;
            }
            else if (number < 10 || (number > 20 && number < 30))
            {
                return _verLabelSize;
            }
            else
            {
                return _horLabelSize;
            }

        }
        private void RunPlayerRun_Click(object sender, EventArgs e)
        {
            int stappen = -1;
            if (!Int32.TryParse(tbStappen.Text, out stappen))
            {
                return;
            }
            if (currentPosition < 0)
            {
                // positionPawnOnField(0, 0);
                currentPosition = 0;
                // sleep();
            }
            int oldPosition = currentPosition;
            currentPosition += stappen;
            if (currentPosition > 39)
            {
                currentPosition -= 40;
            }
            positionPawnOnField(oldPosition, currentPosition);
            //_stappen = stappen;
            //Thread worker = new Thread(new ThreadStart(this.movePawn));
            //worker.Start();
            //worker.Join();
        }
        //int _stappen = -1;
/*
        public void movePawn() 
        {
            for (int teller = 0; teller < _stappen; teller++)
            {
                int oldPos = currentPosition;
                if (++currentPosition >= _label.Length)
                {
                    currentPosition = 0;
                }
                positionPawnOnField(oldPos, currentPosition);
                sleep();
            }
        }
*/
        private void positionPawnOnField(int oldPosition, int newPosition)
        {
            _label[oldPosition].BringToFront();
            int y = _label[newPosition].Location.Y + _label[newPosition].Height - 2 - _pic.Height;
            int x = _label[newPosition].Location.X + 2;
            Point newPos = new Point(x, y);

            System.Windows.Media.Animation.PointAnimation pointAnimation = new System.Windows.Media.Animation.PointAnimation();
            System.Windows.Point swpFrom = new System.Windows.Point();
            swpFrom.X = _pic.Location.X;
            swpFrom.Y = _pic.Location.Y;
            pointAnimation.From = swpFrom; // System.Drawing.Point <-> System.Window.Point
            System.Windows.Point swpTo = new System.Windows.Point();
            swpTo.X = newPos.X;
            swpTo.Y = newPos.Y;
            pointAnimation.To = swpTo;
            pointAnimation.Duration = new System.Windows.Duration(TimeSpan.FromSeconds(2));
            pointAnimation.AutoReverse = false;

            System.Windows.Media.Animation.Storyboard myStoryboard = new System.Windows.Media.Animation.Storyboard();
            myStoryboard.Children.Add(pointAnimation);
            System.Windows.Media.Animation.Storyboard.SetTargetName(pointAnimation, _pic.Name);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(pointAnimation, new System.Windows.PropertyPath(PictureBox.DefaultBackColor)); //DependencyProperty, PropertyInfo, PropertyDescriptor.
 
            _pic.Location = newPos;
            _pic.BringToFront();
            _label[newPosition].SendToBack();
        }

        private void SpeelBordUI_Load(object sender, EventArgs e)
        {

        }

/*
        private void sleep()
        {
            Thread.Sleep(0);
            tbCurrentPosition.Text = "- " + currentPosition + " -";
            Thread.Sleep(0);
            Thread.Sleep(_waitTime);
        }

        delegate void BringToFrontCallback(Control comp);

        private void BringToFront(Control comp)
        {
            if (comp.InvokeRequired)
            {
                BringToFrontCallback d = new BringToFrontCallback(BringToFront);
                this.Invoke(d, new object[] { comp });
            }
            else
            {
                comp.BringToFront();
            }
        }
 */
    }
}
