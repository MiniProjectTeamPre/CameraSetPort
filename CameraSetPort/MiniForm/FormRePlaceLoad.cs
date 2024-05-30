using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraSetPort.MiniForm {
    public partial class FormRePlaceLoad : Form {
        public FormRePlaceLoad(FormSelectHead main_) {
            InitializeComponent();
            main = main_;
        }

        private FormSelectHead main;

        private void FormRePlaceLoad_FormClosing(object sender, FormClosingEventArgs e) {
            
        }

        private void bt_cancel_Click(object sender, EventArgs e) {
            main.cancellationTokenSource.Cancel();
        }
    }
}
