namespace AkariBowens_Sheduling_System
{
    partial class CurrentUserViewForm
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
            this.close_button = new System.Windows.Forms.Button();
            this.appts_label = new System.Windows.Forms.Label();
            this.customers_label = new System.Windows.Forms.Label();
            this.AppointmentDGV = new System.Windows.Forms.DataGridView();
            this.CustomerDGV = new System.Windows.Forms.DataGridView();
            this.customers_delete_button = new System.Windows.Forms.Button();
            this.customers_update_button = new System.Windows.Forms.Button();
            this.customers_add_button = new System.Windows.Forms.Button();
            this.appts_add_button = new System.Windows.Forms.Button();
            this.appts_update_button = new System.Windows.Forms.Button();
            this.appts_delete_button = new System.Windows.Forms.Button();
            this.viewAll_Link = new System.Windows.Forms.LinkLabel();
            this.reports_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_button.ForeColor = System.Drawing.Color.Red;
            this.close_button.Location = new System.Drawing.Point(905, 366);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(91, 46);
            this.close_button.TabIndex = 0;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // appts_label
            // 
            this.appts_label.AutoSize = true;
            this.appts_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appts_label.Location = new System.Drawing.Point(548, 64);
            this.appts_label.Name = "appts_label";
            this.appts_label.Size = new System.Drawing.Size(153, 25);
            this.appts_label.TabIndex = 1;
            this.appts_label.Text = "Appointments";
            // 
            // customers_label
            // 
            this.customers_label.AutoSize = true;
            this.customers_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_label.Location = new System.Drawing.Point(51, 64);
            this.customers_label.Name = "customers_label";
            this.customers_label.Size = new System.Drawing.Size(115, 25);
            this.customers_label.TabIndex = 2;
            this.customers_label.Text = "Customers";
            // 
            // AppointmentDGV
            // 
            this.AppointmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentDGV.Location = new System.Drawing.Point(553, 111);
            this.AppointmentDGV.Name = "AppointmentDGV";
            this.AppointmentDGV.Size = new System.Drawing.Size(463, 136);
            this.AppointmentDGV.TabIndex = 3;
            this.AppointmentDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppointmentDGV_CellContentClick);
            this.AppointmentDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AppointmentDGV_DataBindingComplete);
            // 
            // CustomerDGV
            // 
            this.CustomerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDGV.Location = new System.Drawing.Point(56, 111);
            this.CustomerDGV.Name = "CustomerDGV";
            this.CustomerDGV.Size = new System.Drawing.Size(463, 136);
            this.CustomerDGV.TabIndex = 4;
            this.CustomerDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerDGV_CellContentClick);
            this.CustomerDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CustomerDGV_DataBindingComplete);
            // 
            // customers_delete_button
            // 
            this.customers_delete_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_delete_button.Location = new System.Drawing.Point(446, 275);
            this.customers_delete_button.Name = "customers_delete_button";
            this.customers_delete_button.Size = new System.Drawing.Size(73, 38);
            this.customers_delete_button.TabIndex = 5;
            this.customers_delete_button.Text = "Delete";
            this.customers_delete_button.UseVisualStyleBackColor = true;
            this.customers_delete_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // customers_update_button
            // 
            this.customers_update_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_update_button.Location = new System.Drawing.Point(353, 275);
            this.customers_update_button.Name = "customers_update_button";
            this.customers_update_button.Size = new System.Drawing.Size(73, 38);
            this.customers_update_button.TabIndex = 6;
            this.customers_update_button.Text = "Update";
            this.customers_update_button.UseVisualStyleBackColor = true;
            this.customers_update_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // customers_add_button
            // 
            this.customers_add_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_add_button.Location = new System.Drawing.Point(260, 275);
            this.customers_add_button.Name = "customers_add_button";
            this.customers_add_button.Size = new System.Drawing.Size(73, 38);
            this.customers_add_button.TabIndex = 7;
            this.customers_add_button.Text = "Add";
            this.customers_add_button.UseVisualStyleBackColor = true;
            this.customers_add_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // appts_add_button
            // 
            this.appts_add_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appts_add_button.Location = new System.Drawing.Point(757, 275);
            this.appts_add_button.Name = "appts_add_button";
            this.appts_add_button.Size = new System.Drawing.Size(73, 38);
            this.appts_add_button.TabIndex = 10;
            this.appts_add_button.Text = "Add";
            this.appts_add_button.UseVisualStyleBackColor = true;
            this.appts_add_button.Click += new System.EventHandler(this.appts_add_button_Click);
            // 
            // appts_update_button
            // 
            this.appts_update_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appts_update_button.Location = new System.Drawing.Point(850, 275);
            this.appts_update_button.Name = "appts_update_button";
            this.appts_update_button.Size = new System.Drawing.Size(73, 38);
            this.appts_update_button.TabIndex = 9;
            this.appts_update_button.Text = "Update";
            this.appts_update_button.UseVisualStyleBackColor = true;
            this.appts_update_button.Click += new System.EventHandler(this.appts_update_button_Click);
            // 
            // appts_delete_button
            // 
            this.appts_delete_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appts_delete_button.Location = new System.Drawing.Point(943, 275);
            this.appts_delete_button.Name = "appts_delete_button";
            this.appts_delete_button.Size = new System.Drawing.Size(73, 38);
            this.appts_delete_button.TabIndex = 8;
            this.appts_delete_button.Text = "Delete";
            this.appts_delete_button.UseVisualStyleBackColor = true;
            this.appts_delete_button.Click += new System.EventHandler(this.appts_delete_button_Click);
            // 
            // viewAll_Link
            // 
            this.viewAll_Link.AutoSize = true;
            this.viewAll_Link.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAll_Link.Location = new System.Drawing.Point(847, 83);
            this.viewAll_Link.Name = "viewAll_Link";
            this.viewAll_Link.Size = new System.Drawing.Size(163, 16);
            this.viewAll_Link.TabIndex = 11;
            this.viewAll_Link.TabStop = true;
            this.viewAll_Link.Text = "View Appointments by Day";
            this.viewAll_Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // reports_button
            // 
            this.reports_button.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reports_button.Location = new System.Drawing.Point(109, 366);
            this.reports_button.Name = "reports_button";
            this.reports_button.Size = new System.Drawing.Size(79, 46);
            this.reports_button.TabIndex = 12;
            this.reports_button.Text = "Reports";
            this.reports_button.UseVisualStyleBackColor = true;
            this.reports_button.Click += new System.EventHandler(this.reports_button_Click);
            // 
            // CurrentUserViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 463);
            this.Controls.Add(this.reports_button);
            this.Controls.Add(this.viewAll_Link);
            this.Controls.Add(this.appts_add_button);
            this.Controls.Add(this.appts_update_button);
            this.Controls.Add(this.appts_delete_button);
            this.Controls.Add(this.customers_add_button);
            this.Controls.Add(this.customers_update_button);
            this.Controls.Add(this.customers_delete_button);
            this.Controls.Add(this.CustomerDGV);
            this.Controls.Add(this.AppointmentDGV);
            this.Controls.Add(this.customers_label);
            this.Controls.Add(this.appts_label);
            this.Controls.Add(this.close_button);
            this.Name = "CurrentUserViewForm";
            this.Text = "CurrentUserViewForm";
            this.Load += new System.EventHandler(this.CurrentUserViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label appts_label;
        private System.Windows.Forms.Label customers_label;
        private System.Windows.Forms.DataGridView AppointmentDGV;
        private System.Windows.Forms.DataGridView CustomerDGV;
        private System.Windows.Forms.Button customers_delete_button;
        private System.Windows.Forms.Button customers_update_button;
        private System.Windows.Forms.Button customers_add_button;
        private System.Windows.Forms.Button appts_add_button;
        private System.Windows.Forms.Button appts_update_button;
        private System.Windows.Forms.Button appts_delete_button;
        private System.Windows.Forms.LinkLabel viewAll_Link;
        private System.Windows.Forms.Button reports_button;
    }
}