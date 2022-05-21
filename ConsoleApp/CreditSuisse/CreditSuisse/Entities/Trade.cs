using CreditSuisse.Core.Interfaces;
using System;

namespace CreditSuisse.Entities
{
    public class Trade : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }
    }
}
