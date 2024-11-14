namespace Case_Opgave
{
    public class Student : IPerson
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
