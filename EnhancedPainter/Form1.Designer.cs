namespace EnhancedPainter
{
    partial class PainterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvaspanel = new System.Windows.Forms.Panel();
            this.ShapesGroupbox = new System.Windows.Forms.GroupBox();
            this.OvalradioButton = new System.Windows.Forms.RadioButton();
            this.RectangleradioButton = new System.Windows.Forms.RadioButton();
            this.LineradioButton = new System.Windows.Forms.RadioButton();
            this.SizegroupBox = new System.Windows.Forms.GroupBox();
            this.SizeLargeradioButton = new System.Windows.Forms.RadioButton();
            this.SizeMediumradioButton = new System.Windows.Forms.RadioButton();
            this.SizeSmallradioButton = new System.Windows.Forms.RadioButton();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.ChooseColorbutton = new System.Windows.Forms.Button();
            this.ColorIndicatorlabel = new System.Windows.Forms.Label();
            this.MouseLoactionlabel = new System.Windows.Forms.Label();
            this.TitlelabelForMouseLocation = new System.Windows.Forms.Label();
            this.Width_textBox = new System.Windows.Forms.TextBox();
            this.Height_textBox = new System.Windows.Forms.TextBox();
            this.Dimensions_groupBox = new System.Windows.Forms.GroupBox();
            this.Height_label = new System.Windows.Forms.Label();
            this.Width_label = new System.Windows.Forms.Label();
            this.ShapesGroupbox.SuspendLayout();
            this.SizegroupBox.SuspendLayout();
            this.Dimensions_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvaspanel
            // 
            this.Canvaspanel.BackColor = System.Drawing.Color.White;
            this.Canvaspanel.Location = new System.Drawing.Point(13, 12);
            this.Canvaspanel.Name = "Canvaspanel";
            this.Canvaspanel.Size = new System.Drawing.Size(695, 466);
            this.Canvaspanel.TabIndex = 0;
            this.Canvaspanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvaspanel_paint);
            this.Canvaspanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvaspanel_MouseDown);
            // 
            // ShapesGroupbox
            // 
            this.ShapesGroupbox.Controls.Add(this.OvalradioButton);
            this.ShapesGroupbox.Controls.Add(this.RectangleradioButton);
            this.ShapesGroupbox.Controls.Add(this.LineradioButton);
            this.ShapesGroupbox.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapesGroupbox.Location = new System.Drawing.Point(714, 12);
            this.ShapesGroupbox.Name = "ShapesGroupbox";
            this.ShapesGroupbox.Size = new System.Drawing.Size(211, 140);
            this.ShapesGroupbox.TabIndex = 1;
            this.ShapesGroupbox.TabStop = false;
            this.ShapesGroupbox.Text = "Shapes";
            // 
            // OvalradioButton
            // 
            this.OvalradioButton.AutoSize = true;
            this.OvalradioButton.Location = new System.Drawing.Point(6, 94);
            this.OvalradioButton.Name = "OvalradioButton";
            this.OvalradioButton.Size = new System.Drawing.Size(83, 29);
            this.OvalradioButton.TabIndex = 2;
            this.OvalradioButton.TabStop = true;
            this.OvalradioButton.Text = "Oval";
            this.OvalradioButton.UseVisualStyleBackColor = true;
            this.OvalradioButton.CheckedChanged += new System.EventHandler(this.ShapeCheckChange);
            // 
            // RectangleradioButton
            // 
            this.RectangleradioButton.AutoSize = true;
            this.RectangleradioButton.Location = new System.Drawing.Point(6, 62);
            this.RectangleradioButton.Name = "RectangleradioButton";
            this.RectangleradioButton.Size = new System.Drawing.Size(147, 29);
            this.RectangleradioButton.TabIndex = 1;
            this.RectangleradioButton.TabStop = true;
            this.RectangleradioButton.Text = "Rectangle";
            this.RectangleradioButton.UseVisualStyleBackColor = true;
            this.RectangleradioButton.CheckedChanged += new System.EventHandler(this.ShapeCheckChange);
            // 
            // LineradioButton
            // 
            this.LineradioButton.AutoSize = true;
            this.LineradioButton.Checked = true;
            this.LineradioButton.Location = new System.Drawing.Point(6, 29);
            this.LineradioButton.Name = "LineradioButton";
            this.LineradioButton.Size = new System.Drawing.Size(79, 29);
            this.LineradioButton.TabIndex = 0;
            this.LineradioButton.TabStop = true;
            this.LineradioButton.Text = "Line";
            this.LineradioButton.UseVisualStyleBackColor = true;
            this.LineradioButton.CheckedChanged += new System.EventHandler(this.ShapeCheckChange);
            // 
            // SizegroupBox
            // 
            this.SizegroupBox.Controls.Add(this.SizeLargeradioButton);
            this.SizegroupBox.Controls.Add(this.SizeMediumradioButton);
            this.SizegroupBox.Controls.Add(this.SizeSmallradioButton);
            this.SizegroupBox.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizegroupBox.Location = new System.Drawing.Point(931, 12);
            this.SizegroupBox.Name = "SizegroupBox";
            this.SizegroupBox.Size = new System.Drawing.Size(202, 140);
            this.SizegroupBox.TabIndex = 2;
            this.SizegroupBox.TabStop = false;
            this.SizegroupBox.Text = "Size";
            // 
            // SizeLargeradioButton
            // 
            this.SizeLargeradioButton.AutoSize = true;
            this.SizeLargeradioButton.Location = new System.Drawing.Point(11, 96);
            this.SizeLargeradioButton.Name = "SizeLargeradioButton";
            this.SizeLargeradioButton.Size = new System.Drawing.Size(96, 29);
            this.SizeLargeradioButton.TabIndex = 3;
            this.SizeLargeradioButton.TabStop = true;
            this.SizeLargeradioButton.Text = "Large";
            this.SizeLargeradioButton.UseVisualStyleBackColor = true;
            this.SizeLargeradioButton.CheckedChanged += new System.EventHandler(this.Size_CheckedChanged);
            // 
            // SizeMediumradioButton
            // 
            this.SizeMediumradioButton.AutoSize = true;
            this.SizeMediumradioButton.Location = new System.Drawing.Point(11, 64);
            this.SizeMediumradioButton.Name = "SizeMediumradioButton";
            this.SizeMediumradioButton.Size = new System.Drawing.Size(123, 29);
            this.SizeMediumradioButton.TabIndex = 2;
            this.SizeMediumradioButton.TabStop = true;
            this.SizeMediumradioButton.Text = "Medium";
            this.SizeMediumradioButton.UseVisualStyleBackColor = true;
            this.SizeMediumradioButton.CheckedChanged += new System.EventHandler(this.Size_CheckedChanged);
            // 
            // SizeSmallradioButton
            // 
            this.SizeSmallradioButton.AutoSize = true;
            this.SizeSmallradioButton.Checked = true;
            this.SizeSmallradioButton.Location = new System.Drawing.Point(12, 29);
            this.SizeSmallradioButton.Name = "SizeSmallradioButton";
            this.SizeSmallradioButton.Size = new System.Drawing.Size(95, 29);
            this.SizeSmallradioButton.TabIndex = 1;
            this.SizeSmallradioButton.TabStop = true;
            this.SizeSmallradioButton.Text = "Small";
            this.SizeSmallradioButton.UseVisualStyleBackColor = true;
            this.SizeSmallradioButton.CheckedChanged += new System.EventHandler(this.Size_CheckedChanged);
            // 
            // Clearbutton
            // 
            this.Clearbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Clearbutton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clearbutton.Location = new System.Drawing.Point(727, 439);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(216, 38);
            this.Clearbutton.TabIndex = 4;
            this.Clearbutton.Text = "Clear";
            this.Clearbutton.UseVisualStyleBackColor = false;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // ChooseColorbutton
            // 
            this.ChooseColorbutton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseColorbutton.Location = new System.Drawing.Point(975, 412);
            this.ChooseColorbutton.Name = "ChooseColorbutton";
            this.ChooseColorbutton.Size = new System.Drawing.Size(148, 65);
            this.ChooseColorbutton.TabIndex = 5;
            this.ChooseColorbutton.Text = "Choose Color";
            this.ChooseColorbutton.UseVisualStyleBackColor = true;
            this.ChooseColorbutton.Click += new System.EventHandler(this.ChooseColorbutton_Click);
            // 
            // ColorIndicatorlabel
            // 
            this.ColorIndicatorlabel.BackColor = System.Drawing.Color.Black;
            this.ColorIndicatorlabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorIndicatorlabel.Location = new System.Drawing.Point(1019, 368);
            this.ColorIndicatorlabel.Name = "ColorIndicatorlabel";
            this.ColorIndicatorlabel.Size = new System.Drawing.Size(56, 41);
            this.ColorIndicatorlabel.TabIndex = 6;
            // 
            // MouseLoactionlabel
            // 
            this.MouseLoactionlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.MouseLoactionlabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MouseLoactionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseLoactionlabel.Location = new System.Drawing.Point(727, 383);
            this.MouseLoactionlabel.Name = "MouseLoactionlabel";
            this.MouseLoactionlabel.Size = new System.Drawing.Size(216, 50);
            this.MouseLoactionlabel.TabIndex = 7;
            // 
            // TitlelabelForMouseLocation
            // 
            this.TitlelabelForMouseLocation.BackColor = System.Drawing.Color.Silver;
            this.TitlelabelForMouseLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitlelabelForMouseLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitlelabelForMouseLocation.Location = new System.Drawing.Point(727, 359);
            this.TitlelabelForMouseLocation.Name = "TitlelabelForMouseLocation";
            this.TitlelabelForMouseLocation.Size = new System.Drawing.Size(216, 24);
            this.TitlelabelForMouseLocation.TabIndex = 8;
            this.TitlelabelForMouseLocation.Text = "Mouse Location:";
            // 
            // Width_textBox
            // 
            this.Width_textBox.Location = new System.Drawing.Point(6, 71);
            this.Width_textBox.Name = "Width_textBox";
            this.Width_textBox.Size = new System.Drawing.Size(178, 33);
            this.Width_textBox.TabIndex = 11;
            this.Width_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxKeyPress);
            // 
            // Height_textBox
            // 
            this.Height_textBox.Location = new System.Drawing.Point(223, 71);
            this.Height_textBox.Name = "Height_textBox";
            this.Height_textBox.Size = new System.Drawing.Size(174, 33);
            this.Height_textBox.TabIndex = 12;
            this.Height_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxKeyPress);
            // 
            // Dimensions_groupBox
            // 
            this.Dimensions_groupBox.Controls.Add(this.Height_textBox);
            this.Dimensions_groupBox.Controls.Add(this.Height_label);
            this.Dimensions_groupBox.Controls.Add(this.Width_textBox);
            this.Dimensions_groupBox.Controls.Add(this.Width_label);
            this.Dimensions_groupBox.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dimensions_groupBox.Location = new System.Drawing.Point(720, 167);
            this.Dimensions_groupBox.Name = "Dimensions_groupBox";
            this.Dimensions_groupBox.Size = new System.Drawing.Size(403, 110);
            this.Dimensions_groupBox.TabIndex = 9;
            this.Dimensions_groupBox.TabStop = false;
            this.Dimensions_groupBox.Text = "Dimensions";
            // 
            // Height_label
            // 
            this.Height_label.BackColor = System.Drawing.Color.Silver;
            this.Height_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Height_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Height_label.Location = new System.Drawing.Point(275, 40);
            this.Height_label.Name = "Height_label";
            this.Height_label.Size = new System.Drawing.Size(80, 28);
            this.Height_label.TabIndex = 10;
            this.Height_label.Text = "Height:";
            // 
            // Width_label
            // 
            this.Width_label.BackColor = System.Drawing.Color.Silver;
            this.Width_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Width_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Width_label.Location = new System.Drawing.Point(53, 40);
            this.Width_label.Name = "Width_label";
            this.Width_label.Size = new System.Drawing.Size(72, 28);
            this.Width_label.TabIndex = 9;
            this.Width_label.Text = "Width:";
            // 
            // PainterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 494);
            this.Controls.Add(this.Dimensions_groupBox);
            this.Controls.Add(this.TitlelabelForMouseLocation);
            this.Controls.Add(this.MouseLoactionlabel);
            this.Controls.Add(this.ColorIndicatorlabel);
            this.Controls.Add(this.ChooseColorbutton);
            this.Controls.Add(this.Clearbutton);
            this.Controls.Add(this.SizegroupBox);
            this.Controls.Add(this.ShapesGroupbox);
            this.Controls.Add(this.Canvaspanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PainterForm";
            this.Text = "PainterForm";
            this.ShapesGroupbox.ResumeLayout(false);
            this.ShapesGroupbox.PerformLayout();
            this.SizegroupBox.ResumeLayout(false);
            this.SizegroupBox.PerformLayout();
            this.Dimensions_groupBox.ResumeLayout(false);
            this.Dimensions_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvaspanel;
        private System.Windows.Forms.GroupBox ShapesGroupbox;
        private System.Windows.Forms.RadioButton OvalradioButton;
        private System.Windows.Forms.RadioButton RectangleradioButton;
        private System.Windows.Forms.RadioButton LineradioButton;
        private System.Windows.Forms.GroupBox SizegroupBox;
        private System.Windows.Forms.RadioButton SizeLargeradioButton;
        private System.Windows.Forms.RadioButton SizeMediumradioButton;
        private System.Windows.Forms.RadioButton SizeSmallradioButton;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.Button ChooseColorbutton;
        private System.Windows.Forms.Label ColorIndicatorlabel;
        private System.Windows.Forms.Label MouseLoactionlabel;
        private System.Windows.Forms.Label TitlelabelForMouseLocation;
        private System.Windows.Forms.TextBox Width_textBox;
        private System.Windows.Forms.TextBox Height_textBox;
        private System.Windows.Forms.GroupBox Dimensions_groupBox;
        private System.Windows.Forms.Label Height_label;
        private System.Windows.Forms.Label Width_label;
    }
}

