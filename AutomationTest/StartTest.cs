using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    [TestClass]
    public class StartTest
    {

        private Tc001 tc001;


        public StartTest()
        {
            try
            {
                this.tc001 = new Tc001();
                Helper.GetInstance().AddTest(tc001);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //call tests Tc001
        [TestMethod]
        public void RunTestTc001()
        {
            try
            {
                tc001.TestMethod();
                //close LedLight
                Helper.GetInstance().CloseApplication(tc001);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
