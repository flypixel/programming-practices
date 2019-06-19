using NUnit.Framework;

namespace Builder.Tests
{
    [TestFixture]
    public class BuilderTest
    {
        [Test]
        public void CreateTest()
        {
            var builder = new ObjectBuilder();
            builder.Create("First object");
            Assert.Pass();
        }
    }
}