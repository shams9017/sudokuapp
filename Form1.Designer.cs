
namespace sudokuapp
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
            this.Solve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Solve
            // 
            this.Solve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Solve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Solve.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Solve.ForeColor = System.Drawing.Color.Black;
            this.Solve.Location = new System.Drawing.Point(1197, 537);
            this.Solve.Name = "Solve";
            this.Solve.Size = new System.Drawing.Size(268, 124);
            this.Solve.TabIndex = 10;
            this.Solve.Text = "Solve";
            this.Solve.UseVisualStyleBackColor = true;
            this.Solve.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2786, 1820);
            this.Controls.Add(this.Solve);
            this.Name = "Form1";
            this.Text = "Sudoku Challenge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Solve;
    }
}

