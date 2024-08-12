using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(LoanId), IsUnique = true)]
    [PrimaryKey(nameof(LoanId))]
    public class Loan
    {
        [NotNull]
        [MaxLength(10)]
        public int LoanId { get; set; }

        [NotNull]
        [Precision(4, 2)]
        public decimal DurationInYear { get; set; }

        [NotNull]
        public DateTime LoanStartDate { get; set; }

        [NotNull]
        [Precision(4, 2)]
        public decimal InterestRate { get; set; }

        [NotNull]
        [Precision(10, 2)]
        public decimal LoanAmountTaken { get; set; }

        [NotNull]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal LoanAmountRepaid { get; set; }

        [StringLength(45)]
        public required string LoanType { get; set; }

        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
    }
}
