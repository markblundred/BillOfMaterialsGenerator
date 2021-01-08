using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BillOfMaterials
{
    public static class DebugWriter
    {
        public static void WriteInfo(string info)
        {
            var debugWriter = GetDebugFile();
            debugWriter.WriteLine($"[INFO] { DateTime.Now.ToString("HH:mm:ss") } - { info }");

            debugWriter.Flush();
            debugWriter.Close();
        }
        public static void WriteException(Exception exception)
        {
            var debugWriter = GetDebugFile();
            debugWriter.WriteLine($"[ERROR] { DateTime.Now.ToString("HH:mm:ss") } - { exception.Message }");
            debugWriter.WriteLine(exception.StackTrace);

            debugWriter.Flush();
            debugWriter.Close();
        }

        private static StreamWriter GetDebugFile()
        {
            var filePath = $"./Logs/{ DateTime.Today.ToString("yyyy-MM-dd") }.txt";

            if (!Directory.Exists("./Logs"))
            {
                Directory.CreateDirectory("./Logs");
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return new StreamWriter(filePath, true);
        }
    }
}
