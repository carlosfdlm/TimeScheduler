
namespace TimeScheduler
{
    partial class TimeSchedulerFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSchedulerFrm));
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.btCalculateNextDate = new System.Windows.Forms.Button();
            this.dtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.lbCurrentDate = new System.Windows.Forms.Label();
            this.gbConfiguration = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nupDays = new System.Windows.Forms.NumericUpDown();
            this.cbOccurs = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbLimits = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.txExecutionDescription = new System.Windows.Forms.RichTextBox();
            this.ldDescription = new System.Windows.Forms.Label();
            this.txNextExecutionTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbInput.SuspendLayout();
            this.gbConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDays)).BeginInit();
            this.gbLimits.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.btCalculateNextDate);
            this.gbInput.Controls.Add(this.dtpCurrentDate);
            this.gbInput.Controls.Add(this.lbCurrentDate);
            this.gbInput.Location = new System.Drawing.Point(12, 12);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(590, 64);
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // btCalculateNextDate
            // 
            this.btCalculateNextDate.Location = new System.Drawing.Point(294, 22);
            this.btCalculateNextDate.Name = "btCalculateNextDate";
            this.btCalculateNextDate.Size = new System.Drawing.Size(282, 23);
            this.btCalculateNextDate.TabIndex = 2;
            this.btCalculateNextDate.Text = "Calculate next date";
            this.btCalculateNextDate.UseVisualStyleBackColor = true;
            this.btCalculateNextDate.Click += new System.EventHandler(this.btCalculateNextDate_Click);
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.Location = new System.Drawing.Point(88, 22);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(200, 23);
            this.dtpCurrentDate.TabIndex = 1;
            // 
            // lbCurrentDate
            // 
            this.lbCurrentDate.AutoSize = true;
            this.lbCurrentDate.Location = new System.Drawing.Point(6, 28);
            this.lbCurrentDate.Name = "lbCurrentDate";
            this.lbCurrentDate.Size = new System.Drawing.Size(76, 15);
            this.lbCurrentDate.TabIndex = 0;
            this.lbCurrentDate.Text = "Current date:";
            // 
            // gbConfiguration
            // 
            this.gbConfiguration.Controls.Add(this.label4);
            this.gbConfiguration.Controls.Add(this.nupDays);
            this.gbConfiguration.Controls.Add(this.cbOccurs);
            this.gbConfiguration.Controls.Add(this.cbType);
            this.gbConfiguration.Controls.Add(this.dtpDateTime);
            this.gbConfiguration.Controls.Add(this.label3);
            this.gbConfiguration.Controls.Add(this.label2);
            this.gbConfiguration.Controls.Add(this.lbType);
            this.gbConfiguration.Controls.Add(this.chkEnabled);
            this.gbConfiguration.Location = new System.Drawing.Point(12, 82);
            this.gbConfiguration.Name = "gbConfiguration";
            this.gbConfiguration.Size = new System.Drawing.Size(590, 122);
            this.gbConfiguration.TabIndex = 1;
            this.gbConfiguration.TabStop = false;
            this.gbConfiguration.Text = "Configuration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "day(s)";
            // 
            // nupDays
            // 
            this.nupDays.Location = new System.Drawing.Point(487, 76);
            this.nupDays.Name = "nupDays";
            this.nupDays.Size = new System.Drawing.Size(44, 23);
            this.nupDays.TabIndex = 7;
            // 
            // cbOccurs
            // 
            this.cbOccurs.Location = new System.Drawing.Point(88, 76);
            this.cbOccurs.Name = "cbOccurs";
            this.cbOccurs.Size = new System.Drawing.Size(200, 23);
            this.cbOccurs.TabIndex = 6;
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(88, 18);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(200, 23);
            this.cbType.TabIndex = 5;
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.Location = new System.Drawing.Point(88, 47);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(488, 23);
            this.dtpDateTime.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Occurs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "DateTime:";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(6, 26);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(34, 15);
            this.lbType.TabIndex = 1;
            this.lbType.Text = "Type:";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(294, 18);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(68, 19);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // gbLimits
            // 
            this.gbLimits.Controls.Add(this.dtpEndDate);
            this.gbLimits.Controls.Add(this.lbEndDate);
            this.gbLimits.Controls.Add(this.dtpStartDate);
            this.gbLimits.Controls.Add(this.lbStartDate);
            this.gbLimits.Location = new System.Drawing.Point(12, 210);
            this.gbLimits.Name = "gbLimits";
            this.gbLimits.Size = new System.Drawing.Size(590, 64);
            this.gbLimits.TabIndex = 2;
            this.gbLimits.TabStop = false;
            this.gbLimits.Text = "Limits";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(376, 23);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 8;
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(294, 27);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(56, 15);
            this.lbEndDate.TabIndex = 7;
            this.lbEndDate.Text = "End date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(88, 21);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 5;
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(6, 29);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(60, 15);
            this.lbStartDate.TabIndex = 3;
            this.lbStartDate.Text = "Start date:";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.txExecutionDescription);
            this.gbOutput.Controls.Add(this.ldDescription);
            this.gbOutput.Controls.Add(this.txNextExecutionTime);
            this.gbOutput.Controls.Add(this.label5);
            this.gbOutput.Location = new System.Drawing.Point(12, 286);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(590, 156);
            this.gbOutput.TabIndex = 3;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // txExecutionDescription
            // 
            this.txExecutionDescription.Location = new System.Drawing.Point(6, 80);
            this.txExecutionDescription.Name = "txExecutionDescription";
            this.txExecutionDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txExecutionDescription.Size = new System.Drawing.Size(570, 66);
            this.txExecutionDescription.TabIndex = 7;
            this.txExecutionDescription.Text = "";
            // 
            // ldDescription
            // 
            this.ldDescription.AutoSize = true;
            this.ldDescription.Location = new System.Drawing.Point(6, 62);
            this.ldDescription.Name = "ldDescription";
            this.ldDescription.Size = new System.Drawing.Size(67, 15);
            this.ldDescription.TabIndex = 6;
            this.ldDescription.Text = "Description";
            // 
            // txNextExecutionTime
            // 
            this.txNextExecutionTime.Location = new System.Drawing.Point(131, 23);
            this.txNextExecutionTime.Name = "txNextExecutionTime";
            this.txNextExecutionTime.Size = new System.Drawing.Size(445, 23);
            this.txNextExecutionTime.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Next Execution Time:";
            // 
            // TimeSchedulerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 453);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbLimits);
            this.Controls.Add(this.gbConfiguration);
            this.Controls.Add(this.gbInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeSchedulerFrm";
            this.Text = "Schedule";
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbConfiguration.ResumeLayout(false);
            this.gbConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDays)).EndInit();
            this.gbLimits.ResumeLayout(false);
            this.gbLimits.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Button btCalculateNextDate;
        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private System.Windows.Forms.Label lbCurrentDate;
        private System.Windows.Forms.GroupBox gbConfiguration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupDays;
        private System.Windows.Forms.ComboBox cbOccurs;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.DateTimePicker dtpDateTime;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbLimits;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.RichTextBox txExecutionDescription;
        private System.Windows.Forms.Label ldDescription;
        private System.Windows.Forms.TextBox txNextExecutionTime;
        private System.Windows.Forms.Label label5;
    }
}

