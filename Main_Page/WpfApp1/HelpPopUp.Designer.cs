namespace Egkyklopaideia
{
    partial class HelpPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpPopUp));
            this.labelHelpName = new System.Windows.Forms.Label();
            this.buttonAboutClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHelpName
            // 
            this.labelHelpName.AutoSize = true;
            this.labelHelpName.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelpName.Location = new System.Drawing.Point(41, 37);
            this.labelHelpName.Name = "labelHelpName";
            this.labelHelpName.Size = new System.Drawing.Size(62, 31);
            this.labelHelpName.TabIndex = 1;
            this.labelHelpName.Text = "Help";
            // 
            // buttonAboutClose
            // 
            this.buttonAboutClose.FlatAppearance.BorderSize = 0;
            this.buttonAboutClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAboutClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAboutClose.ForeColor = System.Drawing.Color.White;
            this.buttonAboutClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonAboutClose.Image")));
            this.buttonAboutClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAboutClose.Location = new System.Drawing.Point(422, 22);
            this.buttonAboutClose.Name = "buttonAboutClose";
            this.buttonAboutClose.Size = new System.Drawing.Size(32, 35);
            this.buttonAboutClose.TabIndex = 6;
            this.buttonAboutClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAboutClose.UseVisualStyleBackColor = true;
            // 
            // HelpPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAboutClose);
            this.Controls.Add(this.labelHelpName);
            this.Name = "HelpPopUp";
            this.Size = new System.Drawing.Size(480, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHelpName;
        private System.Windows.Forms.Button buttonAboutClose;
    }
}
