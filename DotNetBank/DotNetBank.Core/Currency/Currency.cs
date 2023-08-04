﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Core.Currency
{
    public class Currency
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Symbol { get; set; } = "";
        public string Code { get; set; } = "";
        public bool IsActive { get; set; }
        public long CreatedAt { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        public List<CurrencyExchangeRate> ExchangeRates { get; set; } = new List<CurrencyExchangeRate>();
    }

    public class CurrencyExchangeRate
    {
        public string Code { get; set; } = "";
        public int Value { get; set; } = 0;
    }
}