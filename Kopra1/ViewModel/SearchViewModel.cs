using Kopra.Annotations;
using Kopra1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kopra.ViewModel
{
    internal class SearchViewModel : INotifyPropertyChanged
    {
        #region Constructors

        public SearchViewModel()
        {
            InicjalizujRealizację();
            InicjalizujStatusyPożyczek();
            InicjalizujOkresyPożyczek();
            InicjalizujOprocentowaniePożyczek();
            InicjalizujKwotęPożyczek();

            InicjalizujIlośćInwestorów();
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public InvestorsModel Investor
        {
            get { return _investor; }
            set
            {
                _investor = value;
                NotifyPropertyChanged(nameof(Investor));
            }
        }

        public InvestorsModel Investors
        {
            get { return _investors; }
            set
            {
                _investors = value;
                NotifyPropertyChanged(nameof(Investors));
            }
        }

        public string Kwota
        {
            get { return _kwota; }
            set
            {
                _kwota = value;
                NotifyPropertyChanged(nameof(Kwota));
            }
        }

        public List<string> KwotaList
        {
            get { return _kwotaList; }
            set
            {
                _kwotaList = value;
                NotifyPropertyChanged(nameof(KwotaList));
            }
        }

        public KeyValuePair<string, Tuple<int, int>> LoanAmount
        {
            get { return _loanAmount; }
            set
            {
                _loanAmount = value;
                NotifyPropertyChanged(nameof(LoanAmount));
            }
        }

        public List<LoanAmount> LoanAmounts { get; set; }

        private KwotaPożyczkiModel _wybranaKwota;
        public KwotaPożyczkiModel WybranaKwota
        {
            get
            {
                return _wybranaKwota;
            }
            set
            {
                _wybranaKwota = value;
                NotifyPropertyChanged(nameof(WybranaKwota));
            }
        }

        //public KeyValuePair<string, Tuple<int, int>> LoanInterest
        //{
        //    get { return _loanInterest; }
        //    set
        //    {
        //        _loanInterest = value;
        //        NotifyPropertyChanged(nameof(LoanInterest));
        //    }
        //}

        public List<InterestModel> LoanInterests
        {
            get { return _loanInterests; }
            set
            {
                _loanInterests = value;
                NotifyPropertyChanged(nameof(LoanInterests));
            }
        }

        public KeyValuePair<string, Tuple<int, int>> LoanPeriod
        {
            get { return _loanPeriod; }
            set
            {
                _loanPeriod = value;
                NotifyPropertyChanged(nameof(LoanPeriod));
            }
        }

        public LoanPeriodsModel LoanPeriods
        {
            get { return _loanPeriods; }
            set
            {
                _loanPeriods = value;
                NotifyPropertyChanged(nameof(LoanPeriods));
            }
        }

        public string Okres
        {
            get { return _okres; }
            set
            {
                _okres = value;
                NotifyPropertyChanged("Okres");
            }
        }

        public List<string> OkresList
        {
            get { return _okresList; }
            set
            {
                _okresList = value;
                NotifyPropertyChanged(nameof(OkresList));
            }
        }

        public string Oprocentowanie { get; }

        public List<string> OprocentowanieList
        {
            get
            {
                return _oprocentowanieList;
            }
            set
            {
                _oprocentowanieList = value;
                NotifyPropertyChanged(nameof(OprocentowanieList));
            }
        }

        public string Realizacja
        {
            get
            {
                return _realizacja;
            }
            set
            {
                _realizacja = value;
                NotifyPropertyChanged("Realizacja");
            }
        }

        public Dictionary<int, string> RealizacjaList
        {
            get
            {
                return _realizacjaList;
            }
            set
            {
                _realizacjaList = value;
                NotifyPropertyChanged("RealizacjaList");
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyPropertyChanged("Status");
            }
        }

        public Dictionary<int, string> StatusDictionary
        {
            get { return _statusDictionary; }
            set
            {
                _statusDictionary = value;
                NotifyPropertyChanged(nameof(StatusDictionary));
            }
        }

        public string TitleSearch
        {
            get
            {
                return _titleSearch;
            }
            set
            {
                _titleSearch = value;
                NotifyPropertyChanged(nameof(TitleSearch));
            }
        }

        #endregion Properties

        #region Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods

        #region Fields

        private InvestorsModel _investor;
        private InvestorsModel _investors;
        private string _kwota;
        private List<string> _kwotaList;
        private KeyValuePair<string, Tuple<int, int>> _loanAmount;
        private LoanAmountModel _loanAmounts;
        private KeyValuePair<string, Tuple<int, int>> _loanInterest;
        private List<InterestModel> _loanInterests;
        private KeyValuePair<string, Tuple<int, int>> _loanPeriod;
        private LoanPeriodsModel _loanPeriods;
        private string _okres;
        private List<string> _okresList;
        private List<string> _oprocentowanieList;
        private string _realizacja;
        private Dictionary<int, string> _realizacjaList;
        private string _status;
        private Dictionary<int, string> _statusDictionary;
        private string _titleSearch;

        #endregion Fields

        private void InicjalizujIlośćInwestorów() => Investors = new InvestorsModel();

        private void InicjalizujKwotęPożyczek()
        {
            LoanAmounts = new LoanAmountModel();
        }

        private void InicjalizujOkresyPożyczek()
        {
            LoanPeriods = new LoanPeriodsModel();
        }

        private void InicjalizujOprocentowaniePożyczek()
        {
            //LoanInterests = new InterestModel();
        }

        private void InicjalizujRealizację()
        {
            RealizacjaList = new Dictionary<int, string>
            {
                {25, "Co najmniej 25%"},
                {50, "Co najmniej 50%"},
                {75, "Co najmniej 75%"}
            };
        }

        
        public List<Status> StatusyPozyczek { get; set; }

        private void InicjalizujStatusyPożyczek()
        {
            StatusyPozyczek = new List<Status>()
            {
                new Status() {Opis = "Nowa pożyczka", StatusLiczbowy = 100},
                new Status() {Opis = "W trakcie tworzenia", StatusLiczbowy = 110},
                new Status() {Opis = "Trwa spłata", StatusLiczbowy = 500},
                new Status() {Opis = "Uzbierano poniżej 50% inwestycji", StatusLiczbowy = 1100},
                new Status() {Opis = "Uzbierano 0% inwestycji", StatusLiczbowy = 1200},
                new Status() {Opis = "Spłacona w całości", StatusLiczbowy = 1300},
                new Status() {Opis = "Usunięta przez obsługę", StatusLiczbowy = 1400},
                new Status() {Opis = "Usunięta przez użytkownika", StatusLiczbowy = 1500}
            };
            StatusDictionary = new Dictionary<int, string>()
            {
                {100, "Nowa pożyczka"},
                {110, "W trakcie tworzenia"},
                {500, "Trwa spłata"},
                {1100, "Uzbierano poniżej 50% inwestycji"},
                {1200, "Uzbierano 0% inwestycji"},
                {1300, "Spłacona w całości"},
                {1400, "Usunięta przez obsługę"},
                {1500, "Usunięta przez użytkownika"}
            };

            statusNieDictionary = new List<costam>();
            var costam1 = new costam();
            costam1.napis = "Nowa pożyczka";
            costam1.wartosc = 100;
            statusNieDictionary.Add(costam1);
        }

        public List<costam> statusNieDictionary
        {
            get;
            set;
        }
    }

    public class costam
    {
        public int wartosc { get; set; }
        public string napis { get; set; }
    }
}