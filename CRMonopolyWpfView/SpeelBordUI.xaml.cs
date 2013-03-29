using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace CRMonopolyWpfView
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SpeelBordUI : Window
    {
        private Point _point = new Point(50, 20);
        private Size _horLabelSize = new Size(100, 50);
        private Size _verLabelSize = new Size(50, 100);
        private Size _cornerLabelSize = new Size(100, 100);

        private int currentPosition = -1;

        private Label[] _label = new Label[40];

        // private Canvas myPanel = new Canvas();

        public SpeelBordUI()
        {
            InitializeComponent();

            //this.Content = myPanel;

            addLabels();
            addButtonAndTextBox();


        }

        private void addButtonAndTextBox()
        {
            Button btnLoop = new Button();

        }

        private void addLabels()
        {
            _point.X = 20 + _cornerLabelSize.Width + (9 * _verLabelSize.Width);
            _point.Y = 20 + _cornerLabelSize.Height + (9 * _horLabelSize.Height);

            for (int _teller = 0; _teller < _label.Length; _teller++)
            {
                _label[_teller] = createLabel(_teller);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private Label createLabel(int number)
        {
            Label myLabel = new Label();
            myLabel.ContentStringFormat = "V{0}";
            myLabel.Content = number;
            myLabel.Width = getLabelSize(number).Width;
            myLabel.Height = getLabelSize(number).Height;
            myLabel.Visibility = Visibility.Visible;
            myLabel.BorderThickness = new Thickness(1.0);
            myLabel.BorderBrush = Brushes.Black;
        
            Point point = getLocation(number);
            Canvas.SetTop(myLabel, point.Y);
            Canvas.SetLeft(myLabel, point.X);

            myPanel.Children.Add(myLabel);

            return myLabel;
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

        private void btnLoop_Click(object sender, RoutedEventArgs e)
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

        }
        private void positionPawnOnField(int oldPosition, int newPosition)
        {
            // _label[oldPosition].BringToFront();
            int y = (int) (Canvas.GetTop(_label[newPosition]) + _label[newPosition].Height - 2 - _pic.Height);
            int x = (int) (Canvas.GetLeft(_label[newPosition]) + 2.0);
//            Point newPos = new Point(x, y);
            Canvas.SetLeft(_pic, x);
            Canvas.SetTop(_pic, y);

/*
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
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(pointAnimation, new System.Windows.PropertyPath(PictureBox.DefaultBackColor)); //DependencyProperty, PropertyInfo, PropertyDescriptor
*/
            //_pic.Location = newPos;
            //_pic.BringToFront();
            //_label[newPosition].SendToBack();
        }

    }
}
