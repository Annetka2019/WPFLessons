using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.Model
{
    public class Indicator
    {
	    public Guid Id { get; set; }

		[Required]
	    public string Name { get; set; }

	    public byte Weight { get; set; }

	    public string Assessment { get; set; }

	    public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}