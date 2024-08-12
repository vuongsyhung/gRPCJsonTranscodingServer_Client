using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GrpcServiceOnlineBanking.Models
{
    [Index(nameof(EmployeeId), IsUnique = true)]
    [PrimaryKey(nameof(EmployeeId))]
    public class Employees
    {
        [NotNull]
        [MaxLength(10)]
        public int EmployeeId { get; set; }

        [StringLength(45)]
        public required string FirstName { get; set; }

        [StringLength(45)]
        public required string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(45)]
        public required string Email { get; set; }

        [StringLength(100)]
        public required string StreesAddress { get; set; }

        [StringLength(45)]
        public required string City { get; set; }

        [StringLength(45)]
        public required string State { get; set; }

        [NotNull]
        [MaxLength(12)]
        public int ZipCode { get; set; }

        [StringLength(45)]
        public required string Country { get; set; }

        [Required]
        public string Sex { get; set; }

        [StringLength(45)]
        public required string LevelOfAccess { get; set; }

        [MaxLength(10)]
        public required int SupervisorId { get; set; }

        [NotNull]        
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
    }
}
