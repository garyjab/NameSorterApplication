using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorterExe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Name> UnsortedNames = new List<Name> { };
            string[] SortedNames;
            // Retrieve all the unsorted names in the text file
            UnsortedNames = FileReader.GetNames(@"unsorted-names-list.txt");

            // Process if the file is not empty
            if (UnsortedNames.Count() > 0)
            {
                // Sort names by using linq OrderBy and ThenBy sorting operators
                IEnumerable<object> IESortedNames = UnsortedNames.OrderBy(lname => lname.LastName)
                                                                 .ThenBy(fname => fname.FirstName);

                // Cast IEnumerable<object> to string[]
                SortedNames = IESortedNames.Cast<Name>()
                                           .Select(a => a.FirstName + " " + a.LastName)
                                           .ToArray();
                
                // Export names into text file, overwrite if file existed
                //
                File.WriteAllLines(@"sorted-names-list.txt", SortedNames);

                // Print every names on console
                Array.ForEach(SortedNames, Console.WriteLine);

            }
            else
                Console.WriteLine("The file is empty!");

        }
    }
}
