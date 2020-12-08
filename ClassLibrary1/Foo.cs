using System.Linq;
using System.Threading;
using Realms;

namespace ClassLibrary1
{
    public class Foo
    {
        public void Bar()
        {
            var path = RealmConfigurationBase.GetPathToRealm();
            var realm = Realm.GetInstance();

            // Use LINQ to query
            var puppies = realm.All<Dog>().Where(d => d.Age < 2);

            puppies.Count(); // => 0 because no dogs have been added yet

            // Update and persist objects with a thread-safe transaction
            realm.Write(() =>
            {
                realm.Add(new Dog { Name = "Rex", Age = 1 });
            });

            // Queries are updated in realtime
            puppies.Count(); // => 1

            // LINQ query syntax works as well
            var oldDogs = from d in realm.All<Dog>() where d.Age > 8 select d;

            // Query and update from any thread
            new Thread(() =>
            {
                var realm2 = Realm.GetInstance();

                var theDog = realm2.All<Dog>().Where(d => d.Age == 1).First();
                realm2.Write(() => theDog.Age = 3);
            }).Start();

        }
    }
}
