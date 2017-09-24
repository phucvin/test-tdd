using System;

namespace TestTdd
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Normal way
            {
                NormalData data = new NormalData("here");
                NormalStore store = new NormalStore();
                store.Energy = 5;
                NormalService service = new NormalService();
                NormalUi ui = new NormalUi(data, store, service);
                Console.WriteLine("Let service calculate: 22 + 5");
                ui.Add(22, 5);
            }

            // After TDD way
            {
                SimpleData data = new SimpleData("somewhere");
                SimpleStore store = new SimpleStore();
                store.Energy = 5;
                SimpleService service = new SimpleService();
                SimpleUi ui = new SimpleUi();
                ui.Data = data;
                ui.Store = store;
                ui.Service = service;
                ui.Init();
                Console.WriteLine("Let service calculate: 10 + 9");
                ui.Add(10, 9);
                Console.WriteLine(ui.Message);
            }
        }
    }
}