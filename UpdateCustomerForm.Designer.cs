namespace AkariBowens_Sheduling_System
{
    partial class UpdateCustomerForm
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
            this.address_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.address_textBox = new System.Windows.Forms.TextBox();
            this.variable_text_label = new System.Windows.Forms.Label();
            this.phone_textBox = new System.Windows.Forms.TextBox();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(69, 329);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(88, 45);
            this.save_button.TabIndex = 17;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.Location = new System.Drawing.Point(192, 329);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(88, 45);
            this.cancel_button.TabIndex = 16;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address_label.Location = new System.Drawing.Point(78, 241);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(55, 16);
            this.address_label.TabIndex = 15;
            this.address_label.Text = "Address";
            // 
            // phone_label
            // 
            this.phone_label.AutoSize = true;
            this.phone_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_label.Location = new System.Drawing.Point(78, 176);
            this.phone_label.Name = "phone_label";
            this.phone_label.Size = new System.Drawing.Size(95, 16);
            this.phone_label.TabIndex = 14;
            this.phone_label.Text = "Phone Number";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(78, 111);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(42, 16);
            this.name_label.TabIndex = 13;
            this.name_label.Text = "Name";
            // 
            // address_textBox
            // 
            this.address_textBox.Location = new System.Drawing.Point(81, 260);
            this.address_textBox.Name = "address_textBox";
            this.address_textBox.Size = new System.Drawing.Size(186, 20);
            this.address_textBox.TabIndex = 12;
            // 
            // variable_text_label
            // 
            this.variable_text_label.AutoSize = true;
            this.variable_text_label.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variable_text_label.Location = new System.Drawing.Point(51, 45);
            this.variable_text_label.Name = "variable_text_label";
            this.variable_text_label.Size = new System.Drawing.Size(106, 25);
            this.variable_text_label.TabIndex = 11;
            this.variable_text_label.Text = "Customer";
            // 
            // phone_textBox
            // 
            this.phone_textBox.Location = new System.Drawing.Point(81, 195);
            this.phone_textBox.MaxLength = 8;
            this.phone_textBox.Name = "phone_textBox";
            this.phone_textBox.Size = new System.Drawing.Size(186, 20);
            this.phone_textBox.TabIndex = 10;
            this.phone_textBox.TextChanged += new System.EventHandler(this.phone_textBox_TextChanged);
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(81, 130);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(186, 20);
            this.name_textBox.TabIndex = 9;
            this.name_textBox.TextChanged += new System.EventHandler(this.name_textBox_TextChanged);
            // 
            // UpdateCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 418);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.address_label);
            this.Controls.Add(this.phone_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.address_textBox);
            this.Controls.Add(this.variable_text_label);
            this.Controls.Add(this.phone_textBox);
            this.Controls.Add(this.name_textBox);
            this.Name = "UpdateCustomerForm";
            this.Text = "UpdateCustomer";
            this.Load += new System.EventHandler(this.UpdateCustomerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Label phone_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox address_textBox;
        private System.Windows.Forms.Label variable_text_label;
        private System.Windows.Forms.TextBox phone_textBox;
        private System.Windows.Forms.TextBox name_textBox;
    }
}