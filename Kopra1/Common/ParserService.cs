//using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kopra.Common
{
    public class ParserService
    {
        public string GetMonthAndYear()
        {
            Regex regex = new Regex("<p class=\"tac green fs13\">(?<monthlyRep>.*)</p>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                monthAndYear = regex.Match(InvestorSource).Groups["monthlyRep"].Value;
            else monthAndYear = "Błąd pobierania danych";
            if (monthAndYear.Contains("Wrzesie"))
            {
                monthAndYear = "Wrzesień 2016";
            }
            else if (monthAndYear.Contains("ernik"))
            {
                monthAndYear = "Październik 2016";
            }
            return monthAndYear;
        }

        public string GetInvestmentSum()
        {
            Regex regex = new Regex(@"aktualizowana raz dziennie"">(?<InvestmentSum>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                investmentSum = regex.Match(MyAccountSource).Groups["InvestmentSum"].Value + " zł";
            else investmentSum = "Błąd pobierania danych";
            return investmentSum;
        }

        public string GetCompleteRepayment()
        {
            Regex regex = new Regex(@"kowita: (?<Repayment>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                completeRepayment = regex.Match(MyAccountSource).Groups["Repayment"].Value + "%";
            else completeRepayment = "Błąd pobierania danych";
            return completeRepayment;

        }

        public string GetPotentialGain()
        {
            Regex regex = new Regex(@"zysk<\/span>:\r\n\s*<strong>(?<PotentialGain>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                potentialGain = regex.Match(MyAccountSource).Groups["PotentialGain"].Value + " zł";
            else potentialGain = "Błąd pobierania danych";
            return potentialGain;
        }

        public string GetAverageInterest()
        {
            Regex regex = new Regex(@"<td width=""40"" align=""right""><strong>(?<AveragePercentage>\d+,\d+)", RegexOptions.None);
            if (regex.IsMatch(MyAccountSource))
                averageInterest = regex.Match(MyAccountSource).Groups["AveragePercentage"].Value + "%";
            else averageInterest = "Błąd pobierania danych";
            return averageInterest;
        }

        public string GetReturnOfInvestment()
        {
            Regex regex = new Regex("<p class=\"stopa_zwrotu_center\">(?<ROI>.*)</p>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                returnOfInvestment = regex.Match(InvestorSource).Groups["ROI"].Value;
            else returnOfInvestment = "Błąd pobierania danych";
            return returnOfInvestment;
        }

        public string GetResources()
        {
            Regex regex = new Regex(@"mr30"">\n.*i: <strong>(?<Srodki>\d+,\d{2})<\/strong>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                resources = regex.Match(InvestorSource).Groups["Srodki"].Value + " zł";
            else resources = "Błąd pobierania danych";
            return resources;
        }

        public string GetLoansInRepayment()
        {
            Regex regex = new Regex(@"<strong>(?<LoansRepayment>\d+)<\/strong>\n.*<\/td>\n.*<\/tr>\n.*<\/table>", RegexOptions.None);
            if (regex.IsMatch(InvestorSource))
                loansInRepayment = regex.Match(InvestorSource).Groups["LoansRepayment"].Value;
            else loansInRepayment = "Błąd pobierania danych";
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
