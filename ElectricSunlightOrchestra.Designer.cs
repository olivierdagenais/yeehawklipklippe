namespace ElectricSunlightOrchestra
{
    partial class ElectricSunlightOrchestra
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
            if (disposing && ( components != null ))
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
            this.components = new System.ComponentModel.Container();
            this.joystickPoll = new System.Windows.Forms.Timer(this.components);
            this.deviceLabel = new System.Windows.Forms.Label();
            this.deviceCombo = new System.Windows.Forms.ComboBox();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.deviceConfiguration = new System.Windows.Forms.DataGridView();
            this.doneLoading = new System.Windows.Forms.Timer(this.components);
            this.mainLayout.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.deviceConfiguration ) ).BeginInit();
            this.SuspendLayout();
            // 
            // joystickPoll
            // 
            this.joystickPoll.Interval = 50;
            this.joystickPoll.Tick += new System.EventHandler(this.joystickPoll_Tick);
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceLabel.Location = new System.Drawing.Point(3, 0);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(54, 25);
            this.deviceLabel.TabIndex = 1;
            this.deviceLabel.Text = "Device";
            this.deviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceCombo
            // 
            this.deviceCombo.Dock = System.Windows.Forms.DockStyle.Left;
            this.deviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceCombo.DropDownWidth = 200;
            this.deviceCombo.FormattingEnabled = true;
            this.deviceCombo.Location = new System.Drawing.Point(63, 3);
            this.deviceCombo.Name = "deviceCombo";
            this.deviceCombo.Size = new System.Drawing.Size(319, 21);
            this.deviceCombo.TabIndex = 0;
            this.deviceCombo.SelectedValueChanged += new System.EventHandler(this.deviceCombo_SelectedValueChanged);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainLayout.Controls.Add(this.deviceCombo, 1, 0);
            this.mainLayout.Controls.Add(this.deviceLabel, 0, 0);
            this.mainLayout.Controls.Add(this.deviceConfiguration, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(543, 317);
            this.mainLayout.TabIndex = 2;
            // 
            // deviceConfiguration
            // 
            this.deviceConfiguration.AllowUserToAddRows = false;
            this.deviceConfiguration.AllowUserToDeleteRows = false;
            this.deviceConfiguration.AllowUserToOrderColumns = true;
            this.deviceConfiguration.AllowUserToResizeRows = false;
            this.deviceConfiguration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.deviceConfiguration.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.deviceConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainLayout.SetColumnSpan(this.deviceConfiguration, 2);
            this.deviceConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceConfiguration.Location = new System.Drawing.Point(3, 28);
            this.deviceConfiguration.MultiSelect = false;
            this.deviceConfiguration.Name = "deviceConfiguration";
            this.deviceConfiguration.Size = new System.Drawing.Size(537, 286);
            this.deviceConfiguration.TabIndex = 2;
            // 
            // doneLoading
            // 
            this.doneLoading.Tick += new System.EventHandler(this.doneLoading_Tick);
            // 
            // ElectricSunlightOrchestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 317);
            this.Controls.Add(this.mainLayout);
            this.Name = "ElectricSunlightOrchestra";
            this.Text = "Electric Sunlight Orchestra";
            this.Load += new System.EventHandler(this.ElectricSunlightOrchestra_Load);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.deviceConfiguration ) ).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer joystickPoll;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.ComboBox deviceCombo;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.DataGridView deviceConfiguration;
        private System.Windows.Forms.Timer doneLoading;
    }
}

