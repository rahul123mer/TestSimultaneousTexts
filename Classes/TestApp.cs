using System;
using System.IO;
using System.Threading.Tasks;

namespace TestSimultaneousTexts.Classes
{
    public class TestApp
    {
        public static int instance_counter = 0;
        
        public static async Task ReceiveInboundText()
        {
            // Write to a text file
            string filePath = @"C:\Users\SLIM5\Desktop\ReceiveInboundTextLog.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{DateTime.Now} ReceiveInboundText triggered, instance_counter = {instance_counter}");
                instance_counter++;
                writer.WriteLine($"{DateTime.Now} Added 1 to instance_counter, it now equals {instance_counter}");
            }

            // Simulate delay
            await Task.Delay(30000);
        }
    }
}
