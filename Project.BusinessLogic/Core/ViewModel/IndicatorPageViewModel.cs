using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.Database;
using Project.BusinessLogic.Contract.Interface.Model;
using Project.BusinessLogic.Contract.Interface.ViewModel;
using Project.BusinessLogic.Core.Model;
using Project.BusinessLogic.Event;
using Project.BusinessLogic.Framework;
using Project.BusinessLogic.Framework.Base;

namespace Project.BusinessLogic.Core.ViewModel
{
	public class IndicatorPageViewModel: BaseViewModel, IIndicatorPageViewModel
	{
		private readonly IRepository<IIndicator> _repository;

		public IndicatorPageViewModel(IRepository<IIndicator> repository) {
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			InitCommands();
			SubscribeEvents();
			SetEnabledAttributes();
		}

		private IIndicator _indicator = new Indicator();
		public IIndicator Indicator {
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
			if (Indicator.Id == Guid.Empty) {
				Indicator.Id = Guid.NewGuid();
				_repository.Add(Indicator);
				IndicatorSaved?.Invoke(this, new IndicatorSavedEventArgs {
					Indicator = Indicator
				});
			}
			else {
				_repository.Edit(Indicator);
			}
			
			MessageBox.Show(Properties.Resources.IndicatorPageSavedMessage);
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