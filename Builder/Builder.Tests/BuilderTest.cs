using NUnit.Framework;

namespace Builder.Tests
{
    [TestFixture]
    public class BuilderTest
    {
        [Test]
        public void CreateTest()
        {
            var builder = new BoxBuilder()
                .SetHeight(5)
                .SetLenght(4)
                .SetWith(6);

            var box1 = builder.Create();
            var box2 = builder.Create();
            Assert.AreEqual(box1, box2);

            var box3 = builder.SetWith(1).Create();
            Assert.AreNotEqual(box1, box3);
        }
    }
}