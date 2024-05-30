using CameraSetPort.MiniClass;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraSetPort {
    public partial class FormStart : Form {
        public FormStart() {
            InitializeComponent();
            formSelectHead = new FormSelectHead(this);
            userSelect = new UserSelect(this);
            fileControlMain = new FileControlMain(this);
        }

        #region ============================================== Input ==============================================
        /// <summary>
        /// Form for select head
        /// </summary>
        private FormSelectHead formSelectHead;

        /// <summary>
        /// Form for user select status
        /// </summary>
        public UserSelect userSelect;

        /// <summary>
        /// For set get all file
        /// </summary>
        public FileControl fileControl = new FileControl();

        /// <summary>
        /// For set file of main
        /// </summary>
        public FileControlMain fileControlMain;
        #endregion

        #region ============================================== Display ==============================================
        public void Log_(string msg) {
            try
            {
                rtb_copy.Invoke(new EventHandler(delegate {
                    rtb_copy.SelectedText = string.Empty;
                    rtb_copy.SelectionFont = new Font(rtb_copy.SelectionFont, FontStyle.Bold);
                    rtb_copy.AppendText(msg);
                    rtb_copy.ScrollToCaret();

                    if (rtb_copy.TextLength > 50000)
                    {
                        rtb_copy.Text = string.Empty;
                    }
                }));
            } catch (Exception) { }
        }
        public void Log(string msg) {
            try
            {
                rtb_copy.Invoke((MethodInvoker)delegate {
                    rtb_copy.SelectedText = string.Empty;
                    rtb_copy.SelectionFont = new Font(rtb_copy.SelectionFont, FontStyle.Bold);
                    rtb_copy.AppendText(msg);
                    rtb_copy.ScrollToCaret();

                    if (rtb_copy.TextLength > 50000)
                    {
                        rtb_copy.Text = string.Empty;
                    }
                });
            } catch (Exception)
            {
                // Handle the exception here
            }
        }


        /// <summary>
        /// Show frm select head
        /// </summary>
        private void ShowFormSelectHead_() {
            this.Hide();
            formSelectHead.ShowDialog();
            this.Show();
            CheckIfFormSelectHeadShouldCloseProgram();
        }
        private void ShowSelectHeadForm() {
            try
            {
                this.Hide();
                formSelectHead.ShowDialog();
            } catch (Exception ex)
            {
                // Handle the exception here
            } finally
            {
                this.Show();
                CheckIfFormSelectHeadShouldCloseProgram();
            }
        }

        #endregion

        #region ============================================== Cal ==============================================
        /// <summary>
        /// Goto form select head
        /// </summary>
        private void GotoFormSelectHead() {
            if (!userSelect.Check())
            {
                return;
            }
            if (bt_next.Visible)
            {
                return;
            }
            bt_next.Visible = true;
            ShowSelectHeadForm();
        }


        /// <summary>
        /// Check ว่าต้องปิดโปรแกรมไหม
        /// </summary>
        private void CheckIfFormSelectHeadShouldCloseProgram() {
            if (formSelectHead.close)
            {
                this.Close();
            }
        }
        #endregion

        #region ============================================== Main ==============================================
        private void FormStart_Load(object sender, EventArgs e) {
            rtb_copy.SelectionAlignment = HorizontalAlignment.Center;
            fileControlMain.CheckFileRead2D();
        }
        private void bt_next_Click(object sender, EventArgs e) {
            ShowSelectHeadForm();
        }
        private void bt_script_Click_(object sender, EventArgs e) {
            lb_script.Text = fileControl.FolderGetName();
            if (!fileControlMain.CheckHeadInFile(fileControl.path + lb_script.Text))
            {
                MessageBox.Show("File fail\r\nไม่มี Head 1 Port,");
                lb_script.Text = string.Empty;
                return;
            }
            if (lb_script.Text == string.Empty)
            {
                userSelect.script = false;
                return;
            }
            fileControlMain.pathManuscript = fileControl.path;
            userSelect.script = true;
            GotoFormSelectHead();
        }
        private void bt_script_Click(object sender, EventArgs e) {
            lb_script.Invoke((MethodInvoker)delegate {
                lb_script.Text = fileControl.FolderGetName();
            });

            if (!fileControlMain.CheckHeadInFile(fileControl.path + lb_script.Text))
            {
                MessageBox.Show("File fail\r\nไม่มี Head 1 Port,");
                lb_script.Invoke((MethodInvoker)delegate {
                    lb_script.Text = string.Empty;
                });
                return;
            }
            if (lb_script.Text == string.Empty)
            {
                userSelect.script = false;
                return;
            }
            fileControlMain.pathManuscript = fileControl.path;
            userSelect.script = true;
            GotoFormSelectHead();
        }
        private void bt_copy_Click(object sender, EventArgs e) {
            try
            {
                rtb_copy.Invoke((MethodInvoker)delegate {
                    rtb_copy.Clear();
                });
                string[] files = fileControl.FolderGetMultiName();
                if (files == null || files.Length == 0)
                {
                    userSelect.copy = false;
                    return;
                }
                foreach (string file in files)
                {
                    if (!fileControlMain.CheckHeadInFile(fileControl.path + file))
                    {
                        MessageBox.Show("File fail\r\nไม่มี Head 1 Port,");
                        continue;
                    }
                    Log(file + "\r\n");
                }
                rtb_copy.Invoke((MethodInvoker)delegate {
                    rtb_copy.Text = rtb_copy.Text.Trim();
                });
                fileControlMain.pathCopy = fileControl.path;
                userSelect.copy = true;
                GotoFormSelectHead();
            } catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show("An error occurred while copying files. Please try again.");
            }
        }

        #endregion


    }
}
