using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Database.Model
{
	[Table("Indicator")]
	public class IndicatorEntity
	{
		public Guid Id { get; set; }

		[Required, MaxLength(400)]
		public string Name { get; set; }

		[Required, MaxLength(500)]
		public string Type { get; set; }

		public virtual ICollection<IndicatorInCardEntity> IndicatorInCards { get; set; } = new HashSet<IndicatorInCardEntity>();
	}
}