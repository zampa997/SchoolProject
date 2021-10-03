using ef_scaffold;
using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Service s = new Service();
            UserInterface ui = new UserInterface(s);
            ui.Start();
        }
    }
}
