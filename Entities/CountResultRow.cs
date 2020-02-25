using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordCounter.Common
{
    [Table("count_results")]
    public class CountResultRow
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("correlation_id")]
        public Guid CorrelationId { get; set; }

        [Column("word_count")]
        public int WordCount { get; set; }
    }
}
