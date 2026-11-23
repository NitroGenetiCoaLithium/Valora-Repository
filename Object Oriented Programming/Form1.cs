using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.Data.SqlClient; // Modern SQL Client package
using System.Windows.Forms;

namespace Object_Oriented_Programming
{
    public partial class Form1 : Form
    {
        // Connection string pointing to your local SQL Server instance and database (db_OOP)
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db_OOP1;Integrated Security=True;Trust Server Certificate=True;";

        // Track failed login attempts
        private int failedAttempts = 0;
        private const int MaxAttempts = 10;

        // Track whether password is currently shown or hidden
        private bool isPasswordVisible = false;

        public Form1()
        {
            InitializeComponent();

            // Apply rounded corners
            RoundPanel(pnlLogIn, 20);
            RoundButton(btnLogIn, 10);

            // Hide password characters by default as you type
            txtLogInPassword.PasswordChar = '•';

            // Set default eye icon state if the picturebox exists
            if (picShowHidePassword != null)
            {
                picShowHidePassword.Image = Properties.Resources.eye_hidden1;
            }
        }

        // ROUND PANEL
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

        private void btnSignUpInLogIn_Click(object sender, EventArgs e)
        {
            Form2 signUpForm = new Form2();
            signUpForm.Show();

            this.Hide();
        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmailAddress.Text;
        }

        private void txtLogInPassword_TextChanged(object sender, EventArgs e)
        {
            string loginPassword = txtLogInPassword.Text;
        }

        // 👁️ SHOW / HIDE PASSWORD TOGGLE ICON CLICK EVENT
        private void picShowHidePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                // Show password (remove mask)
                txtLogInPassword.PasswordChar = '\0';

                // Switch to open eye icon
                picShowHidePassword.Image = Properties.Resources.eye_open1;
            }
            else
            {
                // Hide password (apply bullet mask)
                txtLogInPassword.PasswordChar = '•';

                // Switch back to closed eye with slash icon
                picShowHidePassword.Image = Properties.Resources.eye_hidden1;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // If already locked out, block immediately
            if (!btnLogIn.Enabled)
            {
                MessageBox.Show("Access Denied. Maximum attempts reached. Please restart the application.", "Locked Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = txtEmailAddress.Text.Trim();
            string password = txtLogInPassword.Text.Trim();

            // Validate that inputs aren't empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Database Verification matching tbl_logInfo, user_name, and pass_word
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM tbl_logInfos WHERE user_name = @Username AND pass_word = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            // Success: Credentials match database records, land on Form3
                            Form3 LandingPageForm = new Form3();
                            LandingPageForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Failure: Increment failed attempts
                            failedAttempts++;
                            int attemptsLeft = MaxAttempts - failedAttempts;

                            if (failedAttempts >= MaxAttempts)
                            {
                                // Lock out the user, turn button Red
                                btnLogIn.Enabled = false;
                                btnLogIn.BackColor = Color.Red;
                                btnLogIn.ForeColor = Color.White;

                                MessageBox.Show("Maximum 10 failed login attempts reached! Access is permanently locked for this session. Please end the task and restart the application.", "Locked Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Invalid username or password. You have {attemptsLeft} attempt(s) remaining.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}