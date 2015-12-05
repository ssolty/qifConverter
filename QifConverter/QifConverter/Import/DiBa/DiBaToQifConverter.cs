using FileHelpers;
using QifApi;
using QifApi.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QifConverter.Import.DiBa
{
    public class DiBaToQifConverter : IQifConverter
    {

        private string filePath;

        public DiBaToQifConverter(string filepath)
        {
            filePath = filepath;
        }

        /// <summary>
        /// reads the given filepath diba-csv and generate a qif file
        /// </summary>
        /// <returns>Convertet DiBa-csv as qif</returns>
        public QifDom GetQif()
        {
            
            QifDom res = new QifDom()
            {
                BankTransactions = this.GetTransactions()    
            };

            return res;

        }

        private List<BasicTransaction> GetTransactions()
        {
            List<BasicTransaction> res = new List<BasicTransaction>();

            foreach(var model in this.ReadDiBaFile())
            { 
                res.Add(this.Map(model));
            }
            return res;
        }

        private BasicTransaction Map(DiBaModel model)
        {
            return new BasicTransaction()
            {
                Amount = model.Amount,
                Date = model.Date,
                Payee = model.Payee,
                Memo = model.Memo
            };
        }

        private List<DiBaModel> ReadDiBaFile()
        {
            var engine = new FileHelperEngine<DiBaModel>();

            int ignoreLines = 8;

            engine.BeforeReadRecord += (eng, e) => {
                if(ignoreLines >= 0)
                {
                    e.SkipThisRecord = true;
                    ignoreLines--;
                    return;
                }
                if (e.RecordLine.StartsWith(" ") ||
                    e.RecordLine.StartsWith("-"))
                    e.SkipThisRecord = true;
            };

            var result = engine.ReadFile(this.filePath);
            
            return result.ToList();
        }
    }
}
