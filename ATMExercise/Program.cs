using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATMExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            var system = new Decoder(receiver);

            while (true)
                Thread.Sleep(1000);
        }
    }
}
