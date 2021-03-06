using System.Collections.Generic;
using System.IO;

namespace NameSorterExe
{
    public class FileReader
    {
        // Method to read the contents from input file based on the file path given
        public static List<Name> GetNames (string FilePath)
        {
            string[] NameList;
            List<Name> NameObj = new List<Name> { };

            // Check if file exists
            bool fileExist = File.Exists(FilePath);

            // IF file exists : Proceed to reconstruct name
            // ELSE : Return empty List<Name>
            if(fileExist)
            {
                NameList = File.ReadAllLines(FilePath);
                foreach(string name in NameList)
                {
                    string[] SplittedNames = ReConstructName(name);
                    NameObj.Add(new Name(SplittedNames[0], SplittedNames[1]));
                }
                
            }
            return NameObj;
        }

        // Method to reconstruct the name to first name then last name
        private static string[] ReConstructName(string name) 
        {
            // Break up the name into first and last name
            var names = name.Split(' ', System.StringSplitOptions.None);

            // Assign first and last name into string array
            var length = names.Length;
            names[0] = string.Join(' ', names, 0, length - 1); // First Name
            names[1] = names[length-1]; // Last name

            return names;
        }

    }
}
