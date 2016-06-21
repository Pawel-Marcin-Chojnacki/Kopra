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

            InicjalizujKwotęPożyczek();
            InicjalizujRealizację();
            InicjalizujStatusyPożyczek();
            InicjalizujOkresyPożyczek();
            InicjalizujOprocentowaniePożyczek();
            InicjalizujIlośćInwestorów();
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties
        public List<Status> StatusyPozyczek { get; set; }
        public Investor Investor
        {
            get { return _investor; }
            set
            {
                _investor = value;
                NotifyPropertyChanged(nameof(Investor));
            }
        }

        public List<Investor> Investors
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

        public LoanAmount LoanAmount
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

        public Interest LoanInterest { get; set; }

        public List<Interest> LoanInterests
        {
            get { return _loanInterests; }
            set
            {
                _loanInterests = value;
                NotifyPropertyChanged(nameof(LoanInterests));
            }
        }

        public LoanPeriod LoanPeriod
        {
            get { return _loanPeriod; }
            set
            {
                _loanPeriod = value;
                NotifyPropertyChanged(nameof(LoanPeriod));
            }
        }

        public List<LoanPeriod> LoanPeriods { get; set; }

        public Completion Completion
        {
            get
            {
                return _completion;
            }
            set
            {
                _completion = value;
                NotifyPropertyChanged("Completion");
            }
        }

        public List<Completion> Completions
        {
            get
            {
                return _completions;
            }
            set
            {
                _completions = value;
                NotifyPropertyChanged("Completions");
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

        private Investor _investor;
        private List<Investor> _investors;
        private string _kwota;
        private List<string> _kwotaList;
        private LoanAmount _loanAmount;
        //private LoanAmount _loanAmounts;
        private Interest _loanInterest;
        private List<Interest> _loanInterests;
        private LoanPeriod _loanPeriod;
        private string _okres;
        private List<string> _okresList;
        private List<string> _oprocentowanieList;
        private Completion _completion;
        private List<Completion> _completions;
        private string _status;
        private Dictionary<int, string> _statusDictionary;
        private string _titleSearch;

        #endregion Fields

        private void InicjalizujIlośćInwestorów()
        {
            Investors = new List<Investor>()
            {
                new Investor() {Description = "Brak inwestorów", StartRange = 0, EndRange = 0},
                new Investor() {Description = "1 - 5 inwestorów", StartRange = 1, EndRange = 5},
                new Investor() {Description = "6 - 10 inwestorów", StartRange = 6, EndRange = 10},
                new Investor() {Description = "11 - 20 inwestorów", StartRange = 11, EndRange = 20},
                new Investor() {Description = "21 - 50 inwestorów", StartRange = 21, EndRange = 50},
                new Investor() {Description = "Powyżej 50 inwestorów", StartRange = 50, EndRange = 999},
            };

        } 

        private void InicjalizujKwotęPożyczek()
        {
            LoanAmounts = new List<LoanAmount>()
            {
                new LoanAmount() {StartRange = 0, EndRange = int.MaxValue, RangeDescription = "Dowolna kwota"},
                new LoanAmount() {StartRange = 500, EndRange = 1000, RangeDescription = "Od 500 do 1000 zł"},
                new LoanAmount() {StartRange = 1100, EndRange = 2500, RangeDescription = "Od 1100 do 2500 zł"},
                new LoanAmount() {StartRange = 2600, EndRange = 5000, RangeDescription = "Od 2600 do 5000 zł"},
                new LoanAmount() {StartRange = 5100, EndRange = 10000, RangeDescription = "Od 5100 do 10000 zł"},
                new LoanAmount() {StartRange = 10100, EndRange = 25000, RangeDescription = "Od 10100 do 25000 zł"}
            };
        }

        private void InicjalizujOkresyPożyczek()
        {
            LoanPeriods = new List<LoanPeriod>()
            {
                new LoanPeriod() {Description = "Dowolny okres",StartRange = 0, EndRange = int.MaxValue},
                new LoanPeriod() {Description = "Do pół roku",StartRange = 1, EndRange = 6},
                new LoanPeriod() {Description = "Do 1 roku",StartRange = 6, EndRange = 12},
                new LoanPeriod() {Description = "Od 1 do 2 lat",StartRange = 12, EndRange = 24},
                new LoanPeriod() {Description = "Od 2 do 3 lat",StartRange = 24, EndRange = 36},

            };
        }

        private void InicjalizujOprocentowaniePożyczek()
        {
            LoanInterests = new List<Interest>()
            {
                new Interest() {Description = "Dowolny %", StartRange = 0, EndRange = int.MaxValue},
                new Interest() {Description = "Od 1 do 10%", StartRange = 1, EndRange = 10},
                new Interest() {Description = "Od 11 do 20%", StartRange = 11, EndRange = 20},
                new Interest() {Description = "Od 21 do 25%", StartRange = 21, EndRange = 25},
                new Interest() {Description = "Powyżej 25%", StartRange = 25, EndRange = int.MaxValue}
            };
        }

        private void InicjalizujRealizację()
        {
            Completions = new List<Completion>()
            {
                new Completion() {Description = "Co najmniej 25%", Percentage = 25},
                new Completion() {Description = "Co najmniej 50%", Percentage = 50},
                new Completion() {Description = "Co najmniej 75%", Percentage = 75}
            };
        }

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
           
        }

    }
}