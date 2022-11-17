using JSON_manager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSON_manager
{
    public partial class OpenFileForm : Form
    {
        //
        //Fonts and colours
        //
        Font RegularFocusFont = new Font("Ravie", 12F, FontStyle.Regular, GraphicsUnit.Point);
        Font RegularFont = new Font("Ravie", 10F, FontStyle.Regular, GraphicsUnit.Point);
        Color DarkPurpleColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        public OpenFileForm()
        {
            InitializeComponent();
        }

        #region on click 
        private void DefaultFileLabel_Click(object sender, EventArgs e)
        {

            //Load from file
            bool ok = SerializationClass.DeserializeFromFile();
            if (!ok) { return; }

            //open datagridview
            DataGridViewForm Gridform = new DataGridViewForm();
            Gridform.ShowDialog();

            //close current form
            Close();
        }
        private void DefaultFilePicture_Click(object sender, EventArgs e)
        {
            DefaultFileLabel_Click(sender, e);
        }
        private void CustomFileLabel_Click(object sender, EventArgs e)
        {
            EnterPathForm enterPathForm = new EnterPathForm();
            enterPathForm.ShowDialog();
        }
        private void CustomFilePicture_Click(object sender, EventArgs e)
        {
            CustomFileLabel_Click(sender, e);
        }
        #endregion
        
        #region on hover
        private void DefaultFileLabel_Hover(object sender, EventArgs e)
        {
            DefaultFileLabel.Font = RegularFocusFont;
            DefaultFileLabel.ForeColor = Color.Purple;
        }
        private void DefaultFileLabel_Leave(object sender, EventArgs e)
        {
            DefaultFileLabel.Font = RegularFont;
            DefaultFileLabel.ForeColor = DarkPurpleColor;
        }
        private void CustomFileLabel_Hover(object sender, EventArgs e)
        {
            CustomFileLabel.Font = RegularFocusFont;
            CustomFileLabel.ForeColor = Color.Purple;
        }
        private void CustomFileLabel_Leave(object sender, EventArgs e)
        {
            CustomFileLabel.Font = RegularFont;
            CustomFileLabel.ForeColor = DarkPurpleColor;
        }
        #endregion
    }
}
