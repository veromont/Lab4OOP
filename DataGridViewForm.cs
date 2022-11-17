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
    public partial class DataGridViewForm : Form
    {
        //
        //Fonts and colours
        //
        Font RegularFont = new Font("Constantia", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Font RegularFocusFont = new Font("Constantia", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        Color DarkPurple = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));

        //fields
        public static List<Conferention>? Conferentions;
        public static List<Conferention>? ResultLINQ;
        private int chosenClass;
        
        //constructor
        public DataGridViewForm()
        {
            Conferentions = new List<Conferention>();
            foreach (Conferention con in InformationClass.Conferentions)
            {
                Conferentions.Add(con);
            }
            InitializeComponent();
            chosenClass = 0;
            AddChosenClassRows();
            ChangeLabels();
        }

        //methods within on clicks
        Conferention CopyCurrentObj()
        {
            var ChangedObj = new Conferention();

            //copy strings
            ChangedObj.Name = ClassGridView.Rows[0].Cells[1].Value.ToString();
            ChangedObj.Lector = ClassGridView.Rows[1].Cells[1].Value.ToString();
            ChangedObj.Organisator = ClassGridView.Rows[3].Cells[1].Value.ToString();
            ChangedObj.Venue = ClassGridView.Rows[4].Cells[1].Value.ToString();

            //copy other
            ChangedObj.Terms = TranslatorClass.StringToTerm(ClassGridView.Rows[2].Cells[1].Value.ToString());
            ChangedObj.WorkSubmDeadlineDate = TranslatorClass.StringToDate(ClassGridView.Rows[5].Cells[1].Value.ToString());
            ChangedObj.Price = TranslatorClass.StringToInt(ClassGridView.Rows[6].Cells[1].Value.ToString());
            ChangedObj.Id = TranslatorClass.StringToInt(ClassGridView.Rows[7].Cells[1].Value.ToString());
            return ChangedObj;
        }
        void UpdateLINQInfo()
        {
            if (ResultLINQ == null)
            {
                Conferentions = new List<Conferention>();
                foreach (Conferention con in InformationClass.Conferentions)
                {
                    Conferentions.Add(con);
                }
            }
            else
            {
                Conferentions = ResultLINQ;
            }
        }
        void ClearTable()
        {
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
            ClassGridView.Rows.Clear();
        }
        void AddChosenClassRows()
        {
            ClassGridView.Rows.Add("Name", Conferentions[chosenClass].Name);
            ClassGridView.Rows.Add("Lector", Conferentions[chosenClass].Lector);
            ClassGridView.Rows.Add("Terms", Conferentions[chosenClass].Terms.PresentTerm());
            ClassGridView.Rows.Add("Organisator", Conferentions[chosenClass].Organisator);
            ClassGridView.Rows.Add("Venue", Conferentions[chosenClass].Venue);
            ClassGridView.Rows.Add("Work submission deadline", Conferentions[chosenClass].WorkSubmDeadlineDate.PresentDate());
            ClassGridView.Rows.Add("Price", Conferentions[chosenClass].Price);
            ClassGridView.Rows.Add("Id", Conferentions[chosenClass].Id);
        }
        void ChangeLabels()
        {
            CurrentObjNumLabel.Text = "Current conference number is:  " + (chosenClass + 1);
            ObjectCountLabel.Text = "Total conferences available: " + Conferentions.Count;
        }
        bool chosenClassIsValid()
        {
            if (chosenClass > Conferentions.Count)
            {
                MessageBox.Show("Our file is smaller than that");
                chosenClass = Conferentions.Count - 1;
                return false;
            }
            else if (chosenClass < 1)
            {
                MessageBox.Show("Our file is bigger than that");
                chosenClass = 0;
                return false;
            }
            else 
            {
                ChosenClasstxtbox.Text = "";
                chosenClass--;
                return true; 
            }
        }
        void DisplayChosenClass()
        {
            UpdateLINQInfo();
            ClearTable();
            AddChosenClassRows();
            ChangeLabels();
        }

        #region on click interactions
        private void MagicButton_Click(object sender, EventArgs e)
        {
            string result = ChosenClasstxtbox.Text;
            if (int.TryParse(result, out chosenClass))
            {
                chosenClassIsValid();
                DisplayChosenClass();
            }
            else
            {
                MessageBox.Show("Not eligible value in textbox, try again");
            }
        }

        private void SaveChangesLabel_Click(object sender, EventArgs e)
        {
            Conferention ChangedObj;
            try
            {
                ChangedObj = CopyCurrentObj();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DisplayChosenClass();
                return;
            }
            SerializationClass.SerializeWith(ChangedObj);
        }

        private void DiscardChangesLabelClick(object sender, EventArgs e)
        {
            DisplayChosenClass();
        }

        private void QuitLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LINQsearchLabel_Click(object sender, EventArgs e)
        {
            LINQsearchForm LinqForm = new LINQsearchForm();
            LinqForm.ShowDialog();
        }

        private void CancelSearchLabel_Click(object sender, EventArgs e)
        {
            Conferentions = new List<Conferention>();
            foreach (Conferention con in InformationClass.Conferentions)
            {
                Conferentions.Add(con);
            }
            ResultLINQ = null;
        }

        private void DeleteLabel_Click(object sender, EventArgs e)
        {
            if (Conferentions.Count == 1)
            {
                MessageBox.Show("There should be at least one instance of an object in file");
                return;
            }
            var DeletedObject = Conferentions[chosenClass];
            SerializationClass.SerializeWithout(DeletedObject);
        }

        private void RefreshPicture_Click(object sender, EventArgs e)
        {
            //refresh
            bool ok = SerializationClass.DeserializeFromFile();
            if (!ok)
            {
                MessageBox.Show("Failed to refresh data");
            }

            //copy results here
            Conferentions = new List<Conferention>();
            foreach (Conferention con in InformationClass.Conferentions)
            {
                Conferentions.Add(con);
            }

            //display first object
            chosenClass = 0;
            DisplayChosenClass();

        }

        private void NextPicture_Click(object sender, EventArgs e)
        {
            chosenClass += 2;
            chosenClassIsValid();
            DisplayChosenClass();
        }

        private void PrevPicture_Click(object sender, EventArgs e)
        {
            chosenClassIsValid();
            DisplayChosenClass();
        }
        #endregion
        
        #region on hover interactions
        private void WriteToFileLabel_Hover(object sender, EventArgs e)
        {
            WriteToFileLabel.Font = RegularFocusFont;
            WriteToFileLabel.ForeColor = Color.Purple;
        }
        private void WriteToFileLabel_Leave(object sender, EventArgs e)
        {
            WriteToFileLabel.Font = RegularFont;
            WriteToFileLabel.ForeColor = DarkPurple;
        }
        private void QuitLabel_Hover(object sender, EventArgs e)
        {
            QuitLabel.Font = RegularFocusFont;
            QuitLabel.ForeColor = Color.Purple;
        }
        private void QuitLabel_Leave(object sender, EventArgs e)
        {
            QuitLabel.Font = RegularFont;
            QuitLabel.ForeColor = DarkPurple;
        }
        private void DisplayDefClassLabel_Hover(object sender, EventArgs e)
        {
            DisplayDefClassLabel.Font = RegularFocusFont;
            DisplayDefClassLabel.ForeColor = Color.Purple;
        }
        private void DisplayDefClassLabel_Leave(object sender, EventArgs e)
        {
            DisplayDefClassLabel.Font = RegularFont;
            DisplayDefClassLabel.ForeColor = DarkPurple;
        }
        private void LINQsearchLabel_Hover(object sender, EventArgs e)
        {
            LINQsearchLabel.Font = RegularFocusFont;
            LINQsearchLabel.ForeColor = Color.Purple;
        }
        private void LINQsearchLabel_Leave(object sender, EventArgs e)
        {
            LINQsearchLabel.Font = RegularFont;
            LINQsearchLabel.ForeColor = DarkPurple;
        }
        private void CancelSearchLabel_Hover(object sender, EventArgs e)
        {
            CancelSearchLabel.Font = RegularFocusFont;
            CancelSearchLabel.ForeColor = Color.Purple;
        }
        private void CancelSearchLabel_Leave(object sender, EventArgs e)
        {
            CancelSearchLabel.Font = RegularFont;
            CancelSearchLabel.ForeColor = DarkPurple;
        }
        private void DeleteLabel_Hover(object sender, EventArgs e)
        {
            DeleteLabel.Font = RegularFocusFont;
            DeleteLabel.ForeColor = Color.Purple;
        }
        private void DeleteLabel_Leave(object sender, EventArgs e)
        {
            DeleteLabel.Font = RegularFont;
            DeleteLabel.ForeColor = DarkPurple;
        }
        #endregion
    }
}
