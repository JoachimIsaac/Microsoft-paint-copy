using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhancedPainter
{


    public partial class PainterForm : Form
    {
        public Graphics graphics;
        // private bool StartingPoint = true;
        //private List<Tuple<Point, Point>> ListOfLinePoints = new List<Tuple<Point, Point>>();
        private List<Rectangle> ListOfRectangles = new List<Rectangle>();
        private List<Rectangle> ListRecsForEllipse = new List<Rectangle>();
        // private Point SPoint;
        // private Point EPoint;
        private Pen pen = new Pen(Color.Black, 4.0F);
        private Rectangle rect = new Rectangle(0, 0, 100, 50);
        private ShapesBuilder SBuilder;




        public PainterForm()
        {
            ////////
            InitializeComponent();
            graphics = Canvaspanel.CreateGraphics();
            SBuilder = new ShapesBuilder(graphics);
        }




        //Clears the Canvas.
        private void Clearbutton_Click(object sender, EventArgs e)
        {
            ///////
            Canvaspanel.Invalidate();
            SBuilder.ClearListsOfShapes();
            //ListOfLinePoints.Clear();
            //ListOfRectangles.Clear();
            //ListRecsForEllipse.Clear();
        }



        private void Canvaspanel_MouseDown(object sender, MouseEventArgs e)
        {
            /////////
            if (LineradioButton.Checked)
            {
                DrawLineOnCanvas(e);
            }
            else if (RectangleradioButton.Checked)
            {

                SBuilder.setCurrentStartingState(true);

                if (SBuilder.isStarting() == true)
                {
                    MouseLoactionlabel.Text = $"Starting point X:{e.X} | Y:{e.Y}";
                    DrawRectangleOnCanvas(e);
                }
            }
            else if (OvalradioButton.Checked)
            {
                SBuilder.setCurrentStartingState(true);

                if (SBuilder.isStarting() == true)
                {
                    MouseLoactionlabel.Text = $"Starting point X:{e.X} | Y:{e.Y}";
                    DrawOvalOnCanvas(e);
                }
            }
        }



        private void DrawLineOnCanvas(MouseEventArgs e)
        {//////////
            if (SBuilder.isStarting() == true)
            {

                //SPoint = new Point(e.X, e.Y);

                //StartingPoint = false;

                SBuilder.setSPoint(new Point(e.X, e.Y));
                SBuilder.setCurrentStartingState(false);

                MouseLoactionlabel.Text = $"Starting point X:{SBuilder.getSPoint().X} | Y:{SBuilder.getSPoint().Y}";

            }
            else
            {

                //EPoint = new Point(e.X, e.Y);
                //StartingPoint = true;
                // graphics.DrawLine(pen, SPoint, EPoint);
                //ListOfLinePoints.Add(new Tuple<Point,Point>(SPoint, EPoint));



                SBuilder.setEPoint(new Point(e.X, e.Y));
                SBuilder.setCurrentStartingState(true);

                SBuilder.DrawALine();
                SBuilder.AddLineToListOfLines(new Tuple<Point, Point>(SBuilder.getSPoint(), SBuilder.getEPoint()));


                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }
        }

        private void DrawRectangleOnCanvas(MouseEventArgs e)
        {

            if (SBuilder.isStarting() == true)
            {

                //SPoint = new Point(e.X, e.Y);

                //StartingPoint = false;

                SBuilder.setSPoint(new Point(e.X, e.Y));
                SBuilder.setCurrentStartingState(false);

                MouseLoactionlabel.Text = $"Starting point X:{SBuilder.getSPoint().X} | Y:{SBuilder.getSPoint().Y}";

            }
            else
            {

                //EPoint = new Point(e.X, e.Y);
                //StartingPoint = true;
                // graphics.DrawLine(pen, SPoint, EPoint);
                //ListOfLinePoints.Add(new Tuple<Point,Point>(SPoint, EPoint));



                SBuilder.setEPoint(new Point(e.X, e.Y));
                SBuilder.setCurrentStartingState(true);
                SBuilder.DrawNewRectangle();
                Console.WriteLine("HIII");
                //draw rectangle
                //add point to list of rectangle 
                SBuilder.AddRectangleToListOfRectangles();
                /// SBuilder.AddLineToListOfLines(new Tuple<Point, Point>(SBuilder.getSPoint(), SBuilder.getEPoint()));


                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }




        }

        private void DrawOvalOnCanvas(MouseEventArgs e)
        {
            if (SizeSmallradioButton.Checked)
            {
                rect.X = e.X;
                rect.Y = e.Y;
                graphics.DrawEllipse(pen, rect);
            }
            else if (SizeMediumradioButton.Checked)
            {
                rect.X = e.X;
                rect.Y = e.Y;
                graphics.DrawEllipse(pen, rect);
            }
            else
            {
                rect.X = e.X;
                rect.Y = e.Y;
                graphics.DrawEllipse(pen, rect);
            }

            ListRecsForEllipse.Add(rect);
        }



        private void Size_CheckedChanged(object sender, EventArgs e)
        {
            if (LineradioButton.Checked)
            {
                ChangePenWidth(sender);
            }
            else if (RectangleradioButton.Checked)
            {
                ChangeRectangleSize();
                ChangePenWidth(sender);
            }
            else if (OvalradioButton.Checked)
            {
                ChangeRectangleSize();
                ChangePenWidth(sender);
            }
        }


        private void ChangeRectangleSize()
        {
            if (SizeSmallradioButton.Checked)
            {

                rect = new Rectangle();
                rect.Width = 100;
                rect.Height = 50;
            }
            else if (SizeMediumradioButton.Checked)
            {

                rect = new Rectangle();
                rect.Width = 150;
                rect.Height = 100;
            }
            else
            {

                rect = new Rectangle();
                rect.Width = 200;
                rect.Height = 150;
            }
        }


        private void ChangePenWidth(Object sender)
        {/////////////
            string checkedName = ((RadioButton)sender).Name;

            if (checkedName == "SizeSmallradioButton")
            {
                ///pen.Width = 4.0F;
                SBuilder.setPenWidth(4.0F);
            }
            else if (checkedName == "SizeMediumradioButton")
            {
                //pen.Width = 10.0F;
                SBuilder.setPenWidth(10.0F);
            }
            else
            {

                SBuilder.setPenWidth(20.0F);
                //pen.Width = 20.0F;
            }
        }


        private void ChooseColorbutton_Click(object sender, EventArgs e)
        {/////////////
            OpenColorChooser();
        }



        private void OpenColorChooser()
        {
            ////////////////////
            //Try catch 
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                //pen.Color = colorDlg.Color;
                SBuilder.setPenColor(colorDlg.Color);
                ColorIndicatorlabel.BackColor = colorDlg.Color;
            }
        }

        private void Canvaspanel_paint(object sender, PaintEventArgs e)
        {//////////////
            SBuilder.RedrawCanvas();



            //if (ListOfLinePoints.Count != 0)
            // {
            //    foreach (var pointPair in ListOfLinePoints)
            //     {
            //         graphics.DrawLine(pen, pointPair.Item1, pointPair.Item2);
            //     }
            //  }

            //  if (ListOfRectangles.Count != 0)
            // {
            //     foreach (var rectangle in ListOfRectangles)
            //     {
            //         graphics.DrawRectangle(pen, rectangle);
            //     }
            //  }

            //  if (ListRecsForEllipse.Count != 0)
            //  {
            //      foreach (var rectangle in ListRecsForEllipse)
            //    {
            //      graphics.DrawEllipse(pen, rectangle);
            //  }
            // }
        }



    }
}


public class ShapesBuilder : Form
    {
        public Graphics graphics;
        public bool StartingPoint = true;
        private List<Tuple<Point, Point>> ListOfLinePoints = new List<Tuple<Point, Point>>();
        private List<Rectangle> ListOfRectangles = new List<Rectangle>();
        private List<Rectangle> ListRecsForEllipse = new List<Rectangle>();
        private Point SPoint;
        private Point EPoint;
        private Pen pen = new Pen(Color.Black, 4.0F);
        private Rectangle rect = new Rectangle();


        public ShapesBuilder(Graphics g)
        {
            this.graphics = g;
        }



        public void ClearListsOfShapes()
        {
            ListOfLinePoints.Clear();
            ListOfRectangles.Clear();
            ListRecsForEllipse.Clear();
        }

        public bool isStarting()
        {
            return StartingPoint;
        }

        public void setCurrentStartingState(bool state)
        {
            StartingPoint = state;
        }


        public void setSPoint(Point p1)
        {
            SPoint = p1;
        }

        public Point getSPoint()
        {




            return SPoint;

        }



        public void setEPoint(Point p1)
        {
            EPoint = p1;
        }

        public Point getEPoint()
        {


            return EPoint;

        }


        public void DrawALine()
        {
            this.graphics.DrawLine(this.pen, this.SPoint, this.EPoint);
        }

        public void AddLineToListOfLines(Tuple<Point, Point> points)
        {
            this.ListOfLinePoints.Add(points);
        }

        public void AddRectangleToListOfRectangles()
        {

            this.ListOfRectangles.Add(this.rect);
        }

        private void createNewRectangle()
        {

            // get top left 
            //Try doing it with only one point instead. 
            //User should input width and height. 


            Point topLeft;
            Point bottomRight;

            if (this.SPoint.X < EPoint.X)
            {
                topLeft = this.SPoint;
                bottomRight = this.EPoint;
            }
            else
            {

            }



            ///var size = new Size(topLeft.X - bottomRight.X, topLeft.Y - bottomRight.Y);

            //int minX = Math.Min(SPoint.X, EPoint.X);
            //int maxX = Math.Max(SPoint.X, EPoint.X);
            //int minY = Math.Min(SPoint.Y, EPoint.Y);
            //int maxY = Math.Max(SPoint.Y, EPoint.Y);

            Console.WriteLine("drawwing");
            //this.rect = new Rectangle(topLeft,size);
            //this.graphics.DrawRectangle(this.pen, new Rectangle(topLeft, size));
            //this.ListRecsForEllipse.Add(rect);
        }

        public void DrawNewRectangle()
        {

            createNewRectangle();
            //this.graphics.DrawRectangle(this.pen, this.rect);


        }



        public void AddEllipseToListOfEllipses(Rectangle rect)
        {

            this.ListRecsForEllipse.Add(rect);

        }


        public void RedrawCanvas()
        {
            if (this.ListOfLinePoints.Count != 0)
            {
                foreach (var pointPair in this.ListOfLinePoints)
                {
                    graphics.DrawLine(pen, pointPair.Item1, pointPair.Item2);
                }
            }

            if (this.ListOfRectangles.Count != 0)
            {
                foreach (var rectangle in this.ListOfRectangles)
                {
                    graphics.DrawRectangle(pen, rectangle);
                }
            }

            if (this.ListRecsForEllipse.Count != 0)
            {
                foreach (var rectangle in this.ListRecsForEllipse)
                {
                    graphics.DrawEllipse(pen, rectangle);
                }
            }
        }



        public void setPenColor(Color c)
        {
            this.pen.Color = c;
        }

        public Color getPenColor()
        {
            return this.pen.Color;
        }



        public void setPenWidth(float width)
        {
            this.pen.Width = width;
        }

        public float getPenWidth()
        {
            return this.pen.Width;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShapesBuilder
            // 
            this.ClientSize = new System.Drawing.Size(926, 471);
            this.Name = "ShapesBuilder";
            this.ResumeLayout(false);

        }
    }












    