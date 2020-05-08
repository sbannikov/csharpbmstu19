namespace EmissionsInput
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.parameterLabel = new System.Windows.Forms.Label();
            this.sensorLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sourcesDropDown = new System.Windows.Forms.ComboBox();
            this.sensorsDropDown = new System.Windows.Forms.ComboBox();
            this.parametersDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(409, 672);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(277, 85);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueTextBox.Location = new System.Drawing.Point(512, 498);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(537, 50);
            this.valueTextBox.TabIndex = 1;
            this.valueTextBox.Text = "Значение измерения";
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueLabel.Location = new System.Drawing.Point(64, 501);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(190, 44);
            this.valueLabel.TabIndex = 2;
            this.valueLabel.Text = "Значение";
            // 
            // parameterLabel
            // 
            this.parameterLabel.AutoSize = true;
            this.parameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parameterLabel.Location = new System.Drawing.Point(64, 369);
            this.parameterLabel.Name = "parameterLabel";
            this.parameterLabel.Size = new System.Drawing.Size(196, 44);
            this.parameterLabel.TabIndex = 4;
            this.parameterLabel.Text = "Параметр";
            // 
            // sensorLabel
            // 
            this.sensorLabel.AutoSize = true;
            this.sensorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorLabel.Location = new System.Drawing.Point(64, 232);
            this.sensorLabel.Name = "sensorLabel";
            this.sensorLabel.Size = new System.Drawing.Size(147, 44);
            this.sensorLabel.TabIndex = 6;
            this.sensorLabel.Text = "Датчик";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sourceLabel.Location = new System.Drawing.Point(64, 105);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(366, 44);
            this.sourceLabel.TabIndex = 8;
            this.sourceLabel.Text = "Источник выбросов";
            // 
            // sourcesDropDown
            // 
            this.sourcesDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourcesDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sourcesDropDown.FormattingEnabled = true;
            this.sourcesDropDown.Location = new System.Drawing.Point(512, 102);
            this.sourcesDropDown.Name = "sourcesDropDown";
            this.sourcesDropDown.Size = new System.Drawing.Size(537, 50);
            this.sourcesDropDown.TabIndex = 9;
            this.sourcesDropDown.SelectionChangeCommitted += new System.EventHandler(this.sourcesDropDown_SelectionChangeCommitted);
            // 
            // sensorsDropDown
            // 
            this.sensorsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sensorsDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorsDropDown.FormattingEnabled = true;
            this.sensorsDropDown.Location = new System.Drawing.Point(512, 229);
            this.sensorsDropDown.Name = "sensorsDropDown";
            this.sensorsDropDown.Size = new System.Drawing.Size(537, 50);
            this.sensorsDropDown.TabIndex = 10;
            this.sensorsDropDown.SelectionChangeCommitted += new System.EventHandler(this.sensorsDropDown_SelectionChangeCommitted);
            // 
            // parametersDropDown
            // 
            this.parametersDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parametersDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parametersDropDown.FormattingEnabled = true;
            this.parametersDropDown.Location = new System.Drawing.Point(512, 366);
            this.parametersDropDown.Name = "parametersDropDown";
            this.parametersDropDown.Size = new System.Drawing.Size(537, 50);
            this.parametersDropDown.TabIndex = 11;
            this.parametersDropDown.SelectionChangeCommitted += new System.EventHandler(this.parametersDropDown_SelectionChangeCommitted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 1029);
            this.Controls.Add(this.parametersDropDown);
            this.Controls.Add(this.sensorsDropDown);
            this.Controls.Add(this.sourcesDropDown);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.sensorLabel);
            this.Controls.Add(this.parameterLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.saveButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label parameterLabel;
        private System.Windows.Forms.Label sensorLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.ComboBox sourcesDropDown;
        private System.Windows.Forms.ComboBox sensorsDropDown;
        private System.Windows.Forms.ComboBox parametersDropDown;
    }
}

