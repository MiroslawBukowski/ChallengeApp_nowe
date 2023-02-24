namespace ChallengeApp
{
    public abstract class Person
    {
        protected int age;
       
        public Person(string Name)
        {
            this.Name = Name;
        }

        public Person(int age)
        {
            this.age = age;
        }

        public string Name { get; protected set; }
    }
}
