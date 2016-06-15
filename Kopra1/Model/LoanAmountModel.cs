using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kopra1.Annotations;

namespace Kopra1.Model
{
    internal sealed class LoanAmountModel : INotifyPropertyChanged
    {
        public LoanAmountModel()
        {
            ValueAmount = new List<string>
            {
                "Dowolna kwota",
                "Od 500 do 1000 zł",
                "Od 1100 do 2500 zł",
                "Od 2600 do 5000 zł",
                "Od 5100 do 10000 zł",
                "Od 10100 do 25000 zł"
            };

            ValueRanges = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, int.MaxValue),
                new Tuple<int, int>(500, 1000),
                new Tuple<int, int>(1100, 2500),
                new Tuple<int, int>(2600, 5000),
                new Tuple<int, int>(5100, 10000),
                new Tuple<int, int>(10100, 25000),
            };

            LoanAmount = new Dictionary<string, Tuple<int, int>>();
            for (int i = 0; i < ValueRanges.Count; i++)
            {
                LoanAmount.Add(ValueAmount[i],ValueRanges[i]);
            }
        }


        private Dictionary<string, Tuple<int, int>> _loanAmount;
        public Dictionary<string, Tuple<int, int>> LoanAmount
        {
            get { return _loanAmount; }
            set
            {
                _loanAmount = value;
                NotifyPropertyChanged(nameof(LoanAmount));
            }
        }

        private List<Tuple<int,int>> ValueRanges { get; set; }
        private List<string> ValueAmount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
