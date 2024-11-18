namespace AkariBowens_Sheduling_System
{
    partial class AllAppointmentsCalendar
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.allAppts_label = new System.Windows.Forms.Label();
            this.Close_button = new System.Windows.Forms.Button();
            this.View_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 3);
            this.monthCalendar1.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(27, 70);
            this.monthCalendar1.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // allAppts_label
            // 
            this.allAppts_label.AutoSize = true;
            this.allAppts_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAppts_label.Location = new System.Drawing.Point(371, 24);
            this.allAppts_label.Name = "allAppts_label";
            this.allAppts_label.Size = new System.Drawing.Size(186, 25);
            this.allAppts_label.TabIndex = 1;
            this.allAppts_label.Text = "All Appointments";
            this.allAppts_label.Click += new System.EventHandler(this.allAppts_label_Click);
            // 
            // Close_button
            // 
            this.Close_button.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_button.Location = new System.Drawing.Point(801, 545);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(94, 47);
            this.Close_button.TabIndex = 2;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // View_button
            // 
            this.View_button.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_button.Location = new System.Drawing.Point(671, 545);
            this.View_button.Name = "View_button";
            this.View_button.Size = new System.Drawing.Size(94, 47);
            this.View_button.TabIndex = 3;
            this.View_button.Text = "View";
            this.View_button.UseVisualStyleBackColor = true;
            this.View_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // AllAppointmentsCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 614);
            this.Controls.Add(this.View_button);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.allAppts_label);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "AllAppointmentsCalendar";
            this.Text = "AllAppointmentsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label allAppts_label;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Button View_button;
    }
}