using CameraSetPort.MiniForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraSetPort.MiniClass {
    public class RePlace {

        public RePlace(FormSelectHead main_) {
            main = main_;
        }

        private FormSelectHead main;

        /// <summary>
        /// เอาไว้โชว์ว่ากำลังรันอยู่
        /// </summary>
        private FormRePlaceLoad formRePlaceLoad;


        /// <summary>
        /// เริ่มทำการ replace แบบอัตโนมัติ
        /// </summary>
        public void Run_() {
            formRePlaceLoad = new FormRePlaceLoad(main);
            formRePlaceLoad.Show();
            string[] fileSup = main.main.rtb_copy.Text.Split('\n');
            formRePlaceLoad.pgb_run.Maximum = fileSup.Length * 50;
            List<string> listScript = GetFileList(main.main.fileControlMain.pathManuscript + main.main.lb_script.Text);
            foreach (string fileCopy in fileSup)
            {
                List<string> listCopy = GetFileList(main.main.fileControlMain.pathCopy + fileCopy);
                if (main.bt_head1.BackColor == Color.Blue)
                {
                    SetText("Select Head 1");
                    ForRePlace(listScript, listCopy, 1, fileCopy);
                }
                if (main.bt_head2.BackColor == Color.Blue)
                {
                    SetText("Select Head 2");
                    ForRePlace(listScript, listCopy, 2, fileCopy);
                }
                if (main.bt_head3.BackColor == Color.Blue)
                {
                    SetText("Select Head 3");
                    ForRePlace(listScript, listCopy, 3, fileCopy);
                }
                if (main.bt_head4.BackColor == Color.Blue)
                {
                    SetText("Select Head 4");
                    ForRePlace(listScript, listCopy, 4, fileCopy);
                }
                if (main.bt_head5.BackColor == Color.Blue)
                {
                    SetText("Select Head 5");
                    ForRePlace(listScript, listCopy, 5, fileCopy);
                }
                if (main.bt_head6.BackColor == Color.Blue)
                {
                    SetText("Select Head 6");
                    ForRePlace(listScript, listCopy, 6, fileCopy);
                }
                if (main.bt_head7.BackColor == Color.Blue)
                {
                    SetText("Select Head 7");
                    ForRePlace(listScript, listCopy, 7, fileCopy);
                }
                if (main.bt_head8.BackColor == Color.Blue)
                {
                    SetText("Select Head 8");
                    ForRePlace(listScript, listCopy, 8, fileCopy);
                }
                if (main.bt_head9.BackColor == Color.Blue)
                {
                    SetText("Select Head 9");
                    ForRePlace(listScript, listCopy, 9, fileCopy);
                }
                if (main.bt_head10.BackColor == Color.Blue)
                {
                    SetText("Select Head 10");
                    ForRePlace(listScript, listCopy, 10, fileCopy);
                }
                File.WriteAllLines(main.main.fileControlMain.pathCopy + fileCopy, listCopy);
                SetText("Save Files...");
            }
            formRePlaceLoad.pgb_run.Value = formRePlaceLoad.pgb_run.Maximum;
            main.delay.DelaymS(500);
            formRePlaceLoad.Close();
        }
        public void Run(CancellationToken cancellationToken) {
            try
            {
                using (formRePlaceLoad = new FormRePlaceLoad(main))
                {
                    formRePlaceLoad.Show();
                    string[] fileSup = main.main.rtb_copy.Text.Split('\n');
                    formRePlaceLoad.pgb_run.Maximum = fileSup.Length * 50;
                    List<string> listScript = GetFileList(main.main.fileControlMain.pathManuscript + main.main.lb_script.Text);
                    foreach (string fileCopy in fileSup)
                    {
                        List<string> listCopy = GetFileList(main.main.fileControlMain.pathCopy + fileCopy);
                        if (main.bt_head1.BackColor == Color.Blue)
                        {
                            SetText("Select Head 1");
                            ForRePlace(listScript, listCopy, 1, fileCopy, cancellationToken);
                        }
                        if (main.bt_head2.BackColor == Color.Blue)
                        {
                            SetText("Select Head 2");
                            ForRePlace(listScript, listCopy, 2, fileCopy, cancellationToken);
                        }
                        if (main.bt_head3.BackColor == Color.Blue)
                        {
                            SetText("Select Head 3");
                            ForRePlace(listScript, listCopy, 3, fileCopy, cancellationToken);
                        }
                        if (main.bt_head4.BackColor == Color.Blue)
                        {
                            SetText("Select Head 4");
                            ForRePlace(listScript, listCopy, 4, fileCopy, cancellationToken);
                        }
                        if (main.bt_head5.BackColor == Color.Blue)
                        {
                            SetText("Select Head 5");
                            ForRePlace(listScript, listCopy, 5, fileCopy, cancellationToken);
                        }
                        if (main.bt_head6.BackColor == Color.Blue)
                        {
                            SetText("Select Head 6");
                            ForRePlace(listScript, listCopy, 6, fileCopy, cancellationToken);
                        }
                        if (main.bt_head7.BackColor == Color.Blue)
                        {
                            SetText("Select Head 7");
                            ForRePlace(listScript, listCopy, 7, fileCopy, cancellationToken);
                        }
                        if (main.bt_head8.BackColor == Color.Blue)
                        {
                            SetText("Select Head 8");
                            ForRePlace(listScript, listCopy, 8, fileCopy, cancellationToken);
                        }
                        if (main.bt_head9.BackColor == Color.Blue)
                        {
                            SetText("Select Head 9");
                            ForRePlace(listScript, listCopy, 9, fileCopy, cancellationToken);
                        }
                        if (main.bt_head10.BackColor == Color.Blue)
                        {
                            SetText("Select Head 10");
                            ForRePlace(listScript, listCopy, 10, fileCopy, cancellationToken);
                        }
                        File.WriteAllLines(main.main.fileControlMain.pathCopy + fileCopy, listCopy);
                        SetText("Save Files...");
                    }
                    formRePlaceLoad.pgb_run.Value = formRePlaceLoad.pgb_run.Maximum;
                    main.delay.DelaymS(500);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        // Method to execute on the thread pool thread
        public void RunThreadPool(object state) {
            CancellationToken cancellationToken = (CancellationToken)state;
            try
            {
                Run(cancellationToken);
            } catch (Exception ex)
            {
                // Handle exception
            }
        }


        private List<string> GetFileList_(string path) {
            List<string> files = new List<string>();
            string[] fileSup = File.ReadAllLines(path);
            files.AddRange(fileSup);
            return files;
        }
        private List<string> GetFileList(string path) {
            List<string> files = new List<string>();
            try
            {
                string[] fileSup = File.ReadAllLines(path);
                files.AddRange(fileSup);
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message);
            }
            return files;
        }


        /// <summary>
        /// วนลูป replace ตามจำนวนหัวที่เลือกไว้
        /// </summary>
        private void ForRePlace(List<string> listScript, List<string> listCopy, int head, string nameFile) {
            for (int loop = 0; loop < listScript.Count; loop++)
            {
                if (listScript[loop].Contains("Head " + head + " Port"))
                {
                    listCopy[loop] = listScript[loop];
                    SetText("Replace " + listScript[loop] + " to " + nameFile);
                }
                if (listScript[loop].Contains("Head " + head + " Gamma"))
                {
                    listCopy[loop] = listScript[loop];
                    SetText("Replace " + listScript[loop] + " to " + nameFile);
                }
                if (listScript[loop].Contains("Head " + head + " Set Address"))
                {
                    listCopy[loop] = listScript[loop];
                    SetText("Replace " + listScript[loop] + " to " + nameFile);
                }
            }
        }
        private void ForRePlace(List<string> listScript, List<string> listCopy, int head, string nameFile, CancellationToken cancellationToken) {
            try
            {
                for (int loop = 0; loop < listScript.Count; loop++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }
                    if (listScript[loop].Contains("Head " + head + " Port"))
                    {
                        listCopy[loop] = listScript[loop];
                        SetText("Replace " + listScript[loop] + " to " + nameFile);
                    }
                    if (listScript[loop].Contains("Head " + head + " Gamma"))
                    {
                        listCopy[loop] = listScript[loop];
                        SetText("Replace " + listScript[loop] + " to " + nameFile);
                    }
                    if (listScript[loop].Contains("Head " + head + " Set Address"))
                    {
                        listCopy[loop] = listScript[loop];
                        SetText("Replace " + listScript[loop] + " to " + nameFile);
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred while replacing the script: " + ex.Message);
            }
        }



        /// <summary>
        /// เปลี่ยนข้อความโชว์ว่ากำลังทำอะไรอยู่
        /// </summary>
        private void SetText_(string message) {
            formRePlaceLoad.lb_file.Text = message;
            formRePlaceLoad.pgb_run.Value += 1;
            main.delay.DelaymS(50);
        }
        private void SetText(string message) {
            if (formRePlaceLoad != null && formRePlaceLoad.lb_file != null && formRePlaceLoad.pgb_run != null)
            {
                formRePlaceLoad.Invoke((MethodInvoker)delegate {
                    formRePlaceLoad.lb_file.Text = message;
                    formRePlaceLoad.pgb_run.Value += 1;
                });
                //main.DelaymS(50);
                main.delay.DelaymS(50);
                //Thread.Sleep(50);
            }
        }


    }
}
