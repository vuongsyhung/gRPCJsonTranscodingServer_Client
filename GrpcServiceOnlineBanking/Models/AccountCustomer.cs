using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(AccountId), nameof(CustomerId), IsUnique = true)]
    [PrimaryKey(nameof(AccountId), nameof(CustomerId))]
    public class AccountCustomer
    {
        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(AccountId))]
        public int AccountId { get; set; }

        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
    }
}
