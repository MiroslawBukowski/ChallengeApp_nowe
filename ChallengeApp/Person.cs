namespace ChallengeApp
{
    public abstract class Person
    {
        private readonly string FullName;
        protected int age;
       
        public Person(string fullName)
        {
            this.FullName = fullName;
        }

        public Person(int age)
        {
            this.age = age;
        }

        public string fullName { get; protected set; }
    }
}
