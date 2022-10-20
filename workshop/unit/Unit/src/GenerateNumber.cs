using System;
namespace src
{
    public class GenerateNumber
    {
        private Random _random;

        public GenerateNumber(Random _random)
        {
            this._random = _random;
        }

        public string getResult()
        {
            int number = _random.Next(10);
            return "No" + number;
        }

    }
}

