using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Core.Interfaces
{
    interface ITrade
    {
        double Value { get; } // dollars
        string ClientSector { get; } // sector "Public" or "Private"
        DateTime NextPaymentDate { get; } // next payment date
    }
}
