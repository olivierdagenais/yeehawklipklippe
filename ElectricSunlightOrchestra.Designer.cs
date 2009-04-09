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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.deviceAxisConfiguration = new System.Windows.Forms.DataGridView();
            this.deviceButtonConfiguration = new System.Windows.Forms.DataGridView();
            this.buttonsLabel = new System.Windows.Forms.Label();
            this.axisLabel = new System.Windows.Forms.Label();
            this.doneLoading = new System.Windows.Forms.Timer(this.components);
            this.mainLayout.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.deviceAxisConfiguration ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize) ( this.deviceButtonConfiguration ) ).BeginInit();
            this.SuspendLayout();
            // 
            // joystickPoll
            // 
            this.joystickPoll.Interval = 50;
            this.joystickPoll.Tick += new System.EventHandler(this.joystickPoll_Tick);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.deviceAxisConfiguration, 1, 1);
            this.mainLayout.Controls.Add(this.deviceButtonConfiguration, 0, 1);
            this.mainLayout.Controls.Add(this.buttonsLabel, 0, 0);
            this.mainLayout.Controls.Add(this.axisLabel, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(936, 584);
            this.mainLayout.TabIndex = 2;
            // 
            // deviceAxisConfiguration
            // 
            this.deviceAxisConfiguration.AllowUserToAddRows = false;
            this.deviceAxisConfiguration.AllowUserToDeleteRows = false;
            this.deviceAxisConfiguration.AllowUserToOrderColumns = true;
            this.deviceAxisConfiguration.AllowUserToResizeRows = false;
            this.deviceAxisConfiguration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deviceAxisConfiguration.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.deviceAxisConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceAxisConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceAxisConfiguration.Location = new System.Drawing.Point(471, 23);
            this.deviceAxisConfiguration.Name = "deviceAxisConfiguration";
            this.deviceAxisConfiguration.Size = new System.Drawing.Size(462, 558);
            this.deviceAxisConfiguration.TabIndex = 3;
            // 
            // deviceButtonConfiguration
            // 
            this.deviceButtonConfiguration.AllowUserToAddRows = false;
            this.deviceButtonConfiguration.AllowUserToDeleteRows = false;
            this.deviceButtonConfiguration.AllowUserToOrderColumns = true;
            this.deviceButtonConfiguration.AllowUserToResizeRows = false;
            this.deviceButtonConfiguration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deviceButtonConfiguration.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.deviceButtonConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceButtonConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceButtonConfiguration.Location = new System.Drawing.Point(3, 23);
            this.deviceButtonConfiguration.MultiSelect = false;
            this.deviceButtonConfiguration.Name = "deviceButtonConfiguration";
            this.deviceButtonConfiguration.Size = new System.Drawing.Size(462, 558);
            this.deviceButtonConfiguration.TabIndex = 2;
            // 
            // buttonsLabel
            // 
            this.buttonsLabel.AutoSize = true;
            this.buttonsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsLabel.Location = new System.Drawing.Point(3, 0);
            this.buttonsLabel.Name = "buttonsLabel";
            this.buttonsLabel.Size = new System.Drawing.Size(462, 20);
            this.buttonsLabel.TabIndex = 4;
            this.buttonsLabel.Text = "Buttons (digital inputs)";
            this.buttonsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // axisLabel
            // 
            this.axisLabel.AutoSize = true;
            this.axisLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisLabel.Location = new System.Drawing.Point(471, 0);
            this.axisLabel.Name = "axisLabel";
            this.axisLabel.Size = new System.Drawing.Size(462, 20);
            this.axisLabel.TabIndex = 5;
            this.axisLabel.Text = "Axis (analog inputs)";
            this.axisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doneLoading
            // 
            this.doneLoading.Tick += new System.EventHandler(this.doneLoading_Tick);
            // 
            // ElectricSunlightOrchestra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 584);
            this.Controls.Add(this.mainLayout);
            this.Name = "ElectricSunlightOrchestra";
            this.Text = "Electric Sunlight Orchestra";
            this.Load += new System.EventHandler(this.ElectricSunlightOrchestra_Load);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.deviceAxisConfiguration ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize) ( this.deviceButtonConfiguration ) ).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer joystickPoll;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.DataGridView deviceButtonConfiguration;
        private System.Windows.Forms.Timer doneLoading;
        private System.Windows.Forms.DataGridView deviceAxisConfiguration;
        private System.Windows.Forms.Label buttonsLabel;
        private System.Windows.Forms.Label axisLabel;
    }
}

