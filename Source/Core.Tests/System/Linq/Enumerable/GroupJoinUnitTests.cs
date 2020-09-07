namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Joins a sequence with the grouping of another sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins a sequence with the grouping of another sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoin()
        {
            var people = new[] 
            {
                new { Name = "Hedlund, Magnus" },
                new { Name = "Adams, Terry" },
                new { Name = "Weiss, Charlotte" },
            };
            var magnus = people[0];
            var terry = people[1];
            var charlotte = people[2];
            var pets = new[] 
            { 
                new { Name = "Barley", Owner = terry },
                new { Name = "Boots", Owner = terry },
                new { Name = "Whiskers", Owner = charlotte },
                new { Name = "Daisy", Owner = magnus },
            };

            var query = people.GroupJoin(
                pets,
                person => person,
                pet => pet.Owner,
                (person, petCollection) =>
                new
                {
                    OwnerName = person.Name,
                    Pets = petCollection.Select(pet => pet.Name)
                }).ToArray();

            Assert.AreEqual("Hedlund, Magnus", query[0].OwnerName);
            CollectionAssert.AreEqual(new[] { "Daisy" }, query[0].Pets.ToArray());
            Assert.AreEqual("Adams, Terry", query[1].OwnerName);
            CollectionAssert.AreEqual(new[] { "Barley", "Boots" }, query[1].Pets.ToArray());
            Assert.AreEqual("Weiss, Charlotte", query[2].OwnerName);
            CollectionAssert.AreEqual(new[] { "Whiskers" }, query[2].Pets.ToArray());
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence ignoring casing
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins a sequence with the grouping of another sequence ignoring casing")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinComparer()
        {
            var people = new[]
            {
                new { Name = "hedlund, Magnus" },
                new { Name = "Adams, Terry" },
                new { Name = "Weiss, Charlotte" },
            };
            var terry = people[1];
            var charlotte = people[2];
            var pets = new[]
            {
                new { Name = "Barley", Owner = new { Name = "adams, terry" } },
                new { Name = "Boots", Owner = terry },
                new { Name = "Whiskers", Owner = charlotte },
                new { Name = "Daisy", Owner = new { Name = "Hedlund, Magnus" } },
            };

            var query = people.GroupJoin(
                pets,
                person => person.Name,
                pet => pet.Owner.Name,
                (person, petCollection) =>
                new
                {
                    OwnerName = person.Name,
                    Pets = petCollection.Select(pet => pet.Name)
                },
                StringComparer.OrdinalIgnoreCase).ToArray();

            Assert.AreEqual("hedlund, Magnus", query[0].OwnerName);
            CollectionAssert.AreEqual(new[] { "Daisy" }, query[0].Pets.ToArray());
            Assert.AreEqual("Adams, Terry", query[1].OwnerName);
            CollectionAssert.AreEqual(new[] { "Barley", "Boots" }, query[1].Pets.ToArray());
            Assert.AreEqual("Weiss, Charlotte", query[2].OwnerName);
            CollectionAssert.AreEqual(new[] { "Whiskers" }, query[2].Pets.ToArray());
        }

        /// <summary>
        /// Joins a sequence with the grouping of another sequence using a null comparer on keys
        /// </summary>
        [TestCategory("Unit")]
        [Description("Joins a sequence with the grouping of another sequence using a null comparer on keys")]
        [Priority(1)]
        [TestMethod]
        public void GroupJoinNullComparer()
        {
            var people = new[]
            {
                new { Name = "Hedlund, Magnus" },
                new { Name = "Adams, Terry" },
                new { Name = "Weiss, Charlotte" },
            };
            var magnus = people[0];
            var terry = people[1];
            var charlotte = people[2];
            var pets = new[]
            {
                new { Name = "Barley", Owner = terry },
                new { Name = "Boots", Owner = terry },
                new { Name = "Whiskers", Owner = charlotte },
                new { Name = "Daisy", Owner = magnus },
            };

            var query = people.GroupJoin(
                pets,
                person => person,
                pet => pet.Owner,
                (person, petCollection) =>
                new
                {
                    OwnerName = person.Name,
                    Pets = petCollection.Select(pet => pet.Name)
                },
                null).ToArray();

            Assert.AreEqual("Hedlund, Magnus", query[0].OwnerName);
            CollectionAssert.AreEqual(new[] { "Daisy" }, query[0].Pets.ToArray());
            Assert.AreEqual("Adams, Terry", query[1].OwnerName);
            CollectionAssert.AreEqual(new[] { "Barley", "Boots" }, query[1].Pets.ToArray());
            Assert.AreEqual("Weiss, Charlotte", query[2].OwnerName);
            CollectionAssert.AreEqual(new[] { "Whiskers" }, query[2].Pets.ToArray());
        }
    }
}
