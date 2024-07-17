namespace WinFormsTestAppNet6CSharp
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
            ButtonOpenTestForm1 = new Button();
            ButtonOpenTestForm2 = new Button();
            SuspendLayout();
            // 
            // ButtonOpenTestForm1
            // 
            ButtonOpenTestForm1.Location = new Point(60, 60);
            ButtonOpenTestForm1.Margin = new Padding(2, 2, 2, 2);
            ButtonOpenTestForm1.Name = "ButtonOpenTestForm1";
            ButtonOpenTestForm1.Size = new Size(110, 23);
            ButtonOpenTestForm1.TabIndex = 0;
            ButtonOpenTestForm1.Text = "Open TestForm";
            ButtonOpenTestForm1.UseVisualStyleBackColor = true;
            ButtonOpenTestForm1.Click += ButtonOpenTestForm1_Click;
            // 
            // ButtonOpenTestForm2
            // 
            ButtonOpenTestForm2.Location = new Point(60, 87);
            ButtonOpenTestForm2.Margin = new Padding(2, 2, 2, 2);
            ButtonOpenTestForm2.Name = "ButtonOpenTestForm2";
            ButtonOpenTestForm2.Size = new Size(110, 23);
            ButtonOpenTestForm2.TabIndex = 1;
            ButtonOpenTestForm2.Text = "Open DialogForm";
            ButtonOpenTestForm2.UseVisualStyleBackColor = true;
            ButtonOpenTestForm2.Click += ButtonOpenTestForm2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(ButtonOpenTestForm2);
            Controls.Add(ButtonOpenTestForm1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button ButtonOpenTestForm1;
        private System.Windows.Forms.Button ButtonOpenTestForm2;
    }
}