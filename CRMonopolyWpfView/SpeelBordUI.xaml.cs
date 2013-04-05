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
using System.Diagnostics;

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
        private Point currentPositionPoint;

        private Label[] _label = new Label[40];

        private Storyboard myStoryboard = new Storyboard();
        // private Canvas myPanel = new Canvas();

        public SpeelBordUI()
        {
            InitializeComponent();

            //this.Content = myPanel;

            addLabels();
            addButtonAndTextBox();

            positionPawnOnField(-1, 0);
            currentPosition = 0;
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

            if (number == 0)
            {
                Debug.Write(String.Format("Label 0 staat op: {0}, {1}", point.X, point.Y));
            }

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
            {   // Bottom left corner
                _point.X -= _cornerLabelSize.Width;
            }
            else if (number < 19)
            {   // Left row
                _point.Y -= _horLabelSize.Height;
            }   
            else if (number == 19)
            {   // Top left Corner
                _point.Y -= _cornerLabelSize.Height;
            }
            else if (number == 20)
            {   // Cell right of the top left corner cell
                _point.X += _cornerLabelSize.Width;
            }
            else if (number < 30)
            {   //  rest of the Top row including Top Right Corner
                _point.X += _verLabelSize.Width;
            }
            else if (number == 30)
            {   // Cell below Top Right Corner
                _point.Y += _cornerLabelSize.Height;
            }
            else
            {   // Rest of the right row
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
//            if (currentPosition < 0)
//            {
//                // positionPawnOnField(0, 0);
//                currentPosition = 0;
//                // sleep();
//            }
            int oldPosition = currentPosition;
            currentPosition += stappen;
            if (currentPosition > 39)
            {
                currentPosition -= 40;
            }
            positionPawnOnField(oldPosition, currentPosition);
            myStoryboard.Begin(this);
        }
        private void positionPawnOnField(int oldPosition, int newPosition)
        {

            // CurrentPosition 
//            double curX = oldPosition < 0 ? Canvas.GetLeft(_pic) : Canvas.GetLeft(_label[oldPosition]);
//            double curY = oldPosition < 0 ? Canvas.GetTop(_pic) : Canvas.GetTop(_label[oldPosition]);
            if (currentPositionPoint == null)
            {
                currentPositionPoint = new Point(0.0, 0.0);
            }
//            double curX = Canvas.GetLeft(_pic);
//            double curY = Canvas.GetTop(_pic);
//            Debug.Write(String.Format("Label 0 staat volgens het canvas op: {0}, {1}", curX, curY));
            // Get new position
            double newY = Canvas.GetTop(_label[newPosition]);
            double newX = Canvas.GetLeft(_label[newPosition]);
            newY += (_label[newPosition].Height - 2 - _pic.Height);
            newX += 2.0;

            // Create a NameScope for the page so that we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create a transform. This transform will be used to move the rectangle.
            TranslateTransform animatedTranslateTransform = new TranslateTransform();

            // Register the transform's name with the page so that they it be targeted by a Storyboard. 
            this.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform);
            _pic.RenderTransform = animatedTranslateTransform;

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
//            pFigure.StartPoint = new Point(curX, curY);
            pFigure.StartPoint = currentPositionPoint; // Point(curX, curY);
            LineSegment lineSegment = new LineSegment();
            // PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            Point endPoint = new Point(newX, newY);
            lineSegment.Point = endPoint;
            pFigure.Segments.Add(lineSegment);
            animationPath.Figures.Add(pFigure);
            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();
            // Create a DoubleAnimationUsingPath to move the picture horizontally along the path by animating its TranslateTransform.
            DoubleAnimationUsingPath translateXAnimation = new DoubleAnimationUsingPath();
            translateXAnimation.PathGeometry = animationPath;
            translateXAnimation.Duration = TimeSpan.FromSeconds(1);
            // Set the Source property to X. This makes the animation generate horizontal offset values from the path information. 
            translateXAnimation.Source = PathAnimationSource.X;
            // Set the animation to target the X property of the TranslateTransform named "AnimatedTranslateTransform".
            Storyboard.SetTargetName(translateXAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateXAnimation, new PropertyPath(TranslateTransform.XProperty));

            // Create a DoubleAnimationUsingPath to move the rectangle vertically along the path by animating its TranslateTransform.
            DoubleAnimationUsingPath translateYAnimation = new DoubleAnimationUsingPath();
            translateYAnimation.PathGeometry = animationPath;
            translateYAnimation.Duration = TimeSpan.FromSeconds(1);
            // Set the Source property to Y. This makes the animation generate vertical offset values from the path information. 
            translateYAnimation.Source = PathAnimationSource.Y;
            // Set the animation to target the Y property of the TranslateTransform named "AnimatedTranslateTransform".
            Storyboard.SetTargetName(translateYAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateYAnimation, new PropertyPath(TranslateTransform.YProperty));

            RepeatBehavior rbOnce = new RepeatBehavior(1.0);
            myStoryboard.RepeatBehavior = rbOnce;
            myStoryboard.Children.Add(translateXAnimation);
            myStoryboard.Children.Add(translateYAnimation);

            //_pic.Location = newPos;
            //_pic.BringToFront();
            //_label[newPosition].SendToBack();
                        // Start the animations when the rectangle is loaded.
            _pic.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                myStoryboard.Begin(this);
            };
            currentPositionPoint = endPoint;
        }

    }
}
