using System.Collections.Generic;
using Realms;

namespace ClassLibrary1
{
    public class Person : RealmObject
    {
        public string Name { get; set; }
        public IList<Dog> Dogs { get; }
    }
}