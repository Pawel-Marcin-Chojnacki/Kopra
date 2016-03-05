using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra.ViewModel
{

    //partial class AddFilterViewModel
    //{

    //    private string _kwota;

    //    public string Kwota
    //    {
    //        get { return _kwota; }
    //        set
    //        {
    //            _kwota = value;
    //            KwotaList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Kwota));
    //        }
    //    }

    //    private ComboBoxFiltr _kwotaList;

    //    public ComboBoxFiltr KwotaList
    //    {
    //        get { return _kwotaList; }
    //        set
    //        {
    //            _kwotaList = value;
    //            NotifyPropertyChanged(nameof(KwotaList));
    //        }
    //    }

    //    private string _okres;

    //    public string Okres
    //    {
    //        get { return _okres; }
    //        set
    //        {
    //            _okres = value;
    //            OkresList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Okres));
    //        }
    //    }

    //    private ComboBoxFiltr _okresList;

    //    public ComboBoxFiltr OkresList
    //    {
    //        get
    //        {
    //            return _okresList;
    //        }
    //        set
    //        {
    //            _okresList = value;
    //            NotifyPropertyChanged(nameof(OkresList));
    //        }
    //    }

    //    private string _oprocentowanie;

    //    public string Oprocentowanie
    //    {
    //        get { return _oprocentowanie; }
    //        set
    //        {
    //            _oprocentowanie = value;
    //            OprocentowanieList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Oprocentowanie));
    //        }
    //    }

    //    private ComboBoxFiltr _oprocentowanieList;

    //    public ComboBoxFiltr OprocentowanieList
    //    {

    //        get { return _oprocentowanieList; }
    //        set
    //        {
    //            _oprocentowanieList = value;
    //            NotifyPropertyChanged(nameof(OprocentowanieList));
    //        }
    //    }

    //    private string _realizacja;

    //    public string Realizacja
    //    {
    //        get { return _realizacja; }
    //        set
    //        {
    //            _realizacja = value;
    //            RatingList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Realizacja));
    //        }
    //    }

    //    private ComboBoxFiltr _realizacjaList;
    //        public ComboBoxFiltr RealizacjaList
    //    {
    //        get { return _realizacjaList; }
    //        set
    //        {
    //            _realizacjaList = value;
    //            NotifyPropertyChanged(nameof(RealizacjaList));
    //        }
    //    }

    //    private string _typAukcji;

    //    public string TypAukcji
    //    {
    //        get { return _typAukcji; }
    //        set
    //        {
    //            _typAukcji = value;
    //            TypAukcjiList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(TypAukcji));
    //        }
    //    }

    //    private ComboBoxFiltr _typAukcjiList;

    //    public ComboBoxFiltr TypAukcjiList
    //    {

    //        get { return _typAukcjiList; }
    //        set
    //        {
    //            _typAukcjiList = value;
    //            NotifyPropertyChanged(nameof(TypAukcjiList));
    //        }
    //    }

    //    private string _rating;

    //    public string Rating
    //    {
    //        get { return _rating; }
    //        set
    //        {
    //            _rating = value;
    //            RatingList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Rating));
    //        }
    //    }

    //    private ComboBoxFiltr _ratingList;

    //    public ComboBoxFiltr RatingList
    //    {

    //        get { return _ratingList; }
    //        set
    //        {
    //            _ratingList = value;
    //            NotifyPropertyChanged(nameof(RatingList));
    //        }
    //    }

    //    private string _województwo;

    //    public string Województwo
    //    {
    //        get { return _województwo; }
    //        set
    //        {
    //            _województwo = value;
    //            WojewództwoList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Województwo));
    //        }
    //    }

    //    private ComboBoxFiltr _województwoList;

    //    public ComboBoxFiltr WojewództwoList
    //    {
    //        get { return _województwoList; }
    //        set
    //        {
    //            _województwoList = value;
    //            NotifyPropertyChanged(nameof(WojewództwoList));
    //        }
    //    }

    //    private string _sumaNajbliższychRat;

    //    public string SumaNajbliższychRat
    //    {
    //        get { return _sumaNajbliższychRat; }
    //        set
    //        {
    //            _sumaNajbliższychRat = value;
    //            SumaNajbliższychRatList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(SumaNajbliższychRat));
    //        }
    //    }

    //    private ComboBoxFiltr _sumaNajbliższychRatList;

    //    public ComboBoxFiltr SumaNajbliższychRatList
    //    {
    //        get { return _sumaNajbliższychRatList; }
    //        set
    //        {
    //            _sumaNajbliższychRatList = value;
    //            NotifyPropertyChanged(nameof(SumaNajbliższychRatList));
    //        }
    //    }

    //    private string _limitRaty;

    //    public string LimitRaty
    //    {
    //        get
    //        {
    //            return _limitRaty;
    //        }
    //        set
    //        {
    //            _limitRaty = value;
    //            LimitRatyList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(LimitRaty));
    //        }
    //    }

    //    private ComboBoxFiltr _limitRatyList;

    //    public ComboBoxFiltr LimitRatyList
    //    {
    //        get
    //        {
    //            return _limitRatyList;
    //        }
    //        set
    //        {
    //            _limitRatyList = value;
    //            NotifyPropertyChanged(nameof(LimitRatyList));
    //        }
    //    }

    //    private string _wiek;

    //    public string Wiek
    //    {
    //        get
    //        {
    //            return _wiek;
    //        }
    //        set
    //        {
    //            _wiek = value;
    //            WiekList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Wiek));
    //        }
    //    }

    //    private ComboBoxFiltr _wiekList;

    //    public ComboBoxFiltr WiekList
    //    {
    //        get
    //        {
    //            return _wiekList;
    //        }
    //        set
    //        {
    //            _wiekList = value;
    //            NotifyPropertyChanged(nameof(WiekList));
    //        }
    //    }

    //    private string _stanCywilny;

    //    public string StanCywilny
    //    {
    //        get
    //        {
    //            return _stanCywilny;
    //        }
    //        set
    //        {
    //            _stanCywilny = value;
    //            StanCywilnyList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(StanCywilny));
    //        }
    //    }

    //    private ComboBoxFiltr _stanCywilnyList;

    //    public ComboBoxFiltr StanCywilnyList
    //    {
    //        get
    //        {
    //            return _stanCywilnyList;
    //        }
    //        set
    //        {
    //            _stanCywilnyList = value;
    //            NotifyPropertyChanged(nameof(StanCywilnyList));
    //        }
    //    }

    //    private string _dochody;

    //    public string Dochody
    //    {
    //        get
    //        {
    //            return _dochody;
    //        }
    //        set
    //        {
    //            _dochody = value;
    //            DochodyList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Dochody));
    //        }
    //    }

    //    private ComboBoxFiltr _dochodyList;

    //    public ComboBoxFiltr DochodyList
    //    {
    //        get
    //        {
    //            return _dochodyList;
    //        }
    //        set
    //        {
    //            _dochodyList = value;
    //            NotifyPropertyChanged(nameof(DochodyList));
    //        }
    //    }

    //    private string _wydatki;

    //    public string Wydatki
    //    {
    //        get
    //        {
    //            return _wydatki;
    //        }
    //        set
    //        {
    //            _wydatki = value;
    //            WydatkiList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Wydatki));
    //        }
    //    }

    //    private ComboBoxFiltr _wydatkiList;

    //    public ComboBoxFiltr WydatkiList
    //    {
    //        get
    //        {
    //            return _wydatkiList;
    //        }
    //        set
    //        {
    //            _wydatkiList = value;
    //            NotifyPropertyChanged(nameof(WydatkiList));
    //        }
    //    }

    //    private string _wiekKonta;

    //    public string WiekKonta
    //    {
    //        get { return _wiekKonta; }
    //        set
    //        {
    //            _wiekKonta = value;
    //            WiekKontaList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(WiekKonta));
    //        }
    //    }

    //    private ComboBoxFiltr _wiekKontaList;

    //    public ComboBoxFiltr WiekKontaList
    //    {

    //        get
    //        {
    //            return _wiekKontaList;
    //        }
    //        set
    //        {
    //            _wiekKontaList = value;
    //            NotifyPropertyChanged(nameof(WiekKonta));
    //        }
    //    }

    //    private string _aukcje;

    //    public string Aukcje
    //    {
    //        get { return _aukcje; }
    //        set
    //        {
    //            _aukcje = value;
    //            AukcjeList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(Aukcje));
    //        }
    //    }

    //    private ComboBoxFiltr _aukcjeList;

    //    public ComboBoxFiltr AukcjeList
    //    {

    //        get
    //        {
    //            return _aukcjeList;
    //        }
    //        set
    //        {
    //            _aukcjeList = value;
    //            NotifyPropertyChanged(nameof(AukcjeList));
    //        }
    //    }

    //    private string _inwestorWKokos;

    //    public bool InwestorWKokos
    //    {
    //        get
    //        {
    //            return _inwestorWKokos == "1";
    //        }
    //        set
    //        {
    //            _inwestorWKokos = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(InwestorWKokos));
    //        }
    //    }

    //    private string _promowane;

    //    public bool Promowane
    //    {
    //        get
    //        {
    //            return _promowane == "1";
    //        }
    //        set
    //        {
    //            _promowane = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(Promowane));
    //        }
    //    }

    //    private string _tylkoWyróżnioneAukcje;

    //    public bool TylkoWyróżnioneAukcje
    //    {
    //        get
    //        {
    //            return _tylkoWyróżnioneAukcje == "1";
    //        }
    //        set
    //        {
    //            _tylkoWyróżnioneAukcje = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(TylkoWyróżnioneAukcje));
    //        }
    //    }

    //    private string _tylkoFirmoweAukcje;

    //    public bool TylkoFirmoweAukcje
    //    {
    //        get
    //        {
    //            return _tylkoFirmoweAukcje == "1";
    //        }
    //        set
    //        {
    //            _tylkoFirmoweAukcje = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(TylkoFirmoweAukcje));
    //        }
    //    }

    //    private string _tylkoAukcjeOsóbFizycznych;

    //    public bool TylkoAukcjeOsóbFizycznych
    //    {
    //        get
    //        {
    //            return _tylkoAukcjeOsóbFizycznych == "1";
    //        }
    //        set
    //        {
    //            _tylkoAukcjeOsóbFizycznych = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(TylkoAukcjeOsóbFizycznych));
    //        }
    //    }

    //    private string _weryfikacjaPracodawcy;

    //    public bool WeryfikacjaPracodawcy
    //    {
    //        get
    //        {
    //            return _weryfikacjaPracodawcy == "1";
    //        }
    //        set
    //        {
    //            _weryfikacjaPracodawcy = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(WeryfikacjaPracodawcy));
    //        }
    //    }

    //    private string _weryfikacjaAdresu;

    //    public bool WeryfikacjAdresu
    //    {
    //        get
    //        {
    //            return _weryfikacjaAdresu == "1";
    //        }
    //        set
    //        {
    //            _weryfikacjaAdresu = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(WeryfikacjAdresu));
    //        }
    //    }

    //    private string _weryfikacjaFinansowa;

    //    public bool WeryfikacjaFinansowa
    //    {
    //        get
    //        {
    //            return _weryfikacjaFinansowa == "1";
    //        }
    //        set
    //        {
    //            _weryfikacjaFinansowa = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(WeryfikacjaFinansowa));
    //        }
    //    }

    //    private string _weryfikacjaRachunków;

    //    public bool WeryfikacjaRachunków
    //    {
    //        get
    //        {
    //            return _weryfikacjaRachunków == "1";
    //        }
    //        set
    //        {
    //            _weryfikacjaRachunków = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(WeryfikacjaRachunków));
    //        }
    //    }

    //    private string _numerGG;

    //    public bool NumerGG
    //    {
    //        get
    //        {
    //            return _numerGG == "1";
    //        }
    //        set
    //        {
    //            _numerGG = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(NumerGG));
    //        }
    //    }

    //    private string _numerSkype;

    //    public bool NumerSkype
    //    {
    //        get
    //        {
    //            return _numerSkype == "1";
    //        }
    //        set
    //        {
    //            _numerSkype = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(NumerSkype));
    //        }
    //    }

    //    private string _profilLinkedIn;

    //    public bool ProfilLinkedIn
    //    {
    //        get { return _profilLinkedIn == "1"; }
    //        set
    //        {
    //            _profilLinkedIn = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(ProfilLinkedIn));
    //        }
    //    }

    //    private string _profilGoldenLine;

    //    public bool ProfilGoldenLine
    //    {
    //        get
    //        {
    //            return _profilGoldenLine == "1";
    //        }
    //        set
    //        {
    //            _profilGoldenLine = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(ProfilGoldenLine));
    //        }
    //    }

    //    private string _profilFacebook;

    //    public bool ProfilFacebook
    //    {
    //        get { return _profilFacebook == "1"; }
    //        set
    //        {
    //            _profilFacebook = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(ProfilFacebook));
    //        }
    //    }

    //    private string _profilNaszaKlasa;

    //    public bool ProfilNaszaKlasa
    //    {
    //        get
    //        {
    //            return _profilNaszaKlasa == "1";
    //        }
    //        set
    //        {
    //            _profilNaszaKlasa = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(ProfilNaszaKlasa));
    //        }
    //    }

    //    private string _stronaWWW;

    //    public bool StronaWWW
    //    {
    //        get
    //        {
    //            return _stronaWWW == "1";
    //        }
    //        set
    //        {
    //            _stronaWWW = value ? "1" : "0";
    //            NotifyPropertyChanged(nameof(StronaWWW));
    //        }
    //    }

    //    private string _pozytywneRekomendacje;

    //    public string PozytywneRekomendacje
    //    {
    //        get
    //        {
    //            return _pozytywneRekomendacje;
    //        }
    //        set
    //        {
    //            _pozytywneRekomendacje = value;
    //            PozytywneRekomendacjeList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(PozytywneRekomendacje));
    //        }
    //    }

    //    private ComboBoxFiltr _pozytywneRekomendacjeList;

    //    public ComboBoxFiltr PozytywneRekomendacjeList
    //    {
    //        get
    //        {
    //            return _pozytywneRekomendacjeList;
    //        }
    //        set
    //        {
    //            _pozytywneRekomendacjeList = value;
    //            NotifyPropertyChanged(nameof(PozytywneRekomendacjeList));
    //        }
    //    }

    //    private string _negatywneRekomendacje;

    //    public string NegatywneRekomendacje
    //    {
    //        get
    //        {
    //            return _negatywneRekomendacje;
    //        }
    //        set
    //        {
    //            _negatywneRekomendacje = value;
    //            PozytywneRekomendacjeList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(NegatywneRekomendacje));
    //        }
    //    }

    //    private ComboBoxFiltr _negatywneRekomendacjeList;

    //    public ComboBoxFiltr NegatywneRekomendacjeList
    //    {
    //        get
    //        {
    //            return _negatywneRekomendacjeList;
    //        }
    //        set
    //        {
    //            _negatywneRekomendacjeList = value;
    //            NotifyPropertyChanged(nameof(NegatywneRekomendacjeList));
    //        }
    //    }

    //    private string _neutralneRekomendacje;

    //    public string NeutralneRekomendacje
    //    {
    //        get
    //        {
    //            return _neutralneRekomendacje;

    //        }
    //        set
    //        {
    //            _neutralneRekomendacje = value;
    //            NeutralneRekomendacjeList.WybranePole = value;
    //            NotifyPropertyChanged(nameof(NeutralneRekomendacje));
    //        }
    //    }

    //    private ComboBoxFiltr _neutralneRekomendacjeList;

    //    public ComboBoxFiltr NeutralneRekomendacjeList
    //    {
    //        get
    //        {
    //            return _neutralneRekomendacjeList;
    //        }
    //        set
    //        {
    //            _neutralneRekomendacjeList = value;
    //            NotifyPropertyChanged(nameof(NeutralneRekomendacjeList));
    //        }
    //    }

    //}
}
