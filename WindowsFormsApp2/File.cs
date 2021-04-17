using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    class File
    {
        static bool isChanged;
        static string fileText = "Безымянный";
        static StreamReader reader;
        static StreamWriter writer;
        static string fileContent;
        public static bool IsChanged
        {
            get { return isChanged; }
            set { isChanged = value; }
        }
        public static string FileName
        {
            get { return FileName; }
            set { FileName = value; }
        }
        public static string FileContent
        {
            get { return fileContent; }
            set { fileContent = value; }
        }
        internal static void newFile(RichTextBox textBox, SaveFileDialog saveFileDialog)
        {
            if (!IsChanged)
            {
                textBox.Clear();
                Edit.Origin = "";
                return;
            }
            ConfirmForm confirmForm = new ConfirmForm();
            DialogResult answer = confirmForm.ShowDialog();
            switch (answer)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.No:
                    textBox.Clear();
                    Edit.Origin = "";
                    break;
                case DialogResult.Yes:
                    saveFile(saveFileDialog, textBox);
                    break;
            }
;
        }
        internal static void newWindow()
        {
            KKRITPAD mainform = new KKRITPAD();
            mainform.Show();
        }
        internal static string openFile(OpenFileDialog openfiledialog,RichTextBox textbox)
        {
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openfiledialog.FileName;
                reader = new StreamReader(FileName);
                fileContent = reader.ReadToEnd();
                textbox.Text = fileContent;
                reader.Close();
            }
            
            return FileName;

        }
        internal static void saveFile(SaveFileDialog saveFileDialog, RichTextBox textBox)
        {
            if (FileName == "" || FileName == "Безымянный") saveAs(saveFileDialog, textBox);
            else
            {
                save(FileName, textBox);
            }
        }
        internal static void saveAs(SaveFileDialog saveFileDialog, RichTextBox textBox)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = saveFileDialog.FileName;
                save(FileName, textBox);
            }
        }
        static void save (string fileName, RichTextBox textBox)
        {
            using (writer = new StreamWriter(fileName))
            {
                writer.WriteLine(textBox.Text);
            }
            Edit.Origin = textBox.Text;
            isChanged = false;
        }
    }
}
