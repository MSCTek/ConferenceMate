// <auto-generated> - Template:DTO, Version:1.1, Id:58fa7ee2-89f7-41e6-85ed-8d4482653990
namespace MSC.ConferenceMate.DTO.CM
{
	public partial class Room
	{
		public Room()
		{
			InitializePartial();
		}

		public int RoomId { get; set; } // Primary key
		public string Title { get; set; }
		public string ShortTitle { get; set; }
		public string Description { get; set; }
		public int SeatingCapacity { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public int DataVersion { get; set; }
		public System.DateTime CreatedUtcDate { get; set; }
		public string CreatedBy { get; set; }
		public System.DateTime ModifiedUtcDate { get; set; }
		public string ModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
		// public virtual System.Collections.Generic.ICollection<Session> Sessions { get; set; } // Many to many mapping -- Excluded navigation property per configuration.


		partial void InitializePartial();

	}
}
