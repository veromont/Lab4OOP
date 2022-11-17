using static System.Reflection.Metadata.BlobBuilder;
using System.Text.Json;

namespace JSON_manager
{
    internal class SerializerClass
    {
        private string path = InformationClass.path;
        Conferention Changed;
        public SerializerClass(Conferention changed)
        {
            Changed = changed;
        }
        public bool Serialize()
        {
            try
            {
                //illicit id 
                if (Changed.Id < 0)
                {
                    return false;
                }

                //no comment, too easy
                List<Conferention> FileConferentions = new List<Conferention>();
                foreach (Conferention con in InformationClass.Conferentions)
                {
                    FileConferentions.Add(con);
                }
                List<Conferention> NewConferentions = new List<Conferention>();
                Conferention Old = new Conferention();

                //copy list from deserializer
                foreach (Conferention con in FileConferentions)
                {
                    NewConferentions.Add(con);
                }

                //error check
                if (NewConferentions.Count == 0)
                {
                    MessageBox.Show("NewConferentions.Count == 0");
                    return false;
                }

                //change list
                foreach (Conferention con in NewConferentions)
                {
                    if (Changed.Id == con.Id)
                    {
                        Old = con;
                    }
                }
                if (Old != null)
                {
                    NewConferentions.Remove(Old);
                    NewConferentions.Add(Changed);
                }

                //delete old file
                using (FileStream fs = new FileStream(path, FileMode.Create)){}

                //write new objects to new file
                using (FileStream fs = new FileStream(path, FileMode.Append))
                {
                    JsonSerializer.Serialize(fs, NewConferentions);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public bool SerializeWithout()
        {
            //no comment, too easy
            List<Conferention> FileConferentions = InformationClass.Conferentions;
            List<Conferention> NewConferentions = new List<Conferention>();

            //copy list from deserializer without deleted
            foreach (Conferention con in FileConferentions)
            {
                if (con.Id == Changed.Id) { }
                else
                {
                    NewConferentions.Add(con);
                }
            }

            //delete old file
            using (FileStream fs = new FileStream(path, FileMode.Create)) { }

            //write new objects to new file
            using (FileStream fs = new FileStream(path, FileMode.Append))
            {
                JsonSerializer.Serialize(fs, NewConferentions);
            }
            return true;
        }
    }
}
