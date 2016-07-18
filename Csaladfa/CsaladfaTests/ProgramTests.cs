using Csaladfa;
using FluentAssertions;
using NUnit.Framework;

namespace CsaladfaTests
{
    [TestFixture()]
    public class ProgramTests
    {
        public const string CsaladfaCsv = "csaladfa.csv";

        [Test()]
        public void ValidInputTest()
        {
            Program.IsValidInput(new[] { CsaladfaCsv }).Should().BeTrue();
        }

        [Test()]
        public void InvalidInputTest()
        {
            Program.IsValidInput(new string[0]).Should().BeFalse();
        }

        [Test()]
        public void ExistingInputTest()
        {
            Program.IsValidInput(new[] { CsaladfaCsv }).Should().BeTrue();
        }

        [Test()]
        public void NonExistingInputTest()
        {
            Program.IsValidInput(new[] { "valami.csv" }).Should().BeFalse();
        }

        [Test]
        public void ReadPersons_OnCsaladfaCsv_ReadAllPersons()
        {
            //Arrange
            
            //Act
            var persons = Program.ReadPersons(CsaladfaCsv);
            //Assert
            persons.Should().NotBeNull();
            persons.Should().HaveCount(22);
        }

        [Test]
        public void BuildHierarchy_OnLoadedPersonList_ShouldBuildHierarchy()
        {
            //Arrange
            var persons = Program.ReadPersons(CsaladfaCsv);
            //Act
            Program.BuildHierarchy(persons);
            //Assert
            foreach (var person in persons)
            {
                if (!string.IsNullOrEmpty(person.MotherName))
                {
                    person.Mother.Should().NotBeNull();
                    person.Mother.Name.Should().Be(person.MotherName);
                }
                if (!string.IsNullOrEmpty(person.FatherName))
                {
                    person.Father.Should().NotBeNull();
                    person.Father.Name.Should().Be(person.FatherName);
                }
            }
        }

        [Test]
        public void Children_OnSettingFather_ShouldBeFilled()
        {
            //Arrange
            Person father = new Person();
            Person child = new Person();
            //Act
            child.Father = father;
            //Assert
            father.Childs.Should().Contain(child);
        }
        [Test]
        public void Children_OnSettingMother_ShouldBeFilled()
        {
            //Arrange
            Person mother = new Person();
            Person child = new Person();
            //Act
            child.Mother = mother;
            //Assert
            mother.Childs.Should().Contain(child);
        }
    }
}