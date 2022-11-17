namespace JSON_manager
{
    public class Date
    {
        //properties
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        
        //constructor
        public Date(int day, int month, int year)
        {
            if (day < 32 && day > 0)
            {
                Day = day;
            }
            else
            {
                Day = 1;
                MessageBox.Show("Not valid day, we set 1");
            }
            if (month < 13 && month > 0)
            {
                Month = month;
            }
            else
            {
                Month = 1;
                MessageBox.Show("Not valid month, we set 1");
            }
            if (year > 1000 && year < 9999)
            {

                Year = year;
            }
            else
            {
                Year = 1111;
                Console.WriteLine("Not valid year, we set 1111");
            }
        }
        
        //methods
        public string PresentDate()
        {
            if (Day == 0 || Month == 0 || Year == 0)
            {
                return "Wrong data in Date";
            }
            string result = "";
            string d;
            string m;
            string y;
            if (Day < 10)
            {
                d = "0" + Day;
            }
            else
            {
                d = "" + Day;
            }
            if (Month < 10)
            {
                m = "0" + Month;
            }
            else
            {
                m = "" + Month;
            }
            y = "" + Year;
            result += d + "." + m + "." + y;
            return result;
        }
        
        //operator overloading
        public static bool operator > (Date thisdate, Date date)
        {
            // compare year
            if (thisdate.Year > date.Year)
            {
                return true;
            }
            else if (thisdate.Year < date.Year)
            {
                return false;
            }

            //compare month
            if (thisdate.Month > date.Month)
            {
                return true;
            }
            else if (thisdate.Month < date.Month)
            {
                return false;
            }

            //compare day
            if (thisdate.Day > date.Day)
            {
                return true;
            }
            else if (thisdate.Day < date.Day)
            {
                return false;
            }

            return false;
        }
        public static bool operator < (Date thisdate, Date date)
        {
            // compare year
            if (thisdate.Year < date.Year)
            {
                return true;
            }
            else if (thisdate.Year > date.Year)
            {
                return false;
            }

            //compare month
            if (thisdate.Month < date.Month)
            {
                return true;
            }
            else if (thisdate.Month > date.Month)
            {
                return false;
            }

            //compare day
            if (thisdate.Day < date.Day)
            {
                return true;
            }
            else if (thisdate.Day > date.Day)
            {
                return false;
            }

            return false;
        }
    }
    public class Term
    {
        public Date? StartDate { get; set; }
        public Date? EndDate { get; set; }
        public Term(Date startDate, Date endDate)
        {
            if (startDate > endDate)
            {
                StartDate = endDate;
                EndDate = startDate;
                return;
            }
            StartDate = startDate;
            EndDate = endDate;
        }
        public string PresentTerm()
        {
            string result = "";
            result += "From " + StartDate.PresentDate() + " until " + EndDate.PresentDate();
            return result;
        }
    }
}
