namespace Discotron9000
{
    partial class MainForm
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
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._midiDeviceComboBox = new System.Windows.Forms.ComboBox();
            this._midiChannelComboBox = new System.Windows.Forms.ComboBox();
            this._alwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this._randomiseButton = new System.Windows.Forms.Button();
            this._allOnButton = new System.Windows.Forms.Button();
            this._allOffButton = new System.Windows.Forms.Button();
            this._danceFloorView = new Discotron9000.Controls.DancefloorView();
            this._tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Controls.Add(this._danceFloorView, 0, 1);
            this._tableLayoutPanel.Controls.Add(this.flowLayoutPanel, 0, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(559, 533);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this._midiDeviceComboBox);
            this.flowLayoutPanel.Controls.Add(this._midiChannelComboBox);
            this.flowLayoutPanel.Controls.Add(this._randomiseButton);
            this.flowLayoutPanel.Controls.Add(this._allOnButton);
            this.flowLayoutPanel.Controls.Add(this._allOffButton);
            this.flowLayoutPanel.Controls.Add(this._alwaysOnTopCheckBox);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(553, 54);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // _midiDeviceComboBox
            // 
            this._midiDeviceComboBox.DisplayMember = "Name";
            this._midiDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._midiDeviceComboBox.FormattingEnabled = true;
            this._midiDeviceComboBox.Location = new System.Drawing.Point(3, 3);
            this._midiDeviceComboBox.Name = "_midiDeviceComboBox";
            this._midiDeviceComboBox.Size = new System.Drawing.Size(121, 21);
            this._midiDeviceComboBox.TabIndex = 0;
            this._midiDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this._midiDeviceComboBox_SelectedIndexChanged);
            // 
            // _midiChannelComboBox
            // 
            this._midiChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._midiChannelComboBox.FormattingEnabled = true;
            this._midiChannelComboBox.Location = new System.Drawing.Point(130, 3);
            this._midiChannelComboBox.Name = "_midiChannelComboBox";
            this._midiChannelComboBox.Size = new System.Drawing.Size(121, 21);
            this._midiChannelComboBox.TabIndex = 1;
            this._midiChannelComboBox.SelectedIndexChanged += new System.EventHandler(this._midiChannelComboBox_SelectedIndexChanged);
            // 
            // _alwaysOnTopCheckBox
            // 
            this._alwaysOnTopCheckBox.AutoSize = true;
            this._alwaysOnTopCheckBox.Location = new System.Drawing.Point(3, 32);
            this._alwaysOnTopCheckBox.Name = "_alwaysOnTopCheckBox";
            this._alwaysOnTopCheckBox.Size = new System.Drawing.Size(100, 19);
            this._alwaysOnTopCheckBox.TabIndex = 2;
            this._alwaysOnTopCheckBox.Text = "Always on top";
            this._alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            this._alwaysOnTopCheckBox.CheckedChanged += new System.EventHandler(this._alwaysOnTopCheckBox_CheckedChanged);
            // 
            // _randomiseButton
            // 
            this._randomiseButton.Location = new System.Drawing.Point(257, 3);
            this._randomiseButton.Name = "_randomiseButton";
            this._randomiseButton.Size = new System.Drawing.Size(87, 23);
            this._randomiseButton.TabIndex = 3;
            this._randomiseButton.Text = "Randomise";
            this._randomiseButton.UseVisualStyleBackColor = true;
            this._randomiseButton.Click += new System.EventHandler(this._randomiseButton_Click);
            // 
            // _allOnButton
            // 
            this._allOnButton.Location = new System.Drawing.Point(350, 3);
            this._allOnButton.Name = "_allOnButton";
            this._allOnButton.Size = new System.Drawing.Size(87, 23);
            this._allOnButton.TabIndex = 4;
            this._allOnButton.Text = "All on";
            this._allOnButton.UseVisualStyleBackColor = true;
            this._allOnButton.Click += new System.EventHandler(this._allOnButton_Click);
            // 
            // _allOffButton
            // 
            this._allOffButton.Location = new System.Drawing.Point(443, 3);
            this._allOffButton.Name = "_allOffButton";
            this._allOffButton.Size = new System.Drawing.Size(87, 23);
            this._allOffButton.TabIndex = 4;
            this._allOffButton.Text = "All off";
            this._allOffButton.UseVisualStyleBackColor = true;
            this._allOffButton.Click += new System.EventHandler(this._allOffButton_Click);
            // 
            // _danceFloorView
            // 
            this._danceFloorView.DiscoFloor = null;
            this._danceFloorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._danceFloorView.Location = new System.Drawing.Point(3, 63);
            this._danceFloorView.Name = "_danceFloorView";
            this._danceFloorView.Size = new System.Drawing.Size(553, 467);
            this._danceFloorView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 533);
            this.Controls.Add(this._tableLayoutPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Discotron 9000";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private Controls.DancefloorView _danceFloorView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ComboBox _midiDeviceComboBox;
        private System.Windows.Forms.ComboBox _midiChannelComboBox;
        private System.Windows.Forms.CheckBox _alwaysOnTopCheckBox;
        private System.Windows.Forms.Button _randomiseButton;
        private System.Windows.Forms.Button _allOnButton;
        private System.Windows.Forms.Button _allOffButton;


    }
}

