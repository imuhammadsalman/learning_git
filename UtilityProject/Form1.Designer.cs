namespace UtilityProject
{
    partial class Form1
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
            this.btnTestRegex = new System.Windows.Forms.Button();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestString = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestRegex
            // 
            this.btnTestRegex.Location = new System.Drawing.Point(649, 13);
            this.btnTestRegex.Name = "btnTestRegex";
            this.btnTestRegex.Size = new System.Drawing.Size(141, 44);
            this.btnTestRegex.TabIndex = 0;
            this.btnTestRegex.Text = "Test Regex";
            this.btnTestRegex.UseVisualStyleBackColor = true;
            this.btnTestRegex.Click += new System.EventHandler(this.btnTestRegex_Click);
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(116, 12);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(381, 22);
            this.txtRegex.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Test String";
            // 
            // txtTestString
            // 
            this.txtTestString.Location = new System.Drawing.Point(116, 40);
            this.txtTestString.Name = "txtTestString";
            this.txtTestString.Size = new System.Drawing.Size(381, 22);
            this.txtTestString.TabIndex = 3;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(649, 76);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(141, 48);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTestString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.btnTestRegex);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestRegex;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTestString;
        private System.Windows.Forms.Button btnTest;
    }
}

