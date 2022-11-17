namespace JSON_manager
{
    public partial class WhoForm : Form
    {
        public WhoForm()
        {
            InitializeComponent();
        }

        private void AboutConferenceLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("{\n\"Name\",\n\"Lector\",\n\"Terms\"\n{\n\"StartDate\"{\"Day\",\"Month\",\"Year\"},\n\"EndDate\"{\"Day\",\"Month\",\"Year\"}\n},\n\"Organisator\",\n\"Venue\",\n\"WorkSubmDeadlineDate\"\n{\n\"Day\",\n\"Month\",\n\"Year\"\n},\n\"Price\",\n\"Id\"\n}");
        }
    }
}
