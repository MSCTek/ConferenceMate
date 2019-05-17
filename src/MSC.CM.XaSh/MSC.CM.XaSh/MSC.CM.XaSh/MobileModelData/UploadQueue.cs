using SQLite;
using System;

namespace MSC.CM.XaSh.MobileModelData
{
    [Table("UploadQueue")]
    public class UploadQueue
    {
        public DateTime DateQueued { get; set; }

        public int NumAttempts { get; set; }

        public string QueueableObject { get; set; }

        [PrimaryKey]
        public Guid RecordId { get; set; }

        public bool Success { get; set; }
    }
}