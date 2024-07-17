namespace WinformsTestApp
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
            this.ButtonOpenTestForm1 = new System.Windows.Forms.Button();
            this.ButtonOpenTestForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonOpenTestForm1
            // 
            this.ButtonOpenTestForm1.Location = new System.Drawing.Point(60, 60);
            this.ButtonOpenTestForm1.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonOpenTestForm1.Name = "ButtonOpenTestForm1";
            this.ButtonOpenTestForm1.Size = new System.Drawing.Size(110, 23);
            this.ButtonOpenTestForm1.TabIndex = 0;
            this.ButtonOpenTestForm1.Text = "Open TestForm";
            this.ButtonOpenTestForm1.UseVisualStyleBackColor = true;
            this.ButtonOpenTestForm1.Click += new System.EventHandler(this.ButtonOpenTestForm1_Click);
            // 
            // ButtonOpenTestForm2
            // 
            this.ButtonOpenTestForm2.Location = new System.Drawing.Point(60, 87);
            this.ButtonOpenTestForm2.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonOpenTestForm2.Name = "ButtonOpenTestForm2";
            this.ButtonOpenTestForm2.Size = new System.Drawing.Size(110, 23);
            this.ButtonOpenTestForm2.TabIndex = 1;
            this.ButtonOpenTestForm2.Text = "Open DialogForm";
            this.ButtonOpenTestForm2.UseVisualStyleBackColor = true;
            this.ButtonOpenTestForm2.Click += new System.EventHandler(this.ButtonOpenTestForm2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.ButtonOpenTestForm2);
            this.Controls.Add(this.ButtonOpenTestForm1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOpenTestForm1;
        private System.Windows.Forms.Button ButtonOpenTestForm2;
    }
}