using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.Model
{
    public class Card
    {
	    public Guid Id { get; set; }

		[Required]
	    public string Number { get; set; }

	    [Required]
		public string Name { get; set; }

	    public DateTime? StartDate { get; set; }

	    public DateTime? DueDate { get; set; }

	    public decimal Assessment { get; set; }

	    public virtual ICollection<Indicator> Indicators { get; set; } = new HashSet<Indicator>();
    }
}