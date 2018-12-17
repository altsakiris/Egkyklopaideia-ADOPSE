namespace Egkyklopaideia
{
    partial class AboutPopUp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutPopUp));
            this.labelAboutName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAboutClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAboutName
            // 
            this.labelAboutName.AutoSize = true;
            this.labelAboutName.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutName.Location = new System.Drawing.Point(35, 31);
            this.labelAboutName.Name = "labelAboutName";
            this.labelAboutName.Size = new System.Drawing.Size(79, 31);
            this.labelAboutName.TabIndex = 0;
            this.labelAboutName.Text = "About";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Περιεχόμενο του About";
            // 
            // buttonAboutClose
            // 
            this.buttonAboutClose.FlatAppearance.BorderSize = 0;
            this.buttonAboutClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAboutClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAboutClose.ForeColor = System.Drawing.Color.White;
            this.buttonAboutClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAboutClose.Location = new System.Drawing.Point(429, 15);
            this.buttonAboutClose.Name = "buttonAboutClose";
            this.buttonAboutClose.Size = new System.Drawing.Size(32, 35);
            this.buttonAboutClose.TabIndex = 5;
            this.buttonAboutClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAboutClose.UseVisualStyleBackColor = true;
            this.buttonAboutClose.Click += new System.EventHandler(this.button13_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(429, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 35);
            this.button1.TabIndex = 7;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AboutPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAboutClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAboutName);
            this.Name = "AboutPopUp";
            this.Size = new System.Drawing.Size(480, 320);
            this.Load += new System.EventHandler(this.AboutPopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAboutName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAboutClose;
        private System.Windows.Forms.Button button1;
    }
}
