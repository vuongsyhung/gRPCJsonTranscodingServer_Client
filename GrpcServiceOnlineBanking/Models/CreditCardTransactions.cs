using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(TransactionId), IsUnique = true)]
    [PrimaryKey(nameof(TransactionId))]
    public class CreditCardTransactions
    {
        [NotNull]
        [MaxLength(10)]
        public int TransactionId { get; set; }

        [NotNull]
        [StringLength(45)]        
        [ForeignKey(nameof(CreditCardNumber))]
        public required string CreditCardNumber { get; set; }

        [NotNull]
        public DateTime TransctionDate { get; set; }

        [NotNull]
        [Precision(10, 2)]
        public decimal Amount { get; set; }

        [NotNull]
        [StringLength(45)]
        public required string Merchant { get; set; }
    }
}
