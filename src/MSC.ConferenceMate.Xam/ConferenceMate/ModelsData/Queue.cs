using SQLite;
using System;

namespace QuikRide.ModelsData
{
    [Table("Queue")]
    public class Queue
    {
        public DateTime DateQueued { get; set; }

        public int NumAttempts { get; set; }

        public string QueueableObject { get; set; }

        [PrimaryKey]
        public Guid RecordId { get; set; }

        public bool Success { get; set; }
    }
}