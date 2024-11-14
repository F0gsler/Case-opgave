namespace Case_Opgave
{
    public class Teacher : IPerson
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Teacher(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
