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
    }
}