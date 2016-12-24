namespace Курсач
{
    partial class CustomerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.makedeal_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(88, 41);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ввести данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // makedeal_button
            // 
            this.makedeal_button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makedeal_button.Location = new System.Drawing.Point(88, 114);
            this.makedeal_button.Margin = new System.Windows.Forms.Padding(2);
            this.makedeal_button.Name = "makedeal_button";
            this.makedeal_button.Size = new System.Drawing.Size(146, 49);
            this.makedeal_button.TabIndex = 1;
            this.makedeal_button.Text = "Сделать \r\nзаказ";
            this.makedeal_button.UseVisualStyleBackColor = true;
            this.makedeal_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // back_button
            // 
            this.back_button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(11, 208);
            this.back_button.Margin = new System.Windows.Forms.Padding(2);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(184, 36);
            this.back_button.TabIndex = 2;
            this.back_button.Text = "Выйти из профиля";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(200, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "Закрыть приложение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 255);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.makedeal_button);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button makedeal_button;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button button4;
    }
}