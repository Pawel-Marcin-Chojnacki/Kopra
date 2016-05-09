using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kopra1.Annotations;

namespace Kopra1.Model
{
    class InvestorsModel : INotifyPropertyChanged
    {
        public InvestorsModel()
        {
            Investors = new Dictionary<string, Tuple<int, int>>();
            InvestorsRange = new List<Tuple<int, int>>
            {
                {new Tuple<int, int>(0, 0)},
                {new Tuple<int, int>(1, 5)},
                {new Tuple<int, int>(6, 10)},
                {new Tuple<int, int>(11, 20)},
                {new Tuple<int, int>(21, 50)},
                {new Tuple<int, int>(50, 999)}
            };
            InvestorsAmount = new List<string>
            {
                "Brak inwestorów",
                "1 - 5 inwestorów",
                "6 - 10 inwestorów",
                "11 - 20 inwestorów",
                "21 - 50 inwestorów",
                "Powyżej 50 inwestorów"
            };

            for (int i = 0; i < InvestorsAmount.Count; i++)
            {
                Investors.Add(InvestorsAmount[i],InvestorsRange[i]);
            }

        }

        private Dictionary<string, Tuple<int, int>> _investors;
        public Dictionary<string, Tuple<int, int>> Investors
        {
            get { return _investors; }
            set
            {
                _investors = value;
                NotifyPropertyChanged(nameof(Investors));
            }
        }

        private List<string> _investorsAmount;
        public List<string> InvestorsAmount
        {
            get { return _investorsAmount; }
            set
            {
                _investorsAmount = value;
                NotifyPropertyChanged(nameof(InvestorsAmount));
            }
        }

        private List<Tuple<int, int>> _investorsRange;

        public List<Tuple<int, int>> InvestorsRange
        {
            get { return _investorsRange; }
            set
            {
                _investorsRange = value;
                NotifyPropertyChanged(nameof(InvestorsRange));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
