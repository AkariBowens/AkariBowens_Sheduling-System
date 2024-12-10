namespace AkariBowens_Sheduling_System.Classes
{
    partial class ReportsForm
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
            this.ReportsFormClose_button = new System.Windows.Forms.Button();
            this.ApptsPerMonth_Button = new System.Windows.Forms.Button();
            this.UserSchedule_Button = new System.Windows.Forms.Button();
            this.CustomersPerCountry_Button = new System.Windows.Forms.Button();
            this.Reports_Label = new System.Windows.Forms.Label();
            this.ApptsPerMonth_desc = new System.Windows.Forms.Label();
            this.UserSchedule_desc = new System.Windows.Forms.Label();
            this.CustomersPerCountry_label = new System.Windows.Forms.Label();
            this.VarDGVLabel = new System.Windows.Forms.Label();
            this.ReportsDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportsFormClose_button
            // 
            this.ReportsFormClose_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportsFormClose_button.Location = new System.Drawing.Point(641, 369);
            this.ReportsFormClose_button.Name = "ReportsFormClose_button";
            this.ReportsFormClose_button.Size = new System.Drawing.Size(85, 46);
            this.ReportsFormClose_button.TabIndex = 1;
            this.ReportsFormClose_button.Text = "Close";
            this.ReportsFormClose_button.UseVisualStyleBackColor = true;
            this.ReportsFormClose_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // ApptsPerMonth_Button
            // 
            this.ApptsPerMonth_Button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApptsPerMonth_Button.Location = new System.Drawing.Point(67, 114);
            this.ApptsPerMonth_Button.Name = "ApptsPerMonth_Button";
            this.ApptsPerMonth_Button.Size = new System.Drawing.Size(60, 40);
            this.ApptsPerMonth_Button.TabIndex = 2;
            this.ApptsPerMonth_Button.Text = "View";
            this.ApptsPerMonth_Button.UseVisualStyleBackColor = true;
            this.ApptsPerMonth_Button.Click += new System.EventHandler(this.ApptsPerMonth_Button_Click);
            // 
            // UserSchedule_Button
            // 
            this.UserSchedule_Button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserSchedule_Button.Location = new System.Drawing.Point(67, 187);
            this.UserSchedule_Button.Name = "UserSchedule_Button";
            this.UserSchedule_Button.Size = new System.Drawing.Size(60, 40);
            this.UserSchedule_Button.TabIndex = 3;
            this.UserSchedule_Button.Text = "View";
            this.UserSchedule_Button.UseVisualStyleBackColor = true;
            // 
            // CustomersPerCountry_Button
            // 
            this.CustomersPerCountry_Button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomersPerCountry_Button.Location = new System.Drawing.Point(67, 264);
            this.CustomersPerCountry_Button.Name = "CustomersPerCountry_Button";
            this.CustomersPerCountry_Button.Size = new System.Drawing.Size(60, 40);
            this.CustomersPerCountry_Button.TabIndex = 4;
            this.CustomersPerCountry_Button.Text = "View";
            this.CustomersPerCountry_Button.UseVisualStyleBackColor = true;
            // 
            // Reports_Label
            // 
            this.Reports_Label.AutoSize = true;
            this.Reports_Label.Font = new System.Drawing.Font("Gadugi", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reports_Label.Location = new System.Drawing.Point(38, 33);
            this.Reports_Label.Name = "Reports_Label";
            this.Reports_Label.Size = new System.Drawing.Size(115, 32);
            this.Reports_Label.TabIndex = 5;
            this.Reports_Label.Text = "Reports";
            // 
            // ApptsPerMonth_desc
            // 
            this.ApptsPerMonth_desc.AutoSize = true;
            this.ApptsPerMonth_desc.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApptsPerMonth_desc.Location = new System.Drawing.Point(160, 126);
            this.ApptsPerMonth_desc.Name = "ApptsPerMonth_desc";
            this.ApptsPerMonth_desc.Size = new System.Drawing.Size(153, 16);
            this.ApptsPerMonth_desc.TabIndex = 6;
            this.ApptsPerMonth_desc.Text = "Appointments per month";
            // 
            // UserSchedule_desc
            // 
            this.UserSchedule_desc.AutoSize = true;
            this.UserSchedule_desc.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserSchedule_desc.Location = new System.Drawing.Point(160, 199);
            this.UserSchedule_desc.Name = "UserSchedule_desc";
            this.UserSchedule_desc.Size = new System.Drawing.Size(90, 16);
            this.UserSchedule_desc.TabIndex = 7;
            this.UserSchedule_desc.Text = "User Schedule";
            // 
            // CustomersPerCountry_label
            // 
            this.CustomersPerCountry_label.AutoSize = true;
            this.CustomersPerCountry_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomersPerCountry_label.Location = new System.Drawing.Point(160, 276);
            this.CustomersPerCountry_label.Name = "CustomersPerCountry_label";
            this.CustomersPerCountry_label.Size = new System.Drawing.Size(141, 16);
            this.CustomersPerCountry_label.TabIndex = 8;
            this.CustomersPerCountry_label.Text = "Customers Per Country";
            // 
            // VarDGVLabel
            // 
            this.VarDGVLabel.AutoSize = true;
            this.VarDGVLabel.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VarDGVLabel.Location = new System.Drawing.Point(399, 78);
            this.VarDGVLabel.Name = "VarDGVLabel";
            this.VarDGVLabel.Size = new System.Drawing.Size(184, 19);
            this.VarDGVLabel.TabIndex = 9;
            this.VarDGVLabel.Text = "Appointments Per Month";
            // 
            // ReportsDGV
            // 
            this.ReportsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportsDGV.Location = new System.Drawing.Point(394, 114);
            this.ReportsDGV.Name = "ReportsDGV";
            this.ReportsDGV.Size = new System.Drawing.Size(356, 190);
            this.ReportsDGV.TabIndex = 11;
            this.ReportsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReportsDGV_CellContentClick_1);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.ReportsDGV);
            this.Controls.Add(this.VarDGVLabel);
            this.Controls.Add(this.CustomersPerCountry_label);
            this.Controls.Add(this.UserSchedule_desc);
            this.Controls.Add(this.ApptsPerMonth_desc);
            this.Controls.Add(this.Reports_Label);
            this.Controls.Add(this.CustomersPerCountry_Button);
            this.Controls.Add(this.UserSchedule_Button);
            this.Controls.Add(this.ApptsPerMonth_Button);
            this.Controls.Add(this.ReportsFormClose_button);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)(this.ReportsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ReportsFormClose_button;
        private System.Windows.Forms.Button ApptsPerMonth_Button;
        private System.Windows.Forms.Button UserSchedule_Button;
        private System.Windows.Forms.Button CustomersPerCountry_Button;
        private System.Windows.Forms.Label Reports_Label;
        private System.Windows.Forms.Label ApptsPerMonth_desc;
        private System.Windows.Forms.Label UserSchedule_desc;
        private System.Windows.Forms.Label CustomersPerCountry_label;
        private System.Windows.Forms.Label VarDGVLabel;
        private System.Windows.Forms.DataGridView ReportsDGV;
    }
}