using CameraSetPort.MiniClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraSetPort {
    public partial class FormSelectHead : Form {
        public FormSelectHead(FormStart main_) {
            InitializeComponent();
            main = main_;
            rePlace = new RePlace(this);
        }

        #region ============================================== Input ==============================================
        /// <summary>
        /// Form for main start
        /// </summary>
        public FormStart main;

        /// <summary>
        /// บอกว่าปิดโปรแกรมหรือกดย้อนกลับ True คือปิดโปรแรกม
        /// </summary>
        public bool close;

        /// <summary>
        /// for clase Replace
        /// </summary>
        public RePlace rePlace;

        public MiniClass.ForGUI.Delay delay = new MiniClass.ForGUI.Delay();
        #endregion

        #region ============================================== Display ==============================================

        public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        #endregion

        #region ============================================== Cal ==============================================
        /// <summary>
        /// Checks if any head button inside groupBox2 is selected (blue).
        /// </summary>
        /// <returns>True if at least one head button is selected, false otherwise.</returns>
        private bool CheckSelect() {
            foreach (Control control in groupBox2.Controls)
            {
                if (control is Button button)
                {
                    if (button.Name.StartsWith("bt_head"))
                    {
                        if (button.BackColor == Color.Blue)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Sets the visibility of the bt_replace button based on whether any head button is selected.
        /// </summary>
        private void SetReplace() {
            bt_replace.Visible = CheckSelect();
        }

        #endregion

        #region ============================================== Main ==============================================
        private void Form1_Load(object sender, EventArgs e) {
            lb_version.Text = main.lb_version.Text;
            close = true;
        }
        private void bt_back_Click(object sender, EventArgs e) {
            close = false;
            this.Close();
        }
        private void bt_head_Click(object sender, EventArgs e) {
            Button button = (Button)sender;
            Color currentColor = button.BackColor;

            // Check if the UI thread is available
            if (!button.InvokeRequired)
            {
                button.BackColor = currentColor == Color.White ? Color.Blue : Color.White;
                SetReplace();
            }
            else
            {
                button.Invoke((MethodInvoker)(() => {
                    button.BackColor = currentColor == Color.White ? Color.Blue : Color.White;
                    SetReplace();
                }));
            }
        }
        private void bt_replace_Click(object sender, EventArgs e) {
            // Set up the cancellation token
            cancellationTokenSource = new CancellationTokenSource();

            // Start the task
            //await Task.Run(() => {
            //    // Perform some long-running operation here
            //    // ...
            //    rePlace.Run(cancellationTokenSource.Token);
            //}, cancellationTokenSource.Token);

            rePlace.Run(cancellationTokenSource.Token);

            //ThreadPool.QueueUserWorkItem(new WaitCallback(rePlace.RunThreadPool), cancellationTokenSource.Token);
        }
        #endregion


    }
}
