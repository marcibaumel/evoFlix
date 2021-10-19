using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MoqDemo_uTest
{
    public interface IFoo
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        bool DoSomething(string value);
        bool DoSomething(int number, string value);
        Task<bool> DoSomethingAsync();
        string DoSomethingStringy(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int value);
    }

    public class Bar
    {
        public virtual Baz Baz { get; set; }
        public virtual bool Submit() { return false; }
    }

    public class Baz
    {
        public virtual string Name { get; set; }
    }

    public class CustomObjcet
    {
        public float Forward => 10;
    }

    [TestFixture]
    public class sample
    {

        [SetUp]
        public void TestCaseSetup()
        {
            FooMock = new Mock<IFoo>();
        }


        [TestCase(10)]
        public void Test1(int num)
        {
            var mock = Mock.Of<CustomObjcet>();
            Assert.AreEqual(num, mock.Forward);
        }

        [Test]
        public void Test2()
        {

            FooMock.Setup(x => x.DoSomething("hello")).Returns(true);
        }

        [Test]
        public void Test3()
        {

            var outString = "ack";
            FooMock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

        }

        [Test]
        public void Test4()
        {
            var instance = new Bar();

            FooMock.Setup(foo => foo.Submit(ref instance)).Returns(true);
        }

        private Mock<IFoo> FooMock;
    }

}
