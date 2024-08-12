using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(CreditCardNumber), IsUnique = true)]
    [PrimaryKey(nameof(CreditCardNumber))]
    public class CreditCard
    {
        [NotNull] 
        [StringLength(45)] 
        public required string CreditCardNumber { get; set; }

        [NotNull]
        [Precision(10, 2)]
        public decimal MaximumLimit { get; set; }

        [NotNull]
        public DateTime ExpireDate { get; set; }

        [NotNull]
        [MaxLength(10)]
        public int CreditScore { get; set; }

        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
    }
}
