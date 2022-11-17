using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSON_manager.Forms
{
    public partial class EnterPathForm : Form
    {
        public static string path;
        public EnterPathForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            path = PathTextBox.Text;
            
            //try open
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open)) { }
                MessageBox.Show("We opened file at " + path);
            }
            catch
            {
            }

            //try create
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create)) { }
                MessageBox.Show("We created file at " + path);
            }
            catch
            {
                path = "";
                MessageBox.Show("Path '" + path + "' is invalid");
            }

            Close();
        }
    }
}
