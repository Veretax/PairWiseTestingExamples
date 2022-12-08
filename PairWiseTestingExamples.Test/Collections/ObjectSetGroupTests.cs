using FluentAssertions;
using NUnit.Framework;
using PairWiseTestingExamples.NewFolder;

namespace PairWiseTestingExamples.Test.Collections
{
    [TestFixture]
    public class ObjectSetGroupTests
    {
        [Test]
        public void ObjectSetGroup_Creates_2EmptyListSets()
        {
            // Arrange
            var objectSetGroup = new ObjectSetGroup();

            // Act
            
            // Assert
            objectSetGroup.Count.Should().Be(2);
            objectSetGroup[0].Count.Should().Be(0);
            objectSetGroup[1].Count.Should().Be(0);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(50)]
        [TestCase(100)]
        public void ObjectSetGroupWithCapacity_Creates_EmptyListSetsOfCapacity(int capacity)
        {
            // Arrange
            var objectSetGroup = new ObjectSetGroup(capacity);

            // Act

            // Assert
            objectSetGroup.Count.Should().Be(capacity);
            for (int n = 0; n < capacity; n++)
            {
                objectSetGroup[n].Count.Should().Be(0);
            }
        }

        [Test]
        public void ObjectSetGroupWithCapacity2_Creates_2EmptyListSets()
        {
            // Arrange
            var objectSetGroup = new ObjectSetGroup(2);

            // Act

            // Assert
            objectSetGroup.Count.Should().Be(2);
            objectSetGroup[0].Count.Should().Be(0);
            objectSetGroup[1].Count.Should().Be(0);
        }

        [Test]
        public void DefineObjectSetWith2_InitializesObjectSet_WithObjectSet(/*int setNumber, List<Object> set*/)
        {
            // Arrange
            var objectSetGroup = new ObjectSetGroup(2);
            objectSetGroup.Count.Should().Be(2);
            objectSetGroup[0].Count.Should().Be(0);
            objectSetGroup[1].Count.Should().Be(0);

            var objectSet1 = new List<Object>
            {
                "abcdefg",
                "123456",
                "!@#$%^",
                "",
                "_"
            };

            var objectSet2 = new List<Object>
            {
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second,
                DateTime.Now.Microsecond,
                DateTime.Now.DayOfWeek,
                DateTime.Now.DayOfYear,
                DateTime.Now.Kind,
                DateTime.Now.Millisecond,
                DateTime.Now.Nanosecond,
                DateTime.Now.Ticks,
                DateTime.Now.TimeOfDay,
            };

            // Act
            objectSetGroup.DefineObjectSet(0, objectSet1);

            // Assert

            //objectSetGroup[1].Equals(objectSet1).Should().BeTrue();
            foreach (var obj in objectSet1)
            {
                objectSetGroup[0].Contains(obj).Should().BeTrue();
            }
            objectSetGroup[1].Count.Should().Be(0);

            objectSetGroup.DefineObjectSet(1, objectSet2);
            foreach (var obj in objectSet2)
            {
                objectSetGroup[1].Contains(obj).Should().BeTrue();
            }
            foreach (var obj in objectSet1)
            {
                objectSetGroup[0].Contains(obj).Should().BeTrue();
            }

        }

        [Test]
        public void AddObjectToSet_AddsAnObjectToATargetedSet_DoesNotMutateTheOtherSet(/*int setNumber, List<Object> set*/)
        {
            // Arrange
            var objectSetGroup = new ObjectSetGroup(2);
            objectSetGroup.Count.Should().Be(2);
            objectSetGroup[0].Count.Should().Be(0);
            objectSetGroup[1].Count.Should().Be(0);
            var firstTicks = DateTime.Now.Ticks;
            var secondTicks = DateTime.Now.Ticks;

            // Act
            objectSetGroup.AddObjectToSet(1, firstTicks);

            // Assert
            objectSetGroup[1].Count.Should().Be(1);
            objectSetGroup[0].Count.Should().Be(0);
            objectSetGroup[1].Contains(firstTicks).Should().BeTrue();

            objectSetGroup.AddObjectToSet(0, secondTicks);
            objectSetGroup[1].Count.Should().Be(1);
            objectSetGroup[0].Count.Should().Be(1);
            objectSetGroup[0].Contains(secondTicks).Should().BeTrue();
            
        }
    }
}
