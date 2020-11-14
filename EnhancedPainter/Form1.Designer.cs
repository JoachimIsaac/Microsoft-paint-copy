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
            this.ShapesGroupbox.SuspendLayout();
            this.SizegroupBox.SuspendLayout();
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
            this.OvalradioButton.Size = new System.Drawing.Size(158, 55);
            this.OvalradioButton.TabIndex = 2;
            this.OvalradioButton.TabStop = true;
            this.OvalradioButton.Text = "Oval";
            this.OvalradioButton.UseVisualStyleBackColor = true;
            // 
            // RectangleradioButton
            // 
            this.RectangleradioButton.AutoSize = true;
            this.RectangleradioButton.Location = new System.Drawing.Point(6, 62);
            this.RectangleradioButton.Name = "RectangleradioButton";
            this.RectangleradioButton.Size = new System.Drawing.Size(287, 55);
            this.RectangleradioButton.TabIndex = 1;
            this.RectangleradioButton.TabStop = true;
            this.RectangleradioButton.Text = "Rectangle";
            this.RectangleradioButton.UseVisualStyleBackColor = true;
            // 
            // LineradioButton
            // 
            this.LineradioButton.AutoSize = true;
            this.LineradioButton.Checked = true;
            this.LineradioButton.Location = new System.Drawing.Point(6, 29);
            this.LineradioButton.Name = "LineradioButton";
            this.LineradioButton.Size = new System.Drawing.Size(152, 55);
            this.LineradioButton.TabIndex = 0;
            this.LineradioButton.TabStop = true;
            this.LineradioButton.Text = "Line";
            this.LineradioButton.UseVisualStyleBackColor = true;
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
            this.SizeLargeradioButton.Size = new System.Drawing.Size(186, 55);
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
            this.SizeMediumradioButton.Size = new System.Drawing.Size(238, 55);
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
            this.SizeSmallradioButton.Size = new System.Drawing.Size(183, 55);
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
            this.Clearbutton.Location = new System.Drawing.Point(747, 412);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(159, 65);
            this.Clearbutton.TabIndex = 4;
            this.Clearbutton.Text = "Clear";
            this.Clearbutton.UseVisualStyleBackColor = false;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // ChooseColorbutton
            // 
            this.ChooseColorbutton.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseColorbutton.Location = new System.Drawing.Point(943, 412);
            this.ChooseColorbutton.Name = "ChooseColorbutton";
            this.ChooseColorbutton.Size = new System.Drawing.Size(159, 65);
            this.ChooseColorbutton.TabIndex = 5;
            this.ChooseColorbutton.Text = "Choose Color";
            this.ChooseColorbutton.UseVisualStyleBackColor = true;
            this.ChooseColorbutton.Click += new System.EventHandler(this.ChooseColorbutton_Click);
            // 
            // ColorIndicatorlabel
            // 
            this.ColorIndicatorlabel.BackColor = System.Drawing.Color.Black;
            this.ColorIndicatorlabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorIndicatorlabel.Location = new System.Drawing.Point(943, 368);
            this.ColorIndicatorlabel.Name = "ColorIndicatorlabel";
            this.ColorIndicatorlabel.Size = new System.Drawing.Size(159, 41);
            this.ColorIndicatorlabel.TabIndex = 6;
            // 
            // MouseLoactionlabel
            // 
            this.MouseLoactionlabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.MouseLoactionlabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MouseLoactionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseLoactionlabel.Location = new System.Drawing.Point(810, 228);
            this.MouseLoactionlabel.Name = "MouseLoactionlabel";
            this.MouseLoactionlabel.Size = new System.Drawing.Size(262, 50);
            this.MouseLoactionlabel.TabIndex = 7;
            // 
            // TitlelabelForMouseLocation
            // 
            this.TitlelabelForMouseLocation.BackColor = System.Drawing.Color.Silver;
            this.TitlelabelForMouseLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitlelabelForMouseLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitlelabelForMouseLocation.Location = new System.Drawing.Point(846, 204);
            this.TitlelabelForMouseLocation.Name = "TitlelabelForMouseLocation";
            this.TitlelabelForMouseLocation.Size = new System.Drawing.Size(192, 24);
            this.TitlelabelForMouseLocation.TabIndex = 8;
            this.TitlelabelForMouseLocation.Text = "Mouse Location :";
            // 
            // PainterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 494);
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
    }
}

