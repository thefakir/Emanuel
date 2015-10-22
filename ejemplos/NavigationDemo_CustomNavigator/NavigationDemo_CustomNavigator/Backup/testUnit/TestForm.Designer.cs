namespace testUnit
{
    partial class TestForm
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
            this.button_page1 = new System.Windows.Forms.Button();
            this.button_page2 = new System.Windows.Forms.Button();
            this.button_page3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_page1
            // 
            this.button_page1.Location = new System.Drawing.Point(12, 22);
            this.button_page1.Name = "button_page1";
            this.button_page1.Size = new System.Drawing.Size(268, 29);
            this.button_page1.TabIndex = 0;
            this.button_page1.Text = "Navigate to Page1";
            this.button_page1.UseVisualStyleBackColor = true;
            this.button_page1.Click += new System.EventHandler(this.button_page1_Click);
            // 
            // button_page2
            // 
            this.button_page2.Location = new System.Drawing.Point(12, 57);
            this.button_page2.Name = "button_page2";
            this.button_page2.Size = new System.Drawing.Size(268, 29);
            this.button_page2.TabIndex = 1;
            this.button_page2.Text = "Navigate to Page2";
            this.button_page2.UseVisualStyleBackColor = true;
            this.button_page2.Click += new System.EventHandler(this.button_page2_Click);
            // 
            // button_page3
            // 
            this.button_page3.Location = new System.Drawing.Point(12, 92);
            this.button_page3.Name = "button_page3";
            this.button_page3.Size = new System.Drawing.Size(268, 29);
            this.button_page3.TabIndex = 2;
            this.button_page3.Text = "Navigate to Page3";
            this.button_page3.UseVisualStyleBackColor = true;
            this.button_page3.Click += new System.EventHandler(this.button_page3_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 226);
            this.Controls.Add(this.button_page3);
            this.Controls.Add(this.button_page2);
            this.Controls.Add(this.button_page1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_page1;
        private System.Windows.Forms.Button button_page2;
        private System.Windows.Forms.Button button_page3;
    }
}

