namespace Deelopdracht_2_versie_3
{
    partial class NavigatieScherm
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
            this.backButton = new System.Windows.Forms.Button();
            this.primaryObjectName = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.secondaryObjectName = new System.Windows.Forms.Label();
            this.secondaryObjectSelection = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.attributePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 24);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "←";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // primaryObjectName
            // 
            this.primaryObjectName.AutoSize = true;
            this.primaryObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primaryObjectName.Location = new System.Drawing.Point(7, 39);
            this.primaryObjectName.Name = "primaryObjectName";
            this.primaryObjectName.Size = new System.Drawing.Size(74, 25);
            this.primaryObjectName.TabIndex = 2;
            this.primaryObjectName.Text = "Object";
            this.primaryObjectName.Click += new System.EventHandler(this.label1_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(9, 77);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(59, 13);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "IdName: Id";
            this.idLabel.Click += new System.EventHandler(this.idLabel_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 229);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(40, 40);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "💾";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(58, 229);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(40, 40);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "🗑";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // secondaryObjectName
            // 
            this.secondaryObjectName.AutoSize = true;
            this.secondaryObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondaryObjectName.Location = new System.Drawing.Point(231, 39);
            this.secondaryObjectName.Name = "secondaryObjectName";
            this.secondaryObjectName.Size = new System.Drawing.Size(183, 25);
            this.secondaryObjectName.TabIndex = 7;
            this.secondaryObjectName.Text = "Secondary Object";
            // 
            // secondaryObjectSelection
            // 
            this.secondaryObjectSelection.FormattingEnabled = true;
            this.secondaryObjectSelection.Location = new System.Drawing.Point(236, 93);
            this.secondaryObjectSelection.Name = "secondaryObjectSelection";
            this.secondaryObjectSelection.Size = new System.Drawing.Size(200, 21);
            this.secondaryObjectSelection.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(236, 120);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 40);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectButton.Location = new System.Drawing.Point(282, 120);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(154, 40);
            this.selectButton.TabIndex = 10;
            this.selectButton.Text = "Selecteer object";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // attributePanel
            // 
            this.attributePanel.Location = new System.Drawing.Point(12, 103);
            this.attributePanel.Name = "attributePanel";
            this.attributePanel.Size = new System.Drawing.Size(183, 120);
            this.attributePanel.TabIndex = 11;
            // 
            // NavigatieScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 280);
            this.Controls.Add(this.attributePanel);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.secondaryObjectSelection);
            this.Controls.Add(this.secondaryObjectName);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.primaryObjectName);
            this.Controls.Add(this.backButton);
            this.Name = "NavigatieScherm";
            this.Text = "NavigatieScherm";
            this.Load += new System.EventHandler(this.NavigatieScherm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label primaryObjectName;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label secondaryObjectName;
        private System.Windows.Forms.ComboBox secondaryObjectSelection;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Panel attributePanel;
    }
}