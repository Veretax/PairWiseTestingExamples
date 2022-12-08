using NUnit.Framework;
using PairWiseTestingExamples.NewFolder;
using System;
using FluentAssertions;

namespace PairWiseTestingExamples.Test.Collections
{
    [TestFixture]
    public class ObjectSetTestCaseGeneratorTests
    {
        [Test]
        public void ObjectSetTestCaseGenerator_Begins_WithBlankInitializedObjectSetGroupPair()
        {
            // Arrange
            var sut = new ObjectSetTestCaseGenerator();
            // Act 

            // Assert
            sut.ObjectSetGroup.Should().NotBeNull();
            sut.ObjectSetGroup.Count.Should().Be(2);
        }
        
        [Test]
        [TestCase(2)]
        public void ObjectSetTestCaseGenerator_WhenPassedSetCountBegins_WithBlankInitializedObjectSetOfSizeCount(int count)
        {
            // Arrange
            var sut = new ObjectSetTestCaseGenerator();
            // Act 

            // Assert
            sut.ObjectSetGroup.Should().NotBeNull();
            sut.ObjectSetGroup.Count.Should().Be(2);
        }

        [Test]
        public void InitializeSetData_WithNullSet_LeavesPairedSetsEmpty()
        {
            // Arrange
            var sut = new ObjectSetTestCaseGenerator();
            ObjectSetGroup objectSetGroup = null;

            // Act
            sut.InitializeSetData(objectSetGroup);

            // Assert
            sut.ObjectSetGroup.Should().NotBeNull();
            sut.ObjectSetGroup.Count.Should().Be(2);
        }


        [Test]
        public void InitializeSetData_WithEmptySet_AddsEmptySet()
        {
            // Arrange
            var sut = new ObjectSetTestCaseGenerator();
            List<Object> set1 = new List<object>();
            List<Object> set2 = new List<object>();
            ObjectSetGroup objectSetGroup = new ObjectSetGroup()
            {
                set1,
                set2
            };
            // Act
            sut.InitializeSetData(objectSetGroup);

            // Assert
            sut.ObjectSetGroup.Count.Should().Be(2);
            sut.ObjectSetGroup.Count.Should().Be(2);
            sut.ObjectSetGroup[0].Count.Should().Be(0);
            sut.ObjectSetGroup[1].Count.Should().Be(0);
        }

        [Test]
        public void InitializeSetData_WithNonEmptySet_AddsTheSet()
        {
            // Arrange
            var sut = new ObjectSetTestCaseGenerator();
            List<Object> set1 = new List<object>(){ 1, 2, 3, 4};
            List<Object> set2 = new List<object>(){ 'a', 'b', 'c', 'd', 'e'};
            ObjectSetGroup objectSetGroup = new ObjectSetGroup(2);
            objectSetGroup.DefineObjectSet(0,set1);
            objectSetGroup.DefineObjectSet(1,set2);

            // Act
            sut.InitializeSetData(objectSetGroup);

            // Assert
            sut.ObjectSetGroup.Count.Should().Be(4);
            sut.ObjectSetGroup.ObjectSets.Count.Should().Be(4);
            sut.ObjectSetGroup[0].Count.Should().Be(4);
            sut.ObjectSetGroup[1].Count.Should().Be(4);
        }
    }
}
