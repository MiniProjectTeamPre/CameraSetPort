using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraSetPort.MiniClass {
    public class FileControlMain {

        public FileControlMain(FormStart main_) {
            main = main_;
        }

        public FormStart main;

        public string pathManuscript;

        public string pathCopy;

        /// <summary>
        /// เช็คว่ามีไฟล์ csv ที่ชื่อ read2d หรือเปล่า ถ้ามี จะดึงชื่อไฟล์นั้นมาให้อัตโนมัติ
        /// </summary>
        public void CheckFileRead2D_() {
            string[] files = main.fileControl.FindNameFile("read2d.csv");
            foreach (string file in files)
            {
                if (file.Contains("Step"))
                {
                    if (!CheckHeadInFile(main.fileControl.path + file))
                    {
                        return;
                    }
                    main.lb_script.Text = file;
                    pathManuscript = main.fileControl.path;
                    main.userSelect.script = true;
                    return;
                }
            }
        }
        public void CheckFileRead2D_2() {
            string[] files = main.fileControl.FindNameFile("read2d.csv");
            if (files.Length == 0)
            {
                MessageBox.Show("No files with the name 'read2d.csv' found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedFilePath = null;
            bool foundValidFile = false;

            foreach (string file in files)
            {
                if (file.Contains("Step"))
                {
                    string filePath = main.fileControl.path + file;

                    try
                    {
                        if (CheckHeadInFile(filePath))
                        {
                            foundValidFile = true;
                            selectedFilePath = filePath;
                            break;
                        }
                    } catch (IOException ex)
                    {
                        MessageBox.Show($"An error occurred while reading the file '{filePath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (foundValidFile)
            {
                main.lb_script.Text = selectedFilePath.Replace(main.fileControl.path, string.Empty);
                pathManuscript = main.fileControl.path;
                main.userSelect.script = true;
            }
            else
            {
                MessageBox.Show("No valid 'read2d.csv' file found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void CheckFileRead2D() {
            try
            {
                if (main == null)
                {
                    throw new ArgumentNullException(nameof(main));
                }

                if (main.fileControl == null)
                {
                    throw new InvalidOperationException("fileControl is null.");
                }

                if (main.lb_script == null)
                {
                    throw new InvalidOperationException("lb_script is null.");
                }

                string[] files = main.fileControl.FindNameFile("read2d.csv");
                if (files.Length == 0)
                {
                    MessageBox.Show("No files with the name 'read2d.csv' found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string selectedFilePath = null;
                bool foundValidFile = false;

                foreach (string file in files)
                {
                    if (file.Contains("Step"))
                    {
                        string filePath = Path.Combine(main.fileControl.path, file);

                        try
                        {
                            if (CheckHeadInFile(filePath))
                            {
                                foundValidFile = true;
                                selectedFilePath = filePath;
                                break;
                            }
                        } catch (IOException ex)
                        {
                            MessageBox.Show($"An error occurred while reading the file '{filePath}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (foundValidFile)
                {
                    main.lb_script.Text = selectedFilePath.Replace(main.fileControl.path, string.Empty);
                    pathManuscript = main.fileControl.path;
                    main.userSelect.script = true;
                }
                else
                {
                    MessageBox.Show("No valid 'read2d.csv' file found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in CheckFileRead2D(): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// เช็คว่าไฟล์ที่เลือกมานั้นถูกต้องไหม ถ้าถูกต้องจะมี Head อยู่หน้าสุด
        /// </summary>
        /// <returns></returns>
        public bool CheckHeadInFile_(string path) {
            string[] fileSup = File.ReadAllLines(path);
            if (fileSup[0].Contains("Head 1 Port,"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckHeadInFile(string path) {
            try
            {
                string[] fileSup = File.ReadAllLines(path);
                if (fileSup[0].Contains("Head 1 Port,"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (FileNotFoundException)
            {
                MessageBox.Show("File not found.");
                return false;
            } catch (IOException)
            {
                MessageBox.Show("An I/O error occurred while reading the file.");
                return false;
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message);
                return false;
            }
        }

    }
}
