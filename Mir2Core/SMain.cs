using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Server;
using Server.MirEnvir;

namespace Mir2Core
{
    public class SMain
    {
        public static readonly Envir Envir = new Envir(), EditEnvir = new Envir();
        private static readonly ConcurrentQueue<string> MessageLog = new ConcurrentQueue<string>();
        private static readonly ConcurrentQueue<string> DebugLog = new ConcurrentQueue<string>();
        private static readonly ConcurrentQueue<string> ChatLog = new ConcurrentQueue<string>();

        public static void Enqueue(Exception ex)
        {
            if (MessageLog.Count < 100)
                MessageLog.Enqueue(String.Format("[{0}]: {1} - {2}" + Environment.NewLine, DateTime.Now, ex.TargetSite, ex));
            File.AppendAllText(Settings.LogPath + "Log (" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ").txt",
                String.Format("[{0}]: {1} - {2}" + Environment.NewLine, DateTime.Now, ex.TargetSite, ex));
            Console.Write("[EXCEPTION][{0}]: {1} - {2}" + Environment.NewLine, DateTime.Now, ex.TargetSite, ex);
        }

        public static void EnqueueDebugging(string msg)
        {
            if (DebugLog.Count < 100)
                DebugLog.Enqueue(String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            File.AppendAllText(Settings.LogPath + "DebugLog (" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ").txt",
                String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            Console.Write("[DEBUG][{0}]: {1}" + Environment.NewLine, DateTime.Now, msg);
        }
        public static void EnqueueChat(string msg)
        {
            if (ChatLog.Count < 100)
                ChatLog.Enqueue(String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            File.AppendAllText(Settings.LogPath + "ChatLog (" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ").txt",
                String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));

            Console.Write("[CHAT][{0}]: {1}" + Environment.NewLine, DateTime.Now, msg);
        }

        public static void Enqueue(string msg)
        {
            if (MessageLog.Count < 100)
                MessageLog.Enqueue(String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            File.AppendAllText(Settings.LogPath + "Log (" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ").txt",
                String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            Console.Write("[LOG][{0}]: {1}" + Environment.NewLine, DateTime.Now, msg);
        }

        public void Start()
        {
            //EditEnvir.LoadDB();
            Envir.Start();
        }
    }
}
