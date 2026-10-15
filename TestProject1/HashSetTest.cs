using HashSet;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class HashSetTest
    {
        [Test]
        public void Print_EmptySet_EmptyString()
        {
            var set = new MyHashSet<int>();

            Assert.That(set.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Print_AfterAdds_AllElements()
        {
            var set = new MyHashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);

            Assert.That(set.Print(), Is.EqualTo("1 2 3 "));
        }

        [Test]
        public void Empty_NewSet_True()
        {
            Assert.That(new MyHashSet<int>().Empty(), Is.True);
        }

        [Test]
        public void Empty_AfterAdd_False()
        {
            var set = new MyHashSet<int>();
            set.Add(1);

            Assert.That(set.Empty(), Is.False);
        }
        [Test]
        public void Add_NewElement_ReturnsTrue()
        {
            var set = new MyHashSet<int>();

            Assert.That(set.Add(5), Is.True);
            Assert.That(set.Print(), Is.EqualTo("5 "));
        }

        [Test]
        public void Add_Duplicate_ReturnsFalseAndDoesNotAdd()
        {
            var set = new MyHashSet<int>();
            set.Add(5);

            Assert.That(set.Add(5), Is.False);
            Assert.That(set.Print(), Is.EqualTo("5 "));
        }

        [Test]
        public void Add_ManyElements_NoDuplicates()
        {
            var set = new MyHashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(1);
            set.Add(3);
            set.Add(2);

            Assert.That(set.Print(), Is.EqualTo("1 2 3 "));
        }
        [Test]
        public void Remove_ExistingElement_ReturnsTrue()
        {
            var set = new MyHashSet<int>();
            set.Add(1);
            set.Add(2);

            Assert.That(set.Remove(1), Is.True);
            Assert.That(set.Print(), Is.EqualTo("2 "));
        }

        [Test]
        public void Remove_NonExistingElement_ReturnsFalse()
        {
            var set = new MyHashSet<int>();
            set.Add(1);

            Assert.That(set.Remove(99), Is.False);
            Assert.That(set.Print(), Is.EqualTo("1 "));
        }

        [Test]
        public void Remove_FromEmptySet_ReturnsFalse()
        {
            var set = new MyHashSet<int>();

            Assert.That(set.Remove(1), Is.False);
        }
        [Test]
        public void Union_DisjointSets_AddsAllFromOther()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(3); b.Add(4);

            a.Union(b);

            Assert.That(a.Print(), Is.EqualTo("1 2 3 4 "));
        }

        [Test]
        public void Union_OverlappingSets_NoDuplicates()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(2); b.Add(3);

            a.Union(b);

            Assert.That(a.Print(), Is.EqualTo("1 2 3 "));
        }

        [Test]
        public void Union_WithEmptyOther_NoChange()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>();

            a.Union(b);

            Assert.That(a.Print(), Is.EqualTo("1 2 "));
        }

        [Test]
        public void Union_EmptyThis_TakesAllFromOther()
        {
            var a = new MyHashSet<int>();
            var b = new MyHashSet<int>(); b.Add(1); b.Add(2);

            a.Union(b);

            Assert.That(a.Print(), Is.EqualTo("1 2 "));
        }

        [Test]
        public void Union_NullOther_Throws()
        {
            var a = new MyHashSet<int>();
            a.Add(1);

            Assert.Throws<Exception>(() => a.Union(null));
        }

        [Test]
        public void Union_DoesNotModifyOther()
        {
            var a = new MyHashSet<int>(); a.Add(1);
            var b = new MyHashSet<int>(); b.Add(2); b.Add(3);

            a.Union(b);

            Assert.That(b.Print(), Is.EqualTo("2 3 "));
        }
        [Test]
        public void Intersect_Subset_KeepsOnlyCommon()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2); a.Add(3);
            var b = new MyHashSet<int>(); b.Add(2); b.Add(3);

            a.Intersect(b);

            Assert.That(a.Print(), Is.EqualTo("2 3 "));
        }

        [Test]
        public void Intersect_DisjointSets_ResultEmpty()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(3); b.Add(4);

            a.Intersect(b);

            Assert.That(a.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Intersect_WithEmptyOther_ResultEmpty()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>();

            a.Intersect(b);

            Assert.That(a.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Intersect_OnlyFirstCommon_RestRemoved()
        {
            // ключевой тест: ловит пропуск элементов при удалении в прямом цикле
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2); a.Add(3);
            var b = new MyHashSet<int>(); b.Add(1);

            a.Intersect(b);

            Assert.That(a.Print(), Is.EqualTo("1 "));
        }

        [Test]
        public void Intersect_OnlyLastCommon_FirstTwoRemoved()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2); a.Add(3);
            var b = new MyHashSet<int>(); b.Add(3);

            a.Intersect(b);

            Assert.That(a.Print(), Is.EqualTo("3 "));
        }

        [Test]
        public void Intersect_RemoveInMiddle_KeepsOnlyCommon()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2); a.Add(3); a.Add(4);
            var b = new MyHashSet<int>(); b.Add(2); b.Add(4);

            a.Intersect(b);

            Assert.That(a.Print(), Is.EqualTo("2 4 "));
        }

        [Test]
        public void Intersect_NullOther_Throws()
        {
            var a = new MyHashSet<int>();
            a.Add(1);

            Assert.Throws<Exception>(() => a.Intersect(null));
        }

        [Test]
        public void Intersect_DoesNotModifyOther()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(1); b.Add(3);

            a.Intersect(b);

            Assert.That(b.Print(), Is.EqualTo("1 3 "));
        }
        [Test]
        public void Difference_RemovesCommonElements()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2); a.Add(3);
            var b = new MyHashSet<int>(); b.Add(2); b.Add(3);

            a.Difference(b);

            Assert.That(a.Print(), Is.EqualTo("1 "));
        }

        [Test]
        public void Difference_OnlyFirstCommon_RestKept()
        {
            // ключевой тест на пропуск после удаления
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2); a.Add(3);
            var b = new MyHashSet<int>(); b.Add(1);

            a.Difference(b);

            Assert.That(a.Print(), Is.EqualTo("2 3 "));
        }

        [Test]
        public void Difference_DisjointSets_NoChange()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(3); b.Add(4);

            a.Difference(b);

            Assert.That(a.Print(), Is.EqualTo("1 2 "));
        }

        [Test]
        public void Difference_AllElementsCommon_ResultEmpty()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(1); b.Add(2);

            a.Difference(b);

            Assert.That(a.Print(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Difference_WithEmptyOther_NoChange()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>();

            a.Difference(b);

            Assert.That(a.Print(), Is.EqualTo("1 2 "));
        }
        [Test]
        public void IsSubset_ProperSubset_True()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(1); b.Add(2); b.Add(3);

            Assert.That(a.IsSubset(b), Is.True);
        }

        [Test]
        public void IsSubset_EqualSets_True()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(1); b.Add(2);

            Assert.That(a.IsSubset(b), Is.True);
        }

        [Test]
        public void IsSubset_NotSubset_False()
        {
            var a = new MyHashSet<int>(); a.Add(1); a.Add(2);
            var b = new MyHashSet<int>(); b.Add(1);

            Assert.That(a.IsSubset(b), Is.False);
        }

        [Test]
        public void IsSubset_EmptySet_True()
        {
            var a = new MyHashSet<int>();
            var b = new MyHashSet<int>(); b.Add(1);

            Assert.That(a.IsSubset(b), Is.True);
        }

        [Test]
        public void IsSubset_OtherEmpty_TrueOnlyIfThisEmpty()
        {
            var empty = new MyHashSet<int>();
            var notEmpty = new MyHashSet<int>(); notEmpty.Add(1);

            Assert.That(empty.IsSubset(new MyHashSet<int>()), Is.True);
            Assert.That(notEmpty.IsSubset(new MyHashSet<int>()), Is.False);
        }
    }
}
