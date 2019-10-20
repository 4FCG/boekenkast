namespace Deelopdracht_2_versie_3
{
    partial class LocatieList
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
            this.secondaryObjectName = new System.Windows.Forms.Label();
            this.secondaryObjectSelection = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // secondaryObjectName
            // 
            this.secondaryObjectName.AutoSize = true;
            this.secondaryObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondaryObjectName.Location = new System.Drawing.Point(12, 50);
            this.secondaryObjectName.Name = "secondaryObjectName";
            this.secondaryObjectName.Size = new System.Drawing.Size(93, 25);
            this.secondaryObjectName.TabIndex = 8;
            this.secondaryObjectName.Text = "Locaties";
            // 
            // secondaryObjectSelection
            // 
            this.secondaryObjectSelection.FormattingEnabled = true;
            this.secondaryObjectSelection.Location = new System.Drawing.Point(12, 94);
            this.secondaryObjectSelection.Name = "secondaryObjectSelection";
            this.secondaryObjectSelection.Size = new System.Drawing.Size(200, 21);
            this.secondaryObjectSelection.TabIndex = 9;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(12, 121);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 40);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectButton.Location = new System.Drawing.Point(58, 121);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(154, 40);
            this.selectButton.TabIndex = 11;
            this.selectButton.Text = "Selecteer object";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 24);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "←";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // LocatieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 174);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.secondaryObjectSelection);
            this.Controls.Add(this.secondaryObjectName);
            this.Name = "LocatieList";
            this.Text = "LocatieList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label secondaryObjectName;
        private System.Windows.Forms.ComboBox secondaryObjectSelection;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button backButton;
    }
}