namespace AkariBowens_Sheduling_System
{
    partial class AddAppointmentForm
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
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.end_label = new System.Windows.Forms.Label();
            this.start_label = new System.Windows.Forms.Label();
            this.ApptType_label = new System.Windows.Forms.Label();
            this.end_textBox = new System.Windows.Forms.TextBox();
            this.variable_text_label = new System.Windows.Forms.Label();
            this.start_textBox = new System.Windows.Forms.TextBox();
            this.ApptType_textBox = new System.Windows.Forms.TextBox();
            this.Customer_label = new System.Windows.Forms.Label();
            this.Customer_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(60, 329);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(88, 45);
            this.save_button.TabIndex = 17;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.Location = new System.Drawing.Point(183, 329);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(88, 45);
            this.cancel_button.TabIndex = 16;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // end_label
            // 
            this.end_label.AutoSize = true;
            this.end_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_label.Location = new System.Drawing.Point(179, 176);
            this.end_label.Name = "end_label";
            this.end_label.Size = new System.Drawing.Size(61, 16);
            this.end_label.TabIndex = 15;
            this.end_label.Text = "End Time";
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_label.Location = new System.Drawing.Point(69, 176);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(66, 16);
            this.start_label.TabIndex = 14;
            this.start_label.Text = "Start Time";
            // 
            // ApptType_label
            // 
            this.ApptType_label.AutoSize = true;
            this.ApptType_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApptType_label.Location = new System.Drawing.Point(69, 111);
            this.ApptType_label.Name = "ApptType_label";
            this.ApptType_label.Size = new System.Drawing.Size(35, 16);
            this.ApptType_label.TabIndex = 13;
            this.ApptType_label.Text = "Type";
            // 
            // end_textBox
            // 
            this.end_textBox.Location = new System.Drawing.Point(182, 195);
            this.end_textBox.Name = "end_textBox";
            this.end_textBox.Size = new System.Drawing.Size(76, 20);
            this.end_textBox.TabIndex = 12;
            // 
            // variable_text_label
            // 
            this.variable_text_label.AutoSize = true;
            this.variable_text_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variable_text_label.Location = new System.Drawing.Point(42, 45);
            this.variable_text_label.Name = "variable_text_label";
            this.variable_text_label.Size = new System.Drawing.Size(144, 25);
            this.variable_text_label.TabIndex = 11;
            this.variable_text_label.Text = "Appointment";
            // 
            // start_textBox
            // 
            this.start_textBox.Location = new System.Drawing.Point(72, 195);
            this.start_textBox.Name = "start_textBox";
            this.start_textBox.Size = new System.Drawing.Size(76, 20);
            this.start_textBox.TabIndex = 10;
            this.start_textBox.TextChanged += new System.EventHandler(this.start_textBox_TextChanged);
            // 
            // ApptType_textBox
            // 
            this.ApptType_textBox.Location = new System.Drawing.Point(72, 130);
            this.ApptType_textBox.Name = "ApptType_textBox";
            this.ApptType_textBox.Size = new System.Drawing.Size(186, 20);
            this.ApptType_textBox.TabIndex = 9;
            this.ApptType_textBox.TextChanged += new System.EventHandler(this.ApptType_textBox_TextChanged);
            // 
            // Customer_label
            // 
            this.Customer_label.AutoSize = true;
            this.Customer_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_label.Location = new System.Drawing.Point(69, 243);
            this.Customer_label.Name = "Customer_label";
            this.Customer_label.Size = new System.Drawing.Size(63, 16);
            this.Customer_label.TabIndex = 19;
            this.Customer_label.Text = "Customer";
            // 
            // Customer_textBox
            // 
            this.Customer_textBox.Location = new System.Drawing.Point(72, 262);
            this.Customer_textBox.Name = "Customer_textBox";
            this.Customer_textBox.Size = new System.Drawing.Size(186, 20);
            this.Customer_textBox.TabIndex = 18;
            this.Customer_textBox.TextChanged += new System.EventHandler(this.Customer_textBox_TextChanged);
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 418);
            this.Controls.Add(this.Customer_label);
            this.Controls.Add(this.Customer_textBox);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.end_label);
            this.Controls.Add(this.start_label);
            this.Controls.Add(this.ApptType_label);
            this.Controls.Add(this.end_textBox);
            this.Controls.Add(this.variable_text_label);
            this.Controls.Add(this.start_textBox);
            this.Controls.Add(this.ApptType_textBox);
            this.Name = "AddAppointmentForm";
            this.Text = "AddAppointmentForm";
            this.Load += new System.EventHandler(this.AddAppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label end_label;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label ApptType_label;
        private System.Windows.Forms.TextBox end_textBox;
        private System.Windows.Forms.Label variable_text_label;
        private System.Windows.Forms.TextBox start_textBox;
        private System.Windows.Forms.TextBox ApptType_textBox;
        private System.Windows.Forms.Label Customer_label;
        private System.Windows.Forms.TextBox Customer_textBox;
    }
}