namespace Object_Oriented_Programming
{
    partial class Form4
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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox7 = new TextBox();
            label3 = new Label();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            textBox11 = new TextBox();
            label7 = new Label();
            textBox1 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            comboBox2 = new ComboBox();
            label10 = new Label();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LimeGreen;
            textBox2.Font = new Font("Georgia", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(406, 47);
            textBox2.MinimumSize = new Size(0, 40);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(307, 40);
            textBox2.TabIndex = 2;
            textBox2.Text = "        Rental Calculator";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(922, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(171, 31);
            textBox3.TabIndex = 3;
            textBox3.Text = "  Transaction History";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(33, 93);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(1038, 502);
            textBox4.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(69, 139);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(394, 33);
            comboBox1.TabIndex = 5;
            comboBox1.Text = " Rental/Apartment";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(69, 216);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(394, 31);
            textBox5.TabIndex = 6;
            textBox5.Text = " ₱";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(597, 141);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(394, 31);
            textBox6.TabIndex = 7;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MintCream;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(69, 188);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 8;
            label1.Text = "Rental rate (₱)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MintCream;
            label2.Location = new Point(69, 453);
            label2.Name = "label2";
            label2.Size = new Size(53, 25);
            label2.TabIndex = 9;
            label2.Text = "Total:";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(597, 216);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(394, 31);
            textBox7.TabIndex = 10;
            textBox7.Text = " ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.MintCream;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(597, 188);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 11;
            label3.Text = "Tax (%)";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(69, 357);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(394, 31);
            textBox8.TabIndex = 12;
            textBox8.Text = "₱";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(69, 419);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(394, 31);
            textBox9.TabIndex = 13;
            textBox9.Text = "₱";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(69, 479);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(394, 31);
            textBox10.TabIndex = 14;
            textBox10.Text = "₱";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.MintCream;
            label5.Location = new Point(69, 391);
            label5.Name = "label5";
            label5.Size = new Size(40, 25);
            label5.TabIndex = 16;
            label5.Text = "Tax:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.MintCream;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(69, 329);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 17;
            label6.Text = "Subtotal:";
            label6.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.MintCream;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(597, 113);
            label4.Name = "label4";
            label4.Size = new Size(162, 25);
            label4.TabIndex = 18;
            label4.Text = "Duration (Monthly)";
            // 
            // textBox11
            // 
            textBox11.BackColor = Color.FromArgb(0, 192, 0);
            textBox11.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox11.Location = new Point(615, 526);
            textBox11.Multiline = true;
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(168, 42);
            textBox11.TabIndex = 19;
            textBox11.Text = "     Continue";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.MintCream;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(69, 111);
            label7.Name = "label7";
            label7.Size = new Size(49, 25);
            label7.TabIndex = 20;
            label7.Text = "Type";
            label7.Click += label7_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(362, 526);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(122, 42);
            textBox1.TabIndex = 21;
            textBox1.Text = "    Back";
            // 
            // label8
            // 
            label8.BackColor = Color.Lavender;
            label8.Location = new Point(33, 279);
            label8.Name = "label8";
            label8.Size = new Size(1039, 10);
            label8.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.MintCream;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(66, 289);
            label9.Name = "label9";
            label9.Size = new Size(124, 38);
            label9.TabIndex = 23;
            label9.Text = "Payment";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(615, 355);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(394, 33);
            comboBox2.TabIndex = 24;
            comboBox2.Text = "Choose...";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.MintCream;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(615, 327);
            label10.Name = "label10";
            label10.Size = new Size(170, 25);
            label10.TabIndex = 25;
            label10.Text = "Discount (Optional):";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1105, 620);
            Controls.Add(label10);
            Controls.Add(comboBox2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(textBox11);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(label3);
            Controls.Add(textBox7);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label1;
        private Label label2;
        private TextBox textBox7;
        private Label label3;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label5;
        private Label label6;
        private Label label4;
        private TextBox textBox11;
        private Label label7;
        private TextBox textBox1;
        private Label label8;
        private Label label9;
        private ComboBox comboBox2;
        private Label label10;
    }
}