using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(BranchId), IsUnique = true)]
    [PrimaryKey(nameof(BranchId))]
    public class Branches
    {
        [NotNull]
        [MaxLength(10)]
        public int BranchId { get; set; }

        [StringLength(45)]
        public required string BranchName { get; set; }

        [StringLength(100)]
        public required string StreesAddress { get; set; }

        [StringLength(45)]
        public required string City { get; set; }

        [StringLength(45)]
        public required string State { get; set; }

        [NotNull]
        [MaxLength(12)]
        public int ZipCode { get; set; }

        [StringLength(15)]
        public required string PhoneNumber { get; set; } 
    }
}
 