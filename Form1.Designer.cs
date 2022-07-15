namespace mars_task
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.catButton = new System.Windows.Forms.Button();
            this.vampusButton = new System.Windows.Forms.Button();
            this.ghostButton = new System.Windows.Forms.Button();
            this.bellLabel = new System.Windows.Forms.Label();
            this.protoLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 264);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 379);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(397, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(12, 408);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(397, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "restart map";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // catButton
            // 
            this.catButton.Location = new System.Drawing.Point(12, 452);
            this.catButton.Name = "catButton";
            this.catButton.Size = new System.Drawing.Size(397, 23);
            this.catButton.TabIndex = 3;
            this.catButton.Text = "cat";
            this.catButton.UseVisualStyleBackColor = true;
            this.catButton.Click += new System.EventHandler(this.catButton_Click);
            // 
            // vampusButton
            // 
            this.vampusButton.Location = new System.Drawing.Point(12, 481);
            this.vampusButton.Name = "vampusButton";
            this.vampusButton.Size = new System.Drawing.Size(397, 23);
            this.vampusButton.TabIndex = 4;
            this.vampusButton.Text = "vampus";
            this.vampusButton.UseVisualStyleBackColor = true;
            this.vampusButton.Click += new System.EventHandler(this.vampusButton_Click);
            // 
            // ghostButton
            // 
            this.ghostButton.Location = new System.Drawing.Point(12, 510);
            this.ghostButton.Name = "ghostButton";
            this.ghostButton.Size = new System.Drawing.Size(397, 23);
            this.ghostButton.TabIndex = 5;
            this.ghostButton.Text = "ghost";
            this.ghostButton.UseVisualStyleBackColor = true;
            this.ghostButton.Click += new System.EventHandler(this.ghostButton_Click);
            // 
            // bellLabel
            // 
            this.bellLabel.AutoSize = true;
            this.bellLabel.Location = new System.Drawing.Point(79, 294);
            this.bellLabel.Name = "bellLabel";
            this.bellLabel.Size = new System.Drawing.Size(167, 15);
            this.bellLabel.TabIndex = 6;
            this.bellLabel.Text = "Веровочка с колокольчиком";
            // 
            // protoLabel
            // 
            this.protoLabel.AutoSize = true;
            this.protoLabel.Location = new System.Drawing.Point(79, 333);
            this.protoLabel.Name = "protoLabel";
            this.protoLabel.Size = new System.Drawing.Size(136, 15);
            this.protoLabel.TabIndex = 7;
            this.protoLabel.Text = "Детектор протоплазмы";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::mars_task.Properties.Resources.bell;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 285);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 33);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::mars_task.Properties.Resources.proto;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(12, 324);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 33);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 561);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.protoLabel);
            this.Controls.Add(this.bellLabel);
            this.Controls.Add(this.ghostButton);
            this.Controls.Add(this.vampusButton);
            this.Controls.Add(this.catButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Задание";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private Button clearButton;
        private Button generateButton;
        private Button catButton;
        private Button vampusButton;
        private Button ghostButton;
        private Label bellLabel;
        private Label protoLabel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}