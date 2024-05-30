using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraSetPort.MiniClass {
    public class FileControl {

        public FileControl() {
            pathExe = GetPathExe();
            path = GetPath();
        }
        private string pathExe;

        /// <summary>
        /// ตัวแปรนี้ตอนแรกจะเป็น path exe ต่อมาถ้ามีการ SavePath มันจะเปลี่ยนไปเป็น path ใหม่ที่ถูก save
        /// </summary>
        public string path;

        private string GetPathExe_() {
            string assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string pathExe = Path.GetDirectoryName(assembly);
            pathExe = pathExe.Replace("file:\\", string.Empty);
            return pathExe;
        }
        private string GetPathExe() {
            try
            {
                string assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                string pathExe = Path.GetDirectoryName(assembly);
                pathExe = pathExe.Replace("file:\\", string.Empty);
                return pathExe;
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while retrieving the path of the executable. Details: " + e.Message);
                return string.Empty;
            }
        }


        private string GetPath_() {
            string pathFile = string.Empty;
            try
            {
                pathFile = File.ReadAllText("Path.txt");
            } catch (Exception)
            {

            }
            if (pathFile == string.Empty)
            {
                return pathExe;
            }
            return pathFile;
        }
        private string GetPath() {
            string pathFile = string.Empty;
            try
            {
                pathFile = File.ReadAllText("Path.txt");
            } catch (FileNotFoundException)
            {
                // Path.txt file not found, use default path
                pathFile = pathExe;
            } catch (Exception ex)
            {
                // Error reading Path.txt file, log the exception and use default path
                MessageBox.Show("Error reading Path.txt file: " + ex.Message);
                pathFile = pathExe;
            }
            return pathFile;
        }


        private void SavePath_(string path) {
            File.WriteAllText(pathExe + "\\Path.txt", path);
            this.path = path;
        }
        private void SavePath(string path) {
            try
            {
                if (!string.IsNullOrEmpty(pathExe) && !string.IsNullOrEmpty(path))
                {
                    string filePath = Path.Combine(pathExe, "Path.txt");
                    File.WriteAllText(filePath, path);
                    this.path = path;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error saving path: " + ex.Message);
            }
        }



        /// <summary>
        /// Find file in folder
        /// </summary>
        /// <param name="nameContains"></param>
        /// <returns></returns>
        public string[] FindNameFile_(string nameContains) {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] infos = directoryInfo.GetFiles();
            List<string> allFile = new List<string>();
            foreach (FileInfo file in infos)
            {
                allFile.Add(file.Name);
            }
            List<string> nameFileSelect = allFile.FindAll(element => element.Contains(nameContains));
            return nameFileSelect.ToArray();
        }
        public string[] FindNameFile(string nameContains) {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentException("The path is empty or null.");
                }

                if (!Directory.Exists(path))
                {
                    throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                FileInfo[] infos = directoryInfo.GetFiles();
                List<string> allFile = new List<string>();
                foreach (FileInfo file in infos)
                {
                    allFile.Add(file.Name);
                }
                List<string> nameFileSelect = allFile.FindAll(element => element.Contains(nameContains));
                return nameFileSelect.ToArray();
            } catch (Exception ex)
            {
                // Handle any exception that may occur
                MessageBox.Show($"An error occurred while finding files: {ex.Message}");
                return null;
            }
        }
        public string[] FindNameFile_(string nameContains, string path) {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] infos = directoryInfo.GetFiles();
            List<string> allFile = new List<string>();
            foreach (FileInfo file in infos)
            {
                allFile.Add(file.Name);
            }
            List<string> nameFileSelect = allFile.FindAll(element => element.Contains(nameContains));
            return nameFileSelect.ToArray();
        }
        public string[] FindNameFile(string nameContains, string path) {
            List<string> nameFileSelect = new List<string>();

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                if (!directoryInfo.Exists)
                {
                    throw new DirectoryNotFoundException("Directory not found: " + path);
                }

                FileInfo[] infos = directoryInfo.GetFiles();

                if (infos != null)
                {
                    foreach (FileInfo file in infos)
                    {
                        if (file.Name.Contains(nameContains))
                        {
                            nameFileSelect.Add(file.Name);
                        }
                    }
                }
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while trying to find files: " + e.Message);
            }

            return nameFileSelect.ToArray();
        }



        /// <summary>
        /// Get เฉพาะชื่อไฟล์เท่านั้น
        /// </summary>
        /// <returns></returns>
        public string FolderGetName_() {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            //dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                return dialog.FileAsShellObject.Name;
            }
            return string.Empty;
        }
        public string FolderGetName() {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                    return dialog.FileAsShellObject.Name;
                }
            } catch (Exception e)
            {
                MessageBox.Show("An error occurred while trying to get the folder name: " + e.Message);
            }
            return string.Empty;
        }



        /// <summary>
        /// Get ทั้ง path
        /// </summary>
        /// <returns></returns>
        public string FolderGetFullName_() {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            //dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                return dialog.FileName;
            }
            return string.Empty;
        }
        public string FolderGetFullName() {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
                //dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SavePath(dialog.FileName.Replace(dialog.FileAsShellObject.Name, string.Empty));
                    return dialog.FileName;
                }
                return string.Empty;
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to select a file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }



        /// <summary>
        /// Get เฉพาะชื่อไฟล์เท่านั้น แบบทีละหลายๆไฟล์
        /// </summary>
        /// <returns></returns>
        public string[] FolderGetMultiName_() {
            List<string> files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (string file in dialog.FileNames)
                {
                    string[] split = file.Split('\\');
                    string name = split[split.Length - 1];
                    string pathNew = file.Replace(name, string.Empty);
                    files.Add(name);
                    SavePath(pathNew);
                }
            }
            return files.ToArray();
        }
        public string[] FolderGetMultiName() {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path is not set.");
            }

            List<string> files = new List<string>();

            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = path;
                dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
                dialog.Multiselect = true;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (string file in dialog.FileNames)
                    {
                        string name = Path.GetFileName(file);
                        files.Add(name);
                        string pathNew = Path.GetDirectoryName(file);
                        SavePath(pathNew + "\\");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return files.ToArray();
        }



        /// <summary>
        /// Get ทั้ง path แบบทีละ หลายๆไฟล์
        /// </summary>
        /// <returns></returns>
        public string[] FolderGetMultiFullName_() {
            List<string> files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                foreach (string file in dialog.FileNames)
                {
                    files.Add(file);
                }
            }
            return files.ToArray();
        }
        public string[] FolderGetMultiFullName() {
            List<string> files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Filters.Add(new CommonFileDialogFilter("CSV Files", "*.csv"));
            dialog.Multiselect = true;
            dialog.RestoreDirectory = true;
            try
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (string file in dialog.FileNames)
                    {
                        if (Path.GetExtension(file).ToLower() == ".csv")
                        {
                            files.Add(file);
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error selecting CSV files: " + ex.Message);
            }
            return files.ToArray();
        }

    }
}
