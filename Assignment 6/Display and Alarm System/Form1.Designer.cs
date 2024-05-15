namespace Display_and_Alarm_System
{
    partial class Window
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            TabControl = new TabControl();
            DisplayTab = new TabPage();
            UnitLabel = new Label();
            DisplayTitleLabel = new Label();
            label2 = new Label();
            CurrentTemperatureLabel = new Label();
            CurrentTempPictureBox = new PictureBox();
            TempTextBox = new TextBox();
            TempDataGraph = new ScottPlot.WinForms.FormsPlot();
            SettingsTab = new TabPage();
            DisplaySettingsGroupBox = new GroupBox();
            IntervalUnitLabel = new Label();
            UpdateIntervalLabel = new Label();
            label4 = new Label();
            UpdateIntervalTextBox = new TextBox();
            AlarmEmailTextBox = new TextBox();
            DatabaseSettingsGroupBox = new GroupBox();
            DatabaseAdresseLabel = new Label();
            LocationChoiceLabel = new Label();
            LocationChoiceComboBox = new ComboBox();
            DatabaseNameLabel = new Label();
            DatabaseAdresseTextBox = new TextBox();
            DatabaseNameTextBox = new TextBox();
            HelpTab = new TabPage();
            HelpTextBox = new RichTextBox();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            ConnectButton = new Button();
            TabControl.SuspendLayout();
            DisplayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CurrentTempPictureBox).BeginInit();
            SettingsTab.SuspendLayout();
            DisplaySettingsGroupBox.SuspendLayout();
            DatabaseSettingsGroupBox.SuspendLayout();
            HelpTab.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(DisplayTab);
            TabControl.Controls.Add(SettingsTab);
            TabControl.Controls.Add(HelpTab);
            TabControl.Location = new Point(12, 12);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(776, 426);
            TabControl.TabIndex = 0;
            // 
            // DisplayTab
            // 
            DisplayTab.Controls.Add(UnitLabel);
            DisplayTab.Controls.Add(DisplayTitleLabel);
            DisplayTab.Controls.Add(label2);
            DisplayTab.Controls.Add(CurrentTemperatureLabel);
            DisplayTab.Controls.Add(CurrentTempPictureBox);
            DisplayTab.Controls.Add(TempTextBox);
            DisplayTab.Controls.Add(TempDataGraph);
            DisplayTab.Location = new Point(4, 24);
            DisplayTab.Name = "DisplayTab";
            DisplayTab.Padding = new Padding(3);
            DisplayTab.Size = new Size(768, 398);
            DisplayTab.TabIndex = 0;
            DisplayTab.Text = "Display";
            DisplayTab.UseVisualStyleBackColor = true;
            // 
            // UnitLabel
            // 
            UnitLabel.AutoSize = true;
            UnitLabel.Location = new Point(632, 289);
            UnitLabel.Name = "UnitLabel";
            UnitLabel.Size = new Size(44, 15);
            UnitLabel.TabIndex = 6;
            UnitLabel.Text = "Celsius";
            // 
            // DisplayTitleLabel
            // 
            DisplayTitleLabel.AutoSize = true;
            DisplayTitleLabel.Font = new Font("Segoe UI", 20F);
            DisplayTitleLabel.Location = new Point(284, 0);
            DisplayTitleLabel.Name = "DisplayTitleLabel";
            DisplayTitleLabel.Size = new Size(176, 37);
            DisplayTitleLabel.TabIndex = 5;
            DisplayTitleLabel.Text = "Data For Stue";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 50);
            label2.Name = "label2";
            label2.Size = new Size(135, 15);
            label2.TabIndex = 4;
            label2.Text = "Temperature Data Graph";
            // 
            // CurrentTemperatureLabel
            // 
            CurrentTemperatureLabel.AutoSize = true;
            CurrentTemperatureLabel.Location = new Point(562, 268);
            CurrentTemperatureLabel.Name = "CurrentTemperatureLabel";
            CurrentTemperatureLabel.Size = new Size(116, 15);
            CurrentTemperatureLabel.TabIndex = 3;
            CurrentTemperatureLabel.Text = "Current Temperature";
            // 
            // CurrentTempPictureBox
            // 
            CurrentTempPictureBox.Image = (Image)resources.GetObject("CurrentTempPictureBox.Image");
            CurrentTempPictureBox.ImageLocation = "";
            CurrentTempPictureBox.InitialImage = (Image)resources.GetObject("CurrentTempPictureBox.InitialImage");
            CurrentTempPictureBox.Location = new Point(562, 162);
            CurrentTempPictureBox.Name = "CurrentTempPictureBox";
            CurrentTempPictureBox.Size = new Size(116, 103);
            CurrentTempPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CurrentTempPictureBox.TabIndex = 2;
            CurrentTempPictureBox.TabStop = false;
            // 
            // TempTextBox
            // 
            TempTextBox.Location = new Point(565, 286);
            TempTextBox.Name = "TempTextBox";
            TempTextBox.ReadOnly = true;
            TempTextBox.Size = new Size(63, 23);
            TempTextBox.TabIndex = 1;
            TempTextBox.TextChanged += TempTextBox_TextChanged;
            // 
            // TempDataGraph
            // 
            TempDataGraph.DisplayScale = 1F;
            TempDataGraph.Location = new Point(6, 68);
            TempDataGraph.Name = "TempDataGraph";
            TempDataGraph.Size = new Size(454, 324);
            TempDataGraph.TabIndex = 0;
            // 
            // SettingsTab
            // 
            SettingsTab.Controls.Add(DisplaySettingsGroupBox);
            SettingsTab.Controls.Add(DatabaseSettingsGroupBox);
            SettingsTab.Location = new Point(4, 24);
            SettingsTab.Name = "SettingsTab";
            SettingsTab.Size = new Size(768, 398);
            SettingsTab.TabIndex = 2;
            SettingsTab.Text = "Settings";
            SettingsTab.UseVisualStyleBackColor = true;
            // 
            // DisplaySettingsGroupBox
            // 
            DisplaySettingsGroupBox.Controls.Add(IntervalUnitLabel);
            DisplaySettingsGroupBox.Controls.Add(UpdateIntervalLabel);
            DisplaySettingsGroupBox.Controls.Add(label4);
            DisplaySettingsGroupBox.Controls.Add(UpdateIntervalTextBox);
            DisplaySettingsGroupBox.Controls.Add(AlarmEmailTextBox);
            DisplaySettingsGroupBox.Location = new Point(473, 44);
            DisplaySettingsGroupBox.Name = "DisplaySettingsGroupBox";
            DisplaySettingsGroupBox.Size = new Size(212, 262);
            DisplaySettingsGroupBox.TabIndex = 7;
            DisplaySettingsGroupBox.TabStop = false;
            DisplaySettingsGroupBox.Text = "Display Settings";
            // 
            // IntervalUnitLabel
            // 
            IntervalUnitLabel.AutoSize = true;
            IntervalUnitLabel.Location = new Point(129, 40);
            IntervalUnitLabel.Name = "IntervalUnitLabel";
            IntervalUnitLabel.Size = new Size(59, 15);
            IntervalUnitLabel.TabIndex = 6;
            IntervalUnitLabel.Text = "Second(s)";
            // 
            // UpdateIntervalLabel
            // 
            UpdateIntervalLabel.AutoSize = true;
            UpdateIntervalLabel.Location = new Point(23, 19);
            UpdateIntervalLabel.Name = "UpdateIntervalLabel";
            UpdateIntervalLabel.Size = new Size(87, 15);
            UpdateIntervalLabel.TabIndex = 2;
            UpdateIntervalLabel.Text = "Update Interval";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 202);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 4;
            label4.Text = "Alarm Email";
            // 
            // UpdateIntervalTextBox
            // 
            UpdateIntervalTextBox.Location = new Point(23, 37);
            UpdateIntervalTextBox.Name = "UpdateIntervalTextBox";
            UpdateIntervalTextBox.Size = new Size(100, 23);
            UpdateIntervalTextBox.TabIndex = 1;
            UpdateIntervalTextBox.Text = "1";
            UpdateIntervalTextBox.TextChanged += UpdateIntervalTextBox_TextChanged;
            // 
            // AlarmEmailTextBox
            // 
            AlarmEmailTextBox.Location = new Point(23, 220);
            AlarmEmailTextBox.Name = "AlarmEmailTextBox";
            AlarmEmailTextBox.Size = new Size(165, 23);
            AlarmEmailTextBox.TabIndex = 3;
            // 
            // DatabaseSettingsGroupBox
            // 
            DatabaseSettingsGroupBox.Controls.Add(ConnectButton);
            DatabaseSettingsGroupBox.Controls.Add(DatabaseAdresseLabel);
            DatabaseSettingsGroupBox.Controls.Add(LocationChoiceLabel);
            DatabaseSettingsGroupBox.Controls.Add(LocationChoiceComboBox);
            DatabaseSettingsGroupBox.Controls.Add(DatabaseNameLabel);
            DatabaseSettingsGroupBox.Controls.Add(DatabaseAdresseTextBox);
            DatabaseSettingsGroupBox.Controls.Add(DatabaseNameTextBox);
            DatabaseSettingsGroupBox.Location = new Point(29, 44);
            DatabaseSettingsGroupBox.Name = "DatabaseSettingsGroupBox";
            DatabaseSettingsGroupBox.Size = new Size(339, 262);
            DatabaseSettingsGroupBox.TabIndex = 6;
            DatabaseSettingsGroupBox.TabStop = false;
            DatabaseSettingsGroupBox.Text = "Database Settings";
            // 
            // DatabaseAdresseLabel
            // 
            DatabaseAdresseLabel.AutoSize = true;
            DatabaseAdresseLabel.Location = new Point(44, 19);
            DatabaseAdresseLabel.Name = "DatabaseAdresseLabel";
            DatabaseAdresseLabel.Size = new Size(99, 15);
            DatabaseAdresseLabel.TabIndex = 2;
            DatabaseAdresseLabel.Text = "Database Adresse";
            // 
            // LocationChoiceLabel
            // 
            LocationChoiceLabel.AutoSize = true;
            LocationChoiceLabel.Location = new Point(45, 202);
            LocationChoiceLabel.Name = "LocationChoiceLabel";
            LocationChoiceLabel.Size = new Size(96, 15);
            LocationChoiceLabel.TabIndex = 5;
            LocationChoiceLabel.Text = "Choose Location";
            // 
            // LocationChoiceComboBox
            // 
            LocationChoiceComboBox.FormattingEnabled = true;
            LocationChoiceComboBox.Location = new Point(45, 220);
            LocationChoiceComboBox.Name = "LocationChoiceComboBox";
            LocationChoiceComboBox.Size = new Size(246, 23);
            LocationChoiceComboBox.TabIndex = 0;
            LocationChoiceComboBox.SelectedIndexChanged += LocationChoiceComboBox_SelectedIndexChanged;
            // 
            // DatabaseNameLabel
            // 
            DatabaseNameLabel.AutoSize = true;
            DatabaseNameLabel.Location = new Point(45, 72);
            DatabaseNameLabel.Name = "DatabaseNameLabel";
            DatabaseNameLabel.Size = new Size(90, 15);
            DatabaseNameLabel.TabIndex = 4;
            DatabaseNameLabel.Text = "Database Name";
            // 
            // DatabaseAdresseTextBox
            // 
            DatabaseAdresseTextBox.Location = new Point(44, 37);
            DatabaseAdresseTextBox.Name = "DatabaseAdresseTextBox";
            DatabaseAdresseTextBox.Size = new Size(247, 23);
            DatabaseAdresseTextBox.TabIndex = 1;
            // 
            // DatabaseNameTextBox
            // 
            DatabaseNameTextBox.Location = new Point(45, 90);
            DatabaseNameTextBox.Name = "DatabaseNameTextBox";
            DatabaseNameTextBox.Size = new Size(246, 23);
            DatabaseNameTextBox.TabIndex = 3;
            // 
            // HelpTab
            // 
            HelpTab.Controls.Add(HelpTextBox);
            HelpTab.Location = new Point(4, 24);
            HelpTab.Name = "HelpTab";
            HelpTab.Padding = new Padding(3);
            HelpTab.Size = new Size(768, 398);
            HelpTab.TabIndex = 1;
            HelpTab.Text = "Help";
            HelpTab.UseVisualStyleBackColor = true;
            // 
            // HelpTextBox
            // 
            HelpTextBox.Location = new Point(3, 3);
            HelpTextBox.Name = "HelpTextBox";
            HelpTextBox.ReadOnly = true;
            HelpTextBox.Size = new Size(762, 392);
            HelpTextBox.TabIndex = 0;
            HelpTextBox.Text = resources.GetString("HelpTextBox.Text");
            // 
            // UpdateTimer
            // 
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(44, 129);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(75, 23);
            ConnectButton.TabIndex = 6;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Window";
            Text = "Display and Alarm System";
            Load += Window_Load;
            TabControl.ResumeLayout(false);
            DisplayTab.ResumeLayout(false);
            DisplayTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CurrentTempPictureBox).EndInit();
            SettingsTab.ResumeLayout(false);
            DisplaySettingsGroupBox.ResumeLayout(false);
            DisplaySettingsGroupBox.PerformLayout();
            DatabaseSettingsGroupBox.ResumeLayout(false);
            DatabaseSettingsGroupBox.PerformLayout();
            HelpTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage DisplayTab;
        private ScottPlot.WinForms.FormsPlot TempDataGraph;
        private TabPage HelpTab;
        private RichTextBox HelpTextBox;
        private Label label2;
        private Label CurrentTemperatureLabel;
        private PictureBox CurrentTempPictureBox;
        private TextBox TempTextBox;
        private TabPage SettingsTab;
        private ComboBox LocationChoiceComboBox;
        private Label DisplayTitleLabel;
        private Label UnitLabel;
        private System.Windows.Forms.Timer UpdateTimer;
        private Label DatabaseAdresseLabel;
        private TextBox DatabaseAdresseTextBox;
        private Label DatabaseNameLabel;
        private TextBox DatabaseNameTextBox;
        private Label LocationChoiceLabel;
        private GroupBox DisplaySettingsGroupBox;
        private Label UpdateIntervalLabel;
        private Label label4;
        private TextBox UpdateIntervalTextBox;
        private TextBox AlarmEmailTextBox;
        private GroupBox DatabaseSettingsGroupBox;
        private Label IntervalUnitLabel;
        private Button ConnectButton;
    }
}
