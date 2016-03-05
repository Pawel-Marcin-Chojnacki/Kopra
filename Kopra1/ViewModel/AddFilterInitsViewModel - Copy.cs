using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopra1.ViewModel
{
    partial class AddFilterViewModel
    {
        public AddFilterViewModel()
        {
            InicjalizujKwoty();
            InicjalizyujOkresy();
            InicjalizujOprocentowania();
            InicjalizujRealizacje();
            InicjalizujTypyAukcji();
            InicjalizujRatingi();
            InicjalizujWojewództwa();
            InicjalizujSumyRatNaNajbliższyMiesiąc();
            InicjalizujLimityWysokościRaty();
            InicjalizujWiek();
            InicjalizujStanyCywilne();
            InicjalizujDochody();
            InicjalizujWydatki();
            InicjalizujWiekKonta();
            InicjalizujAukcje();
            InicjalizujPozytywneRekomendacje();
            InicjalizujNegatywneRekomendacje();
            InicjalizujNeutralneRekomendacje();
        }

        private void InicjalizujKwoty()
        {
            KwotaList = new ComboBoxFiltr
            {
                TytułCB = "KwotaList",
                IdCB = 0
            };
            KwotaList.PolaCB.Add(Tuple.Create(0,"500-1000 zł", "500-1000"));
            KwotaList.PolaCB.Add(Tuple.Create(1, "1100-2500 zł", "500-1000"));
            KwotaList.PolaCB.Add(Tuple.Create(2, "2600-5000 zł", "500-1000"));
            KwotaList.PolaCB.Add(Tuple.Create(3, "5100-10000 zł", "500-1000"));
            KwotaList.PolaCB.Add(Tuple.Create(4, "10000-25000 zł", "500-1000"));
            //"500-1000 zł",
            //    "1100-2500 zł",
            //    "2600-5000 zł"
            //    "5100-10000 zł",
            //    "10000-25000 zł"
            
        }

        private void InicjalizyujOkresy()
        {
            OkresList = new List<string>
            {
                "2 miesiące",
                "3 miesiące",
                "4 miesiące",
                "5 miesięcy",
                "6 miesięcy",
                "7 miesięcy",
                "8 miesięcy",
                "9 miesięcy",
                "10 miesięcy",
                "11 miesięcy",
                "12 miesięcy",
                "13 miesięcy",
                "14 miesięcy",
                "15 miesięcy",
                "16 miesięcy",
                "17 miesięcy",
                "18 miesięcy",
                "19 miesięcy",
                "20 miesięcy",
                "21 miesięcy",
                "22 miesiące",
                "23 miesiące",
                "24 miesiące",
                "25 miesięcy",
                "26 miesięcy",
                "27 miesięcy",
                "28 miesięcy",
                "29 miesięcy",
                "30 miesięcy",
                "31 miesięcy",
                "32 miesiące",
                "33 miesiące",
                "34 miesiące",
                "35 miesięcy",
                "36 miesięcy",
                "Co najwyżej 3 miesiące",
                "Co najwyżej 4 miesiące",
                "Co najwyżej 5 miesięcy",
                "Co najwyżej 6 miesięcy",
                "Co najwyżej 7 miesięcy",
                "Co najwyżej 8 miesięcy",
                "Co najwyżej 9 miesięcy",
                "Co najwyżej 10 miesięcy",
                "Co najwyżej 11 miesięcy",
                "Co najwyżej 12 miesięcy",
                "Co najwyżej 13 miesięcy",
                "Co najwyżej 14 miesięcy",
                "Co najwyżej 15 miesięcy",
                "Co najwyżej 16 miesięcy",
                "Co najwyżej 17 miesięcy",
                "Co najwyżej 18 miesięcy",
                "Co najwyżej 19 miesięcy",
                "Co najwyżej 20 miesięcy",
                "Co najwyżej 21 miesięcy",
                "Co najwyżej 22 miesiące",
                "Co najwyżej 23 miesiące",
                "Co najwyżej 24 miesiące",
                "Co najwyżej 25 miesięcy",
                "Co najwyżej 26 miesięcy",
                "Co najwyżej 27 miesięcy",
                "Co najwyżej 28 miesięcy",
                "Co najwyżej 29 miesięcy",
                "Co najwyżej 30 miesięcy",
                "Co najwyżej 31 miesięcy",
                "Co najwyżej 32 miesiące",
                "Co najwyżej 33 miesiące",
                "Co najwyżej 34 miesiące",
                "Co najwyżej 35 miesięcy",
                "Co najwyżej 36 miesięcy"
            };
        }

        private void InicjalizujOprocentowania()
        {
            OprocentowanieList = new List<string>
            {
                "1-6%",
                "7-10%",
                "11-15%",
                "16-20%",
                "21-25%",
                "26-30%",
                "31-45%",
                "powyżej 46%",
                "1-6% RRSO",
                "7-10% RRSO",
                "11-15% RRSO",
                "powyżej 11% RRSO",
                "powyżej 12% RRSO",
                "powyżej 13% RRSO",
                "powyżej 14% RRSO",
                "powyżej 15% RRSO",
                "powyżej 16% RRSO",
                "powyżej 17% RRSO",
                "powyżej 18% RRSO",
                "powyżej 19% RRSO",
                "powyżej 20% RRSO"
            };
        }

        private void InicjalizujRealizacje()
        {
            RealizacjaList = new List<string>
            {
                "co najmniej 25%",
                "co najmniej 50%",
                "co najmniej 75%"
            };
        }

        private void InicjalizujTypyAukcji()
        {
            TypAukcjiList = new List<string>
            {
                "Pożyczki on-line",
                "Pożyczki naziemne",
                "Aukcje zakończone",
                "Aukcje trwające",
                "Aukcje z gwarancją"
            };
        }

        private void InicjalizujRatingi()
        {
            RatingList = new List<string>
            {
                "zielona",
                "co najmniej 1 zielona",
                "dwie zielone",
                "co najmniej 2 zielone",
                "trzy zielone",
                "co najmniej 3 zielone",
                "cztery zielone",
                "co najmniej 4 zielone",
                "pięć zielonych",
                "co najmniej 5 zielone",
                "niebieska",
                "co najmniej 1 niebieska",
                "2 niebieskie",
                "co najmniej 2 niebieskie",
                "3 niebieskie",
                "co najmniej 3 niebieskie",
                "4 niebieskie",
                "co najmniej 4 niebieskie",
                "5 niebieskie",
                "co najmniej 5 niebieskich",
                "czerwona",
                "czerwona i 1 zielona",
                "czerwona i co najmniej 1 zielona",
                "czerwona i 2 zielone",
                "czerwona i co najmniej 2 zielone",
                "czerwona i 3 zielone",
                "czerwona i co najmniej 3 zielone",
                "czerwona i 4 zielone",
            };
        }

        private void InicjalizujWojewództwa()
        {
            WojewództwoList = new List<string>
            {
                "dolnośląskie",
                "kujawsko-pomorskie",
                "lubelskie",
                "lubuskie",
                "łódzkie",
                "małopolskie",
                "mazowieckie",
                "opolskie",
                "podkarpackie",
                "podlaskie",
                "pomorskie",
                "śląskie",
                "świętokrzyskie",
                "warmińsko-mazurskie",
                "wielkopolskie",
                "zachodniopomorskie"
            };
        }

        private void InicjalizujSumyRatNaNajbliższyMiesiąc()
        {
            SumaNajbliższychRatList = new List<string>
            {
                "brak zobowiązań",
                "nie więcej niż 200 zł",
                "nie więcej niż 500 zł",
                "nie więcej niż 800 zł",
                "nie więcej niż 1100 zł",
                "nie więcej niż 1200 zł",
                "więcej niż 1200 zł"
            };
        }

        private void InicjalizujLimityWysokościRaty()
        {
            LimitRatyList = new List<string>
            {
                "nie więcej niż 100 zł",
                "nie więcej niż 200 zł",
                "nie więcej niż 400 zł",
                "nie więcej niż 500 zł",
                "nie więcej niż 700 zł",
                "nie więcej niż 900 zł",
                "nie więcej niż 1000 zł",
                "nie więcej niż 1500 zł",
                "nie więcej niż 2000 zł"
            };
        }

        private void InicjalizujWiek()
        {
            WiekList = new List<string>
            {
                "18-25 lat",
                "26-45 lat",
                "46-60 lat",
                "60 lat i więcej",
            };
        }

        private void InicjalizujStanyCywilne()
        {
            StanCywilnyList = new List<string>
            {
                "kawaler/panna",
                "żonaty/mężatka",
                "wdowiec/wdowa",
                "osoba rozwiedziona",

            };
        }

        private void InicjalizujDochody()
        {
            DochodyList = new List<string>
            {
                "min. 500 zł",
                "min. 1000 zł",
                "min. 1500 zł",
                "min. 2000 zł",
                "min. 2500 zł",
                "min. 3000 zł",
                "min. 4000 zł",
                "min. 5000 zł",
                "min. 6000 zł",
                "min. 7000 zł",
                "min. 8000 zł",
                "min. 9000 zł",
                "min. 10 000 zł",
                "min. 15 000 zł",
                "min. 20 000 zł"
            };
        }

        private void InicjalizujWydatki()
        {
            WydatkiList = new List<string>
            {
                "nie więcej niż 500 zł",
                "501-1000 zł",
                "1001-1500 zł",
                "więcej niż 1500 zł",

            };
        }

        private void InicjalizujWiekKonta()
        {
            WiekKontaList = new List<string>
            {
                "starsze niż 1 m-c",
                "starsze niż 3 m-ce",
                "starsze niż 6 m-cy",
                "starsze niż 1 rok",

            };
        }

        private void InicjalizujAukcje()
        {
            AukcjeList = new List<string>
            {
                "z ostatnich 24h",
                "z ostatnich 2 dni",
                "z ostatnich 3 dni",
                "z ostatnich 4 dni",
                "z ostatnich 5 dni",
                "z ostatnich 6 dni",
                "z ostatnich 7 dni"
            };
        }

        private void InicjalizujPozytywneRekomendacje()
        {
            PozytywneRekomendacjeList = new List<string>
            {
                "powyżej 5",
                "powyżej 10",
                "powyżej 15"
            };
        }

        private void InicjalizujNeutralneRekomendacje()
        {
            NeutralneRekomendacjeList = new List<string>
            {
                "brak negatywnych rekomendacji",
                "nie więcej niż 5",
                "nie więcej niż 10",
                "nie więcej niż 15",
                "nie więcej niż 20",
            };
        }

        private void InicjalizujNegatywneRekomendacje()
        {
            NegatywneRekomendacjeList = new List<string>
            {
                "brak neutralnych rekomendacji",
                "nie więcej niż 10",
                "więcej niż 10"
            };
        }

    }
}
