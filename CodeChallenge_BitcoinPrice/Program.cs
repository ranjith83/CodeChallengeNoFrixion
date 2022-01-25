using CodeChallenge_BitcoinPrice.Business;
using CodeChallenge_BitcoinPrice.Model;
using System;
using System.Threading.Tasks;

namespace CodeChallenge_BitcoinPrice
{
    class Program
    {
        static void Main(string[] args)
        {

            var bitcoinPrice = GetBitcoinPrice(Currency.EUR).GetAwaiter().GetResult();
            Console.WriteLine("Today BTC Price in EUR {0}", bitcoinPrice);
            Console.ReadLine();
        }

        private static async Task<string> GetBitcoinPrice(Currency currency)
        {
            ReadPriceData readPriceData = new ReadPriceData();
            return await readPriceData.GetPrice(currency);
        }
    }
}
