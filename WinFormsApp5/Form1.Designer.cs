namespace WinFormsApp5
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
            button1 = new Button();
            resultLabel = new Label();
            functionTextBox = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            lowerBoundTextBox = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            upperBoundTextBox = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(177, 310);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Oblicz całkę";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(177, 347);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(0, 15);
            resultLabel.TabIndex = 1;
            // 
            // functionTextBox
            // 
            functionTextBox.Location = new Point(162, 189);
            functionTextBox.Name = "functionTextBox";
            functionTextBox.Size = new Size(100, 23);
            functionTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientInactiveCaption;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(424, 21);
            label1.TabIndex = 3;
            label1.Text = "CAŁKOWANIE NUMERYCZNE METODĄ GAUSSA LEGENDRA";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Image = Properties.Resources.gauss;
            pictureBox1.Location = new Point(86, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(266, 83);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 171);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Funkcja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 171);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 6;
            label3.Text = "Podaj liczbę n: (maks 20)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 189);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // lowerBoundTextBox
            // 
            lowerBoundTextBox.Location = new Point(23, 232);
            lowerBoundTextBox.Name = "lowerBoundTextBox";
            lowerBoundTextBox.Size = new Size(100, 23);
            lowerBoundTextBox.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(162, 232);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 215);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 10;
            label4.Text = "Dolna granica";
            // 
            // upperBoundTextBox
            // 
            upperBoundTextBox.AutoSize = true;
            upperBoundTextBox.Location = new Point(162, 215);
            upperBoundTextBox.Name = "upperBoundTextBox";
            upperBoundTextBox.Size = new Size(81, 15);
            upperBoundTextBox.TabIndex = 11;
            upperBoundTextBox.Text = "Górna granica";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SandyBrown;
            ClientSize = new Size(830, 450);
            Controls.Add(upperBoundTextBox);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(lowerBoundTextBox);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(functionTextBox);
            Controls.Add(resultLabel);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Całkowanie numeryczne metodą Gaussa Legendra";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label resultLabel;
        private TextBox functionTextBox;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox lowerBoundTextBox;
        private TextBox textBox3;
        private Label label4;
        private Label upperBoundTextBox;
    }
}
