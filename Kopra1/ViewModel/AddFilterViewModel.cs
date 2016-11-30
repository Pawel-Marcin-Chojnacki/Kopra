using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kopra.Annotations;
using System.Collections.Generic;
using Kopra.Model;
using System;
using Windows.Storage;
using System.Text;
using System.IO;
using Windows.UI.Popups;

namespace Kopra.ViewModel
{
    class AddFilterViewModel : INotifyPropertyChanged
    {
		public AddFilterViewModel()
		{
			InicjalizujKwotęPożyczek();
			InicjalizujRealizację();
			InicjalizujStatusyPożyczek();
			InicjalizujOkresyPożyczek();
			InicjalizujOprocentowaniePożyczek();
			InicjalizujIlośćInwestorów();
		}

		public void WyczyśćFiltr()
		{
			Investor = null;
			Completion = null;
			LoanInterest = null;
			LoanPeriod = null;
			LoanAmount = null;
			Status = null;
			TitleSearch = null;
			FilterName = null;
		}

		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events

		#region Properties
		public List<Status> StatusyPozyczek { get; set; }
		public Investor Investor
		{
			get
			{
				return _investor;
			}
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

		private KwotaPozyczkiModel _wybranaKwota;
		public KwotaPozyczkiModel WybranaKwota
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
		private Interest _loanInterest;
		public Interest LoanInterest {
			get
			{
				return _loanInterest;
			}
			set
			{
				_loanInterest = value;
				NotifyPropertyChanged(nameof(LoanInterest));
			}
	}

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

		private List<LoanPeriod> _loanPeriods;
		public List<LoanPeriod> LoanPeriods
		{
			get

			{
				return _loanPeriods;
			}
			set
			{
				_loanPeriods = value;
				NotifyPropertyChanged(nameof(LoanPeriods));
			}
		}

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

		public Status Status
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

		public string FilterName
		{
			get
			{
				return _filterName;
			}
			set
			{
				_filterName = value;
				NotifyPropertyChanged(nameof(FilterName));
			}
		}


		internal async void AddFilter()
		{
			var filterLink = CreateLinkFromFields();

			try
			{
				var folder = ApplicationData.Current.LocalFolder;
				if (folder != null)
				{
					var file = await folder.CreateFileAsync(FilterName, CreationCollisionOption.ReplaceExisting);
					var fileContent = Encoding.UTF8.GetBytes(filterLink);
					var fileStream = await file.OpenStreamForWriteAsync();
					fileStream.Write(fileContent, 0, fileContent.Length);
					fileStream.Flush();
					fileStream.Dispose();
					var msgDial = new MessageDialog("Filtr został zapisany");
					await msgDial.ShowAsync();
				}
			}
			catch (Exception)
			{
				var msgDial = new MessageDialog("Nie można zapisać filtru: ");
				await msgDial.ShowAsync();
				throw;
			}
			finally
			{
				var content = string.Empty;
				var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FilterName);
				using (var reader = new StreamReader(readingStream))
				{
					content = await reader.ReadToEndAsync();
				}

			}

		}

		private char[] CreateLinkFromFields()
		{
			var link = new StringBuilder();
			if (!string.IsNullOrWhiteSpace(_titleSearch))
			{
				link.Append("&title=" + _titleSearch);
			}
			if (Status!= null )
			{
			    if (Status.StatusLiczbowy == 0)
			    {
			        //link.Append("&status=" + 100)

                }
				link.Append("&status=" + Status.StatusLiczbowy);
			}
			if (LoanAmount != null)
			{
				link.Append("&valueFrom=" + LoanAmount.valueFrom);
				link.Append("&valueTo=" + LoanAmount.valueTo);
			}
			if (LoanPeriod != null)
			{
				link.Append("&periodFrom=" + LoanPeriod.periodFrom);
				link.Append("&periodTo=" + LoanPeriod.periodTo);
			}

			if (LoanInterest != null)
			{
				link.Append("&percentFrom=" + LoanInterest.percentFrom);
				link.Append("&percentTo=" + LoanInterest.percentTo);
			}
			if (Completion != null)
			{
				link.Append("&completedFrom=" + Completion.Percentage);
			}
			if (Investor != null)
			{
				link.Append("&investorsFrom=" + Investor.investorsFrom);
				link.Append("&investorsTo=" + Investor.investorsTo);
			}
			return link.ToString().ToCharArray();
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
		private List<Interest> _loanInterests;
		private LoanPeriod _loanPeriod;
		private Completion _completion;
		private List<Completion> _completions;
		private Status _status;
		private string _titleSearch;
		private string _filterName;

		#endregion Fields

		private void InicjalizujIlośćInwestorów()
		{
			Investors = new List<Investor>()
			{
				new Investor() {Description = "Brak inwestorów", investorsFrom = 0, investorsTo = 0},
				new Investor() {Description = "1 - 5 inwestorów", investorsFrom = 1, investorsTo = 5},
				new Investor() {Description = "6 - 10 inwestorów", investorsFrom = 6, investorsTo = 10},
				new Investor() {Description = "11 - 20 inwestorów", investorsFrom = 11, investorsTo = 20},
				new Investor() {Description = "21 - 50 inwestorów", investorsFrom = 21, investorsTo = 50},
				new Investor() {Description = "Powyżej 50 inwestorów", investorsFrom = 50, investorsTo = 999},
			};

		}

		private void InicjalizujKwotęPożyczek()
		{
			LoanAmounts = new List<LoanAmount>()
			{
				new LoanAmount() {valueFrom = 0, valueTo = int.MaxValue, RangeDescription = "Dowolna kwota"},
				new LoanAmount() {valueFrom = 500, valueTo = 1000, RangeDescription = "Od 500 do 1000 zł"},
				new LoanAmount() {valueFrom = 1100, valueTo = 2500, RangeDescription = "Od 1100 do 2500 zł"},
				new LoanAmount() {valueFrom = 2600, valueTo = 5000, RangeDescription = "Od 2600 do 5000 zł"},
				new LoanAmount() {valueFrom = 5100, valueTo = 10000, RangeDescription = "Od 5100 do 10000 zł"},
				new LoanAmount() {valueFrom = 10100, valueTo = 25000, RangeDescription = "Od 10100 do 25000 zł"}
			};
		}

		private void InicjalizujOkresyPożyczek()
		{
			LoanPeriods = new List<LoanPeriod>()
			{
				new LoanPeriod() {Description = "Dowolny okres",periodFrom = 0, periodTo = int.MaxValue},
				new LoanPeriod() {Description = "Do pół roku",periodFrom = 1, periodTo = 6},
				new LoanPeriod() {Description = "Do 1 roku",periodFrom = 6, periodTo = 12},
				new LoanPeriod() {Description = "Od 1 do 2 lat",periodFrom = 12, periodTo = 24},
				new LoanPeriod() {Description = "Od 2 do 3 lat",periodFrom = 24, periodTo = 36},

			};
		}

		private void InicjalizujOprocentowaniePożyczek()
		{
			LoanInterests = new List<Interest>()
			{
				new Interest() {Description = "Dowolny %", percentFrom = 0, percentTo = int.MaxValue},
				new Interest() {Description = "Od 1 do 10%", percentFrom = 1, percentTo = 10},
				new Interest() {Description = "Od 11 do 20%", percentFrom = 11, percentTo = 20},
				new Interest() {Description = "Od 21 do 25%", percentFrom = 21, percentTo = 25},
				new Interest() {Description = "Powyżej 25%", percentFrom = 25, percentTo = int.MaxValue}
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
                new Status() {Opis = "Brak", StatusLiczbowy = 0},
				new Status() {Opis = "Nowa pożyczka", StatusLiczbowy = 100},
				//new Status() {Opis = "W trakcie tworzenia", StatusLiczbowy = 110},
				new Status() {Opis = "Trwa spłata", StatusLiczbowy = 500},
				new Status() {Opis = "Uzbierano poniżej 50% inwestycji", StatusLiczbowy = 1100},
				new Status() {Opis = "Uzbierano 0% inwestycji", StatusLiczbowy = 1200},
				new Status() {Opis = "Spłacona w całości", StatusLiczbowy = 1300},
				//new Status() {Opis = "Usunięta przez obsługę", StatusLiczbowy = 1400},
				//new Status() {Opis = "Usunięta przez użytkownika", StatusLiczbowy = 1500}
			};
		}

	}
}
