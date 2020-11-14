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
        private List<Rectangle> ListOfRectangles = new List<Rectangle>();
        private List<Rectangle> ListRecsForEllipse = new List<Rectangle>();
        private Pen pen = new Pen(Color.Black, 4.0F);
        private Rectangle rect = new Rectangle(0, 0, 100, 50);
        private ShapesBuilder SBuilder;




        public PainterForm()
        {
            ////////
            InitializeComponent();
            graphics = Canvaspanel.CreateGraphics();
            SBuilder = new ShapesBuilder(graphics);
            HideDimensionsSection();
        }




        //Clears the Canvas.
        private void Clearbutton_Click(object sender, EventArgs e)
        {
            ///////
            Canvaspanel.Invalidate();
            SBuilder.ClearListsOfShapes();
 
        }


        private void HideDimensionsSection()
        {
            Dimensions_groupBox.Visible = false;
            Width_label.Visible = false;
            Height_label.Visible = false;
            Width_textBox.Visible = false;
            Height_textBox.Visible = false;
        }

        private void RevealDimensionsSection()
        {
            Dimensions_groupBox.Visible = true;
            Width_label.Visible = true;
            Height_label.Visible = true;
            Width_textBox.Visible = true;
            Height_textBox.Visible = true;
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
                SBuilder.setSPoint(new Point(e.X, e.Y));
                SBuilder.setCurrentStartingState(false);
                MouseLoactionlabel.Text = $"Starting point X:{SBuilder.getSPoint().X} | Y:{SBuilder.getSPoint().Y}";
            }
            else
            {
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
                SBuilder.setSPoint(new Point(e.X, e.Y));
                SBuilder.setCurrentStartingState(true);
                Tuple<int, int> dimnesions = GetRectangleDimensions();
                SBuilder.DrawNewRectangle(dimnesions.Item1,dimnesions.Item2);
                SBuilder.AddRectangleToListOfRectangles();
                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
                //MouseLoactionlabel.Text = $"Starting point X:{SBuilder.getSPoint().X} | Y:{SBuilder.getSPoint().Y}";

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
            
                ChangePenWidth(sender);
            }
            else if (OvalradioButton.Checked)
            {
              
                ChangePenWidth(sender);
            }
        }


        private Tuple<int, int>  GetRectangleDimensions()
        {

            

            if (Width_textBox.Text.Length != 0 && Height_textBox.Text.Length != 0)
            {
                int width = int.Parse(Width_textBox.Text);
                int height = int.Parse(Height_textBox.Text);
                return new Tuple<int, int>(width, height);
            }

            return new Tuple<int, int>(0, 0);
        }


        private void ChangePenWidth(Object sender)
        {/////////////
            string checkedName = ((RadioButton)sender).Name;

            if (checkedName == "SizeSmallradioButton")
            {
            
                SBuilder.setPenWidth(4.0F);
            }
            else if (checkedName == "SizeMediumradioButton")
            {
        
                SBuilder.setPenWidth(10.0F);
            }
            else
            {

                SBuilder.setPenWidth(20.0F);
        
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
        }

        private void ShapeCheckChange(object sender, EventArgs e)
        {
            if (LineradioButton.Checked)
            {
                HideDimensionsSection();
            }
            else if (RectangleradioButton.Checked)
            {
                RevealDimensionsSection();
            }
            else if (OvalradioButton.Checked)
            {
                RevealDimensionsSection();
            }
        }


        //Prevents user from inputting anything but integers and floats, flaot only to one decimal point.
        private void TextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            ///Allow only integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

          
            
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

        

        public void DrawNewRectangle(int width, int height)
        {

        
        //this.graphics.DrawRectangle(this.pen, this.rect);
        Size size = new Size((int)width, (int)height);

        this.rect = new Rectangle(SPoint, size);
        this.graphics.DrawRectangle(this.pen, this.rect);
        this.ListOfRectangles.Add(rect);

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

        
    }












    