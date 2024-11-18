namespace AkariBowens_Sheduling_System
{
    partial class UpdateAppointmentForm
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
            this.End_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Start_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Customer_label = new System.Windows.Forms.Label();
            this.Customer_textBox = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.end_label = new System.Windows.Forms.Label();
            this.start_label = new System.Windows.Forms.Label();
            this.ApptType_label = new System.Windows.Forms.Label();
            this.variable_text_label = new System.Windows.Forms.Label();
            this.ApptType_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // End_DateTimePicker
            // 
            this.End_DateTimePicker.CustomFormat = "hh:mm:ss tt";
            this.End_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.End_DateTimePicker.Location = new System.Drawing.Point(74, 246);
            this.End_DateTimePicker.MaxDate = new System.DateTime(2224, 12, 31, 0, 0, 0, 0);
            this.End_DateTimePicker.MinDate = new System.DateTime(2003, 1, 1, 0, 0, 0, 0);
            this.End_DateTimePicker.Name = "End_DateTimePicker";
            this.End_DateTimePicker.Size = new System.Drawing.Size(86, 20);
            this.End_DateTimePicker.TabIndex = 32;
            this.End_DateTimePicker.ValueChanged += new System.EventHandler(this.End_DateTimePicker_ValueChanged);
            // 
            // Start_DateTimePicker
            // 
            this.Start_DateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            this.Start_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Start_DateTimePicker.Location = new System.Drawing.Point(74, 187);
            this.Start_DateTimePicker.MaxDate = new System.DateTime(2224, 12, 31, 0, 0, 0, 0);
            this.Start_DateTimePicker.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.Start_DateTimePicker.Name = "Start_DateTimePicker";
            this.Start_DateTimePicker.Size = new System.Drawing.Size(160, 20);
            this.Start_DateTimePicker.TabIndex = 31;
            this.Start_DateTimePicker.ValueChanged += new System.EventHandler(this.Start_DateTimePicker_ValueChanged);
            // 
            // Customer_label
            // 
            this.Customer_label.AutoSize = true;
            this.Customer_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_label.Location = new System.Drawing.Point(74, 286);
            this.Customer_label.Name = "Customer_label";
            this.Customer_label.Size = new System.Drawing.Size(63, 16);
            this.Customer_label.TabIndex = 30;
            this.Customer_label.Text = "Customer";
            // 
            // Customer_textBox
            // 
            this.Customer_textBox.Location = new System.Drawing.Point(74, 305);
            this.Customer_textBox.Name = "Customer_textBox";
            this.Customer_textBox.Size = new System.Drawing.Size(186, 20);
            this.Customer_textBox.TabIndex = 29;
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(62, 391);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(88, 45);
            this.save_button.TabIndex = 28;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.Location = new System.Drawing.Point(185, 391);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(88, 45);
            this.cancel_button.TabIndex = 27;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // end_label
            // 
            this.end_label.AutoSize = true;
            this.end_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_label.Location = new System.Drawing.Point(74, 227);
            this.end_label.Name = "end_label";
            this.end_label.Size = new System.Drawing.Size(61, 16);
            this.end_label.TabIndex = 26;
            this.end_label.Text = "End Time";
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_label.Location = new System.Drawing.Point(74, 168);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(66, 16);
            this.start_label.TabIndex = 25;
            this.start_label.Text = "Start Time";
            // 
            // ApptType_label
            // 
            this.ApptType_label.AutoSize = true;
            this.ApptType_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApptType_label.Location = new System.Drawing.Point(74, 109);
            this.ApptType_label.Name = "ApptType_label";
            this.ApptType_label.Size = new System.Drawing.Size(35, 16);
            this.ApptType_label.TabIndex = 24;
            this.ApptType_label.Text = "Type";
            // 
            // variable_text_label
            // 
            this.variable_text_label.AutoSize = true;
            this.variable_text_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variable_text_label.Location = new System.Drawing.Point(44, 43);
            this.variable_text_label.Name = "variable_text_label";
            this.variable_text_label.Size = new System.Drawing.Size(144, 25);
            this.variable_text_label.TabIndex = 23;
            this.variable_text_label.Text = "Appointment";
            // 
            // ApptType_textBox
            // 
            this.ApptType_textBox.Location = new System.Drawing.Point(74, 128);
            this.ApptType_textBox.Name = "ApptType_textBox";
            this.ApptType_textBox.Size = new System.Drawing.Size(186, 20);
            this.ApptType_textBox.TabIndex = 22;
            this.ApptType_textBox.TextChanged += new System.EventHandler(this.ApptType_textBox_TextChanged);
            // 
            // UpdateAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 478);
            this.Controls.Add(this.End_DateTimePicker);
            this.Controls.Add(this.Start_DateTimePicker);
            this.Controls.Add(this.Customer_label);
            this.Controls.Add(this.Customer_textBox);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.end_label);
            this.Controls.Add(this.start_label);
            this.Controls.Add(this.ApptType_label);
            this.Controls.Add(this.variable_text_label);
            this.Controls.Add(this.ApptType_textBox);
            this.Name = "UpdateAppointmentForm";
            this.Text = "UpdateAppointmentForm";
            this.Load += new System.EventHandler(this.UpdateAppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker End_DateTimePicker;
        private System.Windows.Forms.DateTimePicker Start_DateTimePicker;
        private System.Windows.Forms.Label Customer_label;
        private System.Windows.Forms.TextBox Customer_textBox;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label end_label;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label ApptType_label;
        private System.Windows.Forms.Label variable_text_label;
        private System.Windows.Forms.TextBox ApptType_textBox;
    }
}