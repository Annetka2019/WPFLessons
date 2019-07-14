using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF_EF_Rebbit_MSTest_Moq.Annotations;

namespace WPF_EF_Rebbit_MSTest_Moq.Framework.Base
{
	public class BaseViewModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}