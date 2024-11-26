namespace AkariBowens_Sheduling_System
{
    partial class AppointmentsForm
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
            this.appointments_DGV = new System.Windows.Forms.DataGridView();
            this.appointments_label = new System.Windows.Forms.Label();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Update_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Close_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointments_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // appointments_DGV
            // 
            this.appointments_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointments_DGV.Location = new System.Drawing.Point(67, 91);
            this.appointments_DGV.Name = "appointments_DGV";
            this.appointments_DGV.Size = new System.Drawing.Size(450, 150);
            this.appointments_DGV.TabIndex = 0;
            // 
            // appointments_label
            // 
            this.appointments_label.AutoSize = true;
            this.appointments_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointments_label.Location = new System.Drawing.Point(30, 30);
            this.appointments_label.Name = "appointments_label";
            this.appointments_label.Size = new System.Drawing.Size(153, 25);
            this.appointments_label.TabIndex = 1;
            this.appointments_label.Text = "Appointments";
            // 
            // Add_Button
            // 
            this.Add_Button.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Button.Location = new System.Drawing.Point(273, 264);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(82, 42);
            this.Add_Button.TabIndex = 2;
            this.Add_Button.Text = "Add";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Update_Button
            // 
            this.Update_Button.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Button.Location = new System.Drawing.Point(178, 264);
            this.Update_Button.Name = "Update_Button";
            this.Update_Button.Size = new System.Drawing.Size(82, 42);
            this.Update_Button.TabIndex = 3;
            this.Update_Button.Text = "Update";
            this.Update_Button.UseVisualStyleBackColor = true;
            this.Update_Button.Click += new System.EventHandler(this.Update_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Button.Location = new System.Drawing.Point(83, 264);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(82, 42);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Close_button
            // 
            this.Close_button.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_button.Location = new System.Drawing.Point(419, 264);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(82, 42);
            this.Close_button.TabIndex = 5;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // AppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 371);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Update_Button);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.appointments_label);
            this.Controls.Add(this.appointments_DGV);
            this.Name = "AppointmentsForm";
            this.Text = "AppointmentsForm";
            this.Load += new System.EventHandler(this.AppointmentsForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointments_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView appointments_DGV;
        private System.Windows.Forms.Label appointments_label;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Button Update_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Close_button;
    }
}