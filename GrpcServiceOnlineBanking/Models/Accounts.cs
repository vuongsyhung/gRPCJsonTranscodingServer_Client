using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(AccountId), IsUnique = true)]
    [PrimaryKey(nameof(AccountId))]
    public class Accounts
    {
        [NotNull]
        [MaxLength(10)]
        public int AccountId { get; set; }

        [NotNull]
        [Precision(10, 2)]
        public decimal AccountBalance { get; set; } 
        
        [NotNull]
        public DateTime DateOpen { get; set; }

        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(BranchId))]
        public int BranchId { get; set; }

        [NotNull]
        [StringLength(20)]
        [ForeignKey(nameof(TypeOfAccount))]
        public required string TypeOfAccount { get; set; }
    }
}
