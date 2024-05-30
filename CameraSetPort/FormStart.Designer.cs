namespace CameraSetPort {
    partial class FormStart {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_copy = new System.Windows.Forms.RichTextBox();
            this.bt_copy = new System.Windows.Forms.Button();
            this.lb_script = new System.Windows.Forms.Label();
            this.bt_script = new System.Windows.Forms.Button();
            this.bt_next = new System.Windows.Forms.Button();
            this.lb_version = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.rtb_copy);
            this.groupBox2.Controls.Add(this.bt_copy);
            this.groupBox2.Controls.Add(this.lb_script);
            this.groupBox2.Controls.Add(this.bt_script);
            this.groupBox2.Controls.Add(this.bt_next);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 480);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rtb_copy
            // 
            this.rtb_copy.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_copy.ForeColor = System.Drawing.Color.Blue;
            this.rtb_copy.Location = new System.Drawing.Point(149, 322);
            this.rtb_copy.Name = "rtb_copy";
            this.rtb_copy.Size = new System.Drawing.Size(590, 142);
            this.rtb_copy.TabIndex = 5;
            this.rtb_copy.Text = "";
            // 
            // bt_copy
            // 
            this.bt_copy.BackColor = System.Drawing.Color.White;
            this.bt_copy.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_copy.ForeColor = System.Drawing.Color.Black;
            this.bt_copy.Location = new System.Drawing.Point(325, 229);
            this.bt_copy.Name = "bt_copy";
            this.bt_copy.Size = new System.Drawing.Size(240, 70);
            this.bt_copy.TabIndex = 4;
            this.bt_copy.Text = "Copy";
            this.bt_copy.UseVisualStyleBackColor = false;
            this.bt_copy.Click += new System.EventHandler(this.bt_copy_Click);
            // 
            // lb_script
            // 
            this.lb_script.BackColor = System.Drawing.Color.White;
            this.lb_script.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_script.ForeColor = System.Drawing.Color.Blue;
            this.lb_script.Location = new System.Drawing.Point(6, 137);
            this.lb_script.Name = "lb_script";
            this.lb_script.Size = new System.Drawing.Size(886, 36);
            this.lb_script.TabIndex = 3;
            this.lb_script.Text = "_____________";
            this.lb_script.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_script
            // 
            this.bt_script.BackColor = System.Drawing.Color.White;
            this.bt_script.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_script.ForeColor = System.Drawing.Color.Black;
            this.bt_script.Location = new System.Drawing.Point(325, 53);
            this.bt_script.Name = "bt_script";
            this.bt_script.Size = new System.Drawing.Size(240, 70);
            this.bt_script.TabIndex = 2;
            this.bt_script.Text = "Manuscript";
            this.bt_script.UseVisualStyleBackColor = false;
            this.bt_script.Click += new System.EventHandler(this.bt_script_Click);
            // 
            // bt_next
            // 
            this.bt_next.BackColor = System.Drawing.Color.White;
            this.bt_next.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_next.ForeColor = System.Drawing.Color.Blue;
            this.bt_next.Location = new System.Drawing.Point(824, 19);
            this.bt_next.Name = "bt_next";
            this.bt_next.Size = new System.Drawing.Size(68, 70);
            this.bt_next.TabIndex = 1;
            this.bt_next.Text = ">>";
            this.bt_next.UseVisualStyleBackColor = false;
            this.bt_next.Visible = false;
            this.bt_next.Click += new System.EventHandler(this.bt_next_Click);
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_version.ForeColor = System.Drawing.Color.White;
            this.lb_version.Location = new System.Drawing.Point(850, 556);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(61, 17);
            this.lb_version.TabIndex = 2;
            this.lb_version.Text = "V2023.02";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::CameraSetPort.Properties.Resources.ImageProfiles;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Location = new System.Drawing.Point(0, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(922, 578);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Set Port";
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_next;
        public System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Button bt_script;
        public System.Windows.Forms.Label lb_script;
        private System.Windows.Forms.Button bt_copy;
        public System.Windows.Forms.RichTextBox rtb_copy;
    }
}

