using System.ComponentModel.DataAnnotations;

namespace PersonManager.API.DTO
{
    /// <summary>
    /// DTO for updating basic person information.
    /// </summary>
    public class PersonUpdateDto
    {
        /// <summary>
        /// Last name of the person.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// First name of the person.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Vorname { get; set; } = null!;
    }
}
