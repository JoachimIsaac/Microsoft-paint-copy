/*
 
Name: Joachim Isaac 

Date:11/14/2020

Course: CMPS4143, Fall 2020, Dr. Stringfellow.

Purpose: To create painter program that makes use of radio buttons and mouse event handlers, menus, combo box and graphics concepts.
         This program draws lines, rectangles and ovals and also fills them.

Noted Extra Credit:
--> Implemented Clear Button
--> Customizable pen Size
--> Color Dialog Box 

 */

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
using System.Collections;

namespace EnhancedPainter
{


    public partial class PainterForm : Form
    {

        public Graphics graphics;
        private ShapesBuilder SBuilder;


        //Painter form constructor.
        public PainterForm()
        {

            InitializeComponent();

            //Creates graphics variable that is linked to the canvas we draw on.
            graphics = Canvaspanel.CreateGraphics();


            //Create and instance of the class that holds all the objects we need to use, pen, graphics etc.
            SBuilder = new ShapesBuilder(graphics);


            //Hide the dimensions sections, since the default drawing setting is drawing lines.
            HideDimensionsSection();
        }




        //When clear button is clicked it clears the Canvas.
        private void Clearbutton_Click(object sender, EventArgs e)
        {

            Canvaspanel.Invalidate();

            //Clears all our data structures that hold the current lines and shapes on the canvas.
            SBuilder.ClearListsOfShapes();

        }



        //This reaveals the entire dimensions section.
        private void RevealDimensionsSection()
        {
            Dimensions_groupBox.Visible = true;
            Width_label.Visible = true;
            Height_label.Visible = true;
            Width_textBox.Visible = true;
            Height_textBox.Visible = true;
            Width_textBox.Text = "";
            Height_textBox.Text = "";
        }



        //Hides the entire dimensions section.
        private void HideDimensionsSection()
        {
            Dimensions_groupBox.Visible = false;
            Width_label.Visible = false;
            Height_label.Visible = false;
            Width_textBox.Visible = false;
            Height_textBox.Visible = false;
        }




        //Reveals size section and the line radio button.
        private void RevealSizeSection()
        {
            SizegroupBox.Visible = true;
            SizeSmallradioButton.Visible = true;
            SizeMediumradioButton.Visible = true;
            SizeLargeradioButton.Visible = true;
            LineradioButton.Visible = true;
        }



        //Hides the size section and the line radio button.
        //Hides the line button because you can't fill a line.
        private void HideSizeSection()
        {
            SizegroupBox.Visible = false;
            SizeSmallradioButton.Visible = false;
            SizeMediumradioButton.Visible = false;
            SizeLargeradioButton.Visible = false;
            LineradioButton.Visible = false;
        }



        //Triggers on mouse down on the panel.
        //Decisions are made based on what radio button is currently checked.
        private void Canvaspanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //if the line radio button is check, call the draw line fucntion.
                if (LineradioButton.Checked)
                {
                    if (Draw_radioButton.Checked)
                    {
                        DrawLineOnCanvas(e);
                    }
                }
                else if (RectangleradioButton.Checked)//if the rectangle radio button is checked 
                {                                     //we call the draw rectangle fucntion or the fill. 
                    SBuilder.setCurrentStartingState(true);

                    if (SBuilder.isStarting() == true)
                    {
                        MouseLoactionlabel.Text = $"Starting point X:{e.X} | Y:{e.Y}";

                        //If draw radio button is checked and we have valid dimensions draw a retangle on canvas.
                        if (Draw_radioButton.Checked && Width_textBox.Text.Length != 0 && Height_textBox.Text.Length != 0)
                        {
                            DrawRectangleOnCanvas(e);
                        }
                        else
                        {//if fill radio button is checked fill the rectangle .
                            FillRectangleOnCanvas(e);
                        }
                    }
                }
                else if (OvalradioButton.Checked)//if the oval radio button is checked
                {                               //we call the draw oval function.
                    SBuilder.setCurrentStartingState(true);

                    // if this is the starting point.
                    if (SBuilder.isStarting() == true)
                    {
                        MouseLoactionlabel.Text = $"Starting point X:{e.X} | Y:{e.Y}";

                        //If draw radio button is checked and and both text boxes are filled..
                        if (Draw_radioButton.Checked && Width_textBox.Text.Length != 0 && Height_textBox.Text.Length != 0)
                        {
                            DrawOvalOnCanvas(e);
                        }
                        else//If fill radio button is checked, fill the oval/Ellispe .
                        {
                            FillEllispeOnCanvas(e);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //Draws the line on canvas
        private void DrawLineOnCanvas(MouseEventArgs e)
        {
            if (SBuilder.isStarting() == true)//if this is the starting point.
            {
                SBuilder.setSPoint(new Point(e.X, e.Y));//set the current point where mouse was clicked.

                //set the current starting state to false, the next time we click we are going to get an ending point.
                SBuilder.setCurrentStartingState(false);

                //Display the mouse position.
                MouseLoactionlabel.Text = $"Starting point X:{SBuilder.getSPoint().X} | Y:{SBuilder.getSPoint().Y}";
            }
            else
            {
                //set current end point.
                SBuilder.setEPoint(new Point(e.X, e.Y));

                // reset our start state.
                SBuilder.setCurrentStartingState(true);

                //Draw our line.
                SBuilder.DrawALine();

                //Create a tuple of the current pen and start and end points.
                Tuple<Pen, Point, Point> pen_and_points = new Tuple<Pen, Point, Point>((Pen)SBuilder.getPen().Clone(), SBuilder.getSPoint(), SBuilder.getEPoint());

                //Add this tuple to the list.
                SBuilder.AddLineToListOfLines(pen_and_points);

                //Display the mouse end point location.
                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }
        }





        //Draws the rectangle on the canvas.
        private void DrawRectangleOnCanvas(MouseEventArgs e)
        {

            //Ensure our state always starts as true for a rectangle.
            SBuilder.setCurrentStartingState(true);


            //We only need to click once to draw.
            if (SBuilder.isStarting() == true)
            {
                //Set current start point.
                SBuilder.setSPoint(new Point(e.X, e.Y));

                //Get the current rectangle dimensions.
                Tuple<int, int> dimnesions = GetRectangleDimensions();

                //Draw rectangle on canvas.
                SBuilder.DrawNewRectangle(dimnesions.Item1, dimnesions.Item2);

                //Display mouse location.
                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }
        }





        //Draws the Oval/ellispe on the canvas.
        private void DrawOvalOnCanvas(MouseEventArgs e)
        {
            //Ensure our state always starts as true for a shape.
            SBuilder.setCurrentStartingState(true);

            // We only need to click once to draw.
            if (SBuilder.isStarting() == true)
            {
                //Set current start point.
                SBuilder.setSPoint(new Point(e.X, e.Y));

                //Get the current  dimensions.
                Tuple<int, int> dimnesions = GetRectangleDimensions();

                //Draw Ellipse on canvas.
                SBuilder.DrawNewEllipse(dimnesions.Item1, dimnesions.Item2);

                //Display mouse location.
                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }
        }





        //Fills the rectangle.
        private void FillRectangleOnCanvas(MouseEventArgs e)
        {
            //Create point of current position. 
            Point current_point = new Point(e.X, e.Y);

            //If this point is in the area of a valid rectangle fill it.
            this.SBuilder.Fill_Closest_Shape(current_point, true);
        }







        private void FillEllispeOnCanvas(MouseEventArgs e)
        {
            //Create point for current position.
            Point current_point = new Point(e.X, e.Y);

            //If this point is in the area of a valid Ellispe fill it.
            //Since we pass in false, then it is not a rectangle, it is an Ellispe.
            this.SBuilder.Fill_Closest_Shape(current_point, false);
        }




        //Changes the size of the pen width .
        private void Size_CheckedChanged(object sender, EventArgs e)
        {
            //Change width of pen when size is changed 
             ChangePenWidth(sender);
           
        }





        private Tuple<int, int> GetRectangleDimensions()
        {
            try
            {
                //Grabs the dimensions within the width and height text boxes.
                //and returns a tuple with the dimensions.
                if (Width_textBox.Text.Length != 0 && Height_textBox.Text.Length != 0)
                {
                    int width = int.Parse(Width_textBox.Text);
                    int height = int.Parse(Height_textBox.Text);

                    return new Tuple<int, int>(width, height);
                }
                else
                {//default to zero if both text boxes are not filled.
                    return new Tuple<int, int>(0, 0);
                }
            }
            catch(Exception ex)
            {
              MessageBox.Show(ex.Message, "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
              return new Tuple<int, int>(0, 0);
            }

            
        }





        //Handles the changing of text width based on which radio button is selected.
        private void ChangePenWidth(Object sender)
        {

            string checkedName = ((RadioButton)sender).Name;

            //Changes size on checked name. 
            if (checkedName == "SizeSmallradioButton")//smallest
            {
                SBuilder.setPenWidth(4.0F);
            }
            else if (checkedName == "SizeMediumradioButton")//medium
            {
                SBuilder.setPenWidth(10.0F);
            }
            else//largest
            {
                SBuilder.setPenWidth(20.0F);
            }
        }





        //onclick even for the color button, it calls the function that opens the color dialog.
        private void ChooseColorbutton_Click(object sender, EventArgs e)
        {
            OpenColorChooser();//opens color chooser dialog box.
        }






        //Open's color chooser dialog box.
        private void OpenColorChooser()
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                //sets the pen color to what the user chooses.
                SBuilder.setPenColor(colorDlg.Color);

                ColorIndicatorlabel.BackColor = colorDlg.Color;
            }
        }






        //Redraws the canvas when the paint event is triggered.
        private void Canvaspanel_paint(object sender, PaintEventArgs e)
        {
            SBuilder.RedrawCanvas();//redraws the canvas.
        }






        //When a shape radio button is changed, hide dimension's group box and it's content's or reveal them.
        private void ShapeCheckChange(object sender, EventArgs e)
        {
            if (LineradioButton.Checked)//if line button is checked hide the dimensions section.
            {
                HideDimensionsSection();
            }
            else
            {
                if (Fill_radioButton.Checked != true) //if the fill button is not checked reveal the dimensions section. 
                {
                    RevealDimensionsSection();
                }
            }
        }




        //Hides or reveals size section and/or dimensions sections when we click draw or fill.
        private void Draw_Fill_CheckedChanged(object sender, EventArgs e)
        {
            if (Draw_radioButton.Checked)//if draw button is checked reveal the size section.
            {
                RevealSizeSection();

                if (LineradioButton.Checked != true)//if the line button is not checked reveal dimensions section.
                {
                    RevealDimensionsSection();
                }
            }
            else//if the draw button is not checked hide size section and hide dimension section.
            {
                HideSizeSection();
                HideDimensionsSection();
            }
        }



        //Prevents user from inputting anything, but positive integers.
        private void TextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            //prevents the user from inputting anything but postive integers.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }




    }
}



//Shape builder class that holds all our shapes and graphics data structures.
public class ShapesBuilder : Form
{
    public Graphics graphics;

    private bool StartingPoint = true;

    private Point SPoint;
    private Point EPoint;

    private Pen pen = new Pen(Color.Black, 4.0F);
    private Rectangle rect = new Rectangle();

    private List<Tuple<Pen, Point, Point>> ListOfLinePoints = new List<Tuple<Pen, Point, Point>>();

    private List<Tuple<Pen, Rectangle>> ListOfRectangles = new List<Tuple<Pen, Rectangle>>();

    private List<Tuple<Pen, Rectangle>> ListRecsForEllipse = new List<Tuple<Pen, Rectangle>>();

    private Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle, bool, Color>> Rectangles_and_AreasToFill = new Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle, bool, Color>>();
    private Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle, bool, Color>> Ellipses_and_AreasToFill = new Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle, bool, Color>>();




    //Constructor 
    public ShapesBuilder(Graphics g)
    {
        this.graphics = g;
    }




    //Gets current pen
    public Pen getPen()
    {
        return this.pen;
    }




    //Sets pen's variable with a pen object
    public void setPen(Pen p)
    {
        this.pen = p;
    }



    //Sets pen's color 
    public void setPenColor(Color c)
    {
        this.pen.Color = c;
    }




    //Gets pen color 
    public Color getPenColor()
    {
        return this.pen.Color;
    }



    //Sets pen's width.
    public void setPenWidth(float width)
    {
        this.pen.Width = width;
    }




    //Gets pen's current width.
    public float getPenWidth()
    {
        return this.pen.Width;
    }





    //Sets the starting point.
    public void setSPoint(Point p1)
    {
        SPoint = p1;
    }





    //Gets the starting point.
    public Point getSPoint()
    {
        return SPoint;
    }




    //Sets the ending point.
    public void setEPoint(Point p1)
    {
        EPoint = p1;
    }



    //Gets the ending point.
    public Point getEPoint()
    {
        return EPoint;
    }




    //Returns true if the current clicking state is the starting point.
    public bool isStarting()
    {
        return StartingPoint;
    }





    //Clears all the points and shapes in our point/shapes lists and the Dictionaries.
    public void ClearListsOfShapes()
    {
        ListOfLinePoints.Clear();
        ListOfRectangles.Clear();
        ListRecsForEllipse.Clear();
        Rectangles_and_AreasToFill.Clear();
        Ellipses_and_AreasToFill.Clear();
    }




    //Sets the current starting state, either true or false.
    public void setCurrentStartingState(bool state)
    {
        StartingPoint = state;
    }




    //Adds points to list of points.
    public void AddLineToListOfLines(Tuple<Pen, Point, Point> pen_and_points)
    {
        this.ListOfLinePoints.Add(pen_and_points);
    }





    //Draws a line on the canvas 
    public void DrawALine()
    {
        this.graphics.DrawLine(this.pen, this.SPoint, this.EPoint);
    }





    //Draws rectangle on canvas
    public void DrawNewRectangle(int width, int height)
    {
        Size size = new Size(width, height);

        this.rect = new Rectangle(SPoint, size);

        this.graphics.DrawRectangle(this.pen, this.rect);

        //Create a tuple that holds the pen and rectangle, clone ensures we have a deep copy of the pen, so that we remeber the original color.
        Tuple<Pen, Rectangle> pen_and_rectangle = new Tuple<Pen, Rectangle>((Pen)this.pen.Clone(), this.rect);


        //Create a tuple that holds the pen,rectangle, filled state represented by bool, and Color.
        //Clone ensures we have a deep copy of the pen, so that we remeber the original color.
        Tuple<Pen, Rectangle, bool, Color> pen_and_rectangle_and_state = new Tuple<Pen, Rectangle, bool, Color>((Pen)this.pen.Clone(), this.rect, false, Color.Transparent);

        //Tuple which hold the current starting point and the dimensions we have for the shape.
        Tuple<Point, int, int> point_and_dimensions = new Tuple<Point, int, int>(SPoint, width, height);


        //Add the pen and rectangle tuple to our list that holds all of them.
        this.ListOfRectangles.Add(pen_and_rectangle);


        //Add the tuple of point and dimensions as the key of our dictionary and the tuple with the pen, rectangle, fill state and color as the value.
        this.Rectangles_and_AreasToFill.Add(point_and_dimensions, pen_and_rectangle_and_state);

    }


    //Draws Ellipse on canvas
    public void DrawNewEllipse(int width, int height)
    {
        Size size = new Size(width, height);

        this.rect = new Rectangle(SPoint, size);

        this.graphics.DrawEllipse(this.pen, this.rect);

        //Create a tuple that holds the pen and rectangle, clone ensures we have a deep copy of the pen, so that we remember the original color.
        Tuple<Pen, Rectangle> pen_and_rectangle = new Tuple<Pen, Rectangle>((Pen)this.pen.Clone(), this.rect);


        //Create a tuple that holds the pen, rectangle, filled state represented by bool, and Color.
        //clone ensures we have a deep copy of the pen, so that we remeber the original color.
        Tuple<Pen, Rectangle, bool, Color> pen_and_rectangle_and_state = new Tuple<Pen, Rectangle, bool, Color>((Pen)this.pen.Clone(), this.rect, false, Color.Transparent);


        //Tuple which holds the current starting point and the dimensions we have for the shape.
        Tuple<Point, int, int> point_and_dimensions = new Tuple<Point, int, int>(SPoint, width, height);


        //Add the pen and Ellispes tuple to our list that holds all of them.
        this.ListRecsForEllipse.Add(pen_and_rectangle);


        //Add the tuple of point and dimensions as the key of our dictionary and the tuple with the pen, rectangle, fill state and color as the value.
        this.Ellipses_and_AreasToFill.Add(point_and_dimensions, pen_and_rectangle_and_state);

    }



    //Fills the closest rectangle/Ellispe to the current point
    public void Fill_Closest_Shape(Point current_point, bool isRectangle)
    {
        //Create brush to Fill.
        SolidBrush Brush = new SolidBrush(pen.Color);


        if (isRectangle)//If the current shape we are looking for is rectangle.
        {
            //Finds the Closest point to reactangle so that it fills it.
            Rectangle rectToFill = this.pick_rectangle_to_fill(this.Rectangles_and_AreasToFill, current_point);


            //If we get an invalid Rectangle or no Rectangle do nothing.
            if (rectToFill.Width == 0 && rectToFill.Height == 0 && rectToFill.X == 0 && rectToFill.Y == 0)
            {
                return;
            }
            else
            {
                //Fill the rectangle.
                graphics.FillRectangle(Brush, rectToFill);
            }
        }
        else//If the current shape we are looking for to fill is an Ellispe.
        {
            //Finds the nearest Ellispe to fill.
            Rectangle rectToFill = this.pick_rectangle_to_fill(this.Ellipses_and_AreasToFill, current_point);

            //If we get no Ellispe or an invalid Ellispe do nothing.
            if (rectToFill.Width == 0 && rectToFill.Height == 0 && rectToFill.X == 0 && rectToFill.Y == 0)
            {
                return;
            }
            else
            {   
                //Fill the Ellipse.
                graphics.FillEllipse(Brush, rectToFill);
            }
        }

    }



    //Picks closest area to current point
    private Rectangle pick_rectangle_to_fill(Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle, bool, Color>> shapes_and_points, Point current_point)
    {
        //Holds the max difference of the nearest area to fill and the current point area.
        int max_remainder = int.MinValue;// formula for differnece ==> area - (current_pointX * current_pointY)

        Rectangle rectToFill = new Rectangle(0, 0, 0, 0);//holds the rectangle to fill, we initailze it with an invalid rectangle.

        Tuple<Point, int, int> key = new Tuple<Point, int, int>(new Point(0, 0), 0, 0);// holds the key of the max_remainder.


        //kvp == key pair value
        foreach (var kvp in shapes_and_points)//Loops through the Dictionary of points, rectangles, colors and fill state.
        {
            Point firstPoint = new Point(kvp.Key.Item1.X, kvp.Key.Item1.Y);//loads first point 

            //We add the dimensions to the orginal points to get our second point
            //e.g point 0 + a width of 400 means our second point is 400.
            int secondPointX = kvp.Key.Item1.X + kvp.Key.Item2;
            int secondPointY = kvp.Key.Item1.Y + kvp.Key.Item3;
            Point secondPoint = new Point(secondPointX, secondPointY);//loads second point



            if (this.FoundPoint(firstPoint, secondPoint, current_point))//if the current point is within a shape's area. (returns tru or false)
            {
                //Calculate the current difference.
                int current_difference = (secondPoint.X * secondPoint.Y) - (current_point.X * current_point.Y);

                //If the current difference is the less than the max_remainder 
                //set the rectangle to fill, the current diffrence as the max remainder and the current key of the max_remainder.
                if (max_remainder < current_difference)
                {
                    max_remainder = current_difference;
                    rectToFill = kvp.Value.Item2;
                    key = kvp.Key;
                }
            }
        }

        // if the key with the largest remainder is in the Dictionary
        if (shapes_and_points.ContainsKey(key))
        {
            //Reset the value of the dictionary so that we change the current fill state to true and the current color 
            shapes_and_points[key] = new Tuple<Pen, Rectangle, bool, Color>(shapes_and_points[key].Item1, shapes_and_points[key].Item2, true, this.pen.Color);

            return rectToFill;
        }
        else
        {
            //if the key is not in the rectangle return this as a default.
            return new Rectangle(0, 0, 0, 0);
        }


    }


    //States whether the current point is within the area of the shapes near it.
    public bool FoundPoint(Point sp, Point ep, Point curr)
    {
        if (curr.X > sp.X && curr.X < ep.X && curr.Y > sp.Y && curr.Y < ep.Y)
        {
            return true;
        }
        else
        {
            return false;
        } 

        
    }




    //Redraws Canvas of all shapes that was are currently drawn.
    public void RedrawCanvas()
    {
        //Draws all lines in our line Points list.
        if (this.ListOfLinePoints.Count != 0)
        {
            foreach (var pointPair in this.ListOfLinePoints)
            {
                graphics.DrawLine(pointPair.Item1, pointPair.Item2, pointPair.Item3);
            }
        }


        //Draw all rectangles that are in our rectangle list.
        if (this.ListOfRectangles.Count != 0)
        {
            foreach (var pen_and_rect in this.ListOfRectangles)
            {
                graphics.DrawRectangle(pen_and_rect.Item1, pen_and_rect.Item2);
            }
        }


        //Draw all Ellipses that are in our Ellispe list.
        if (this.ListRecsForEllipse.Count != 0)
        {
            foreach (var pen_and_rect in this.ListRecsForEllipse)
            {
                graphics.DrawEllipse(pen_and_rect.Item1, pen_and_rect.Item2);
            }
        }


        //Refill all previously filled rectangles.
        if (this.Rectangles_and_AreasToFill.Count != 0)
        {
            foreach (var KvP in this.Rectangles_and_AreasToFill)
            {
                if (KvP.Value.Item3 == true)
                {
                    SolidBrush Brush = new SolidBrush(KvP.Value.Item4);
                    graphics.FillRectangle(Brush, KvP.Value.Item2);
                }
            }
        }


        //Refill all previously filled Ellipses.
        if (this.Ellipses_and_AreasToFill.Count != 0)
        {
            foreach (var KvP in this.Ellipses_and_AreasToFill)
            {
                if (KvP.Value.Item3 == true)
                {
                    SolidBrush Brush = new SolidBrush(KvP.Value.Item4);
                    graphics.FillEllipse(Brush, KvP.Value.Item2);
                }
            }
        }



    }







}












