namespace TestTask1
{
    partial class Form1
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
            this.generateFiles = new System.Windows.Forms.Button();
            this.labelProc = new System.Windows.Forms.Label();
            this.mergeFiles = new System.Windows.Forms.Button();
            this.labelMerg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combTextBox = new System.Windows.Forms.TextBox();
            this.importToDB = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.getSum = new System.Windows.Forms.Button();
            this.getMedian = new System.Windows.Forms.Button();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxMedian = new System.Windows.Forms.TextBox();
            this.median = new System.Windows.Forms.Label();
            this.sum = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.lineTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateFiles
            // 
            this.generateFiles.Location = new System.Drawing.Point(322, 19);
            this.generateFiles.Name = "generateFiles";
            this.generateFiles.Size = new System.Drawing.Size(117, 39);
            this.generateFiles.TabIndex = 0;
            this.generateFiles.Text = "Generate";
            this.generateFiles.UseVisualStyleBackColor = true;
            this.generateFiles.Click += new System.EventHandler(this.generateFiles_Click);
            // 
            // labelProc
            // 
            this.labelProc.AutoSize = true;
            this.labelProc.Location = new System.Drawing.Point(457, 30);
            this.labelProc.Name = "labelProc";
            this.labelProc.Size = new System.Drawing.Size(0, 17);
            this.labelProc.TabIndex = 1;
            // 
            // mergeFiles
            // 
            this.mergeFiles.Enabled = false;
            this.mergeFiles.Location = new System.Drawing.Point(29, 85);
            this.mergeFiles.Name = "mergeFiles";
            this.mergeFiles.Size = new System.Drawing.Size(85, 39);
            this.mergeFiles.TabIndex = 2;
            this.mergeFiles.Text = "Merge";
            this.mergeFiles.UseVisualStyleBackColor = true;
            this.mergeFiles.Click += new System.EventHandler(this.mergeFiles_Click);
            // 
            // labelMerg
            // 
            this.labelMerg.AutoSize = true;
            this.labelMerg.Location = new System.Drawing.Point(45, 137);
            this.labelMerg.Name = "labelMerg";
            this.labelMerg.Size = new System.Drawing.Size(0, 17);
            this.labelMerg.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter symbol combination";
            // 
            // combTextBox
            // 
            this.combTextBox.Location = new System.Drawing.Point(123, 102);
            this.combTextBox.Name = "combTextBox";
            this.combTextBox.Size = new System.Drawing.Size(167, 22);
            this.combTextBox.TabIndex = 5;
            // 
            // importToDB
            // 
            this.importToDB.Enabled = false;
            this.importToDB.Location = new System.Drawing.Point(29, 178);
            this.importToDB.Name = "importToDB";
            this.importToDB.Size = new System.Drawing.Size(128, 52);
            this.importToDB.TabIndex = 6;
            this.importToDB.Text = "ImportToDB";
            this.importToDB.UseVisualStyleBackColor = true;
            this.importToDB.Click += new System.EventHandler(this.importToDB_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(182, 178);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 17);
            this.countLabel.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(175, 198);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(580, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // getSum
            // 
            this.getSum.Enabled = false;
            this.getSum.Location = new System.Drawing.Point(322, 85);
            this.getSum.Name = "getSum";
            this.getSum.Size = new System.Drawing.Size(117, 39);
            this.getSum.TabIndex = 9;
            this.getSum.Text = "GetNumSum";
            this.getSum.UseVisualStyleBackColor = true;
            this.getSum.Click += new System.EventHandler(this.getSum_Click);
            // 
            // getMedian
            // 
            this.getMedian.Enabled = false;
            this.getMedian.Location = new System.Drawing.Point(322, 140);
            this.getMedian.Name = "getMedian";
            this.getMedian.Size = new System.Drawing.Size(117, 39);
            this.getMedian.TabIndex = 10;
            this.getMedian.Text = "GetMedian";
            this.getMedian.UseVisualStyleBackColor = true;
            this.getMedian.Click += new System.EventHandler(this.getMedian_Click);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(455, 102);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(192, 22);
            this.textBoxSum.TabIndex = 11;
            // 
            // textBoxMedian
            // 
            this.textBoxMedian.Location = new System.Drawing.Point(455, 157);
            this.textBoxMedian.Name = "textBoxMedian";
            this.textBoxMedian.ReadOnly = true;
            this.textBoxMedian.Size = new System.Drawing.Size(192, 22);
            this.textBoxMedian.TabIndex = 12;
            // 
            // median
            // 
            this.median.AutoSize = true;
            this.median.Location = new System.Drawing.Point(455, 137);
            this.median.Name = "median";
            this.median.Size = new System.Drawing.Size(54, 17);
            this.median.TabIndex = 13;
            this.median.Text = "Median";
            // 
            // sum
            // 
            this.sum.AutoSize = true;
            this.sum.Location = new System.Drawing.Point(455, 82);
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(113, 17);
            this.sum.TabIndex = 14;
            this.sum.Text = "Sum of Numbers";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(29, 36);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(119, 22);
            this.fileTextBox.TabIndex = 15;
            // 
            // lineTextBox
            // 
            this.lineTextBox.Location = new System.Drawing.Point(175, 36);
            this.lineTextBox.Name = "lineTextBox";
            this.lineTextBox.Size = new System.Drawing.Size(110, 22);
            this.lineTextBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enter num of Files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Enter num of lines in file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lineTextBox);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.median);
            this.Controls.Add(this.textBoxMedian);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.getMedian);
            this.Controls.Add(this.getSum);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.importToDB);
            this.Controls.Add(this.combTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMerg);
            this.Controls.Add(this.mergeFiles);
            this.Controls.Add(this.labelProc);
            this.Controls.Add(this.generateFiles);
            this.Name = "Form1";
            this.Text = "FileGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateFiles;
        private System.Windows.Forms.Label labelProc;
        private System.Windows.Forms.Button mergeFiles;
        private System.Windows.Forms.Label labelMerg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox combTextBox;
        private System.Windows.Forms.Button importToDB;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button getSum;
        private System.Windows.Forms.Button getMedian;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.TextBox textBoxMedian;
        private System.Windows.Forms.Label median;
        private System.Windows.Forms.Label sum;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.TextBox lineTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

