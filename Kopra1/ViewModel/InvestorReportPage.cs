using Kopra.Common;

namespace Kopra.ViewModel
{
    public class InvestorReportPage : MainViewModel
    {
        private DataService dataService = new DataService();
        private ParserService parserService;
        private string investorReportAddress = "https://kokos.pl/raporty/inwestor";
        private string myAccountAddress = "https://kokos.pl/moje_konto";
        private string ivestorReportSource;
        private string myAccountSource;
        private string _averageInterest;
        private string _completeRepayment;
        private string _investmentSum;
        private string _loansInRepayment;
        private string _monthAndYear;
        private string _potentialGain;
        private string _resources;
        private string _returnOfInvestments;

        public string AverageInterest
        {
            get
            {
                return _averageInterest;
            }
            set
            {
                _averageInterest = value;
                NotifyPropertyChanged(nameof(AverageInterest));
            }
        }
        public string CompleteRepayment
        {
            get
            {
                return _completeRepayment;
            }
            set
            {
                _completeRepayment = value;
                NotifyPropertyChanged(nameof(CompleteRepayment));
            }
        }
        public string InvestmentSum
        {
            get
            {
                return _investmentSum;
            }
            set
            {
                _investmentSum = value;
                NotifyPropertyChanged(nameof(InvestmentSum));
            }
        }
        public string LoansInRepayment
        {
            get
            {
                return _loansInRepayment;
            }
            set
            {
                _loansInRepayment = value;
                NotifyPropertyChanged(nameof(LoansInRepayment));
            }
        }
        public string MonthAndYear
        {
            get
            {
                return _monthAndYear;
            }
            set
            {
                _monthAndYear = value;
                NotifyPropertyChanged(nameof(MonthAndYear));
            }
        }
        public string PotentialGain
        {
            get
            {
                return _potentialGain;
            }
            set
            {
                _potentialGain = value;
                NotifyPropertyChanged(nameof(PotentialGain));
            }
        }
        public string Resources
        {
            get
            {
                return _resources;
            }
            set
            {
                _resources = value;
                NotifyPropertyChanged(nameof(Resources));
            }
        }
        public string ReturnOfInvestments
        {
            get
            {
                return _returnOfInvestments;
            }
            set
            {
                _returnOfInvestments = value;
                NotifyPropertyChanged(nameof(ReturnOfInvestments));
            }
        }

        public InvestorReportPage()
        {
            LoadData();
        }

        private async void LoadData()
        {
            ivestorReportSource = await KokosConnectionManager.GetWebSource(investorReportAddress);
            myAccountSource = await KokosConnectionManager.GetWebSource(myAccountAddress);
            parserService = new ParserService(ivestorReportSource, myAccountSource);
            //parserService.LoadHTMLFromString(ivestorReportSource);
            AverageInterest = parserService.GetAverageInterest();
            CompleteRepayment = parserService.GetCompleteRepayment();
            InvestmentSum = parserService.GetInvestmentSum();
            LoansInRepayment = parserService.GetLoansInRepayment();
            MonthAndYear = parserService.GetMonthAndYear();
            PotentialGain = parserService.GetPotentialGain();
            Resources = parserService.GetResources();
            ReturnOfInvestments = parserService.GetReturnOfInvestment();
        }

    }
}