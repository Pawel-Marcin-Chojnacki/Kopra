using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra.ViewModel
{
    partial class AddFilterViewModel
    {
    //    public AddFilterViewModel()
    //    {
    //        InicjalizujKwoty();
    //        InicjalizyujOkresy();
    //        InicjalizujOprocentowania();
    //        InicjalizujRealizacje();
    //        InicjalizujTypyAukcji();
    //        InicjalizujRatingi();
    //        InicjalizujWojewództwa();
    //        InicjalizujSumyRatNaNajbliższyMiesiąc();
    //        InicjalizujLimityWysokościRaty();
    //        InicjalizujWiek();
    //        InicjalizujStanyCywilne();
    //        InicjalizujDochody();
    //        InicjalizujWydatki();
    //        InicjalizujWiekKonta();
    //        InicjalizujAukcje();
    //        InicjalizujPozytywneRekomendacje();
    //        InicjalizujNegatywneRekomendacje();
    //        InicjalizujNeutralneRekomendacje();
    //    }

    //    private void InicjalizujKwoty()
    //    {
    //        KwotaList = new ComboBoxFiltr
    //        {
    //            TytułCB = "KwotaList",
    //            IdCB = 0,
    //            PolaCB = new List<Tuple<int, string, string>>()
    //        };

    //        KwotaList.PolaCB.Add(Tuple.Create(0,"500-1000 zł", "500-1000"));
    //        KwotaList.PolaCB.Add(Tuple.Create(1, "1100-2500 zł", "500-1000"));
    //        KwotaList.PolaCB.Add(Tuple.Create(2, "2600-5000 zł", "500-1000"));
    //        KwotaList.PolaCB.Add(Tuple.Create(3, "5100-10000 zł", "500-1000"));
    //        KwotaList.PolaCB.Add(Tuple.Create(4, "10000-25000 zł", "500-1000"));
    //    }

    //    private void InicjalizyujOkresy()
    //    {
    //        OkresList = new ComboBoxFiltr()
    //        {
    //            TytułCB = "OkresList",
    //            IdCB = 1,
    //            PolaCB = new List<Tuple<int, string, string>>()
    //        };
    //        OkresList.PolaCB.Add(Tuple.Create(0, "2 miesiące", "2"));
    //            OkresList.PolaCB.Add(Tuple.Create(1, "3 miesiące", "3"));
    //            OkresList.PolaCB.Add(Tuple.Create(2, "4 miesiące", "4"));
    //            OkresList.PolaCB.Add(Tuple.Create(3, "5 miesięcy", "5"));
    //            OkresList.PolaCB.Add(Tuple.Create(4, "6 miesięcy", "6"));
    //            OkresList.PolaCB.Add(Tuple.Create(5, "7 miesięcy", "7"));
    //            OkresList.PolaCB.Add(Tuple.Create(6, "8 miesięcy", "8"));
    //            OkresList.PolaCB.Add(Tuple.Create(7, "9 miesięcy", "9"));
    //            OkresList.PolaCB.Add(Tuple.Create(8, "10 miesięcy","10"));
    //            OkresList.PolaCB.Add(Tuple.Create(10, "11 miesięcy","11"));
    //            OkresList.PolaCB.Add(Tuple.Create(11, "12 miesięcy","12"));
    //            OkresList.PolaCB.Add(Tuple.Create(12, "13 miesięcy","13"));
    //            OkresList.PolaCB.Add(Tuple.Create(13, "14 miesięcy","14"));
    //            OkresList.PolaCB.Add(Tuple.Create(14, "15 miesięcy","15"));
    //            OkresList.PolaCB.Add(Tuple.Create(15, "16 miesięcy","16"));
    //            OkresList.PolaCB.Add(Tuple.Create(16, "17 miesięcy","17"));
    //            OkresList.PolaCB.Add(Tuple.Create(17, "18 miesięcy","18"));
    //            OkresList.PolaCB.Add(Tuple.Create(18, "19 miesięcy","19"));
    //            OkresList.PolaCB.Add(Tuple.Create(19, "20 miesięcy","20"));
    //            OkresList.PolaCB.Add(Tuple.Create(20, "21 miesięcy","21"));
    //            OkresList.PolaCB.Add(Tuple.Create(21, "22 miesiące","22"));
    //            OkresList.PolaCB.Add(Tuple.Create(22, "23 miesiące","23"));
    //            OkresList.PolaCB.Add(Tuple.Create(23, "24 miesiące","24"));
    //            OkresList.PolaCB.Add(Tuple.Create(24, "25 miesięcy","25"));
    //            OkresList.PolaCB.Add(Tuple.Create(25, "26 miesięcy","26"));
    //            OkresList.PolaCB.Add(Tuple.Create(26, "27 miesięcy","27"));
    //            OkresList.PolaCB.Add(Tuple.Create(27, "28 miesięcy","28"));
    //            OkresList.PolaCB.Add(Tuple.Create(28, "29 miesięcy","29"));
    //            OkresList.PolaCB.Add(Tuple.Create(29, "30 miesięcy","30"));
    //            OkresList.PolaCB.Add(Tuple.Create(30, "31 miesięcy","31"));
    //            OkresList.PolaCB.Add(Tuple.Create(31, "32 miesiące","32"));
    //            OkresList.PolaCB.Add(Tuple.Create(32, "33 miesiące","33"));
    //            OkresList.PolaCB.Add(Tuple.Create(33, "34 miesiące","34"));
    //            OkresList.PolaCB.Add(Tuple.Create(34, "35 miesięcy","35"));
    //            OkresList.PolaCB.Add(Tuple.Create(35, "36 miesięcy","36"));
    //            OkresList.PolaCB.Add(Tuple.Create(36, "Co najwyżej 3 miesiące", "conajwyzej3"));
    //            OkresList.PolaCB.Add(Tuple.Create(37, "Co najwyżej 4 miesiące", "conajwyzej4"));
    //            OkresList.PolaCB.Add(Tuple.Create(38, "Co najwyżej 5 miesięcy", "conajwyzej5"));
    //            OkresList.PolaCB.Add(Tuple.Create(39, "Co najwyżej 6 miesięcy", "conajwyzej6"));
    //            OkresList.PolaCB.Add(Tuple.Create(40, "Co najwyżej 7 miesięcy", "conajwyzej7"));
    //            OkresList.PolaCB.Add(Tuple.Create(41, "Co najwyżej 8 miesięcy", "conajwyzej8"));
    //            OkresList.PolaCB.Add(Tuple.Create(42, "Co najwyżej 9 miesięcy", "conajwyzej9"));
    //            OkresList.PolaCB.Add(Tuple.Create(43, "Co najwyżej 10 miesięcy","conajwyzej10"));
    //            OkresList.PolaCB.Add(Tuple.Create(44, "Co najwyżej 11 miesięcy","conajwyzej11"));
    //            OkresList.PolaCB.Add(Tuple.Create(45, "Co najwyżej 12 miesięcy","conajwyzej12"));
    //            OkresList.PolaCB.Add(Tuple.Create(46, "Co najwyżej 13 miesięcy","conajwyzej13"));
    //            OkresList.PolaCB.Add(Tuple.Create(47, "Co najwyżej 14 miesięcy","conajwyzej14"));
    //            OkresList.PolaCB.Add(Tuple.Create(48, "Co najwyżej 15 miesięcy","conajwyzej15"));
    //            OkresList.PolaCB.Add(Tuple.Create(49, "Co najwyżej 16 miesięcy","conajwyzej16"));
    //            OkresList.PolaCB.Add(Tuple.Create(50, "Co najwyżej 17 miesięcy","conajwyzej17"));
    //            OkresList.PolaCB.Add(Tuple.Create(51, "Co najwyżej 18 miesięcy","conajwyzej18"));
    //            OkresList.PolaCB.Add(Tuple.Create(52, "Co najwyżej 19 miesięcy","conajwyzej19"));
    //            OkresList.PolaCB.Add(Tuple.Create(53, "Co najwyżej 20 miesięcy","conajwyzej20"));
    //            OkresList.PolaCB.Add(Tuple.Create(54, "Co najwyżej 21 miesięcy","conajwyzej21"));
    //            OkresList.PolaCB.Add(Tuple.Create(55, "Co najwyżej 22 miesiące","conajwyzej22"));
    //            OkresList.PolaCB.Add(Tuple.Create(56, "Co najwyżej 23 miesiące","conajwyzej23"));
    //            OkresList.PolaCB.Add(Tuple.Create(57, "Co najwyżej 24 miesiące","conajwyzej24"));
    //            OkresList.PolaCB.Add(Tuple.Create(58, "Co najwyżej 25 miesięcy","conajwyzej25"));
    //            OkresList.PolaCB.Add(Tuple.Create(59, "Co najwyżej 26 miesięcy","conajwyzej26"));
    //            OkresList.PolaCB.Add(Tuple.Create(60, "Co najwyżej 27 miesięcy","conajwyzej27"));
    //            OkresList.PolaCB.Add(Tuple.Create(61, "Co najwyżej 28 miesięcy","conajwyzej28"));
    //            OkresList.PolaCB.Add(Tuple.Create(62, "Co najwyżej 29 miesięcy","conajwyzej29"));
    //            OkresList.PolaCB.Add(Tuple.Create(63, "Co najwyżej 30 miesięcy","conajwyzej30"));
    //            OkresList.PolaCB.Add(Tuple.Create(64, "Co najwyżej 31 miesięcy","conajwyzej31"));
    //            OkresList.PolaCB.Add(Tuple.Create(65, "Co najwyżej 32 miesiące","conajwyzej32"));
    //            OkresList.PolaCB.Add(Tuple.Create(66, "Co najwyżej 33 miesiące","conajwyzej33"));
    //            OkresList.PolaCB.Add(Tuple.Create(67, "Co najwyżej 34 miesiące","conajwyzej34"));
    //            OkresList.PolaCB.Add(Tuple.Create(68, "Co najwyżej 35 miesięcy","conajwyzej35"));
    //            OkresList.PolaCB.Add(Tuple.Create(69, "Co najwyżej 36 miesięcy","conajwyzej36"));
            
    //    }

    //    private void InicjalizujOprocentowania()
    //    {
    //        OprocentowanieList = new ComboBoxFiltr
    //            {
    //                TytułCB = "OprocentowanieList",
    //                IdCB = 2,
    //                PolaCB = new List<Tuple<int, string, string>>()
    //            };

    //        //OkresList.PolaCB.Add(Tuple.Create(0, "1-6%", "1-6");
    //        //OkresList.PolaCB.Add(Tuple.Create(1, "7-10%", "7-10");
    //        //    OkresList.PolaCB.Add(Tuple.Create(2 ,"11-15%",
    //        //    OkresList.PolaCB.Add(Tuple.Create(3 ,"16-20%",
    //        //    OkresList.PolaCB.Add(Tuple.Create(4 ,"21-25%",
    //        //    OkresList.PolaCB.Add(Tuple.Create(5 ,"26-30%",
    //        //    OkresList.PolaCB.Add(Tuple.Create(6 ,"31-45%",
    //        //    OkresList.PolaCB.Add(Tuple.Create(7 ,"powyżej 46%",
    //        //    OkresList.PolaCB.Add(Tuple.Create(8 ,"1-6% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(9 ,"7-10% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(10 ,"11-15% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(11 ,"powyżej 11% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(12 ,"powyżej 12% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(13 ,"powyżej 13% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(14 ,"powyżej 14% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(15 ,"powyżej 15% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(16 ,"powyżej 16% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(17 ,"powyżej 17% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(18 ,"powyżej 18% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(19 ,"powyżej 19% RRSO",
    //        //    OkresList.PolaCB.Add(Tuple.Create(20 ,"powyżej 20% RRSO",
            
    //}

    //    private void InicjalizujRealizacje()
    //    {
    //        RealizacjaList = new ComboBoxFiltr();
    //        //{
    //        //    "co najmniej 25%",
    //        //    "co najmniej 50%",
    //        //    "co najmniej 75%"
    //        //};
    //    }

    //    private void InicjalizujTypyAukcji()
    //    {
    //        TypAukcjiList = new ComboBoxFiltr();
    //        //{
    //        //    "Pożyczki on-line",
    //        //    "Pożyczki naziemne",
    //        //    "Aukcje zakończone",
    //        //    "Aukcje trwające",
    //        //    "Aukcje z gwarancją"
    //        //};
    //    }

    //    private void InicjalizujRatingi()
    //    {
    //        RatingList = new ComboBoxFiltr();
    //        //{
    //        //    "zielona",
    //        //    "co najmniej 1 zielona",
    //        //    "dwie zielone",
    //        //    "co najmniej 2 zielone",
    //        //    "trzy zielone",
    //        //    "co najmniej 3 zielone",
    //        //    "cztery zielone",
    //        //    "co najmniej 4 zielone",
    //        //    "pięć zielonych",
    //        //    "co najmniej 5 zielone",
    //        //    "niebieska",
    //        //    "co najmniej 1 niebieska",
    //        //    "2 niebieskie",
    //        //    "co najmniej 2 niebieskie",
    //        //    "3 niebieskie",
    //        //    "co najmniej 3 niebieskie",
    //        //    "4 niebieskie",
    //        //    "co najmniej 4 niebieskie",
    //        //    "5 niebieskie",
    //        //    "co najmniej 5 niebieskich",
    //        //    "czerwona",
    //        //    "czerwona i 1 zielona",
    //        //    "czerwona i co najmniej 1 zielona",
    //        //    "czerwona i 2 zielone",
    //        //    "czerwona i co najmniej 2 zielone",
    //        //    "czerwona i 3 zielone",
    //        //    "czerwona i co najmniej 3 zielone",
    //        //    "czerwona i 4 zielone",
    //        //};
    //    }

    //    private void InicjalizujWojewództwa()
    //    {
    //        WojewództwoList = new ComboBoxFiltr();
    //        //{
    //        //    "dolnośląskie",
    //        //    "kujawsko-pomorskie",
    //        //    "lubelskie",
    //        //    "lubuskie",
    //        //    "łódzkie",
    //        //    "małopolskie",
    //        //    "mazowieckie",
    //        //    "opolskie",
    //        //    "podkarpackie",
    //        //    "podlaskie",
    //        //    "pomorskie",
    //        //    "śląskie",
    //        //    "świętokrzyskie",
    //        //    "warmińsko-mazurskie",
    //        //    "wielkopolskie",
    //        //    "zachodniopomorskie"
    //        //};
    //    }

    //    private void InicjalizujSumyRatNaNajbliższyMiesiąc()
    //    {
    //        SumaNajbliższychRatList = new ComboBoxFiltr();
    //        //{
    //        //    "brak zobowiązań",
    //        //    "nie więcej niż 200 zł",
    //        //    "nie więcej niż 500 zł",
    //        //    "nie więcej niż 800 zł",
    //        //    "nie więcej niż 1100 zł",
    //        //    "nie więcej niż 1200 zł",
    //        //    "więcej niż 1200 zł"
    //        //};
    //    }

    //    private void InicjalizujLimityWysokościRaty()
    //    {
    //        LimitRatyList = new ComboBoxFiltr();
    //        //{
    //        //    "nie więcej niż 100 zł",
    //        //    "nie więcej niż 200 zł",
    //        //    "nie więcej niż 400 zł",
    //        //    "nie więcej niż 500 zł",
    //        //    "nie więcej niż 700 zł",
    //        //    "nie więcej niż 900 zł",
    //        //    "nie więcej niż 1000 zł",
    //        //    "nie więcej niż 1500 zł",
    //        //    "nie więcej niż 2000 zł"
    //        //};
    //    }

    //    private void InicjalizujWiek()
    //    {
    //        //WiekList = new ComboBoxFiltr();
    //        //{
    //        //    "18-25 lat",
    //        //    "26-45 lat",
    //        //    "46-60 lat",
    //        //    "60 lat i więcej",
    //        //};
    //    }

    //    private void InicjalizujStanyCywilne()
    //    {
    //        StanCywilnyList = new ComboBoxFiltr();
    //        //{
    //        //    "kawaler/panna",
    //        //    "żonaty/mężatka",
    //        //    "wdowiec/wdowa",
    //        //    "osoba rozwiedziona",

    //        //};
    //    }

    //    private void InicjalizujDochody()
    //    {
    //        //DochodyList = new ComboBoxFiltr();
    //        //{
    //        //    "min. 500 zł",
    //        //    "min. 1000 zł",
    //        //    "min. 1500 zł",
    //        //    "min. 2000 zł",
    //        //    "min. 2500 zł",
    //        //    "min. 3000 zł",
    //        //    "min. 4000 zł",
    //        //    "min. 5000 zł",
    //        //    "min. 6000 zł",
    //        //    "min. 7000 zł",
    //        //    "min. 8000 zł",
    //        //    "min. 9000 zł",
    //        //    "min. 10 000 zł",
    //        //    "min. 15 000 zł",
    //        //    "min. 20 000 zł"
    //        //};
    //    }

    //    private void InicjalizujWydatki()
    //    {
    //        //WydatkiList = new ComboBoxFiltr();
    //        //{
    //        //    "nie więcej niż 500 zł",
    //        //    "501-1000 zł",
    //        //    "1001-1500 zł",
    //        //    "więcej niż 1500 zł",

    //        //};
    //    }

    //    private void InicjalizujWiekKonta()
    //    {
    //        //WiekKontaList = new ComboBoxFiltr();
    //        //{
    //        //    "starsze niż 1 m-c",
    //        //    "starsze niż 3 m-ce",
    //        //    "starsze niż 6 m-cy",
    //        //    "starsze niż 1 rok",

    //        //};
    //    }

    //    private void InicjalizujAukcje()
    //    {
    //        AukcjeList = new ComboBoxFiltr();
    //        //{
    //        //    "z ostatnich 24h",
    //        //    "z ostatnich 2 dni",
    //        //    "z ostatnich 3 dni",
    //        //    "z ostatnich 4 dni",
    //        //    "z ostatnich 5 dni",
    //        //    "z ostatnich 6 dni",
    //        //    "z ostatnich 7 dni"
    //        //};
    //    }

    //    private void InicjalizujPozytywneRekomendacje()
    //    {
    //        PozytywneRekomendacjeList = new ComboBoxFiltr();
    //        //{
    //        //    "powyżej 5",
    //        //    "powyżej 10",
    //        //    "powyżej 15"
    //        //};
    //    }

    //    private void InicjalizujNeutralneRekomendacje()
    //    {
    //        NeutralneRekomendacjeList = new ComboBoxFiltr();
    //        //{
    //        //    "brak negatywnych rekomendacji",
    //        //    "nie więcej niż 5",
    //        //    "nie więcej niż 10",
    //        //    "nie więcej niż 15",
    //        //    "nie więcej niż 20",
    //        //};
    //    }

    //    private void InicjalizujNegatywneRekomendacje()
    //    {
    //        NegatywneRekomendacjeList = new ComboBoxFiltr();
    //        //{
    //        //    "brak neutralnych rekomendacji",
    //        //    "nie więcej niż 10",
    //        //    "więcej niż 10"
    //        //};
    //    }

    }
}
