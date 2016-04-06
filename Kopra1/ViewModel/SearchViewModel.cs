    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Kopra.Annotations;

namespace Kopra.ViewModel
{
    internal class SearchViewModel:INotifyPropertyChanged
    {
        public SearchViewModel()
        {
        }

        public SearchViewModel(string oprocentowanie)
        {
            Oprocentowanie = oprocentowanie;
            //Inicjalizacja wartości comboboxów.
            InicjalizujOkresyPożyczek();
            InicjalizujKwotyPożyczek();
            InicjalizujOprocentowaniePożyczek();

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
                NotifyPropertyChanged(nameof(Okres));
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