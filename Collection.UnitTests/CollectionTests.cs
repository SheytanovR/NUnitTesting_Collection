using NUnit.Framework;

namespace Collection.UnitTests
{
    public class CollectionTests
    {

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var collection= new Collection<int>();
            var expectedResult ="[]";
            Assert.That(collection.ToString(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Collection_ConstructorSingileItem()
        {
            var collection = new Collection<int>(5);
            var expectedResult = 5;
            Assert.That(collection[0], Is.EqualTo(expectedResult));
        }

        [Test]

        public void Test_Collection_ConstructorMultipleItems()
        {
            var collection = new Collection<int>(5, 6, 8, 9, 10);
            var expectedResult = "[5, 6, 8, 9, 10]";

            Assert.That(collection.ToString(), Is.EqualTo(expectedResult)); 
        }

        [Test]
        public void Test_Collection_Add()
        {
            var collection = new Collection<int>();

            collection.Add(1);
            collection.Add(5);

            var expectedResult = "[1, 5]";

            Assert.That(collection.ToString(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var collection = new Collection<int>();
            var oldCapacity=collection.Capacity;
            var newCollection = Enumerable.Range(1000, 2000).ToArray();    
            collection.AddRange(newCollection);

            string expectedCollection = "" + string.Join(",", collection) + "";

            Assert.That(collection.ToString(), Is.EqualTo(expectedCollection));
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var collection = new Collection<string>("Nikola", "Vyara");

            var index0 = collection[0];
            var index1 = collection[1];

            Assert.That(index0, Is.EqualTo("Nikola"));
            Assert.That(index1, Is.EqualTo("Vyara"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var collection = new Collection<string>();

            collection.InsertAt(0, "Nikola");
            collection.InsertAt(1, "Vyara");

            Assert.That(collection[0], Is.EqualTo("Nikola"));
            Assert.That(collection[1], Is.EqualTo("Vyara"));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var collection = new Collection<int>(2, 3, 6);

            Assert.That(() => { collection[3] = 10; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
 
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var collection = new Collection<string>("Nikola", "Vyara");

            Assert.That(() => { var name = collection[2]; }, 
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_ToStringNestedCollection()
        {
            var names = new Collection<string>("Nikola", "Vyara");
            var nums = new Collection<int>(2, 20);
            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(names, nums, dates);

            string nestedString=nested.ToString();

            Assert.That(nestedString, Is.EqualTo("[[Nikola, Vyara], [2, 20], []]"));
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var collection = new Collection<int>();
            var items = Enumerable.Range(0, itemsCount).ToArray();

            collection.AddRange(items);

            Assert.That(collection.Count == itemsCount);
        }

        [Test]
        public void Test_Collection_ExchnageFirstLast()
        {
            var collection = new Collection<int>(2,5,6);
            var initialIndex0 = collection[0];
            var initialIndex2 = collection[2];

            collection.Exchange(0, 2);
            var changedIndex0 = collection[0];
            var changedIndex2 = collection[2];

            Assert.That(initialIndex0, Is.EqualTo(changedIndex2));
            Assert.That(initialIndex2, Is.EqualTo(changedIndex0));
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var collection = new Collection<int>(2, 5, 6);

            collection.RemoveAt(0);

            Assert.That(collection.ToString(), Is.EqualTo("[5, 6]"));
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var collection = new Collection<int>(2, 5, 6);
            var oldCapacity=collection.Capacity;
            var newItems=Enumerable.Range(1, 30).ToArray();

            for (int i = 1; i <= 30; i++)
            {
                collection.Add(i);
            }

            Assert.That(collection.ToString(), Is.EqualTo($"[2, 5, 6, {string.Join(", ", newItems)}]"));
            Assert.That(collection.Capacity, Is.GreaterThan(oldCapacity));
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var collection = new Collection<int>(2, 5, 6);
            var oldCount = collection.Count;

            collection.Clear();

            Assert.That(collection.ToString(), Is.EqualTo("[]"));
            Assert.That(collection.Count, Is.LessThan(oldCount));
        }
    }
}