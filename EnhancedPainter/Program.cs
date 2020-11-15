/*
 
Name: Joachim Isaac 

Date:11/14/2020

Course: CMPS4143, Fall 2020, Dr. Stringfellow.

Purpose: To create  painter program that makes use of radio buttons and mouse event handlers, menus, combo box and graphics concepts.
         This program draws lines, rectangles and ovals and also fills them.

Noted Extra Credit:
--> Implemented Clear Button
--> Customizable pen Size
--> Color Dialog Box 

 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhancedPainter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PainterForm());
        }
    }
}
