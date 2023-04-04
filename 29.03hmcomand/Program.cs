using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._03hmcomand
{
    interface Command
    {
        object Execut();
        void Undo();
    }
    class Tv_Porgram : Command
    {
        public string tv;
        public Tv_Porgram(string tv)
        {
            this.tv = tv;
        }
        public object Execut()
        {
            return "TV";
        }
        public void Undo()
        {
            Console.WriteLine($"TV: {tv}");
        }
    }
    class Wave_Command : Command
    {
        public string microwave { set; get; }
        public string time { set; get; }
        public Wave_Command(string microwave, string time)
        {
            this.microwave = microwave;
            this.time = time;
        }
        public object Execut()
        {
            return "Tv program";
        }
        public void Undo()
        {
            Console.WriteLine($"Wave: {microwave}");
            Console.WriteLine($"Cold_down: {time}");
        }
    }
    class Controller
    {
        Command command;
        public void SetOnController(Command command)
        {
            this.command = command;
        }
        public void SetOffController(Command command)
        {
            this.command = command;
        }
        public void PressButton()
        {
            var process = command.Execut();
        }
    }
    class Microwave
    {
        public void StartCooking()
        {
            Console.WriteLine("Wave of dace");
        }
        public void StopCooking()
        {
            Console.WriteLine("Wave stope");
        }
    }
    class TV_prog
    {
        public void On()
        {
            Console.WriteLine("Microwave is turning on");
        }
        public void Off()
        {
            Console.WriteLine("Microwave is turning off");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.SetOnController(new Wave_Command("wave", "60 sec"));
            Microwave microwave = new Microwave();
            controller.SetOffController(new Tv_Porgram("tv"));
        }
    }
}