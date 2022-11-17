using JSON_manager.Forms;

namespace JSON_manager
{
    public partial class MainForm : Form
    {
        //
        //Fonts and colours
        //
        Font RegularFont = new Font("Ravie", 15F, FontStyle.Regular, GraphicsUnit.Point);
        Font RegularFocusFont = new Font("Ravie", 17F, FontStyle.Regular, GraphicsUnit.Point);
        Color DarkPurple = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        public MainForm()
        {
            InitializeComponent();
        }

        #region On click interactions
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All images are taken from https://icons8.com/icons/set/json-logo");
        }
        private void GreetingLabel_Click(object sender, EventArgs e)
        {
            string? name = ClickingClass.GreetingFunctional();
            if (name != null)
            {
                GreetingLabel.Text = "Hello, " + name + "!";
            }
        }
        private void OpenFileLabel_Click(object sender, EventArgs e)
        {
            Form OpenFileForm = new OpenFileForm();
            OpenFileForm.ShowDialog();
        }
        private void CreateFileLabel_Click(object sender, EventArgs e)
        {
            EnterPathForm enterPathForm = new EnterPathForm();
            enterPathForm.ShowDialog();
        }
        private void WhoLabel_Click(object sender, EventArgs e)
        {
            Form WhoForm = new WhoForm();
            WhoForm.ShowDialog();
        }
        private void ExitLabel_Click(object sender, EventArgs e)
        {
            Close();
        }
#endregion

        #region Hover interactions (color, font)
        //who label
        private void WhoLabel_Hover(object sender, EventArgs e)
        {
            WhoLabel.Font = RegularFocusFont;
            WhoLabel.ForeColor = Color.Purple;
        }
        private void WhoLabel_Leave(object sender, EventArgs e)
        {
            this.WhoLabel.Font = RegularFont;
            this.WhoLabel.ForeColor = DarkPurple;
        }
        //open file
        private void OpenFileLabel_Hover(object sender, EventArgs e)
        {
            OpenFileLabel.Font = RegularFocusFont;
            OpenFileLabel.ForeColor = Color.Purple;
        }
        private void OpenFileLabel_Leave(object sender, EventArgs e)
        {
            OpenFileLabel.Font = RegularFont;
            OpenFileLabel.ForeColor = DarkPurple;
        }
        //create file
        private void CreateFileLabel_Hover(object sender, EventArgs e)
        {
            CreateFileLabel.Font = RegularFocusFont;
            CreateFileLabel.ForeColor = Color.Purple;
        }
        private void CreateFileLabel_Leave(object sender, EventArgs e)
        {
            CreateFileLabel.Font = RegularFont;
            CreateFileLabel.ForeColor = DarkPurple;
        }
        //exit
        private void ExitLabel_Hover(object sender, EventArgs e)
        {
            ExitLabel.Font = RegularFocusFont;
            ExitLabel.ForeColor = Color.Purple;
        }
        private void ExitLabel_Leave(object sender, EventArgs e)
        {
            ExitLabel.Font = RegularFont;
            ExitLabel.ForeColor = DarkPurple;
        }
        #endregion
    }
}