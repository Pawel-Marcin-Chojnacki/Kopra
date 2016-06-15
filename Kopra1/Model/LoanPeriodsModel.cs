using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kopra1.Annotations;

namespace Kopra1.Model
{
    internal sealed class LoanPeriodsModel : INotifyPropertyChanged
    {
        public LoanPeriodsModel()
        {
            ValueRanges = new List<string>()
            {
                "Dowolny okres",
                "Do pół roku",
                "Do 1 roku",
                "Od 1 do 2 lat",
                "Od 2 do 3 lat"
            };
            PeriodRanges = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, int.MaxValue),
                new Tuple<int, int>(1, 6),
                new Tuple<int, int>(6, 12),
                new Tuple<int, int>(12, 24),
                new Tuple<int, int>(24, 36)
            };
            LoanPeriods = new Dictionary<string, Tuple<int, int>>();
            for (int i = 0; i < PeriodRanges.Count; i++)
            {
                LoanPeriods.Add(ValueRanges[i], PeriodRanges[i]);
            }
        }

        public Dictionary<string, Tuple<int,int>> LoanPeriods { get; set; }
        private List<Tuple<int,int>> PeriodRanges { get; set; }
        private List<string> ValueRanges { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
