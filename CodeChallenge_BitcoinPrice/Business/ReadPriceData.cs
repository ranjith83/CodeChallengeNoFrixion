using CodeChallenge_BitcoinPrice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_BitcoinPrice.Business
{
   
    public class ReadPriceData
    {
        //This to be in configuration
        private readonly string APIURL = "https://api.coindesk.com/v1/bpi/currentprice.json";

        public async Task<string> GetPrice(Currency currency)
        {
            var currentPrice = await ReadClientData();
            if (currentPrice != null)
            {
                switch (currency)
                {
                    case Currency.EUR:
                        return currentPrice.bpi.EUR.rate;
                    case Currency.GBP:
                        return currentPrice.bpi.GBP.rate;
                    case Currency.USD:
                        return currentPrice.bpi.USD.rate;

                    default:
                        return String.Empty;
                }
            }
            return String.Empty;
        }

        private async Task<CoinDesk> ReadClientData()
        {
            CoinDesk coinDesk = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(APIURL))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        coinDesk = JsonConvert.DeserializeObject<CoinDesk>(apiResponse);
                    }
                }
            }
            catch(Exception ex)
            {
                //log the exception here
            }
            return coinDesk;
        }
    }
}
