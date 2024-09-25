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
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.ForeColor = System.Drawing.Color.Red;
            this.close_button.Location = new System.Drawing.Point(633, 339);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(106, 50);
            this.close_button.TabIndex = 0;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // appts_label
            // 
            this.appts_label.AutoSize = true;
            this.appts_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appts_label.Location = new System.Drawing.Point(470, 45);
            this.appts_label.Name = "appts_label";
            this.appts_label.Size = new System.Drawing.Size(153, 25);
            this.appts_label.TabIndex = 1;
            this.appts_label.Text = "Appointments";
            // 
            // customers_label
            // 
            this.customers_label.AutoSize = true;
            this.customers_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_label.Location = new System.Drawing.Point(34, 45);
            this.customers_label.Name = "customers_label";
            this.customers_label.Size = new System.Drawing.Size(115, 25);
            this.customers_label.TabIndex = 2;
            this.customers_label.Text = "Customers";
            // 
            // CurrentUserViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customers_label);
            this.Controls.Add(this.appts_label);
            this.Controls.Add(this.close_button);
            this.Name = "CurrentUserViewForm";
            this.Text = "CurrentUserViewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label appts_label;
        private System.Windows.Forms.Label customers_label;
    }
}