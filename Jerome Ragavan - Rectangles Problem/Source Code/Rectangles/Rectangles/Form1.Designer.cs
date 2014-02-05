namespace Rectangles
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
            this.pnlInput = new System.Windows.Forms.Panel();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.btnInput = new System.Windows.Forms.Button();
            this.nudInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Location = new System.Drawing.Point(13, 13);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1055, 259);
            this.pnlInput.TabIndex = 0;
            // 
            // pnlOutput
            // 
            this.pnlOutput.BackColor = System.Drawing.Color.White;
            this.pnlOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOutput.Location = new System.Drawing.Point(13, 278);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(1055, 261);
            this.pnlOutput.TabIndex = 1;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(1073, 39);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(164, 23);
            this.btnInput.TabIndex = 2;
            this.btnInput.Text = "Generate Input";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // nudInput
            // 
            this.nudInput.Location = new System.Drawing.Point(1074, 13);
            this.nudInput.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudInput.Name = "nudInput";
            this.nudInput.Size = new System.Drawing.Size(163, 20);
            this.nudInput.TabIndex = 3;
            this.nudInput.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 551);
            this.Controls.Add(this.nudInput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.pnlInput);
            this.Name = "Form1";
            this.Text = "Rotating Rectangles";
            ((System.ComponentModel.ISupportInitialize)(this.nudInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.NumericUpDown nudInput;
    }
}

