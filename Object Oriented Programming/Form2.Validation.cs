using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Object_Oriented_Programming
{
    public partial class Form2
    {
        // Global validation check to enable/disable the Sign Up button dynamically
        private void ValidateFormState()
        {
            bool areFieldsNotEmpty = !string.IsNullOrWhiteSpace(txtUsername.Text) &&
                                     !string.IsNullOrWhiteSpace(txtContactNo.Text) &&
                                     !string.IsNullOrWhiteSpace(txtSignUpEmailAddress.Text) &&
                                     !string.IsNullOrWhiteSpace(txtSignUpPassword.Text) &&
                                     !string.IsNullOrWhiteSpace(txtConfirmPassword.Text);

            bool isCheckedTerms = chkTerms != null && chkTerms.Checked;

            btnSignUp.Enabled = areFieldsNotEmpty &&
                                isUsernameAvailable &&
                                isContactValid &&
                                isEmailValid &&
                                isPasswordValid &&
                                isPasswordMatch &&
                                isCheckedTerms;
        }

        private void txtSignUpPassword_TextChanged(object? sender, EventArgs e)
        {
            string password = txtSignUpPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                txtSignUpPassword.BackColor = SystemColors.Window;
                if (lblPasswordStatus != null) lblPasswordStatus.Text = "";
                if (lblPasswordBoxIndicator != null) lblPasswordBoxIndicator.Text = "";
                isPasswordValid = false;
                return;
            }

            if (password.Length > 15)
            {
                txtSignUpPassword.BackColor = Color.MistyRose;
                if (lblPasswordStatus != null)
                {
                    lblPasswordStatus.ForeColor = Color.Red;
                    lblPasswordStatus.Text = "Password must be 15 characters or less";
                }
                if (lblPasswordBoxIndicator != null)
                {
                    lblPasswordBoxIndicator.ForeColor = Color.Red;
                    lblPasswordBoxIndicator.Text = "✕";
                }
                isPasswordValid = false;
            }
            else
            {
                txtSignUpPassword.BackColor = Color.Honeydew;
                if (lblPasswordStatus != null) lblPasswordStatus.Text = "";
                if (lblPasswordBoxIndicator != null)
                {
                    lblPasswordBoxIndicator.ForeColor = Color.Green;
                    lblPasswordBoxIndicator.Text = "✓";
                }
                isPasswordValid = true;
            }
        }

        private void ValidatePasswordMatch()
        {
            string password = txtSignUpPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(confirmPassword))
            {
                txtConfirmPassword.BackColor = SystemColors.Window;
                if (lblConfirmPasswordStatus != null) lblConfirmPasswordStatus.Text = "";
                if (lblConfirmPasswordBoxIndicator != null) lblConfirmPasswordBoxIndicator.Text = "";
                isPasswordMatch = false;
                return;
            }

            if (password == confirmPassword)
            {
                txtConfirmPassword.BackColor = Color.Honeydew;
                if (lblConfirmPasswordStatus != null) lblConfirmPasswordStatus.Text = "";
                if (lblConfirmPasswordBoxIndicator != null)
                {
                    lblConfirmPasswordBoxIndicator.ForeColor = Color.Green;
                    lblConfirmPasswordBoxIndicator.Text = "✓";
                }
                isPasswordMatch = true;
            }
            else
            {
                txtConfirmPassword.BackColor = Color.MistyRose;
                if (lblConfirmPasswordStatus != null)
                {
                    lblConfirmPasswordStatus.ForeColor = Color.Red;
                    lblConfirmPasswordStatus.Text = "Passwords do not match";
                }
                if (lblConfirmPasswordBoxIndicator != null)
                {
                    lblConfirmPasswordBoxIndicator.ForeColor = Color.Red;
                    lblConfirmPasswordBoxIndicator.Text = "✕";
                }
                isPasswordMatch = false;
            }
        }

        // Contact Number Validation in real-time as you type
        private void txtContactNo_TextChanged(object? sender, EventArgs e)
        {
            string contactNo = txtContactNo.Text;

            if (contactNo.Contains(" "))
            {
                contactNo = contactNo.Replace(" ", "");
                txtContactNo.Text = contactNo;
                txtContactNo.SelectionStart = txtContactNo.Text.Length;
            }

            foreach (char c in contactNo)
            {
                if (!char.IsDigit(c))
                {
                    txtContactNo.BackColor = Color.MistyRose;
                    lblContactStatus.ForeColor = Color.Red;
                    lblContactStatus.Text = "Contact number cannot contain letters or symbols";
                    lblContactBoxIndicator.ForeColor = Color.Red;
                    lblContactBoxIndicator.Text = "✕";
                    isContactValid = false;
                    return;
                }
            }

            if (string.IsNullOrEmpty(contactNo))
            {
                txtContactNo.BackColor = SystemColors.Window;
                lblContactStatus.Text = "";
                lblContactBoxIndicator.Text = "";
                isContactValid = false;
                return;
            }

            if (contactNo.Length >= 1 && contactNo[0] != '0')
            {
                txtContactNo.BackColor = Color.MistyRose;
                lblContactStatus.ForeColor = Color.Red;
                lblContactStatus.Text = "Contact number must start with 09";
                lblContactBoxIndicator.ForeColor = Color.Red;
                lblContactBoxIndicator.Text = "✕";
                isContactValid = false;
                return;
            }
            if (contactNo.Length >= 2 && contactNo[1] != '9')
            {
                txtContactNo.BackColor = Color.MistyRose;
                lblContactStatus.ForeColor = Color.Red;
                lblContactStatus.Text = "Contact number must start with 09";
                lblContactBoxIndicator.ForeColor = Color.Red;
                lblContactBoxIndicator.Text = "✕";
                isContactValid = false;
                return;
            }

            if (contactNo.Length > 11)
            {
                txtContactNo.BackColor = Color.MistyRose;
                lblContactStatus.ForeColor = Color.Red;
                lblContactStatus.Text = "The contact number must be exactly 11 characters";
                lblContactBoxIndicator.ForeColor = Color.Red;
                lblContactBoxIndicator.Text = "✕";
                isContactValid = false;
                return;
            }

            if (contactNo.Length < 11)
            {
                txtContactNo.BackColor = Color.MistyRose;
                lblContactStatus.ForeColor = Color.Red;
                lblContactStatus.Text = $"Contact number must be 11 digits ({contactNo.Length}/11)";
                lblContactBoxIndicator.ForeColor = Color.Red;
                lblContactBoxIndicator.Text = "✕";
                isContactValid = false;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(1) FROM tbl_logInfos WHERE contact_no = @contactNo";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@contactNo", contactNo);
                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            txtContactNo.BackColor = Color.MistyRose;
                            lblContactStatus.ForeColor = Color.Red;
                            lblContactStatus.Text = "The number is already taken";
                            lblContactBoxIndicator.ForeColor = Color.Red;
                            lblContactBoxIndicator.Text = "✕";
                            isContactValid = false;
                        }
                        else
                        {
                            txtContactNo.BackColor = Color.Honeydew;
                            lblContactStatus.Text = "";
                            lblContactBoxIndicator.ForeColor = Color.Green;
                            lblContactBoxIndicator.Text = "✓";
                            isContactValid = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtContactNo.BackColor = Color.MistyRose;
                    lblContactStatus.ForeColor = Color.Red;
                    lblContactStatus.Text = "DB Error: " + ex.Message;
                    lblContactBoxIndicator.ForeColor = Color.Red;
                    lblContactBoxIndicator.Text = "!";
                    isContactValid = false;
                }
            }
        }

        // Email Address Validation
        private void txtSignUpEmailAddress_TextChanged(object? sender, EventArgs e)
        {
            string email = txtSignUpEmailAddress.Text;

            if (email.Contains(" "))
            {
                email = email.Replace(" ", "");
                txtSignUpEmailAddress.Text = email;
                txtSignUpEmailAddress.SelectionStart = txtSignUpEmailAddress.Text.Length;
            }

            email = email.Trim();

            if (string.IsNullOrEmpty(email))
            {
                txtSignUpEmailAddress.BackColor = SystemColors.Window;
                lblEmailStatus.Text = "";
                lblEmailBoxIndicator.Text = "";
                isEmailValid = false;
                return;
            }

            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) || email.Equals("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                txtSignUpEmailAddress.BackColor = Color.MistyRose;
                lblEmailStatus.ForeColor = Color.Red;
                lblEmailStatus.Text = "Email address must end with @gmail.com";
                lblEmailBoxIndicator.ForeColor = Color.Red;
                lblEmailBoxIndicator.Text = "✕";
                isEmailValid = false;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(1) FROM tbl_logInfos WHERE email_address = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            txtSignUpEmailAddress.BackColor = Color.MistyRose;
                            lblEmailStatus.ForeColor = Color.Red;
                            lblEmailStatus.Text = "The email is already taken";
                            lblEmailBoxIndicator.ForeColor = Color.Red;
                            lblEmailBoxIndicator.Text = "✕";
                            isEmailValid = false;
                        }
                        else
                        {
                            txtSignUpEmailAddress.BackColor = Color.Honeydew;
                            lblEmailStatus.Text = "";
                            lblEmailBoxIndicator.ForeColor = Color.Green;
                            lblEmailBoxIndicator.Text = "✓";
                            isEmailValid = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtSignUpEmailAddress.BackColor = Color.MistyRose;
                    lblEmailStatus.ForeColor = Color.Red;
                    lblEmailStatus.Text = "DB Error: " + ex.Message;
                    lblEmailBoxIndicator.ForeColor = Color.Red;
                    lblEmailBoxIndicator.Text = "!";
                    isEmailValid = false;
                }
            }
        }

        // Username Check in real-time
        private void txtUsername_TextChanged(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;

            if (username.Contains(" "))
            {
                username = username.Replace(" ", "");
                txtUsername.Text = username;
                txtUsername.SelectionStart = txtUsername.Text.Length;
            }

            username = username.Trim();

            if (string.IsNullOrEmpty(username))
            {
                txtUsername.BackColor = SystemColors.Window;
                if (lblUsernameStatus != null) lblUsernameStatus.Text = "";
                if (lblBoxIndicator != null) lblBoxIndicator.Text = "";
                isUsernameAvailable = false;
                return;
            }

            if (username.Length > 15)
            {
                txtUsername.BackColor = Color.MistyRose;
                if (lblUsernameStatus != null)
                {
                    lblUsernameStatus.ForeColor = Color.Red;
                    lblUsernameStatus.Text = "Username must be 15 characters or less";
                }
                if (lblBoxIndicator != null)
                {
                    lblBoxIndicator.ForeColor = Color.Red;
                    lblBoxIndicator.Text = "✕";
                }
                isUsernameAvailable = false;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(1) FROM tbl_logInfos WHERE user_name = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            txtUsername.BackColor = Color.MistyRose;
                            if (lblUsernameStatus != null)
                            {
                                lblUsernameStatus.ForeColor = Color.Red;
                                lblUsernameStatus.Text = "The username is taken";
                            }
                            if (lblBoxIndicator != null)
                            {
                                lblBoxIndicator.ForeColor = Color.Red;
                                lblBoxIndicator.Text = "✕";
                            }
                            isUsernameAvailable = false;
                        }
                        else
                        {
                            txtUsername.BackColor = Color.Honeydew;
                            if (lblUsernameStatus != null)
                            {
                                lblUsernameStatus.Text = "";
                            }
                            if (lblBoxIndicator != null)
                            {
                                lblBoxIndicator.ForeColor = Color.Green;
                                lblBoxIndicator.Text = "✓";
                            }
                            isUsernameAvailable = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtUsername.BackColor = Color.MistyRose;
                    if (lblUsernameStatus != null)
                    {
                        lblUsernameStatus.ForeColor = Color.Red;
                        lblUsernameStatus.Text = "DB Error: " + ex.Message;
                    }
                    if (lblBoxIndicator != null) lblBoxIndicator.Text = "!";
                    isUsernameAvailable = false;
                }
            }
        }
    }
}