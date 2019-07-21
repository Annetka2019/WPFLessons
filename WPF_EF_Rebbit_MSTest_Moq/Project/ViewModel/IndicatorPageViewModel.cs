using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_EF_Rebbit_MSTest_Moq.Database;
using WPF_EF_Rebbit_MSTest_Moq.Framework;
using WPF_EF_Rebbit_MSTest_Moq.Framework.Base;
using WPF_EF_Rebbit_MSTest_Moq.Project.Events;
using WPF_EF_Rebbit_MSTest_Moq.Project.Model;
using WPF_EF_Rebbit_MSTest_Moq.Properties;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.ViewModel
{
	public class IndicatorPageViewModel: BaseViewModel
	{
		public IndicatorPageViewModel() {
			InitCommands();
			SubscribeEvents();
			SetEnabledAttributes();
		}

		private Indicator _indicator = new Indicator();
		public Indicator Indicator {
			get => _indicator;
			set {
				_indicator = value;
				OnPropertyChanged();
				SubscribeIndicatorPropertyChanged();
				SetIsSaveButtonEnabled();
			}
		} 

		private bool _isSaveButtonEnabled;
		public bool IsSaveButtonEnabled {
			get => _isSaveButtonEnabled;
			set {
				_isSaveButtonEnabled = value;
				OnPropertyChanged();
			}
		}

		public ICommand SaveCommand { get; private set; }

		private void InitCommands() {
			SaveCommand = new DelegateCommand(SaveIndicator);
		}

		private void SaveIndicator(object obj) {
			using (var ctx = new ProjectDbContext()) {
				if (Indicator.Id == Guid.Empty) {
					Indicator.Id = Guid.NewGuid();
					ctx.Indicators.Add(Indicator);
					IndicatorSaved?.Invoke(this, new IndicatorSavedEventArgs {
						Indicator = Indicator
					});
				}
				else {
					Indicator indicatorDb = ctx.Indicators.Find(Indicator.Id);
					if (indicatorDb != null) {
						indicatorDb.Name = Indicator.Name;
						indicatorDb.Type = Indicator.Type;
					}
				}
				ctx.SaveChanges();
				MessageBox.Show(Resources.IndicatorPageSavedMessage);
			}
		}

		private void SubscribeEvents() {
			SubscribeIndicatorPropertyChanged();
		}

		private void SubscribeIndicatorPropertyChanged() {
			Indicator.PropertyChanged += IndicatorOnPropertyChanged;
		}

		private void IndicatorOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
			SetIsSaveButtonEnabled();
		}

		private void SetEnabledAttributes() {
			SetIsSaveButtonEnabled();
		}

		private void SetIsSaveButtonEnabled() {
			IsSaveButtonEnabled = !string.IsNullOrEmpty(Indicator.Name) && !string.IsNullOrEmpty(Indicator.Type);
		}

		public event EventHandler<IndicatorSavedEventArgs> IndicatorSaved;
	}
}