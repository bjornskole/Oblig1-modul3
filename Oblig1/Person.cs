using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    public class Person
    {   
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get;  set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }


       
        public string GetDescription(bool hasMother = true, bool hasFather = true)
        {
            string text = $@"
            {(FirstName != null ? FirstName + " " : "")}
            {(LastName != null ? LastName + " " : "")}
            {(Id != null ? $"(Id={Id})" : "(Id=1)")}
            {(BirthYear != null ? " Født: " + BirthYear : "")}
            {(DeathYear != null ? " Død: " + DeathYear : "")}
            {(Father != null && hasFather ? " Far: " + Father.GetDescription(false, false) : "")}
            {(Mother != null && hasMother ? " Mor: " + Mother.GetDescription(false, false) : "")}
            ";
            return Trimmer(text);
        }

        private static string Trimmer(string text)
        {
            string emptyString = "";
            string multipleSpace = "  ";
            return text.Replace("\n", emptyString).Replace("\r", emptyString).Replace(multipleSpace, emptyString).Trim();
        }
    }
}
