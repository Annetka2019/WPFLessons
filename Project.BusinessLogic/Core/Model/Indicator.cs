using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Project.BusinessLogic.Annotations;
using Project.BusinessLogic.Contract.Interface.Model;

namespace Project.BusinessLogic.Core.Model
{
    public class Indicator: IIndicator, INotifyPropertyChanged
    {
	    public Guid Id { get; set; }

	    private string _name;
	    public string Name {
		    get => _name;
		    set {
			    _name = value;
				OnPropertyChanged();
		    }
	    }

	    private string _type;
	    public string Type {
			get => _type;
			set {
				_type = value;
				OnPropertyChanged();
			}
		}

		public virtual ICollection<IIndicatorInCard> IndicatorInCards { get; set; } = new HashSet<IIndicatorInCard>();

	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
}