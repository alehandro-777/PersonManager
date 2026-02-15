using System;
using System.ComponentModel.DataAnnotations;

namespace PersonManager.API.DTO
{
    /// <summary>
    /// DTO representing an address of a person.
    /// </summary>
    public class AnschriftDto
    {
        /// <summary>
        /// Unique identifier of the address.
        /// </summary>
        public int AnschriftId { get; set; }

        /// <summary>
        /// City of the address.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Ort { get; set; } = null!;

        /// <summary>
        /// Street name of the address.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Strasse { get; set; } = null!;

        /// <summary>
        /// House number of the address.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Hausnummer { get; set; } = null!;

        /// <summary>
        /// Postal code of the address.
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Postleitzahl { get; set; } = null!;
    }
}
