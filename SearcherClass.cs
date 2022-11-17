namespace JSON_manager
{
    internal class SearcherClass
    {
        List<Conferention> Conferentions;
        public SearcherClass()
        {
            Conferentions = new List<Conferention>();
            foreach (Conferention con in InformationClass.Conferentions)
            {
                Conferention temp = con.Copy();
                Conferentions.Add(temp);
            }
        }

        private void ShortenConfsNames(string name)
        {
            int maxlen = name.Length;
            foreach (Conferention conferention in Conferentions)
            {
                if (conferention.Name.Length > maxlen)
                {
                    conferention.Name = conferention.Name.Substring(0, maxlen);
                }
            }
        }

        public List<Conferention>? SearchById(int id)
        {
            //linq search
            var Result = from Conferention conf in Conferentions where (conf.Id == id) select conf;
            
            //nothing found
            if (Result == null || Result.Count() == 0) { return null; }

            //something`s here
            else { return Result.ToList(); }
        }
        public List<Conferention>? SearchByName(string name)
        {
            ShortenConfsNames(name);

            //'true' list of conferentions
            Conferentions = InformationClass.Conferentions;
            List<Conferention> Result = new List<Conferention> ();

            //linq search
            var ResultId = from conf in Conferentions where conf.Name == name select conf.Id;

            //nothing found
            if (ResultId == null || ResultId.Count() == 0) { return null; }

            //return full names
            foreach (int id in ResultId)
            {
                Conferention? temp = SearchById(id)[0];
                if (temp != null)
                {
                    Result.Add(temp);
                }
            }

            return Result.ToList();
        }
        public List<Conferention>? SearchByDate(Date date)
        {
            //search
            var Result = from con in Conferentions where con.Terms.StartDate > date select con;

            //nothing found
            if (Result == null || Result.Count() == 0) { return null; }

            //something`s here
            return Result.ToList();
        }
    }
}
