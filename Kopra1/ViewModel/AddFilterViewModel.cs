using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Kopra.Annotations;

namespace Kopra.ViewModel
{
    partial class AddFilterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public void DodajFiltr(string filtr)
        //{
        //}

        //private string _filtr;
        //public string Filtr { get; set; }

        private string _tytułAukcji;
        public string TytułAukcji
        {
            get { return _tytułAukcji; }
            set
            {
                _tytułAukcji = value;
                NotifyPropertyChanged(nameof(TytułAukcji));
            }
        }

        public void WyczyśćFiltr()
        {
            //Kwota = Okres = Oprocentowanie = Aukcje = Dochody = LimitRaty = NegatywneRekomendacje = NeutralneRekomendacje = PozytywneRekomendacje = Rating = Realizacja = StanCywilny = SumaNajbliższychRat = TypAukcji = Wiek = WiekKonta = Województwo = Wydatki = null;
            //StronaWWW = InwestorWKokos = NumerGG = NumerSkype = ProfilFacebook = ProfilGoldenLine = ProfilLinkedIn = ProfilNaszaKlasa = Promowane = TylkoAukcjeOsóbFizycznych =TylkoFirmoweAukcje = TylkoWyróżnioneAukcje = WeryfikacjAdresu = WeryfikacjaFinansowa = WeryfikacjaPracodawcy = WeryfikacjaRachunków = false;

        }
    }
}
