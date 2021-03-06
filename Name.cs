namespace NameSorterExe
{
    public class Name
    {
        // getter for first and last name
        public string LastName { get; }
        public string FirstName { get; }

        // overload default constructor to take in 2 string parameters 
        public Name(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

    }
}
