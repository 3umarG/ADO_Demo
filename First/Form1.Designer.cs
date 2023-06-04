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
            northwindDB = new Button();
            anotherDB = new Button();
            btnCount = new Button();
            btnSP = new Button();
            btnCommand = new Button();
            cbIDs = new ComboBox();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(3, 224);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(144, 55);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open Connection";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += openConnection;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(4, 294);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(143, 55);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close Connection";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += closeConnection;
            // 
            // northwindDB
            // 
            northwindDB.Location = new Point(160, 224);
            northwindDB.Name = "northwindDB";
            northwindDB.Size = new Size(107, 55);
            northwindDB.TabIndex = 2;
            northwindDB.Text = "Northwind";
            northwindDB.UseVisualStyleBackColor = true;
            northwindDB.Click += button1_Click;
            // 
            // anotherDB
            // 
            anotherDB.Location = new Point(160, 294);
            anotherDB.Name = "anotherDB";
            anotherDB.Size = new Size(107, 55);
            anotherDB.TabIndex = 3;
            anotherDB.Text = "Another DB";
            anotherDB.UseVisualStyleBackColor = true;
            anotherDB.Click += button1_Click_1;
            // 
            // btnCount
            // 
            btnCount.Location = new Point(280, 224);
            btnCount.Name = "btnCount";
            btnCount.Size = new Size(139, 55);
            btnCount.TabIndex = 4;
            btnCount.Text = "Get Count Scalar";
            btnCount.UseVisualStyleBackColor = true;
            btnCount.Click += btnCount_Click;
            // 
            // btnSP
            // 
            btnSP.Location = new Point(280, 294);
            btnSP.Name = "btnSP";
            btnSP.Size = new Size(139, 55);
            btnSP.TabIndex = 5;
            btnSP.Text = "Stored Proced";
            btnSP.UseVisualStyleBackColor = true;
            btnSP.Click += btnNonQuery_Click;
            // 
            // btnCommand
            // 
            btnCommand.Location = new Point(280, 166);
            btnCommand.Name = "btnCommand";
            btnCommand.Size = new Size(139, 42);
            btnCommand.TabIndex = 6;
            btnCommand.Text = "Command";
            btnCommand.UseVisualStyleBackColor = true;
            btnCommand.Click += btnCommand_Click;
            // 
            // cbIDs
            // 
            cbIDs.FormattingEnabled = true;
            cbIDs.Location = new Point(12, 177);
            cbIDs.Name = "cbIDs";
            cbIDs.Size = new Size(255, 23);
            cbIDs.TabIndex = 7;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbIDs);
            Controls.Add(btnCommand);
            Controls.Add(btnSP);
            Controls.Add(btnCount);
            Controls.Add(anotherDB);
            Controls.Add(northwindDB);
            Controls.Add(btnClose);
            Controls.Add(btnOpen);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpen;
        private Button btnClose;
        private Button northwindDB;
        private Button anotherDB;
        private Button btnCount;
        private Button btnSP;
        private Button btnCommand;
        private ComboBox cbIDs;
    }
}