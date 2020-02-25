using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordCounter.Common
{
    [Table("count_requests")]
    public class CountRequest
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("correlation_id")]
        public Guid CorrelationId { get; set; }

        [Column("content")]
        public string Content { get; set; }
    }
}
