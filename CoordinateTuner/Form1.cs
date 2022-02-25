using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using MathNet.Numerics.Interpolation;
using CubicSpline = TestMySpline.CubicSpline;

namespace CoordinateTuner
{
    public partial class Form1 : Form
    {
        private bool _spline = false;
        private bool _moving = false;
        private int _index = 0;

        private Graphics _g;
        private Graphics _g2;

        private List<Point> _points;
        private Point _currentPoint;

        private Pen pen;
        private Pen selectedPen;

        private Image _image;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Bitmap bitmap = new(fieldPanel.Width, fieldPanel.Height); 

            _g = fieldPanel.CreateGraphics();
            _g.SmoothingMode = SmoothingMode.AntiAlias;
            
            _g2 = Graphics.FromImage(bitmap);
            coordinatePanel.BackgroundImage = bitmap;
            coordinatePanel.BackgroundImageLayout = ImageLayout.None;

            _points = new List<Point>();

            _image = resizeImage(Properties.Resources.cropped, fieldPanel.Size);

            pen = new Pen(Color.Black, 3);
            selectedPen = new Pen(Color.Red, 3);
        }

        public void updatePanel()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < _points.Count; i++)
            {
                listBox1.Items.Add($"{_points[i].X} , {3658 - _points[i].Y}");
            }

            _g.Clear(Color.White);
            //_g2.Clear(Color.White);

            _g.DrawImage(_image, 0, 0);
            //_g2.DrawImage(_image, 0, 0);

            for (int i = 0; i < _points.Count; i++)
            {
                if (_moving && _index == i)
                    _g.DrawEllipse(selectedPen, (int)(_points[i].X / 8.5258) - 5, (int)(_points[i].Y / 8.5258) - 5, 10, 10);
                else
                    _g.DrawEllipse(pen, (int)(_points[i].X / 8.5258) - 5, (int)(_points[i].Y / 8.5258) - 5, 10, 10);

                if (i > 0 && !_spline)
                    _g.DrawLine(pen, (int)(_points[i - 1].X / 8.5258), (int)(_points[i - 1].Y / 8.5258), (int)(_points[i].X / 8.5258), (int)(_points[i].Y / 8.5258));
            }

            if (_spline && _points.Count > 0)
            {
                float[] xs = new float[_points.Count];
                float[] ys = new float[_points.Count];
                

                for (int i = 0; i < _points.Count; i++)
                {
                    xs[i] = (int)(_points[i].X / 8.5258);
                    ys[i] = (int)(_points[i].Y / 8.5258);
                }

                double[] distances = new double[xs.Length];

                int distance = 0;

                for (int i = 1; i < xs.Length; i++)
                {
                    double dx = xs[i] - xs[i - 1];
                    double dy = ys[i] - ys[i - 1];
                    double dist = Math.Sqrt(dx * dx + dy * dy);
                    distances[i] = dist;
                    distance += (int) dist;
                }

                float[] calculatedXs;
                float[] calculatedYs;

                CubicSpline.FitParametric(xs, ys, 500, out calculatedXs, out calculatedYs);

                Point oldPoint = new Point(-2, -2);

                for (int i = 0; i < 500; i++)
                {
                    if (oldPoint.X < -1 )
                    {
                        oldPoint = new Point((int)calculatedXs[i], (int)calculatedYs[i]);
                        continue;
                    }
                    else
                    {
                        Point point = new Point((int)calculatedXs[i], (int)calculatedYs[i]);
                        _g.DrawLine(pen, oldPoint.X, oldPoint.Y, point.X, point.Y);
                        oldPoint = point;
                    }
                }
            }

        }

        private static Image resizeImage(Image imgToResize, Size size)  
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height; 
            
            float nPercent = 0;  
            float nPercentW = 0;  
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);  

            if (nPercentH < nPercentW)  
                nPercent = nPercentH;  
            else  
                nPercent = nPercentW;  
 
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);  

            Bitmap b = new (destWidth, destHeight);  
            Graphics g = Graphics.FromImage(b); 
            
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);  
            g.Dispose();  

            return b;  
        }

        private void coordinatePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fieldPanel_MouseMove(object sender, MouseEventArgs e)
        {
            _currentPoint = e.Location;

            if (_moving)
            {
                _points[_index] = new Point((int)(_currentPoint.X * 8.5258), (int)(_currentPoint.Y * 8.5258));
                updatePanel();
            }
        }

        private void fieldPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!_moving)
                {
                    for (int i = 0; i < _points.Count; i++)
                    {
                        double dx = (_points[i].X / 8.5258) - _currentPoint.X;
                        double dy = (_points[i].Y / 8.5258) - _currentPoint.Y;

                        if (Math.Sqrt(dx * dx - dy * dy) < 10)
                        {
                            _moving = true;
                            _index = i;
                            updatePanel();
                            return;
                        }
                        else
                            _moving = false;
                    }

                    _points.Add(new Point((int)(_currentPoint.X * 8.5258), (int)(_currentPoint.Y * 8.5258)));
                }
                else
                {
                    _moving = false;
                }

                
                updatePanel();
            } else if (e.Button == MouseButtons.Right && _moving)
            {
                _points.RemoveAt(_index);
                _moving = false;
                updatePanel();
                
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            _points.RemoveAt(listBox1.SelectedIndex);

            updatePanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_points.Count < 3)
                return;
            _spline = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _spline = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            updatePanel();
        }
    }
}