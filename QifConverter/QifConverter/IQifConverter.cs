using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QifConverter
{
    interface IQifConverter
    {
        /// <summary>
        /// Qif Getter
        /// </summary>
        /// <returns>QifDom</returns>
        QifApi.QifDom GetQif();
    }
}
