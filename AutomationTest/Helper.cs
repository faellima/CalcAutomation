using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace AutomationTest
{
    public class Helper
    {
        private static Helper _helper;
        private Dictionary<string, bool> _tests;
        private bool _isOpen = true;

        public static Helper GetInstance()
        {
            if (_helper == null)
                _helper = new Helper();

            return _helper;
        }

        public Helper()
        {
            _tests = new Dictionary<string, bool>();
            OpenApplication();
        }

        //variables
        private Application _applicationCalc;
        public Window MainCalc;

        //paths
        //public static string PATH_APP => @"C:\Program Files\LG Led Light\LG.LedLight.exe";
        public static string PATH_APP => @"C:\Users\rafael\Downloads\calc.exe";

        //Open LedLight
        public void OpenApplication()
        {
            EndTask("calc");
            _applicationCalc = Application.Launch(PATH_APP);
            MainCalc = _applicationCalc.GetWindow("Calculator");
            MainCalc.WaitWhileBusy();
        }

        //Close LedLight
        public void CloseApplication(object test)
        {
            try
            {
                Thread.Sleep(1000);

                if (_tests != null && _tests.ContainsKey(test.ToString()))
                {
                    _tests.Remove(test.ToString());
                    _tests.Add(test.ToString(), true);
                }

                if (!_tests.Values.Any(c => c == false))
                    _applicationCalc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void AddTest(object test)
        {
            try
            {
                if (!_tests.ContainsKey(test.ToString()))
                    _tests.Add(test.ToString(), false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void EndTask(string taskname)
        {
            string processName = taskname;
            string fixstring = taskname.Replace(".exe", "");

            if (taskname.Contains(".exe"))
            {
                foreach (Process process in Process.GetProcessesByName(fixstring))
                {
                    process.Kill();
                }
            }
            else if (!taskname.Contains(".exe"))
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
        }
    }
}
