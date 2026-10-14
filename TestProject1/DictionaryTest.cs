using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Dictionary;
namespace TestProject1
{
    public class MyDictionaryTest
    {
        [Test]
        public void Add_ExistingKey_CountNotChanged()
        {
            var dictionary = new MyDictionary<int, string>();
            var expectedRes = 1;
            dictionary.Add(4, "brbr");
            dictionary.Add(4, "ththt");
            var actualRes = dictionary.Count;
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Add_NullKey_CountNotChanged()
        {
            var dictionary = new MyDictionary<string, string>();
            dictionary.Add("4", "brbr");
            Assert.That(() => dictionary.Add(null, "ththt"), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void Add_NonExistentKey_CountChanged()
        {
            var dictionary = new MyDictionary<int, string>();
            var expectedRes = 2;
            dictionary.Add(4, "brbr");
            dictionary.Add(5, "ththt");
            var actualRes = dictionary.Count;
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Add_CheckResize_IncreasedArray()
        {
            var dictionary = new MyDictionary<int, string>();
            var expectedRes = 17;
            for (int i = 0; i < 17; i++)
            {
                dictionary.Add(i, $"value{i}");
            }
            var actualRes = dictionary.Count;
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void GetValue_ExistingKey_ReturnsCorrectValue()
        {
            var dictionary = new MyDictionary<int, string>();
            var expectedRes = "gaga";
            dictionary.Add(1, "gaga");
            var actualRes = dictionary.GetValue(1);
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void GetValue_NonExistentKey_ThrowsKeyNotFoundException()
        {
            var dictionary = new MyDictionary<int, string>();
            dictionary.Add(1, "gaga");
            Assert.That(() => dictionary.GetValue(2), Throws.TypeOf<KeyNotFoundException>());
        }
        [Test]
        public void Remove_ExistingKey_DecrementCount()
        {
            var dictionary = new MyDictionary<int, string>();
            var expectedRes = 1;
            dictionary.Add(1, "queen");
            dictionary.Add(2, "adele");
            dictionary.Remove(2);
            var actualRes = dictionary.Count;
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
        [Test]
        public void Remove_NullKey_DecrementCount()
        {
            var dictionary = new MyDictionary<string, string>();
            dictionary.Add("1", "queen");
            dictionary.Add("2", "adele");
            dictionary.Remove("3");
            var actualRes = dictionary.Count;
            Assert.That(() => dictionary.Remove(null), Throws.TypeOf<ArgumentNullException>());
        }
        [Test]
        public void Remove_NonExistentKey_UnchangedCount()
        {
            var dictionary = new MyDictionary<int, string>();
            var expectedRes = 2;
            dictionary.Add(1, "queen");
            dictionary.Add(2, "adele");
            dictionary.Remove(3);
            var actualRes = dictionary.Count;
            Assert.That(actualRes, Is.EqualTo(expectedRes));
        }
    }
}
