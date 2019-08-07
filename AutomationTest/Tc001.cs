using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using Assert = NUnit.Framework.Assert;

namespace AutomationTest
{
    public class Tc001
    {
        public void TestMethod()
        {
      
            var num1 = Helper.GetInstance().MainCalc.Get<Button>(SearchCriteria.ByText("5"));
            num1.Click();
            var op = Helper.GetInstance().MainCalc.Get<Button>(SearchCriteria.ByText("+"));
            op.Click();
            var num2 = Helper.GetInstance().MainCalc.Get<Button>(SearchCriteria.ByText("6"));
            num2.Click();
            var equals = Helper.GetInstance().MainCalc.Get<Button>(SearchCriteria.ByText("="));
            equals.Click();

            Thread.Sleep(3000);

            var result = Helper.GetInstance().MainCalc.Get<Label>(SearchCriteria.ByAutomationId("150"));
            Assert.AreEqual(result.Text, "11");
        }
    }
}
