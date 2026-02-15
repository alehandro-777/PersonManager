using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonManager.API.DTO
{
    /// <summary>
    /// DTO for detailed information about a person, including addresses and phone numbers.
    /// </summary>
    public class PersonDetailDto
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

        /// <summary>
        /// List of addresses associated with the person.
        /// </summary>
        public List<AnschriftDto> Anschriften { get; set; } = new();

        /// <summary>
        /// List of phone numbers associated with the person.
        /// </summary>
        public List<TelefonverbindungDto> Telefonnummern { get; set; } = new();
    }
}
