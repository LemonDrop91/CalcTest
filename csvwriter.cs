using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ConsoleApplication12
{
    class Program								
    {
        static void Main(string[] args)
        {

            var theIncident = new Dictionary<string, string>();

    
            Console.WriteLine("Welcome! Please give a title for this Bug:");
            string UserInputTitle = Console.ReadLine();
            Console.WriteLine("\n");
            theIncident.Add("the Title", UserInputTitle);

            Console.WriteLine("Please describe the problem:");
            string UserInputProblem = Console.ReadLine();
            Console.WriteLine("\n");
            theIncident.Add("the Problem", UserInputProblem);

            Console.WriteLine("Now please describe the solution:");
            string UserInputSolution = Console.ReadLine();
            Console.WriteLine("\n");
            theIncident.Add("the Solution", UserInputSolution);

            Console.WriteLine("Here is the record you made of this Bug: \n");


            var keys = theIncident.Keys;

            foreach (var key in keys)
            {
                Console.WriteLine(key + ": " + theIncident[key]);
            }
            Console.ReadLine();
            
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            using (CsvFileWriter writer = new CsvFileWriter(mydocpath + @"\LemonDropBugs.csv", true)) 
            {
                for (int i = 0; i < 1; i++)
                {
                    CsvRow Row = new CsvRow();
                    
                    
                    Row.Add(String.Format(theIncident["the Title"]));
                    Row.Add(String.Format(theIncident["the Problem"]));
                    Row.Add(String.Format(theIncident["the Solution"]));
                    writer.WriteRow(Row);
                    
                    
                }
            }

	
        }


        public class CsvRow : List<string>
        {
            public string LineText { get; set; }
        }

        public class CsvFileWriter : StreamWriter
        {
            public CsvFileWriter(Stream stream)
                : base(stream)
            {
            }
            public CsvFileWriter(string filename, Boolean existornot)
                : base(filename, true)
            {
            }
            public void WriteRow(CsvRow row)
            {
                StringBuilder builder = new StringBuilder();
                bool firstColumn = true;
                foreach (string value in row)
                {
                    if (!firstColumn)
                        builder.Append(',');
                    if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                        builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                    else
                        builder.Append(value);
                    firstColumn = false;
                }
                row.LineText = builder.ToString();
                WriteLine(row.LineText);
            }
        }





    }
}
