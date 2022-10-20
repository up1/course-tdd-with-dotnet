using System;
namespace src
{
    public class GenerateNumber
    {
        public string getResult()
        {
            Random random = new Random();
            int number = random.Next(10);
            return "No" + number;
        }

    }
}

