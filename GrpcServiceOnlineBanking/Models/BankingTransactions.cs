using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(TransactionId), IsUnique = true)]
    [PrimaryKey(nameof(TransactionId))]
    public class BankingTransactions
    {
        [NotNull]
        public int TransactionId { get; set; }

        [StringLength(45)]
        public required string TransactionType { get; set; }

        [StringLength(100)]
        public required string Description { get; set; }

        [NotNull]
        [Precision(10, 2)]
        public decimal Amount { get; set; }

        [NotNull]
        public DateTime Date { get; set; }

        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; } 
    }
}
