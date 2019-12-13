using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Contract.Interface.Event
{
	public interface IIndicatorSavedEventArgs
	{
		IIndicator Indicator { get; set; }
	}
}