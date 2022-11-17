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
    public partial class LINQsearchForm : Form
    {
        bool NameSearchMode;
        bool IdSearchMode;
        bool DateSearchMode;
        List<Conferention>? Conferentions;
        public LINQsearchForm()
        {
            InitializeComponent();
            NameSearchMode = false;
            IdSearchMode = false;
            DateSearchMode = false;
        }
        //methods
        private void SetToDefault()
        {
            searchByIdToolStripMenuItem.ForeColor = DarkPurpleColor;
            searchByIdToolStripMenuItem.Font = HeaderFont;

            searchByNameToolStripMenuItem.ForeColor = DarkPurpleColor;
            searchByNameToolStripMenuItem.Font = HeaderFont;

            searchByDateToolStripMenuItem.ForeColor = DarkPurpleColor;
            searchByDateToolStripMenuItem.Font = HeaderFont;

            NameSearchMode = false;
            IdSearchMode = false;
            DateSearchMode = false;
        }
        private void SearchByName()
        {
            //same for all three
            Conferentions = new List<Conferention>();
            foreach (Conferention conf in DataGridViewForm.Conferentions)
            {
                Conferentions.Add(conf);
            }
            SearcherClass Seeker = new SearcherClass();
            string txtboxvalue = InfoTextBox.Text;

            //
            Conferentions = Seeker.SearchByName(txtboxvalue);
            if (Conferentions == null)
            {
                MessageBox.Show("Not found");
                InfoTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("found objects: " + Conferentions.Count);
                DataGridViewForm.ResultLINQ = Conferentions;
            }
        }
        private void SearchById()
        {
            //same for all three
            Conferentions = new List<Conferention>();
            foreach (Conferention conf in DataGridViewForm.Conferentions)
            {
                Conferentions.Add(conf);
            }
            SearcherClass Seeker = new SearcherClass();
            string txtboxvalue = InfoTextBox.Text;

            //
            int id = TranslatorClass.StringToInt(txtboxvalue);
            Conferentions.Clear();
            Conferentions = Seeker.SearchById(id);
            if (Conferentions == null)
            {
                MessageBox.Show("Not found");
                InfoTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("found objects: " + Conferentions.Count);
                DataGridViewForm.ResultLINQ = Conferentions;
            }
        }
        private void SearchByDate()
        {
            //same for all three
            Conferentions = new List<Conferention>();
            foreach (Conferention conf in DataGridViewForm.Conferentions)
            {
                Conferentions.Add(conf);
            }
            SearcherClass Seeker = new SearcherClass();
            string txtboxvalue = InfoTextBox.Text;

            //
            Date? date = TranslatorClass.StringToDate(txtboxvalue);
            if(date == null)
            {
                return;
            }
            Conferentions.Clear();
            Conferentions = Seeker.SearchByDate(date);
            if (Conferentions == null)
            {
                MessageBox.Show("Not found");
                InfoTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("found objects: " + Conferentions.Count);
                DataGridViewForm.ResultLINQ = Conferentions;
            }
        }

        #region on click
        private void searchByNameToolstripMenu_Click(object sender, EventArgs e)
        {
            //design
            SetToDefault();
            searchByNameToolStripMenuItem.ForeColor = PurpleColor;
            searchByNameToolStripMenuItem.Font = HeaderFocusFont;
            
            //mode
            NameSearchMode = true;
        }
        private void searchByIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //design
            SetToDefault();
            searchByIdToolStripMenuItem.ForeColor = PurpleColor;
            searchByIdToolStripMenuItem.Font = HeaderFocusFont;
            
            //mode
            IdSearchMode = true;
        }
        private void searchByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //design
            SetToDefault();
            searchByDateToolStripMenuItem.ForeColor = PurpleColor;
            searchByDateToolStripMenuItem.Font = HeaderFocusFont;

            //mode
            DateSearchMode = true;
        }

        //former magic button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (NameSearchMode)
            {
                SearchByName();
            }
            else if (IdSearchMode)
            {
                SearchById();
            }
            else if (DateSearchMode)
            {
               SearchByDate();
            }
            Close();
        }
        #endregion
    }
}
