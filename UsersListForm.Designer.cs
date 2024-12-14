namespace AkariBowens_Sheduling_System.Classes
{
    partial class UsersListForm
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
            this.cancel_button = new System.Windows.Forms.Button();
            this.UsersDGV = new System.Windows.Forms.DataGridView();
            this.users_label = new System.Windows.Forms.Label();
            this.select_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.Location = new System.Drawing.Point(300, 257);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(72, 41);
            this.cancel_button.TabIndex = 0;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // UsersDGV
            // 
            this.UsersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDGV.Location = new System.Drawing.Point(77, 86);
            this.UsersDGV.Name = "UsersDGV";
            this.UsersDGV.Size = new System.Drawing.Size(270, 134);
            this.UsersDGV.TabIndex = 1;
            this.UsersDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.UsersDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.UsersDGV_DataBindingComplete);
            // 
            // users_label
            // 
            this.users_label.AutoSize = true;
            this.users_label.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.users_label.Location = new System.Drawing.Point(25, 27);
            this.users_label.Name = "users_label";
            this.users_label.Size = new System.Drawing.Size(74, 28);
            this.users_label.TabIndex = 2;
            this.users_label.Text = "Users";
            this.users_label.Click += new System.EventHandler(this.users_label_Click);
            // 
            // select_button
            // 
            this.select_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_button.Location = new System.Drawing.Point(198, 257);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(72, 41);
            this.select_button.TabIndex = 3;
            this.select_button.Text = "Select";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // UsersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 329);
            this.Controls.Add(this.select_button);
            this.Controls.Add(this.users_label);
            this.Controls.Add(this.UsersDGV);
            this.Controls.Add(this.cancel_button);
            this.Name = "UsersListForm";
            this.Text = "UsersListForm";
            this.Load += new System.EventHandler(this.UsersListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.DataGridView UsersDGV;
        private System.Windows.Forms.Label users_label;
        private System.Windows.Forms.Button select_button;
    }
}