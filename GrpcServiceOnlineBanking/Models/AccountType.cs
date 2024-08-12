using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(TypeOfAccount), IsUnique = true)]    
    [PrimaryKey(nameof(TypeOfAccount))]
    public class AccountType
    {
        [NotNull]
        [StringLength(20)]
        public required string TypeOfAccount  { get; set; }

        [NotNull]
        [Precision(10, 2)]
        public decimal MinimumBalanceRestriction  { get; set; }
    }
}
 