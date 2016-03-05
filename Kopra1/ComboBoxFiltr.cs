using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra
{
    public class ComboBoxFiltr
    {
        public int IdCB { get; set; }
        public string TytułCB { get; set; }
        public List<Tuple<int,string,string>> PolaCB { get; set; }
        public string WybranePole { get; set; }
    }
}
