namespace DAQ_Simulation_Application
{
    partial class main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_window));
            sampling_timer = new System.Windows.Forms.Timer(components);
            logging_filename_label = new Label();
            logging_filename_textbox = new TextBox();
            sample_once_button = new Button();
            sensor_value_label = new Label();
            sensor_value_textbox = new TextBox();
            sample_button = new Button();
            menu_strip = new MenuStrip();
            loggingToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            menu_strip.SuspendLayout();
            SuspendLayout();
            // 
            // sampling_timer
            // 
            sampling_timer.Interval = 55;
            sampling_timer.Tick += SamplingTimerTick;
            // 
            // logging_filename_label
            // 
            logging_filename_label.AutoSize = true;
            logging_filename_label.Location = new Point(21, 264);
            logging_filename_label.Name = "logging_filename_label";
            logging_filename_label.Size = new Size(102, 15);
            logging_filename_label.TabIndex = 23;
            logging_filename_label.Text = "Logging Filename";
            // 
            // logging_filename_textbox
            // 
            logging_filename_textbox.Location = new Point(21, 282);
            logging_filename_textbox.Name = "logging_filename_textbox";
            logging_filename_textbox.Size = new Size(311, 23);
            logging_filename_textbox.TabIndex = 22;
            // 
            // sample_once_button
            // 
            sample_once_button.Location = new Point(21, 78);
            sample_once_button.Name = "sample_once_button";
            sample_once_button.Size = new Size(94, 23);
            sample_once_button.TabIndex = 20;
            sample_once_button.Text = "Sample Once";
            sample_once_button.UseVisualStyleBackColor = true;
            sample_once_button.Click += SampleOnceButtonClick;
            // 
            // sensor_value_label
            // 
            sensor_value_label.AutoSize = true;
            sensor_value_label.Location = new Point(386, 31);
            sensor_value_label.Name = "sensor_value_label";
            sensor_value_label.Size = new Size(78, 15);
            sensor_value_label.TabIndex = 19;
            sensor_value_label.Text = "Sensor Values";
            // 
            // sensor_value_textbox
            // 
            sensor_value_textbox.Location = new Point(386, 49);
            sensor_value_textbox.Multiline = true;
            sensor_value_textbox.Name = "sensor_value_textbox";
            sensor_value_textbox.ReadOnly = true;
            sensor_value_textbox.ScrollBars = ScrollBars.Vertical;
            sensor_value_textbox.Size = new Size(394, 370);
            sensor_value_textbox.TabIndex = 15;
            // 
            // sample_button
            // 
            sample_button.Location = new Point(21, 49);
            sample_button.Name = "sample_button";
            sample_button.Size = new Size(94, 23);
            sample_button.TabIndex = 12;
            sample_button.Text = "Start Sampling";
            sample_button.UseVisualStyleBackColor = true;
            sample_button.Click += SampleButtonClick;
            // 
            // menu_strip
            // 
            menu_strip.Items.AddRange(new ToolStripItem[] { loggingToolStripMenuItem, helpToolStripMenuItem });
            menu_strip.Location = new Point(0, 0);
            menu_strip.Name = "menu_strip";
            menu_strip.Size = new Size(800, 24);
            menu_strip.TabIndex = 24;
            menu_strip.Text = "Menu Strip";
            // 
            // loggingToolStripMenuItem
            // 
            loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            loggingToolStripMenuItem.Size = new Size(63, 20);
            loggingToolStripMenuItem.Text = "Logging";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += HelpToolStripMenuItemClick;
            // 
            // main_window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logging_filename_label);
            Controls.Add(logging_filename_textbox);
            Controls.Add(sample_once_button);
            Controls.Add(sensor_value_label);
            Controls.Add(sensor_value_textbox);
            Controls.Add(sample_button);
            Controls.Add(menu_strip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menu_strip;
            Name = "main_window";
            Text = "DAQ Simulator";
            menu_strip.ResumeLayout(false);
            menu_strip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer sampling_timer;
        private Label logging_filename_label;
        private TextBox logging_filename_textbox;
        private Button sample_once_button;
        private Label sensor_value_label;
        private TextBox sensor_value_textbox;
        private Button sample_button;
        private MenuStrip menu_strip;
        private ToolStripMenuItem loggingToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
    }
}
