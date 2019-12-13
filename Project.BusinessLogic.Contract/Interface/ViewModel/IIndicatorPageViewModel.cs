using System;
using System.Windows.Input;
using Project.BusinessLogic.Contract.Interface.Event;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Contract.Interface.ViewModel
{
	public interface IIndicatorPageViewModel
	{
		IIndicator Indicator { get; set; }
		ICommand SaveCommand { get; }
		event EventHandler<IIndicatorSavedEventArgs> IndicatorSaved;
	}
}