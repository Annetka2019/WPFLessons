using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Database.Model
{
	[Table("Card")]
    public class CardEntity
    {
	    public Guid Id { get; set; }

		[Required]
	    public string Number { get; set; }

	    [Required, MaxLength(500)]
		public string Name { get; set; }

	    public DateTime? StartDate { get; set; }

	    public DateTime? DueDate { get; set; }

	    public decimal Assessment { get; set; }

	    public virtual ICollection<IndicatorInCardEntity> IndicatorInCards { get; set; } = new HashSet<IndicatorInCardEntity>();
    }
}