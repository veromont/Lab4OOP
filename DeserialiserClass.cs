using System.Text.Json;

namespace JSON_manager
{
    public class DeserializerClass
    {
        private string path = InformationClass.path;
        public DeserializerClass()
        {
            InformationClass.Conferentions = new List<Conferention>();
        }
        public bool Deserialize()
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))                
                {
                    var tempList = JsonSerializer.Deserialize<List<Conferention>>(fs);
                    if (tempList == null)
                    {
                        MessageBox.Show("File is empty");
                        return false;
                    }
                    else
                    {
                        InformationClass.Conferentions = tempList;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
