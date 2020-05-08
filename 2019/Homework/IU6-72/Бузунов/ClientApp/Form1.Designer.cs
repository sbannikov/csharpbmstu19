namespace ClientApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sourceBox = new System.Windows.Forms.ComboBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sensorLabel = new System.Windows.Forms.Label();
            this.sensorBox = new System.Windows.Forms.ComboBox();
            this.paramLabel = new System.Windows.Forms.Label();
            this.paramBox = new System.Windows.Forms.ComboBox();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceBox
            // 
            this.sourceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceBox.FormattingEnabled = true;
            this.sourceBox.Items.AddRange(new object[] {
            "1659c3c8-e887-4b73-bee7-b1cabf2cc8e9"});
            this.sourceBox.Location = new System.Drawing.Point(200, 25);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sourceBox.Size = new System.Drawing.Size(226, 21);
            this.sourceBox.Sorted = true;
            this.sourceBox.TabIndex = 0;
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sourceLabel.Location = new System.Drawing.Point(10, 26);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(158, 20);
            this.sourceLabel.TabIndex = 1;
            this.sourceLabel.Text = "Источник выбросов";
            // 
            // sensorLabel
            // 
            this.sensorLabel.AutoSize = true;
            this.sensorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sensorLabel.Location = new System.Drawing.Point(10, 66);
            this.sensorLabel.Name = "sensorLabel";
            this.sensorLabel.Size = new System.Drawing.Size(65, 20);
            this.sensorLabel.TabIndex = 3;
            this.sensorLabel.Text = "Датчик";
            // 
            // sensorBox
            // 
            this.sensorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sensorBox.FormattingEnabled = true;
            this.sensorBox.Items.AddRange(new object[] {
            "ajrk32cw-8323-13kl-12mf-mfaiii123ja",
            "bbc5c3fe-0368-466f-8d7f-efffed500fa2"});
            this.sensorBox.Location = new System.Drawing.Point(200, 65);
            this.sensorBox.Name = "sensorBox";
            this.sensorBox.Size = new System.Drawing.Size(226, 21);
            this.sensorBox.Sorted = true;
            this.sensorBox.TabIndex = 2;
            // 
            // paramLabel
            // 
            this.paramLabel.AutoSize = true;
            this.paramLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paramLabel.Location = new System.Drawing.Point(10, 107);
            this.paramLabel.Name = "paramLabel";
            this.paramLabel.Size = new System.Drawing.Size(86, 20);
            this.paramLabel.TabIndex = 5;
            this.paramLabel.Text = "Параметр";
            // 
            // paramBox
            // 
            this.paramBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paramBox.FormattingEnabled = true;
            this.paramBox.Items.AddRange(new object[] {
            "Аммиак в кг/ч",
            "Взвешенные вещества в кг/ч",
            "Диоксид серы в кг/ч",
            "Оксиды азота в кг/ч",
            "Сероводород в кг/ч",
            "Состояние электронной пломбы датчика",
            "Углерода оксид (полнота сгорания) в кг/ч",
            "Углерода оксид в кг/ч",
            "Фтоистый водород в кг/ч",
            "Хлористый водород в кг/ч"});
            this.paramBox.Location = new System.Drawing.Point(200, 106);
            this.paramBox.Name = "paramBox";
            this.paramBox.Size = new System.Drawing.Size(226, 21);
            this.paramBox.Sorted = true;
            this.paramBox.TabIndex = 4;
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(200, 151);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(226, 20);
            this.valueBox.TabIndex = 6;
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.valueLabel.Location = new System.Drawing.Point(12, 151);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(83, 20);
            this.valueLabel.TabIndex = 7;
            this.valueLabel.Text = "Значение";
            // 
            // saveButton
            // 
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(85, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(290, 35);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(ClientApp.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 252);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.paramLabel);
            this.Controls.Add(this.paramBox);
            this.Controls.Add(this.sensorLabel);
            this.Controls.Add(this.sensorBox);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.sourceBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 290);
            this.MinimumSize = new System.Drawing.Size(460, 290);
            this.Name = "MainForm";
            this.Text = "Приложение для ввода данных";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sourceBox;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label sensorLabel;
        private System.Windows.Forms.ComboBox sensorBox;
        private System.Windows.Forms.Label paramLabel;
        private System.Windows.Forms.ComboBox paramBox;
        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}

