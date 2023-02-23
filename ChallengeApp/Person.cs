namespace ChallengeApp
{
    public abstract class Person
    {
        protected int age;
       
        public Person(string name)
        {
            this.Name = name;
        }

        public Person(int age)
        {
            this.age = age;
        }

        public string Name { get; protected set; }
    }
}
