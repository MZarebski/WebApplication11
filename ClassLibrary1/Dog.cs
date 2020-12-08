using Realms;

namespace ClassLibrary1
{
    public class Dog : RealmObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Owner { get; set; }
    }
}