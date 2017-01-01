using System.Text.RegularExpressions;

namespace Kopra.Common
{
    public class ParserService
    {
        private const string AbsentData = "Brak danych.";
        public string GetMonthAndYear()
        {
            var regex = new Regex("<p class=\"tac green fs13\">(?<monthlyRep>.*)</p>", RegexOptions.None);
            monthAndYear = regex.IsMatch(InvestorSource) ? regex.Match(InvestorSource).Groups["monthlyRep"].Value : AbsentData;
            if (monthAndYear.Contains("Wrzesie"))
            {
                monthAndYear = "Wrzesień 2016";
            }
            else if (monthAndYear.Contains("ernik"))
            {
                monthAndYear = "Październik 2016";
            }
            else if (monthAndYear.Contains("stopad"))
            {
                monthAndYear = "Listopad 2016";
            }
            else if (monthAndYear.Contains("Grudzie"))
            {
                monthAndYear = "Grudzień 2016";
            }
            return monthAndYear;
        }

        public string GetInvestmentSum()
        {
            var regex = new Regex(@"aktualizowana raz dziennie"">(?<InvestmentSum>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                investmentSum = regex.Match(MyAccountSource).Groups["InvestmentSum"].Value + " zł";
            else investmentSum = AbsentData;
            return investmentSum;
        }

        public string GetCompleteRepayment()
        {
            var regex = new Regex(@"kowita: (?<Repayment>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                completeRepayment = regex.Match(MyAccountSource).Groups["Repayment"].Value + "%";
            else completeRepayment = AbsentData;
            return completeRepayment;

        }

        public string GetPotentialGain()
        {
            var regex = new Regex(@"zysk<\/span>:\r\n\s*<strong>(?<PotentialGain>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                potentialGain = regex.Match(MyAccountSource).Groups["PotentialGain"].Value + " zł";
            else potentialGain = AbsentData;
            return potentialGain;
        }

        public string GetAverageInterest()
        {
            var regex = new Regex(@"<td width=""40"" align=""right""><strong>(?<AveragePercentage>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                averageInterest = regex.Match(MyAccountSource).Groups["AveragePercentage"].Value + "%";
            else averageInterest = AbsentData;
            return averageInterest;
        }

        public string GetReturnOfInvestment()
        {
            var regex = new Regex("<p class=\"stopa_zwrotu_center\">(?<ROI>.*)</p>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                returnOfInvestment = regex.Match(InvestorSource).Groups["ROI"].Value;
            else returnOfInvestment = AbsentData;
            return returnOfInvestment;
        }

        public string GetResources()
        {
            var regex = new Regex(@"mr30"">\n.*i: <strong>(?<Srodki>\d+,\d{2})<\/strong>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                resources = regex.Match(InvestorSource).Groups["Srodki"].Value + " zł";
            else resources = AbsentData;
            return resources;
        }

        public string GetLoansInRepayment()
        {
            var regex = new Regex(@"<strong>(?<LoansRepayment>\d+)<\/strong>\n.*<\/td>\n.*<\/tr>\n.*<\/table>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                loansInRepayment = regex.Match(InvestorSource).Groups["LoansRepayment"].Value;
            else loansInRepayment = AbsentData;
            return loansInRepayment;
        }

        public ParserService(string investorSource, string myAccountSource )
        {
            InvestorSource = investorSource;
            MyAccountSource = myAccountSource;
        }

        private string InvestorSource;
        private string MyAccountSource;
        private string monthAndYear;
        private string returnOfInvestment;
        private string resources;
        private string investmentSum;
        private string loansInRepayment;
        private string averageInterest;
        private string potentialGain;
        private string completeRepayment;

        //HtmlDocument document = new HtmlDocument();

        //public void LoadHTMLFromString(string html)
        //{
        //    document.LoadHtml(html);
        //}

    }
}
