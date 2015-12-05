using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QifConverter.Import.FileHelper
{
    class GermanDecimalConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            from = from.Replace(".", "");
            from = from.Replace(",", "");

            return Convert.ToDecimal(Decimal.Parse(from) / 100);
        }

        public override string FieldToString(object fieldValue)
        {
            return ((decimal)fieldValue).ToString("#.##").Replace(".", ",");
        }
        
    }
}
