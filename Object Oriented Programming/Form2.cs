using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Object_Oriented_Programming
{
    public partial class Form2 : Form
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db_OOP;Integrated Security=True;TrustServerCertificate=True";
        private bool isUsernameAvailable = false;
        private bool isContactValid = false;
        private bool isEmailValid = false;
        private bool isPasswordValid = false;
        private bool isPasswordMatch = false;
        private bool isPasswordVisible = false;

        // UI feedback controls
        private Label lblUsernameStatus = null!;
        private Label lblBoxIndicator = null!;
        private Label lblContactStatus = null!;
        private Label lblContactBoxIndicator = null!;
        private Label lblEmailStatus = null!;
        private Label lblEmailBoxIndicator = null!;
        private Label lblPasswordStatus = null!;
        private Label lblPasswordBoxIndicator = null!;
        private Label lblConfirmPasswordStatus = null!;
        private Label lblConfirmPasswordBoxIndicator = null!;
        private Button btnTogglePassword = null!;

        public Form2()
        {
            InitializeComponent();

            RoundPanel(pnlSignUp, 20);
            RoundButton(btnSignUp, 10);

            // Initially disable the Sign Up button until all criteria are met
            btnSignUp.Enabled = false;

            // Hook up TextChanged and Resize events for real-time validation as you type
            this.txtUsername.TextChanged += (s, e) => { txtUsername_TextChanged(s, e); ValidateFormState(); };
            this.txtUsername.Resize += txtUsername_Resize;

            this.txtContactNo.TextChanged += (s, e) => { txtContactNo_TextChanged(s, e); ValidateFormState(); };
            this.txtContactNo.Resize += txtContactNo_Resize;

            this.txtSignUpEmailAddress.TextChanged += (s, e) => { txtSignUpEmailAddress_TextChanged(s, e); ValidateFormState(); };
            this.txtSignUpEmailAddress.Resize += txtSignUpEmailAddress_Resize;

            this.txtSignUpPassword.TextChanged += (s, e) => { txtSignUpPassword_TextChanged(s, e); ValidatePasswordMatch(); ValidateFormState(); };
            this.txtSignUpPassword.Resize += txtSignUpPassword_Resize;

            this.txtConfirmPassword.TextChanged += (s, e) => { ValidatePasswordMatch(); ValidateFormState(); };

            if (chkTerms != null)
            {
                this.chkTerms.CheckedChanged += (s, e) => ValidateFormState();
            }

            SetupStatusComponents();
        }

        private void SetupStatusComponents()
        {
            // Username Status Label Below
            lblUsernameStatus = new Label
            {
                AutoSize = true,
                Location = new Point(txtUsername.Left, txtUsername.Bottom + 2),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            if (txtUsername.Parent != null)
            {
                txtUsername.Parent.Controls.Add(lblUsernameStatus);
                lblUsernameStatus.BringToFront();
            }

            // Username Indicator Inside
            lblBoxIndicator = new Label
            {
                AutoSize = false,
                Size = new Size(20, txtUsername.Height - 4),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                Cursor = Cursors.Default
            };
            txtUsername.Controls.Add(lblBoxIndicator);
            PositionBoxIndicator();

            // Contact Status Label Below
            lblContactStatus = new Label
            {
                AutoSize = true,
                Location = new Point(txtContactNo.Left, txtContactNo.Bottom + 2),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            if (txtContactNo.Parent != null)
            {
                txtContactNo.Parent.Controls.Add(lblContactStatus);
                lblContactStatus.BringToFront();
            }

            // Contact Indicator Inside
            lblContactBoxIndicator = new Label
            {
                AutoSize = false,
                Size = new Size(20, txtContactNo.Height - 4),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                Cursor = Cursors.Default
            };
            txtContactNo.Controls.Add(lblContactBoxIndicator);
            PositionContactBoxIndicator();

            // Email Status Label Below
            lblEmailStatus = new Label
            {
                AutoSize = true,
                Location = new Point(txtSignUpEmailAddress.Left, txtSignUpEmailAddress.Bottom + 2),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            if (txtSignUpEmailAddress.Parent != null)
            {
                txtSignUpEmailAddress.Parent.Controls.Add(lblEmailStatus);
                lblEmailStatus.BringToFront();
            }

            // Email Indicator Inside
            lblEmailBoxIndicator = new Label
            {
                AutoSize = false,
                Size = new Size(20, txtSignUpEmailAddress.Height - 4),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                Cursor = Cursors.Default
            };
            txtSignUpEmailAddress.Controls.Add(lblEmailBoxIndicator);
            PositionEmailBoxIndicator();

            // Password Status Label Below
            lblPasswordStatus = new Label
            {
                AutoSize = true,
                Location = new Point(txtSignUpPassword.Left, txtSignUpPassword.Bottom + 2),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            if (txtSignUpPassword.Parent != null)
            {
                txtSignUpPassword.Parent.Controls.Add(lblPasswordStatus);
                lblPasswordStatus.BringToFront();
            }

            // Password Indicator Inside
            lblPasswordBoxIndicator = new Label
            {
                AutoSize = false,
                Size = new Size(20, txtSignUpPassword.Height - 4),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                Cursor = Cursors.Default
            };
            txtSignUpPassword.Controls.Add(lblPasswordBoxIndicator);

            // Confirm Password Status Label Below
            lblConfirmPasswordStatus = new Label
            {
                AutoSize = true,
                Location = new Point(txtConfirmPassword.Left, txtConfirmPassword.Bottom + 2),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };
            if (txtConfirmPassword.Parent != null)
            {
                txtConfirmPassword.Parent.Controls.Add(lblConfirmPasswordStatus);
                lblConfirmPasswordStatus.BringToFront();
            }

            // Confirm Password Indicator Inside
            lblConfirmPasswordBoxIndicator = new Label
            {
                AutoSize = false,
                Size = new Size(20, txtConfirmPassword.Height - 4),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                Cursor = Cursors.Default
            };
            txtConfirmPassword.Controls.Add(lblConfirmPasswordBoxIndicator);
            PositionConfirmPasswordBoxIndicator();

            // Password Toggle Button Inside
            btnTogglePassword = new Button
            {
                AutoSize = false,
                Size = new Size(25, txtSignUpPassword.Height - 4),
                Text = "👁",
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = true,
                Cursor = Cursors.Hand
            };
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.Click += btnTogglePassword_Click;
            txtSignUpPassword.Controls.Add(btnTogglePassword);
            PositionPasswordToggle();
            PositionPasswordBoxIndicator();
        }

        private void PositionBoxIndicator()
        {
            if (lblBoxIndicator != null && txtUsername != null)
            {
                lblBoxIndicator.Location = new Point(txtUsername.Width - lblBoxIndicator.Width - 3, 2);
                lblBoxIndicator.Height = txtUsername.Height - 4;
            }
        }

        private void PositionContactBoxIndicator()
        {
            if (lblContactBoxIndicator != null && txtContactNo != null)
            {
                lblContactBoxIndicator.Location = new Point(txtContactNo.Width - lblContactBoxIndicator.Width - 3, 2);
                lblContactBoxIndicator.Height = txtContactNo.Height - 4;
            }
        }

        private void PositionEmailBoxIndicator()
        {
            if (lblEmailBoxIndicator != null && txtSignUpEmailAddress != null)
            {
                lblEmailBoxIndicator.Location = new Point(txtSignUpEmailAddress.Width - lblEmailBoxIndicator.Width - 3, 2);
                lblEmailBoxIndicator.Height = txtSignUpEmailAddress.Height - 4;
            }
        }

        private void PositionPasswordBoxIndicator()
        {
            if (lblPasswordBoxIndicator != null && txtSignUpPassword != null && btnTogglePassword != null)
            {
                lblPasswordBoxIndicator.Location = new Point(txtSignUpPassword.Width - lblPasswordBoxIndicator.Width - btnTogglePassword.Width - 5, 2);
                lblPasswordBoxIndicator.Height = txtSignUpPassword.Height - 4;
            }
        }

        private void PositionConfirmPasswordBoxIndicator()
        {
            if (lblConfirmPasswordBoxIndicator != null && txtConfirmPassword != null)
            {
                lblConfirmPasswordBoxIndicator.Location = new Point(txtConfirmPassword.Width - lblConfirmPasswordBoxIndicator.Width - 3, 2);
                lblConfirmPasswordBoxIndicator.Height = txtConfirmPassword.Height - 4;
            }
        }

        private void PositionPasswordToggle()
        {
            if (btnTogglePassword != null && txtSignUpPassword != null)
            {
                btnTogglePassword.Location = new Point(txtSignUpPassword.Width - btnTogglePassword.Width - 3, 2);
                btnTogglePassword.Height = txtSignUpPassword.Height - 4;
            }
        }

        private void txtUsername_Resize(object? sender, EventArgs e) => PositionBoxIndicator();
        private void txtContactNo_Resize(object? sender, EventArgs e) => PositionContactBoxIndicator();
        private void txtSignUpEmailAddress_Resize(object? sender, EventArgs e) => PositionEmailBoxIndicator();
        private void txtSignUpPassword_Resize(object? sender, EventArgs e)
        {
            PositionPasswordToggle();
            PositionPasswordBoxIndicator();
        }

        private void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(panel.Width - diameter, 0, diameter, diameter, 270, 90);
            path.AddArc(panel.Width - diameter, panel.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(0, panel.Height - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            panel.Region = new Region(path);
            path.Dispose();
        }

        private void RoundButton(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            diameter = Math.Min(diameter, button.Height);

            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(button.Width - diameter, 0, diameter, diameter, 270, 90);
            path.AddArc(button.Width - diameter, button.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(0, button.Height - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            path.Dispose();
        }

        private void btnLogIninSignUp_Click(object? sender, EventArgs e)
        {
            Form1 logInForm = new Form1();
            logInForm.Show();
            this.Hide();
        }

        private void lblAlreadyHaveAnAccount_Click(object? sender, EventArgs e) { }

        private void btnTogglePassword_Click(object? sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtSignUpPassword.UseSystemPasswordChar = false;
                btnTogglePassword.Text = "🔒";
            }
            else
            {
                txtSignUpPassword.UseSystemPasswordChar = true;
                btnTogglePassword.Text = "👁";
            }

            txtSignUpPassword.SelectionStart = txtSignUpPassword.Text.Length;
        }

        private void btnSignUp_Click(object? sender, EventArgs e)
        {
            if (!btnSignUp.Enabled) return;

            string username = txtUsername.Text.Trim();
            string password = txtSignUpPassword.Text.Trim();
            string contactNo = txtContactNo.Text.Trim();
            string email = txtSignUpEmailAddress.Text.Trim();

            // Confirmation popup before DB execution
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to create this account?",
                "Confirm Account Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string insertQuery = "INSERT INTO tbl_logInfo (user_name, pass_word, contact_no, email_address, is_active) VALUES (@username, @password, @contactNo, @email, @isActive)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@username", username);
                            insertCmd.Parameters.AddWithValue("@password", password);
                            insertCmd.Parameters.AddWithValue("@contactNo", contactNo);
                            insertCmd.Parameters.AddWithValue("@email", email);
                            insertCmd.Parameters.AddWithValue("@isActive", 1);

                            insertCmd.ExecuteNonQuery();
                        }

                        // Custom Welcome Message Dialog
                        using (Form welcomeDialog = new Form())
                        {
                            welcomeDialog.Text = "Welcome to Valora";
                            welcomeDialog.Size = new Size(360, 175);
                            welcomeDialog.StartPosition = FormStartPosition.CenterParent;
                            welcomeDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                            welcomeDialog.MaximizeBox = false;
                            welcomeDialog.MinimizeBox = false;

                            Label lblWelcome = new Label
                            {
                                Text = $"Welcome to Valora, {username}!",
                                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                                AutoSize = false,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Top,
                                Height = 75
                            };

                            Button btnExplore = new Button
                            {
                                Text = "Explore Valora",
                                Size = new Size(140, 35),
                                Location = new Point((welcomeDialog.ClientSize.Width - 140) / 2, 85),
                                DialogResult = DialogResult.OK,
                                BackColor = Color.DarkGreen,
                                ForeColor = Color.White,
                                FlatStyle = FlatStyle.Flat
                            };

                            welcomeDialog.Controls.Add(lblWelcome);
                            welcomeDialog.Controls.Add(btnExplore);
                            welcomeDialog.AcceptButton = btnExplore;
                            welcomeDialog.ShowDialog(this);
                        }

                        Form3 LandingPageForm = new Form3();
                        LandingPageForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void picShowPassword3_Click(object? sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtSignUpPassword.PasswordChar = '\0';
                picShowPassword3.Image = Properties.Resources.eye_open1;
            }
            else
            {
                txtSignUpPassword.PasswordChar = '•';
                picShowPassword3.Image = Properties.Resources.eye_hidden1;
            }
        }

        private void picShowPassword2_Click(object? sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtConfirmPassword.PasswordChar = '\0';
                picShowPassword2.Image = Properties.Resources.eye_open1;
            }
            else
            {
                txtConfirmPassword.PasswordChar = '•';
                picShowPassword2.Image = Properties.Resources.eye_hidden1;
            }
        }
    }
}