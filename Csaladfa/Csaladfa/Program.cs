using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Csaladfa.Questions;
using CsvHelper;
using CsvHelper.Configuration;
/*
 Leírás, és tanácsok helye. Később ha lesz időm egy frissített verzióval elküldöm.

 Hibák feloldásához a hiányzó nuget package-eket kell letölteni. 
 Ez automatikusan megtörténik első fordításkor.
 */
namespace Csaladfa
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!IsValidInput(args))
            {
                Console.WriteLine("Usage: Csaladfa.exe csaladfa.csv");
                Console.ReadKey(false);
            }
            var csaladfa = CreateCsaladfa(args);
            var questions = GetQuestions();
            AnswerQuestions(questions, csaladfa);
            Console.ReadKey(true);
        }

        public static bool IsValidInput(string[] args)
        {
            return args.Length == 1 && File.Exists(args[0]);
        }

        private static CsaladfaContext CreateCsaladfa(string[] args)
        {
            var persons = ReadPersons(args[0]);
            BuildHierarchy(persons);
            var families = Buildfamilies(persons);
            CsaladfaContext context = new CsaladfaContext
            {
                Persons = persons,
                Families = families
            };
            return context;
        }

        public static List<Person> ReadPersons(string file)
        {
            using (var streamReader = new StreamReader(file, Encoding.UTF8))
            {
                var csvConfiguration = new CsvConfiguration
                {
                    Delimiter = ";",
                    HasHeaderRecord = false
                };
                csvConfiguration.RegisterClassMap(typeof(PersonClassMap));
                using (var reader = new CsvReader(streamReader, csvConfiguration))
                {
                    return reader.GetRecords<Person>().ToList();
                }
            }
        }

        private static List<Family> Buildfamilies(List<Person> persons)
        {
            var families = new List<Family>();
            foreach (var person in persons.Where(e => !e.IsOrphan()))
            {
                var family = families.FirstOrDefault(cs => cs.IsChildOfFamily(person));
                if (family == null)
                {
                    families.Add(Family.CreateNewFor(person));
                }
                else
                {
                    family.Childs.Add(person);
                }
            }
            return families;
        }

        public static void BuildHierarchy(List<Person> persons)
        {
            foreach (var person in persons)
            {
                if (!string.IsNullOrEmpty(person.FatherName))
                {
                    person.Father = persons.FirstOrDefault(e => e.Name == person.FatherName);
                }
                if (!string.IsNullOrEmpty(person.MotherName))
                {
                    person.Mother = persons.FirstOrDefault(e => e.Name == person.MotherName);
                }
            }
        }

        private static List<IQuestion> GetQuestions()
        {
            return new List<IQuestion>
            {
                new Question1(),
                new Question2(),
                new Question3(),
                new Question4(),
                new Question5(),
                new Question6(),
                new Question7(),
                new Question8(),
                new Question9(),
                new Question10()
            };
        }

        private static void AnswerQuestions(List<IQuestion> questions, CsaladfaContext csaladfa)
        {
            foreach (var question in questions)
            {
                question.Answer(csaladfa, Console.Out);
            }
        }

    }
}
