using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication2
{
    class Program
    {
        //Execute program to turn off monitor and lock computer instantly.
        //You can create a windows shortcut and point it to this exe, assign a shortcut to one press lockout the computer.
        const int SC_MONITORPOWER = 0xF170;
        const int WM_SYSCOMMAND = 0x0112;
        const int MONITOR_ON = -1;
        const int MONITOR_OFF = 2;
        const int MONITOR_STANBY = 1;

        [DllImport("msvcrt.dll")]
        public static extern int puts(string c);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
        [DllImport("user32.dll")]
        static extern bool LockWorkStation();
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg,
        IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //Or 
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(int hWnd, int msg, int wParam, int lParam);
        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Lockdown();
            ///Console.ReadLine();
        }

        public void Lockdown()
        {
            //SendMessage(ValidHWND, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
            System.IntPtr intTemp = GetConsoleWindow();
            PostMessage(intTemp.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
            LockWorkStation();
        }
    }
}