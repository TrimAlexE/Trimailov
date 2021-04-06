using System;
using System.Collections.Generic;
using System.IO;
using core;

namespace Trimailov
{
    public class MyLog : LogAbstract<MyLog>, ILogInterface
    {
        public static void Log(string result)
        {
            MyLog.Instance().log.Add(result);
        }
        public static List<string> GetLog()
        {
            return MyLog.Instance().log;
        }
        public static void Write()
        {
            MyLog.Instance()._write();
        }
        protected override void _write()
        {
            foreach (string x in log)
            {
                Console.WriteLine(x);
            }
            DateTime date = DateTime.Now;
            string file = $"./Log/{date.ToString("dd.M.yyyy_hh.mm.ss.fff")}.log";
            DirectoryInfo dirInfo = new DirectoryInfo($"./Log/");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            using (FileStream fstream = new FileStream(file, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(String.Join("\n", log));
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
