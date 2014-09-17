namespace ATM.Tests
{
    using ATM.DataAccess;
    using ATM.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ATMTest
    {
        [TestMethod]
        public void TestWithdrawCashInsufficient()
        {
            var dataManager = new DataManager(new ATMEntities());

            dataManager.InsertCardAccount("1113335559", "9871", 200.0M);

            var withdrawResult = dataManager.WithdrawMoney("1113335557", "9871", 200.0M);

            Assert.AreEqual(ATMOperationResult.CashInsufficient, withdrawResult);
        }
    }
}