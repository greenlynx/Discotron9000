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
            this._randomiseButton = new System.Windows.Forms.Button();
            this._allOnButton = new System.Windows.Forms.Button();
            this._allOffButton = new System.Windows.Forms.Button();
            this._alwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this._serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._serialPortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._closeSerialButton = new System.Windows.Forms.Button();
            this.openSerialButton = new System.Windows.Forms.Button();
            this._danceFloorView = new Discotron9000.Controls.DancefloorView();
            this._tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.flowLayoutPanel.Controls.Add(this._serialPortComboBox);
            this.flowLayoutPanel.Controls.Add(this._closeSerialButton);
            this.flowLayoutPanel.Controls.Add(this.openSerialButton);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(553, 58);
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
            // _serialPortComboBox
            // 
            this._serialPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._serialPortComboBox.FormattingEnabled = true;
            this._serialPortComboBox.Location = new System.Drawing.Point(109, 32);
            this._serialPortComboBox.Name = "_serialPortComboBox";
            this._serialPortComboBox.Size = new System.Drawing.Size(121, 21);
            this._serialPortComboBox.TabIndex = 5;
            this._serialPortComboBox.SelectedIndexChanged += new System.EventHandler(this._serialPortComboBox_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._serialPortStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "_statusStrip";
            // 
            // _serialPortStatusLabel
            // 
            this._serialPortStatusLabel.Name = "_serialPortStatusLabel";
            this._serialPortStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _closeSerialButton
            // 
            this._closeSerialButton.Location = new System.Drawing.Point(236, 32);
            this._closeSerialButton.Name = "_closeSerialButton";
            this._closeSerialButton.Size = new System.Drawing.Size(92, 23);
            this._closeSerialButton.TabIndex = 6;
            this._closeSerialButton.Text = "Close serial";
            this._closeSerialButton.UseVisualStyleBackColor = true;
            this._closeSerialButton.Click += new System.EventHandler(this._closeSerialButton_Click);
            // 
            // openSerialButton
            // 
            this.openSerialButton.Location = new System.Drawing.Point(334, 32);
            this.openSerialButton.Name = "openSerialButton";
            this.openSerialButton.Size = new System.Drawing.Size(92, 23);
            this.openSerialButton.TabIndex = 6;
            this.openSerialButton.Text = "Open serial";
            this.openSerialButton.UseVisualStyleBackColor = true;
            this.openSerialButton.Click += new System.EventHandler(this.openSerialButton_Click);
            // 
            // _danceFloorView
            // 
            this._danceFloorView.DiscoFloor = null;
            this._danceFloorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._danceFloorView.Location = new System.Drawing.Point(3, 67);
            this._danceFloorView.Name = "_danceFloorView";
            this._danceFloorView.Size = new System.Drawing.Size(553, 463);
            this._danceFloorView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 533);
            this.Controls.Add(this.statusStrip1);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox _serialPortComboBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _serialPortStatusLabel;
        private System.Windows.Forms.Button _closeSerialButton;
        private System.Windows.Forms.Button openSerialButton;


    }
}

