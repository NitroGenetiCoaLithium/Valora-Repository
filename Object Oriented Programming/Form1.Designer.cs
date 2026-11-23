namespace Object_Oriented_Programming
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pctLogIn = new PictureBox();
            pnlLogIn = new Panel();
            picShowHidePassword = new PictureBox();
            btnSignUpInLogIn = new Button();
            lblDontHaveAnAccount = new Label();
            btnLogIn = new Button();
            txtLogInPassword = new TextBox();
            lblLogInPassword = new Label();
            txtEmailAddress = new TextBox();
            lblEmailAddress = new Label();
            lblMessageLogIn = new Label();
            lblWelcomeBack = new Label();
            lblValora = new Label();
            pctLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pctLogIn).BeginInit();
            pnlLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctLogo).BeginInit();
            SuspendLayout();
            // 
            // pctLogIn
            // 
            pctLogIn.Image = Properties.Resources._5e6a7038_1ced_49a1_889f_c579b889d961_removebg_preview;
            pctLogIn.Location = new Point(54, 31);
            pctLogIn.Name = "pctLogIn";
            pctLogIn.Size = new Size(478, 643);
            pctLogIn.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLogIn.TabIndex = 0;
            pctLogIn.TabStop = false;
            // 
            // pnlLogIn
            // 
            pnlLogIn.BackColor = Color.White;
            pnlLogIn.Controls.Add(picShowHidePassword);
            pnlLogIn.Controls.Add(btnSignUpInLogIn);
            pnlLogIn.Controls.Add(lblDontHaveAnAccount);
            pnlLogIn.Controls.Add(btnLogIn);
            pnlLogIn.Controls.Add(txtLogInPassword);
            pnlLogIn.Controls.Add(lblLogInPassword);
            pnlLogIn.Controls.Add(txtEmailAddress);
            pnlLogIn.Controls.Add(lblEmailAddress);
            pnlLogIn.Controls.Add(lblMessageLogIn);
            pnlLogIn.Controls.Add(lblWelcomeBack);
            pnlLogIn.Controls.Add(lblValora);
            pnlLogIn.Controls.Add(pctLogo);
            pnlLogIn.Location = new Point(660, 94);
            pnlLogIn.Name = "pnlLogIn";
            pnlLogIn.Size = new Size(341, 430);
            pnlLogIn.TabIndex = 1;
            // 
            // picShowHidePassword
            // 
            picShowHidePassword.BackgroundImageLayout = ImageLayout.None;
            picShowHidePassword.Image = Properties.Resources.eye_open1;
            picShowHidePassword.Location = new Point(282, 250);
            picShowHidePassword.Name = "picShowHidePassword";
            picShowHidePassword.Size = new Size(24, 19);
            picShowHidePassword.SizeMode = PictureBoxSizeMode.Zoom;
            picShowHidePassword.TabIndex = 11;
            picShowHidePassword.TabStop = false;
            picShowHidePassword.Click += picShowHidePassword_Click;
            // 
            // btnSignUpInLogIn
            // 
            btnSignUpInLogIn.Location = new Point(168, 377);
            btnSignUpInLogIn.Name = "btnSignUpInLogIn";
            btnSignUpInLogIn.Size = new Size(75, 23);
            btnSignUpInLogIn.TabIndex = 10;
            btnSignUpInLogIn.Text = "Sign Up";
            btnSignUpInLogIn.UseVisualStyleBackColor = true;
            btnSignUpInLogIn.Click += btnSignUpInLogIn_Click;
            // 
            // lblDontHaveAnAccount
            // 
            lblDontHaveAnAccount.AutoSize = true;
            lblDontHaveAnAccount.Location = new Point(31, 381);
            lblDontHaveAnAccount.Name = "lblDontHaveAnAccount";
            lblDontHaveAnAccount.Size = new Size(131, 15);
            lblDontHaveAnAccount.TabIndex = 9;
            lblDontHaveAnAccount.Text = "Don't have an account?";
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.DarkGreen;
            btnLogIn.FlatStyle = FlatStyle.Popup;
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(31, 295);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(278, 33);
            btnLogIn.TabIndex = 8;
            btnLogIn.Text = "Log In";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // txtLogInPassword
            // 
            txtLogInPassword.Location = new Point(31, 248);
            txtLogInPassword.Name = "txtLogInPassword";
            txtLogInPassword.Size = new Size(278, 23);
            txtLogInPassword.TabIndex = 6;
            // 
            // lblLogInPassword
            // 
            lblLogInPassword.AutoSize = true;
            lblLogInPassword.Location = new Point(31, 230);
            lblLogInPassword.Name = "lblLogInPassword";
            lblLogInPassword.Size = new Size(57, 15);
            lblLogInPassword.TabIndex = 5;
            lblLogInPassword.Text = "Password";
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Location = new Point(31, 189);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(278, 23);
            txtEmailAddress.TabIndex = 4;
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Location = new Point(31, 171);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(81, 15);
            lblEmailAddress.TabIndex = 3;
            lblEmailAddress.Text = "Email Address";
            // 
            // lblMessageLogIn
            // 
            lblMessageLogIn.AutoSize = true;
            lblMessageLogIn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessageLogIn.Location = new Point(79, 131);
            lblMessageLogIn.Name = "lblMessageLogIn";
            lblMessageLogIn.Size = new Size(193, 17);
            lblMessageLogIn.TabIndex = 2;
            lblMessageLogIn.Text = "Log in to continue your journey.";
            // 
            // lblWelcomeBack
            // 
            lblWelcomeBack.AutoSize = true;
            lblWelcomeBack.Font = new Font("Georgia", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeBack.Location = new Point(68, 97);
            lblWelcomeBack.Name = "lblWelcomeBack";
            lblWelcomeBack.Size = new Size(214, 34);
            lblWelcomeBack.TabIndex = 1;
            lblWelcomeBack.Text = "Welcome Back!";
            // 
            // lblValora
            // 
            lblValora.AutoSize = true;
            lblValora.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValora.Location = new Point(136, 50);
            lblValora.Name = "lblValora";
            lblValora.Size = new Size(74, 25);
            lblValora.TabIndex = 0;
            lblValora.Text = "Valora";
            // 
            // pctLogo
            // 
            pctLogo.Image = (Image)resources.GetObject("pctLogo.Image");
            pctLogo.Location = new Point(145, 11);
            pctLogo.Name = "pctLogo";
            pctLogo.Size = new Size(53, 47);
            pctLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLogo.TabIndex = 23;
            pctLogo.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1111, 637);
            Controls.Add(pnlLogIn);
            Controls.Add(pctLogIn);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)pctLogIn).EndInit();
            pnlLogIn.ResumeLayout(false);
            pnlLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pctLogIn;
        private Panel pnlLogIn;
        private Label lblMessageLogIn;
        private Label lblWelcomeBack;
        private Label lblValora;
        private Button btnLogIn;
        private TextBox txtLogInPassword;
        private Label lblLogInPassword;
        private TextBox txtEmailAddress;
        private Label lblEmailAddress;
        private Button btnSignUpInLogIn;
        private Label lblDontHaveAnAccount;
        private PictureBox pctLogo;
    }
}
