using System.ComponentModel.DataAnnotations;

namespace PersonManager.API.DTO
{
    /// <summary>
    /// DTO representing a phone number of a person.
    /// </summary>
    public class TelefonverbindungDto
    {
        /// <summary>
        /// Unique identifier of the phone record.
        /// </summary>
        public int TelefonverbindungId { get; set; }

        /// <summary>
        /// Phone number of the person.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Nummer { get; set; } = null!;
    }
}
