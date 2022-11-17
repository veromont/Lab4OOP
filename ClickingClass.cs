using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_manager
{
    internal class ClickingClass
    {
        public static string? GreetingFunctional()
        {
            Form GreetForm = new GreetingForm();
            GreetForm.ShowDialog();

            string? name = null;
            while (name == null)
            {
                name = GreetingForm.username;
                if (Application.OpenForms.OfType<GreetingForm>().Count() == 0) ;
                {
                    break;
                }
            }
            GreetForm.Close();
            return name;
        }
    }
}
