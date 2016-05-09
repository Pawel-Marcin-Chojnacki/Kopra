    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Kopra.Annotations;
    using Kopra1.Model;

namespace Kopra.ViewModel
{
    internal class SearchViewModel : INotifyPropertyChanged
    {

        private InvestorsModel _investors;

        public InvestorsModel Investors
        {
            get { return _investors; }
            set
            {
                _investors = value;
                NotifyPropertyChanged(nameof(Investors));
            }
        }


        //private ObservableCollection<Tuple<int,int , string>> _iloscInwestorow;
        //public ObservableCollection<Tuple<int, int, string>> IloscInwestorow
        //{
        //    get
        //    {
        //        return _iloscInwestorow;
        //    }
        //    set
        //    {
        //        _iloscInwestorow = value;
        //        NotifyPropertyChanged("IloscInwestorow");
        //    }
        //}

        private List<string> _realizacjaList; 
        public List<string> RealizacjaList
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

        private string _realizacja;
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
        private string _status;
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


        private List<string> _kwotaList;

        public List<string> KwotaList
        {
            get { return _kwotaList; }
            set
            {
                _kwotaList = value;
                NotifyPropertyChanged(nameof(KwotaList));
            }
        }

        private Dictionary<int, string> _statusDictionary;

        public Dictionary<int, string> StatusDictionary
        {
            get { return _statusDictionary; }
            set
            {
                _statusDictionary = value;
                NotifyPropertyChanged(nameof(StatusDictionary));
            }

        } 
        private string _titleSearch;
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

        

        public SearchViewModel()
        {
            InicjalizujRealizację();
            InicjalizujStatusyPożyczek();
            InicjalizujOkresyPożyczek();
            InicjalizujKwotyPożyczek();
            InicjalizujOprocentowaniePożyczek();
            Investors = new InvestorsModel();
            //InicjalizujIlośćInwestorów();
        }

        //private void InicjalizujIlośćInwestorów()
        //{
        //    IloscInwestorow = new ObservableCollection<Tuple<int, int, string>>()
        //    {
        //        new Tuple<int, int, string>(0,0,"Brak inwestorów"),
        //        new Tuple<int, int, string>(1,5,"1 - 5 inwestorów"),
        //        new Tuple<int, int, string>(6,10,"6 - 10 inwestorów"),
        //        new Tuple<int, int, string>(11,20,"11 - 20 inwestorów"),
        //        new Tuple<int, int, string>(21,50,"21 - 50 inwestorów"),
        //        new Tuple<int, int, string>(50,999,"Powyżej 50 inwestorów")
        //    };
        //}


        public SearchViewModel(string oprocentowanie)
        {
            Oprocentowanie = oprocentowanie;
            //Inicjalizacja wartości comboboxów.
            InicjalizujStatusyPożyczek();
            InicjalizujOkresyPożyczek();
            InicjalizujKwotyPożyczek();
            InicjalizujOprocentowaniePożyczek();

        }

        private void InicjalizujRealizację()
        {
            RealizacjaList = new List<string>
            {
                "Co najmniej 25%",
                "Co najmniej 50%",
                "Co najmniej 75%"
            };
        }

        private void InicjalizujStatusyPożyczek()
        {
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
        }

        private void InicjalizujOprocentowaniePożyczek()
        {
            OprocentowanieList = new List<string>
            {
                "Dowolny %",
                "Od 1 do 10%",
                "Od 11 do 20%",
                "Od 21 do 25%",
                "Powyżej 25%"
            };
        }

        private void InicjalizujKwotyPożyczek()
        {
           KwotaList = new List<string>
           {
               "Dowolna kwota",
               "Od 500 do 1000 zł",
               "Od 1100 do 2500 zł",
               "Od 2600 do 5000 zł",
               "Od 5100 do 10000 zł",
               "Od 10100 do 25000 zł"
           };
        }

        private void InicjalizujOkresyPożyczek()
        {

            OkresList = new List<string>
            {
                "Dowolny okres",
                "Do pół roku",
                "Do 1 roku",
                "Od 1 do 2 lat",
                "Od 2 do 3 lat"
            };
        }

        private string _okres;

        public string Okres
        {
            get { return _okres;}
            set
            {
                _okres = value;
                NotifyPropertyChanged("Okres");
            }
        }

        private List<string> _okresList;

        public List<string> OkresList
        {
            get { return _okresList; }
            set
            {
                _okresList = value;
                NotifyPropertyChanged(nameof(OkresList));
            }
        }

        private string _kwota;
        public string Kwota
        {
            get { return _kwota;}
            set
            {
                _kwota = value;
                NotifyPropertyChanged(nameof(Kwota));
            }
        }



        private List<string> _oprocentowanieList;

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

        public string Oprocentowanie { get; }

  

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}