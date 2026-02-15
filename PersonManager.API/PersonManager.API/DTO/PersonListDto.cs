using System;
using System.ComponentModel.DataAnnotations;

namespace PersonManager.API.DTO
{
    /// <summary>
    /// DTO for listing persons in a summary view.
    /// </summary>
    public class PersonListDto
    {
        /// <summary>
        /// Unique identifier of the person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Last name of the person.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// First name of the person.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Vorname { get; set; } = null!;

        /// <summary>
        /// Date of birth of the person.
        /// </summary>
        [Required]
        public DateTime Geburtsdatum { get; set; }
    }
}
