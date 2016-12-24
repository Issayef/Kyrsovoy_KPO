namespace Курсач
{
    partial class SupplierForm
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
            this.Close_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.makedeal_button = new System.Windows.Forms.Button();
            this.EnterData_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Close_button
            // 
            this.Close_button.BackColor = System.Drawing.Color.GhostWhite;
            this.Close_button.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close_button.Location = new System.Drawing.Point(255, 239);
            this.Close_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(217, 44);
            this.Close_button.TabIndex = 7;
            this.Close_button.Text = "Закрыть приложение";
            this.Close_button.UseVisualStyleBackColor = false;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // back_button
            // 
            this.back_button.BackColor = System.Drawing.Color.GhostWhite;
            this.back_button.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(12, 239);
            this.back_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(211, 44);
            this.back_button.TabIndex = 6;
            this.back_button.Text = "Выйти из профиля";
            this.back_button.UseVisualStyleBackColor = false;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // makedeal_button
            // 
            this.makedeal_button.BackColor = System.Drawing.Color.AliceBlue;
            this.makedeal_button.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makedeal_button.Location = new System.Drawing.Point(152, 114);
            this.makedeal_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.makedeal_button.Name = "makedeal_button";
            this.makedeal_button.Size = new System.Drawing.Size(195, 60);
            this.makedeal_button.TabIndex = 5;
            this.makedeal_button.Text = "Сделать \r\nпоставку";
            this.makedeal_button.UseVisualStyleBackColor = false;
            this.makedeal_button.Click += new System.EventHandler(this.makedeal_button_Click);
            // 
            // EnterData_button
            // 
            this.EnterData_button.BackColor = System.Drawing.Color.AliceBlue;
            this.EnterData_button.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterData_button.Location = new System.Drawing.Point(152, 35);
            this.EnterData_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnterData_button.Name = "EnterData_button";
            this.EnterData_button.Size = new System.Drawing.Size(195, 46);
            this.EnterData_button.TabIndex = 4;
            this.EnterData_button.Text = "Ввести данные";
            this.EnterData_button.UseVisualStyleBackColor = false;
            this.EnterData_button.Click += new System.EventHandler(this.EnterData_button_Click);
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(499, 321);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.makedeal_button);
            this.Controls.Add(this.EnterData_button);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SupplierForm";
            this.Text = "SupplierForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button makedeal_button;
        private System.Windows.Forms.Button EnterData_button;
    }
}