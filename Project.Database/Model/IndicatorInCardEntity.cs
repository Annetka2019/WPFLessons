using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mapper = AutoMapper.Configuration.Annotations;

namespace Project.Database.Model
{
	[Table("IndicatorInCard")]
	public class IndicatorInCardEntity
	{
		public Guid Id { get; set; }

		[Required, ForeignKey("Card")]
		public Guid CardId { get; set; }

		[Mapper.Ignore]
		public CardEntity Card { get; set; }

		[Required, ForeignKey("Indicator")]
		public Guid IndicatorId { get; set; }

		[Mapper.Ignore]
		public IndicatorEntity Indicator { get; set; }

		public byte Weight { get; set; }

		[MaxLength(50)]
		public string Assessment { get; set; }
	}
}