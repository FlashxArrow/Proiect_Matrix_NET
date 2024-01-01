namespace Proiect_Matrix
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
            this.read_data_matrix = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.add_matrices = new System.Windows.Forms.Button();
            this.subtract_matrices = new System.Windows.Forms.Button();
            this.transpose_matrices = new System.Windows.Forms.Button();
            this.multiply_matrices = new System.Windows.Forms.Button();
            this.matrices_power = new System.Windows.Forms.Button();
            this.n_power = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // read_data_matrix
            // 
            this.read_data_matrix.Location = new System.Drawing.Point(129, 67);
            this.read_data_matrix.Name = "read_data_matrix";
            this.read_data_matrix.Size = new System.Drawing.Size(188, 64);
            this.read_data_matrix.TabIndex = 0;
            this.read_data_matrix.Text = "Read Data Matrix";
            this.read_data_matrix.UseVisualStyleBackColor = true;
            this.read_data_matrix.Click += new System.EventHandler(this.read_data_matrix_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proiect Matrix";
            // 
            // add_matrices
            // 
            this.add_matrices.Location = new System.Drawing.Point(226, 137);
            this.add_matrices.Name = "add_matrices";
            this.add_matrices.Size = new System.Drawing.Size(188, 64);
            this.add_matrices.TabIndex = 6;
            this.add_matrices.Text = "Add Matrices\r\n";
            this.add_matrices.UseVisualStyleBackColor = true;
            this.add_matrices.Click += new System.EventHandler(this.add_matrices_Click);
            // 
            // subtract_matrices
            // 
            this.subtract_matrices.Location = new System.Drawing.Point(18, 137);
            this.subtract_matrices.Name = "subtract_matrices";
            this.subtract_matrices.Size = new System.Drawing.Size(188, 64);
            this.subtract_matrices.TabIndex = 7;
            this.subtract_matrices.Text = "Subtract Matrices\r\n";
            this.subtract_matrices.UseVisualStyleBackColor = true;
            this.subtract_matrices.Click += new System.EventHandler(this.subtract_matrices_Click);
            // 
            // transpose_matrices
            // 
            this.transpose_matrices.Location = new System.Drawing.Point(226, 228);
            this.transpose_matrices.Name = "transpose_matrices";
            this.transpose_matrices.Size = new System.Drawing.Size(188, 64);
            this.transpose_matrices.TabIndex = 8;
            this.transpose_matrices.Text = "Transposes of Matrices";
            this.transpose_matrices.UseVisualStyleBackColor = true;
            this.transpose_matrices.Click += new System.EventHandler(this.transpose_matrices_Click);
            // 
            // multiply_matrices
            // 
            this.multiply_matrices.Location = new System.Drawing.Point(12, 228);
            this.multiply_matrices.Name = "multiply_matrices";
            this.multiply_matrices.Size = new System.Drawing.Size(188, 64);
            this.multiply_matrices.TabIndex = 9;
            this.multiply_matrices.Text = "Multiply Matrices\r\n";
            this.multiply_matrices.UseVisualStyleBackColor = true;
            this.multiply_matrices.Click += new System.EventHandler(this.multiply_matrices_Click);
            // 
            // matrices_power
            // 
            this.matrices_power.Location = new System.Drawing.Point(12, 329);
            this.matrices_power.Name = "matrices_power";
            this.matrices_power.Size = new System.Drawing.Size(188, 64);
            this.matrices_power.TabIndex = 10;
            this.matrices_power.Text = "Matrices of Power N\r\n";
            this.matrices_power.UseVisualStyleBackColor = true;
            this.matrices_power.Click += new System.EventHandler(this.matrices_power_Click);
            // 
            // n_power
            // 
            this.n_power.Location = new System.Drawing.Point(348, 341);
            this.n_power.Multiline = true;
            this.n_power.Name = "n_power";
            this.n_power.Size = new System.Drawing.Size(65, 33);
            this.n_power.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 33);
            this.label3.TabIndex = 13;
            this.label3.Text = "Write N:\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 399);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.n_power);
            this.Controls.Add(this.matrices_power);
            this.Controls.Add(this.multiply_matrices);
            this.Controls.Add(this.transpose_matrices);
            this.Controls.Add(this.subtract_matrices);
            this.Controls.Add(this.add_matrices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.read_data_matrix);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button read_data_matrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_matrices;
        private System.Windows.Forms.Button subtract_matrices;
        private System.Windows.Forms.Button transpose_matrices;
        private System.Windows.Forms.Button multiply_matrices;
        private System.Windows.Forms.Button matrices_power;
        private System.Windows.Forms.TextBox n_power;
        private System.Windows.Forms.Label label3;
    }
}

