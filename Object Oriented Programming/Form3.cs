using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Object_Oriented_Programming
{
    public partial class Form3 : Form
    {
        private bool isSaved = false;
        public Form3()
        {
            InitializeComponent();

            pctOutlineHeart.Visible = true;
            pctheart_red.Visible = false;

            pctOutlineHeart2.Visible = true;
            pctheart_red2.Visible = false;

            pctOutlineHeart3.Visible = true;
            pctheart_red3.Visible = false;

            pctOutlineHeart4.Visible = true;
            pctheart_red4.Visible = false;

            RoundPanel(pnlLandPgNeedHelp, 20);
            RoundPanel1(pnlFeatured1, 20);
            RoundPanel2(pnlFeatured2, 20);
            RoundPanel3(pnlFeatured3, 20);
            RoundPanel4(pnlFeatured4, 20);
            RoundPanelPlaceHolder(pnlPlaceHolderofbarangay, 20);
            RoundButton(btnContactUs, 10);
            RoundButtonMessages(btnMessages, 10);
            RoundButtonBookings(btnBookings, 10);
            RoundPictureBox(pctFurnitureHome, 20);
        }

        private void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter,
                panel.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter,
                diameter, diameter, 90, 90);

            path.CloseFigure();

            panel.Region = new Region(path);
            path.Dispose();
        }

        private void RoundPanel1(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter,
                panel.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter,
                diameter, diameter, 90, 90);

            path.CloseFigure();

            panel.Region = new Region(path);
            path.Dispose();
        }

        private void RoundPanel2(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter,
                panel.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter,
                diameter, diameter, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
            path.Dispose();
        }

        private void RoundPanel3(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter,
                panel.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter,
                diameter, diameter, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
            path.Dispose();
        }

        private void RoundPanel4(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter,
                panel.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter,
                diameter, diameter, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
            path.Dispose();
        }

        private void RoundPanelPlaceHolder(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter,
                panel.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter,
                diameter, diameter, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
            path.Dispose();
        }

        // ROUND BUTTON
        private void RoundButton(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            // Prevent radius from exceeding button height
            diameter = Math.Min(diameter, button.Height);

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(button.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(button.Width - diameter,
                button.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, button.Height - diameter,
                diameter, diameter, 90, 90);

            path.CloseFigure();

            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            path.Dispose();
        }

        private void RoundButtonMessages(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            // Prevent radius from exceeding button height
            diameter = Math.Min(diameter, button.Height);

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(button.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(button.Width - diameter,
                button.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, button.Height - diameter,
                diameter, diameter, 90, 90);

            path.CloseFigure();

            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            path.Dispose();
        }

        private void RoundButtonBookings(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            // Prevent radius from exceeding button height
            diameter = Math.Min(diameter, button.Height);

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(button.Width - diameter, 0,
                diameter, diameter, 270, 90);
            path.AddArc(button.Width - diameter,
                button.Height - diameter,
                diameter, diameter, 0, 90);
            path.AddArc(0, button.Height - diameter,
                diameter, diameter, 90, 90);

            path.CloseFigure();

            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            path.Dispose();
        }

        // ROUND PICTUREBOX
        private void RoundPictureBox(PictureBox pictureBox, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pictureBox.Width - radius, 0,
                radius, radius, 270, 90);
            path.AddArc(pictureBox.Width - radius,
                pictureBox.Height - radius,
                radius, radius, 0, 90);
            path.AddArc(0, pictureBox.Height - radius,
                radius, radius, 90, 90);

            path.CloseFigure();

            pictureBox.Region = new Region(path);
            path.Dispose();
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 LogInForm = new Form1();
            LogInForm.Show();

            this.Hide();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {

        }

        private void lblGreenProperties_Click(object sender, EventArgs e)
        {

        }

        private void pctOutlineHeart_Click(object sender, EventArgs e)
        {
            isSaved = true;

            pctOutlineHeart.Visible = false;
            pctheart_red.Visible = true;
        }

        private void pctheart_red_Click(object sender, EventArgs e)
        {
            isSaved = false;

            pctheart_red.Visible = false;
            pctOutlineHeart.Visible = true;
        }

        private void pctOutlineHeart2_Click(object sender, EventArgs e)
        {
            isSaved = true;

            pctOutlineHeart2.Visible = false;
            pctheart_red2.Visible = true;
        }

        private void pctheart_red2_Click(object sender, EventArgs e)
        {
            isSaved = false;

            pctheart_red2.Visible = false;
            pctOutlineHeart2.Visible = true;
        }

        private void pctOutlineHeart3_Click(object sender, EventArgs e)
        {
            isSaved = true;

            pctOutlineHeart3.Visible = false;
            pctheart_red3.Visible = true;
        }

        private void pctheart_red3_Click(object sender, EventArgs e)
        {
            isSaved = false;

            pctheart_red3.Visible = false;
            pctOutlineHeart3.Visible = true;
        }

        private void pctOutlineHeart4_Click(object sender, EventArgs e)
        {
            isSaved = true;

            pctOutlineHeart4.Visible = false;
            pctheart_red4.Visible = true;
        }

        private void pctheart_red4_Click(object sender, EventArgs e)
        {
            isSaved = false;

            pctheart_red4.Visible = false;
            pctOutlineHeart4.Visible = true;
        }

    }
}
