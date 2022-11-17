namespace JSON_manager
{
    internal class TranslatorClass
    {
        public static int StringToInt(string number)
        {
            if (int.TryParse(number, out int result))
            {
                return result;
            }
            else
            {
                MessageBox.Show("Cannot convert '" + number + "' to int");
                return -1;
            }
        }
        public static Date? StringToDate(string date)
        {
            string[] parts;
            parts = date.Split('.');
            int days;
            int months;
            int years;
            if (int.TryParse(parts[0], out days)) { }
            else
            {
                MessageBox.Show("Cannot convert'" + date + "' to date");
                return null;
            }
            if (int.TryParse(parts[1], out months)) { }
            else
            {
                MessageBox.Show("Cannot convert'" + date + "' to date");
                return null;
            }
            if (int.TryParse(parts[2], out years)) { }
            else
            {
                MessageBox.Show("Cannot convert'" + date + "' to date");
                return null;
            }
            Date result = new Date(days, months, years);
            return result;
        }
        public static Term? StringToTerm(string term)
        {
            //format "From 'Date' until 'Date'"
            string[] parts;
            parts = term.Split(' ');
            Date? Start = StringToDate(parts[1]);
            Date? End = StringToDate(parts[3]);
            Term? Result = new Term(Start, End);
            return Result;
        }
    }
}
