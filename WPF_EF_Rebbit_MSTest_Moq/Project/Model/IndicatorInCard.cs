using System;
using System.ComponentModel.DataAnnotations;

namespace WPF_EF_Rebbit_MSTest_Moq.Project.Model
{
	public class IndicatorInCard
	{
		public Guid Id { get; set; }

		[Required]
		public Guid CardId { get; set; }

		[Required]
		public Guid IndicatorId { get; set; }

		public byte Weight { get; set; }

		[MaxLength(50)]
		public string Assessment { get; set; }
	}
}