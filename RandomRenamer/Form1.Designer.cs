namespace RandomRenamer
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
            button1 = new Button();
            button2 = new Button();
            statusLabel = new Label();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sitka Subheading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(196, 219);
            button1.Name = "button1";
            button1.Size = new Size(116, 62);
            button1.TabIndex = 0;
            button1.Text = "select";
            button1.UseVisualStyleBackColor = false;
            button1.Click += SelectFolderButton_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Sitka Subheading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(492, 219);
            button2.Name = "button2";
            button2.Size = new Size(116, 62);
            button2.TabIndex = 0;
            button2.Text = "rename";
            button2.UseVisualStyleBackColor = false;
            button2.Click += RenameFilesButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.Font = new Font("Sitka Subheading", 18F, FontStyle.Regular, GraphicsUnit.Point);
            statusLabel.ForeColor = SystemColors.ButtonHighlight;
            statusLabel.Location = new Point(92, 336);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(70, 35);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "path:";
            statusLabel.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Sitka Subheading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(758, 12);
            button3.Name = "button3";
            button3.Size = new Size(30, 35);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = false;
            button3.Click += ExitButton_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Sitka Subheading", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(722, 12);
            button4.Name = "button4";
            button4.Size = new Size(30, 35);
            button4.TabIndex = 0;
            button4.UseVisualStyleBackColor = false;
            button4.Click += MinimizeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Sitka Subheading", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(155, 86);
            label1.Name = "label1";
            label1.Size = new Size(482, 35);
            label1.TabIndex = 1;
            label1.Text = "Select a path to the files you want to rename";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(288, 306);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(226, 29);
            progressBar.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar);
            Controls.Add(label1);
            Controls.Add(statusLabel);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Random Renamer";
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label statusLabel;
        private Button button3;
        private Button button4;
        private Label label1;
        private ProgressBar progressBar;
    }
}