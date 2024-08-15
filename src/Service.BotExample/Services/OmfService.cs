using System;

namespace Service.BotExample.Services
{
    public class OmgService
    {
        public void Omg()
        {
            Console.WriteLine("Omg!");
        }
    }

    public interface IOmgService
    {
        void Omg();
    }
}