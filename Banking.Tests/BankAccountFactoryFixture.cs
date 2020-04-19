using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public class BankAccountFactoryFixture : BankAccountTest
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        [TestCleanup]
        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
