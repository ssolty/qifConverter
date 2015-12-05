using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QifConverter.Import.DiBa
{
    using FileHelpers;
    using FileHelper;

    /// <summary>
    /// CSV Model for german bank DiBa
    /// </summary>
    [DelimitedRecord(";")]
    [IgnoreEmptyLines]
    public class DiBaModel
    {
        [FieldQuoted]
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        public DateTime bookingDate;

        /// <summary>
        /// value dat
        /// </summary>
        [FieldQuoted]
        [FieldConverter(ConverterKind.Date, "dd.MM.yyyy")]
        public DateTime Date;
        
        [FieldQuoted]
        public string Payee;

        [FieldQuoted]
        public string BookingText;
        
        [FieldQuoted]
        public string Memo;

        /// <summary>
        /// Transaction Amount
        /// </summary>
        [FieldQuoted]
        [FieldConverter(typeof(GermanDecimalConverter))]
        public decimal Amount;

        [FieldQuoted]
        public string AmountCurrency;

        /// <summary>
        /// Account balance
        /// </summary>
        [FieldQuoted]
        [FieldConverter(typeof(GermanDecimalConverter))]
        public decimal Saldo;

        [FieldQuoted]
        public string SaldoCurrency;

    }
}
