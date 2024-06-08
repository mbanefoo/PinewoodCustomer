using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PinewoodCustomer.Shared.Models
{
    public class Customer
    {
        public int id { get; set; }
        [JsonPropertyName("firstname")]
        [Required]
        public string? firstName { get; set; }
        [Required]
        [JsonPropertyName("lastname")]
        public string? lastName { get; set; } 
        public string? gender { get; set; }
        [EmailAddress]
        public string? email { get; set; } 
        public string? phone { get; set; } 
        [JsonPropertyName("address")]
        public string? address { get; set; }
        public string? city { get; set; } 
        public string? county { get; set; }
        [JsonPropertyName("postcode")]
        public string? postCode { get; set; } 
        public string? country { get; set; } 

    }
}
