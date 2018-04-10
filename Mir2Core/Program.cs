using System;
using System.IO;
using Server;

namespace Mir2Core
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("System Start...");
                Packet.IsServer = true;
                Settings.Load();
                var smain = new SMain();
                smain.Start();
                Settings.Save();
                while (true)
                {
                    Console.ReadKey();
                }

            }
            catch (Exception ex)
            {
                File.AppendAllText(Settings.LogPath + "Error Log (" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ").txt",
                    String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, ex.ToString()));
                Console.WriteLine("[EXCEPTION]");
                Console.WriteLine(ex);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            
        }
    }
}
