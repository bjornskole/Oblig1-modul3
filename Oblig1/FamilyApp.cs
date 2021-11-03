using System;
using System.Collections.Generic;
using System.Linq;

namespace Oblig1
{
    public class FamilyApp
    {

        static List<Person> _people;
        public string WelcomeMessage { get; set; }
        public string CommandPrompt { get; set; }
        static string str;
        static string helpMessage = $@"
            hjelp: viser en hjelpetekst som forklarer alle kommandoene
            liste: lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. 
            vis + id: viser en bestemt person med mor, far og barn, og dem sin id
            ";

        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
            WelcomeMessage = MessageTrimmer(helpMessage);
        }

        public string HandleCommand(string command)
        {
            var tempCommand = command.Split(' ');
            string com = tempCommand[0];
            string text =
            (command == "hjelp" ? MessageTrimmer(helpMessage)
            : command == "liste" ? LoopPeople()
            : com == "vis" ? ShowPerson(command)
            : MessageTrimmer(helpMessage));
            return text;
        }

        public static string LoopPeople()
        {
            str = "";
            
                foreach (var p in _people)
                {
                    str += $"{p.GetDescription()} \n";
                }
            
            return str;

        }
        public static string ShowPerson(string command)
        {
            str = "";
            var tempCommand = command.Split(' ');
            string id = tempCommand[1];
            var result = _people.Where(x => x.Id.ToString() == id ).FirstOrDefault();

            return result != null ? str = result.GetDescription() + (GetKids(id) != null ? GetKids(id) : null) : "No data for this id, please try again!";
            
        }

        public static string GetKids(string id)
        {   
            var result = _people.Where(x => x.Father != null && x.Father.Id.ToString() == id || x.Mother != null && x.Mother.Id.ToString() == id);

            string kidString = null;

            foreach (var p in result)
            {
                kidString += $"    {p.GetDescription(false, false)}\n";
            }

            return (kidString != null ? "\n  Barn:\n" : "") + kidString;
        }

        private static string MessageTrimmer(string text)
        {
            return text.Replace("  ", "").Trim();
        }

    }
}