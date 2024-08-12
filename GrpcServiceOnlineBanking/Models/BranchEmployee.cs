using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(BranchId), nameof(EmployeeId), IsUnique = true)]
    [PrimaryKey(nameof(BranchId), nameof(EmployeeId))]       
    public class BranchEmployee
    {
        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }

        [NotNull]
        [MaxLength(10)]
        [ForeignKey(nameof(BranchId))]
        public int BranchId { get; set; }

        [NotNull]
        public DateTime StartDate { get; set; }

        [NotNull]
        public DateTime EndDate { get; set; }  
    }
}
