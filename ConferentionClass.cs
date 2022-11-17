using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_manager
{
    public class Conferention
    {
        public string Name { get; set; }
        public string Lector { get; set; }
        public Term? Terms { get; set; }
        public string Organisator { get; set; }
        public string Venue { get; set; }
        public Date? WorkSubmDeadlineDate { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public Conferention(string name, string lector, Term terms, string organisator, string venue, Date workSubmDeadlineDate, int price, int id)
        {
            Name = name;
            Lector = lector;
            Terms = terms;
            Organisator = organisator;
            Venue = venue;
            WorkSubmDeadlineDate = workSubmDeadlineDate;
            Price = price;
            Id = id;
        }
        public Conferention()
        {
            Name = "";
            Lector = "";
            Terms = null;
            Organisator = "";
            Venue = "";
            WorkSubmDeadlineDate= null;
            Price = 0;
            Id = 0;
        }
        public Conferention Copy()
        {
            Conferention New = new Conferention();
            New.Name = this.Name;
            New.Lector = this.Lector;
            New.Terms = this.Terms;
            New.Organisator = this.Organisator;
            New.Venue = this.Venue;
            New.WorkSubmDeadlineDate = this.WorkSubmDeadlineDate;
            New.Price = this.Price;
            New.Id = this.Id;
            return New;
        }
    }
}
