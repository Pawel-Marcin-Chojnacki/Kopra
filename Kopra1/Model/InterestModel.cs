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
    internal sealed class InterestModel : INotifyPropertyChanged
    {
        public InterestModel()
        {
            ValueRanges = new List<string>
            {
                "Dowolny %",
                "Od 1 do 10%",
                "Od 11 do 20%",
                "Od 21 do 25%",
                "Powyżej 25%"
            };
            InterestRanges = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, int.MaxValue),
                new Tuple<int, int>(1, 10),
                new Tuple<int, int>(11, 20),
                new Tuple<int, int>(21, 25),
                new Tuple<int, int>(25, int.MaxValue)
            };
            Interest = new Dictionary<string, Tuple<int, int>>();
            for (int i = 0; i < InterestRanges.Count; i++)
            {
                Interest.Add(ValueRanges[i], InterestRanges[i]);
            }
        }

        public Dictionary<string, Tuple<int, int>> Interest { get; set; }
        private List<Tuple<int, int>> InterestRanges { get; set; }
        public List<string> ValueRanges { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
