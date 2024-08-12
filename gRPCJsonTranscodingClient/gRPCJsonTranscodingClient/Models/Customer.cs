using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace gRPCJsonTranscodingClient.Models  
{  
    public class Customer
    {        
        [Key]
        [NotNull]        
        public int CustomerId { get; set; }
       
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
        public int ZipCode { get; set; }

        [StringLength(45)]
        public required string Country { get; set; }

        [Required]
        public string Sex { get; set; }
    }
}
