// <auto-generated> - Template:SqliteModelData, Version:1.1, Id:c5caad15-b3be-4443-87d8-7cabde59f7b0
using SQLite;

namespace MSC.CM.Xam.ModelData.CM
{
	[Table("LanguageType")]
	public partial class LanguageType
	{
		public string Code { get; set; }
		public string CreatedBy { get; set; }
		public System.DateTime CreatedUtcDate { get; set; }
		public int DataVersion { get; set; }
		public int DisplayPriority { get; set; }
		public string DisplayText { get; set; }
		public bool IsDeleted { get; set; }
		public int? LanguageCultureIdentifier { get; set; }

		[PrimaryKey]
		public int LanguageTypeId { get; set; }

		public string ModifiedBy { get; set; }
		public System.DateTime ModifiedUtcDate { get; set; }
		public string NativeName { get; set; }
		public string ThreeLetterIsoLanguageName { get; set; }
		public string TwoLetterIsoLanguageName { get; set; }
	}
}
