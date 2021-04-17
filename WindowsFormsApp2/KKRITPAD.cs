using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class KKRITPAD : Form
    {
        string title ="Безыманный - KKRITPAD";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public KKRITPAD()
        {
            InitializeComponent();
            this.Text = this.Title;
        }

        private void savefile(object sender, EventArgs e)
        {
            File.saveFile(saveFileDialog1, richTextBox1);
            removeChangesMarker();
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            string Path = File.openFile(openFileDialog1, richTextBox1);
            if (Path != "")
            {
                string[] PathElements = Path.Split('\\');
                Title = PathElements[PathElements.Length - 1] + "- KKRITPAD";
                Text = Title;
                Edit.Origin = richTextBox1.Text;
            }
            
        }

        private void DateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit.getDateTime(richTextBox1);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.saveAs(saveFileDialog1, richTextBox1);
            removeChangesMarker();
        }

        private void KKRITPAD_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            File.IsChanged = !Edit.isEqualToOrigin(richTextBox1.Text);
            if (File.IsChanged) this.Text = "*" + this.Title;
        }
        void removeChangesMarker()
        {
            if (!File.IsChanged)
            {
                this.Text = this.Title;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.newFile(richTextBox1, saveFileDialog1);
            removeChangesMarker();
            
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.newWindow();
        }
    }
}
