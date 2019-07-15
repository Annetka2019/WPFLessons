using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.Model
{
    public class Indicator
    {
	    public Guid Id { get; set; }

		[Required, MaxLength(400)]
	    public string Name { get; set; }

		[Required, MaxLength(500)]
	    public string Type { get; set; }

		public virtual ICollection<IndicatorInCard> IndicatorInCards { get; set; } = new HashSet<IndicatorInCard>();
	}
}