﻿













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



        public PainterForm(){

            InitializeComponent();
            graphics = Canvaspanel.CreateGraphics();
            SBuilder = new ShapesBuilder(graphics);
            HideDimensionsSection();
        }




        //Clears the Canvas.
        private void Clearbutton_Click(object sender, EventArgs e)
        {
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

        private void HideSizeSection()
        {
            SizegroupBox.Visible = false;
            SizeSmallradioButton.Visible = false;
            SizeMediumradioButton.Visible = false;
            SizeLargeradioButton.Visible = false;
            LineradioButton.Visible = false;
        }

        private void RevealSizeSection()
        {
            SizegroupBox.Visible = true;
            SizeSmallradioButton.Visible = true;
            SizeMediumradioButton.Visible = true;
            SizeLargeradioButton.Visible = true;
            LineradioButton.Visible = true;
        }



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




        private void Canvaspanel_MouseDown(object sender, MouseEventArgs e)
        {
            /////////
            if (LineradioButton.Checked)
            {
                if (Draw_radioButton.Checked) {
                    DrawLineOnCanvas(e);
                }

            }
            else if (RectangleradioButton.Checked)
            {
                SBuilder.setCurrentStartingState(true);

                if (SBuilder.isStarting() == true)
                {
                    MouseLoactionlabel.Text = $"Starting point X:{e.X} | Y:{e.Y}";
                    if (Draw_radioButton.Checked)
                    {
                        DrawRectangleOnCanvas(e);
                    }
                    else
                    {
                        FillRectangleOnCanvas(e);
                    }
                }
            }
            else if (OvalradioButton.Checked)
            {
                SBuilder.setCurrentStartingState(true);

                if (SBuilder.isStarting() == true)
                {
                    MouseLoactionlabel.Text = $"Starting point X:{e.X} | Y:{e.Y}";

                    if (Draw_radioButton.Checked)
                    {
                        DrawOvalOnCanvas(e);
                    }
                    else
                    {

                        FillEllispeOnCanvas(e);
                    }
                }
            }
        }



        private void DrawLineOnCanvas(MouseEventArgs e)
        {
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

                Tuple<Pen, Point, Point> pen_and_points = new Tuple<Pen, Point, Point>((Pen)SBuilder.getPen().Clone(), SBuilder.getSPoint(), SBuilder.getEPoint());

                SBuilder.AddLineToListOfLines(pen_and_points);

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

                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }
        }

        private void DrawOvalOnCanvas(MouseEventArgs e)
        {
            if (SBuilder.isStarting() == true)
            {
                SBuilder.setSPoint(new Point(e.X, e.Y));

                SBuilder.setCurrentStartingState(true);

                Tuple<int, int> dimnesions = GetRectangleDimensions();

                SBuilder.DrawNewEllipse(dimnesions.Item1, dimnesions.Item2);

                MouseLoactionlabel.Text = $"Last Ending point X:{SBuilder.getEPoint().X} | Y:{SBuilder.getEPoint().Y}";
            }
        }



        private void FillRectangleOnCanvas(MouseEventArgs e)
        {
            Point current_point = new Point(e.X, e.Y);
            this.SBuilder.Fill_Closest_Rectangle(current_point,true);
        }


        private void FillEllispeOnCanvas(MouseEventArgs e)
        {
            Point current_point = new Point(e.X, e.Y);
            this.SBuilder.Fill_Closest_Rectangle(current_point, false);
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
        {
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




        //Actives the button 
        private void ChooseColorbutton_Click(object sender, EventArgs e)
        {
            OpenColorChooser();
        }




        //Open's color chooser dialog box.
        private void OpenColorChooser()
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                SBuilder.setPenColor(colorDlg.Color);
                ColorIndicatorlabel.BackColor = colorDlg.Color;
            }
        }



        //Redraws the canvas when the paint event is triggered.
        private void Canvaspanel_paint(object sender, PaintEventArgs e)
        {
            SBuilder.RedrawCanvas();
        }





        //When the shape radio button is changed, hide dimension's group box and it's content's or reveal them.
        private void ShapeCheckChange(object sender, EventArgs e)
        {
            if (LineradioButton.Checked)
            {
                HideDimensionsSection();
            }
            else
            {
                if(Fill_radioButton.Checked != true)
                {
                    RevealDimensionsSection();
                }
                

            }
        }





        //Prevents user from inputting anything but positive integers.
        private void TextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Draw_Fill_CheckedChanged(object sender, EventArgs e)
        {
            if (Draw_radioButton.Checked)
            {
                RevealSizeSection();
                
                if(LineradioButton.Checked != true)
                {
                    RevealDimensionsSection();
                }
            }
            else
            {
                HideSizeSection();
                HideDimensionsSection();
            }

        }
    }
}


public class ShapesBuilder : Form
    {
        public Graphics graphics;

        public bool StartingPoint = true;

        private Point SPoint;
        private Point EPoint;

        private Pen pen = new Pen(Color.Black, 4.0F);
        private Rectangle rect = new Rectangle();

        private List<Tuple<Pen,Point, Point>> ListOfLinePoints = new List<Tuple<Pen,Point, Point>>();

        private List<Tuple<Pen,Rectangle>> ListOfRectangles = new List<Tuple<Pen, Rectangle>>();

        private List<Tuple<Pen, Rectangle>> ListRecsForEllipse = new List<Tuple<Pen, Rectangle>>();

        Dictionary<Tuple<Point, int, int>,Tuple<Pen,Rectangle, bool,Color>>  Rectangles_and_AreasToFill = new Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle,bool,Color>>();
        Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle,bool,Color>> Ellipses_and_AreasToFill = new Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle, bool,Color>>();

 


    //Constructor 
    public ShapesBuilder(Graphics g){
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


        //Sets the setting point.
        public void setEPoint(Point p1)
        {
            EPoint = p1;
        }


        //Gets the setting point.
        public Point getEPoint()
        {
            return EPoint;
        }


        //Returns true if it is a starting point.
        public bool isStarting()
        {
                return StartingPoint;
         }

        
        //Clears all the points in our point lists.
        public void ClearListsOfShapes(){

            ListOfLinePoints.Clear();
            ListOfRectangles.Clear();
            ListRecsForEllipse.Clear();
            Rectangles_and_AreasToFill.Clear();

        }

        
        //Sets the current starting state, either true or false.
        public void setCurrentStartingState(bool state)
        {
            StartingPoint = state;
        }




    
        //Adds points to list of points.
        public void AddLineToListOfLines(Tuple<Pen,Point, Point> points)
        {
            this.ListOfLinePoints.Add(points);
        }


        //Draws a line on the canvas 
        public void DrawALine()
        {
            this.graphics.DrawLine((Pen)this.pen.Clone(), this.SPoint, this.EPoint);
        }



        //Draws rectangle on canvas
        public void DrawNewRectangle(int width, int height)
        {
            Size size = new Size(width, height);

            this.rect = new Rectangle(SPoint, size);

            this.graphics.DrawRectangle(this.pen, this.rect);

            Tuple<Pen, Rectangle> pen_and_rectangle = new Tuple<Pen, Rectangle>((Pen)this.pen.Clone(), this.rect);
            Tuple<Pen, Rectangle, bool,Color> pen_and_rectangle_and_state = new Tuple<Pen, Rectangle,bool,Color>((Pen)this.pen.Clone(), this.rect,false,Color.Transparent);
            Tuple<Point, int, int> point_and_dimensions = new Tuple<Point, int, int>(SPoint, width, height);

           this.ListOfRectangles.Add( pen_and_rectangle);


            
        //add to rectangle hashset 
        // this.Rectangle_and_AreaToFill.Add(point_and_dimensions, pen_and_rectangle);
        this.Rectangles_and_AreasToFill.Add(point_and_dimensions, pen_and_rectangle_and_state);
    }


        //Draws Ellipse on canvas
        public void DrawNewEllipse(int width, int height)
        {
            Size size = new Size(width, height);

            this.rect = new Rectangle(SPoint, size);

            this.graphics.DrawEllipse(this.pen, this.rect);

            Tuple<Pen, Rectangle> pen_and_rectangle = new Tuple<Pen, Rectangle>((Pen)this.pen.Clone(), this.rect);
            Tuple<Pen, Rectangle, bool,Color> pen_and_rectangle_and_state = new Tuple<Pen, Rectangle, bool,Color>((Pen)this.pen.Clone(), this.rect, false,Color.Transparent);
            Tuple<Point, int, int> point_and_dimensions = new Tuple<Point, int, int>(SPoint, width, height);

            this.ListRecsForEllipse.Add(pen_and_rectangle);


        this.Ellipses_and_AreasToFill.Add(point_and_dimensions, pen_and_rectangle_and_state);

    }



        public void Fill_Closest_Rectangle(Point current_point,bool isRectangle){

   

        SolidBrush Brush = new SolidBrush(pen.Color);

        if (isRectangle) {

            Rectangle rectToFill = this.pick_rectangle_to_fill(this.Rectangles_and_AreasToFill, current_point);
            graphics.FillRectangle(Brush, rectToFill);
        }
        else
        {
            Rectangle rectToFill = this.pick_rectangle_to_fill(this.Ellipses_and_AreasToFill, current_point);

            if (rectToFill.Width == 0 && rectToFill.Height == 0 && rectToFill.X == 0 && rectToFill.Y == 0)
            {
                return;
            }
            else
            { 
                graphics.FillEllipse(Brush, rectToFill);
            }
        }
        


        
        
        
        }


    public Rectangle pick_rectangle_to_fill(Dictionary<Tuple<Point, int, int>, Tuple<Pen, Rectangle,bool,Color>> shapes_and_points,Point current_point)
    {
        int max_remainder = int.MinValue;
        Rectangle rectToFill = new Rectangle(0,0,0,0);
        Tuple<Point, int, int> key = new Tuple<Point, int, int>(new Point(0,0),0,0);

        foreach (var kvp in shapes_and_points)
        {
            Point firstPoint = new Point(kvp.Key.Item1.X, kvp.Key.Item1.Y);
            Point secondPoint = new Point(kvp.Key.Item1.X + kvp.Key.Item2, kvp.Key.Item1.Y + kvp.Key.Item3);


           
                if (this.FoundPoint(firstPoint, secondPoint, current_point))
                {
                    int current_difference = (secondPoint.X * secondPoint.Y) - (current_point.X * secondPoint.Y);

                    if (max_remainder < current_difference)
                    {
                        max_remainder = current_difference;

                        rectToFill = kvp.Value.Item2;
                        key = kvp.Key;
                    }
                }
        }

        if (shapes_and_points.ContainsKey(key))
        {
            shapes_and_points[key] = new Tuple<Pen, Rectangle, bool, Color>(shapes_and_points[key].Item1, shapes_and_points[key].Item2, true, this.pen.Color);
            return rectToFill;
        }
        else
        {
            return new Rectangle(0, 0, 0, 0);
        }


    }


    public bool FoundPoint(Point sp, Point ep,Point curr)
    {
        if (curr.X > sp.X && curr.X < ep.X &&
           curr.Y > sp.Y && curr.Y < ep.Y)
            return true;

        return false;
    }


        //Redraws Canvas of all shapes that was are currently drawn.
        public void RedrawCanvas()
        {
        

        if (this.ListOfLinePoints.Count != 0)
            {
                foreach (var pointPair in this.ListOfLinePoints)
                {
                    graphics.DrawLine(pointPair.Item1, pointPair.Item2, pointPair.Item3);
                }
            }

            if (this.ListOfRectangles.Count != 0)
            {
                foreach (var pen_and_rect in this.ListOfRectangles)
                {
                    graphics.DrawRectangle(pen_and_rect.Item1, pen_and_rect.Item2);
                }
            }

            if (this.ListRecsForEllipse.Count != 0)
            {
                foreach (var pen_and_rect in this.ListRecsForEllipse)
                {
                   graphics.DrawEllipse(pen_and_rect.Item1, pen_and_rect.Item2);
                }
            }



            if(this.Rectangles_and_AreasToFill.Count != 0)
            {
                foreach(var KvP in this.Rectangles_and_AreasToFill){
                    
                    if(KvP.Value.Item3 == true)
                {
                    SolidBrush Brush = new SolidBrush(KvP.Value.Item4);
                    graphics.FillRectangle(Brush, KvP.Value.Item2);
                }

                }
            }

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












    