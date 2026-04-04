using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AlphaFleet.Common.EntityValidation;
namespace AlphaFleet.Data.Models
{
    public class Station
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(StationNameMinLength)]
        [MaxLength(StationNameMaxLength)]
        public string Name { get; set; }
        [Required]
        [MinLength(StationLocationMinLength)]
        [MaxLength(StationLocationMaxLength)]
        public string Location { get; set; }
        [Required]
        [MinLength(StationDescriptionMinLength)]
        [MaxLength(StationDescriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        [Range(StationHealthMinValue, StationHealthMaxValue)]
        public int Health { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDestroyed { get; set; } = false;
    }
}
