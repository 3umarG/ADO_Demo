namespace First
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
            btnOpen = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            btnOpen.Location = new Point(54, 266);
            btnOpen.Name = "button1";
            btnOpen.Size = new Size(144, 55);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open Connection";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += openConnection;
            // 
            // button2
            // 
            btnClose.Location = new Point(598, 266);
            btnClose.Name = "button2";
            btnClose.Size = new Size(143, 55);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close Connection";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += closeConnection;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnOpen);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpen;
        private Button btnClose;
    }
}