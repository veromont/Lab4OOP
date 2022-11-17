using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSON_manager
{
    public partial class GreetingForm : Form
    {
        public static string? username;
        public GreetingForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            username = nameTextBox.Text;
            Close();
        }
    }
}
