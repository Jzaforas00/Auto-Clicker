namespace AutoClicker
{
    partial class AutoClicker
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
            containerClickIntervals = new GroupBox();
            label4 = new Label();
            fieldMilisecond = new TextBox();
            label3 = new Label();
            fieldSecond = new TextBox();
            label2 = new Label();
            fieldMinut = new TextBox();
            label1 = new Label();
            fieldHour = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnChangeKey = new Button();
            containerClickRepeat = new GroupBox();
            rdRepeatIndefinitely = new RadioButton();
            rdRepeat = new RadioButton();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            containerClickOptions = new GroupBox();
            comboClickType = new ComboBox();
            comboMouseButton = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            containerClickIntervals.SuspendLayout();
            containerClickRepeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            containerClickOptions.SuspendLayout();
            SuspendLayout();
            // 
            // containerClickIntervals
            // 
            containerClickIntervals.Controls.Add(label4);
            containerClickIntervals.Controls.Add(fieldMilisecond);
            containerClickIntervals.Controls.Add(label3);
            containerClickIntervals.Controls.Add(fieldSecond);
            containerClickIntervals.Controls.Add(label2);
            containerClickIntervals.Controls.Add(fieldMinut);
            containerClickIntervals.Controls.Add(label1);
            containerClickIntervals.Controls.Add(fieldHour);
            containerClickIntervals.Location = new Point(12, 12);
            containerClickIntervals.Name = "containerClickIntervals";
            containerClickIntervals.Size = new Size(606, 76);
            containerClickIntervals.TabIndex = 0;
            containerClickIntervals.TabStop = false;
            containerClickIntervals.Text = "Click Interval";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(510, 29);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 9;
            label4.Text = "miliseconds";
            // 
            // fieldMilisecond
            // 
            fieldMilisecond.Location = new Point(420, 26);
            fieldMilisecond.Name = "fieldMilisecond";
            fieldMilisecond.Size = new Size(84, 27);
            fieldMilisecond.TabIndex = 4;
            fieldMilisecond.Text = "100";
            fieldMilisecond.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(378, 29);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 7;
            label3.Text = "secs";
            // 
            // fieldSecond
            // 
            fieldSecond.Location = new Point(288, 26);
            fieldSecond.Name = "fieldSecond";
            fieldSecond.Size = new Size(84, 27);
            fieldSecond.TabIndex = 3;
            fieldSecond.Text = "0";
            fieldSecond.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 29);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 5;
            label2.Text = "mins";
            // 
            // fieldMinut
            // 
            fieldMinut.Location = new Point(152, 26);
            fieldMinut.Name = "fieldMinut";
            fieldMinut.Size = new Size(84, 27);
            fieldMinut.TabIndex = 2;
            fieldMinut.Text = "0";
            fieldMinut.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 29);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 4;
            label1.Text = "hours";
            // 
            // fieldHour
            // 
            fieldHour.Location = new Point(11, 26);
            fieldHour.Name = "fieldHour";
            fieldHour.Size = new Size(84, 27);
            fieldHour.TabIndex = 1;
            fieldHour.Text = "0";
            fieldHour.TextAlign = HorizontalAlignment.Right;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(56, 258);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(163, 56);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start (F6)";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(234, 258);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(163, 56);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop (F6)";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnChangeKey
            // 
            btnChangeKey.Location = new Point(412, 258);
            btnChangeKey.Name = "btnChangeKey";
            btnChangeKey.Size = new Size(163, 56);
            btnChangeKey.TabIndex = 3;
            btnChangeKey.Text = "Change Hotkey";
            btnChangeKey.UseVisualStyleBackColor = true;
            btnChangeKey.Click += btnChangeKey_Click;
            // 
            // containerClickRepeat
            // 
            containerClickRepeat.Controls.Add(rdRepeatIndefinitely);
            containerClickRepeat.Controls.Add(rdRepeat);
            containerClickRepeat.Controls.Add(label5);
            containerClickRepeat.Controls.Add(numericUpDown1);
            containerClickRepeat.Location = new Point(12, 102);
            containerClickRepeat.Name = "containerClickRepeat";
            containerClickRepeat.Size = new Size(290, 125);
            containerClickRepeat.TabIndex = 4;
            containerClickRepeat.TabStop = false;
            containerClickRepeat.Text = "Click Repeat";
            // 
            // rdRepeatIndefinitely
            // 
            rdRepeatIndefinitely.AutoSize = true;
            rdRepeatIndefinitely.Location = new Point(48, 75);
            rdRepeatIndefinitely.Name = "rdRepeatIndefinitely";
            rdRepeatIndefinitely.Size = new Size(155, 24);
            rdRepeatIndefinitely.TabIndex = 3;
            rdRepeatIndefinitely.TabStop = true;
            rdRepeatIndefinitely.Text = "Repeat Indefinitely";
            rdRepeatIndefinitely.UseVisualStyleBackColor = true;
            // 
            // rdRepeat
            // 
            rdRepeat.AutoSize = true;
            rdRepeat.Location = new Point(48, 37);
            rdRepeat.Name = "rdRepeat";
            rdRepeat.Size = new Size(77, 24);
            rdRepeat.TabIndex = 2;
            rdRepeat.TabStop = true;
            rdRepeat.Text = "Repeat";
            rdRepeat.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(216, 39);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 1;
            label5.Text = "repeat";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(139, 37);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(71, 27);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // containerClickOptions
            // 
            containerClickOptions.Controls.Add(comboClickType);
            containerClickOptions.Controls.Add(comboMouseButton);
            containerClickOptions.Controls.Add(label7);
            containerClickOptions.Controls.Add(label6);
            containerClickOptions.Location = new Point(328, 102);
            containerClickOptions.Name = "containerClickOptions";
            containerClickOptions.Size = new Size(290, 125);
            containerClickOptions.TabIndex = 6;
            containerClickOptions.TabStop = false;
            containerClickOptions.Text = "Click Options";
            // 
            // comboClickType
            // 
            comboClickType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboClickType.FormattingEnabled = true;
            comboClickType.Items.AddRange(new object[] { "Single", "Double" });
            comboClickType.Location = new Point(130, 74);
            comboClickType.Name = "comboClickType";
            comboClickType.Size = new Size(130, 28);
            comboClickType.TabIndex = 5;
            // 
            // comboMouseButton
            // 
            comboMouseButton.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMouseButton.FormattingEnabled = true;
            comboMouseButton.Items.AddRange(new object[] { "Left", "Right" });
            comboMouseButton.Location = new Point(130, 36);
            comboMouseButton.Name = "comboMouseButton";
            comboMouseButton.Size = new Size(130, 28);
            comboMouseButton.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 79);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 3;
            label7.Text = "Click type:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 39);
            label6.Name = "label6";
            label6.Size = new Size(104, 20);
            label6.TabIndex = 2;
            label6.Text = "Mouse button:";
            // 
            // AutoClicker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 354);
            Controls.Add(containerClickOptions);
            Controls.Add(containerClickRepeat);
            Controls.Add(btnChangeKey);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(containerClickIntervals);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AutoClicker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AutoClicker";
            containerClickIntervals.ResumeLayout(false);
            containerClickIntervals.PerformLayout();
            containerClickRepeat.ResumeLayout(false);
            containerClickRepeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            containerClickOptions.ResumeLayout(false);
            containerClickOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox containerClickIntervals;
        private Button btnStart;
        private Button btnStop;
        private Button btnChangeKey;
        private Label label3;
        private TextBox fieldSecond;
        private Label label2;
        private TextBox fieldMinut;
        private Label label1;
        private TextBox fieldHour;
        private Label label4;
        private TextBox fieldMilisecond;
        private GroupBox containerClickRepeat;
        private GroupBox containerClickOptions;
        private RadioButton rdRepeatIndefinitely;
        private RadioButton rdRepeat;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private Label label7;
        private ComboBox comboClickType;
        private ComboBox comboMouseButton;
    }
}
