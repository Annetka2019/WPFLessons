using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WPF_EF_Rebbit_MSTest_Moq.Annotations;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.Model
{
    public class Indicator: INotifyPropertyChanged
    {
	    public Guid Id { get; set; }

	    private string _name;
		[Required, MaxLength(400)] 
	    public string Name {
		    get => _name;
		    set {
			    _name = value;
				OnPropertyChanged();
		    }
	    }

	    private string _type;
		[Required, MaxLength(500)]
	    public string Type {
			get => _type;
			set {
				_type = value;
				OnPropertyChanged();
			}
		}

		public virtual ICollection<IndicatorInCard> IndicatorInCards { get; set; } = new HashSet<IndicatorInCard>();

	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
}