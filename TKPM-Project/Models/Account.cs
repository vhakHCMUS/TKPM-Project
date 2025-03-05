using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TKPM_Project.Models
{
    // Interface IAccount
    public interface IAccount
    {
        int Id { get; set; }
        string Username { get; set; }
        string Role { get; set; }
    }

    // Base class Account, implementing IAccount
    public class Account : IAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }  // Required for C# 11+

        [Required]
        [MaxLength(100)]
        public required string PasswordHash { get; set; }  // Required for C# 11+

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "Basic";  // Default role is "Basic"

        // List of liked features (not available for GuestAccount)
        public virtual List<string> LikedFeatures { get; set; } = new List<string>();  // Liked features for account
    }

    // PremiumAccount class, inheriting from Account
    public class PremiumAccount : Account
    {
        public DateTime PremiumExpiryDate { get; set; } // Date when premium account expires

        // Property to check if the account is still premium
        public bool IsPremium => PremiumExpiryDate > DateTime.Now;

        // Constructor automatically sets the Role to "Premium"
        public PremiumAccount()
        {
            Role = "Premium";
        }
    }

    // GuestAccount class, inheriting from Account but excluding LikedFeatures
    public class GuestAccount : Account
    {
        public DateTime GuestSessionExpiry { get; set; } // Expiry time of guest session

        // Constructor automatically sets the Role to "Guest"
        public GuestAccount()
        {
            Role = "Guest";
            Username = "Guest"; // Default guest username
            PasswordHash = string.Empty; // No password for guest accounts
        }

        // Guest accounts do not have liked features, so we hide this property
        public override List<string> LikedFeatures
        {
            get => null;  // Guest cannot have liked features
            set { /* do nothing */ }
        }

        // Property to check if guest session is still valid
        public bool IsGuestSessionValid => GuestSessionExpiry > DateTime.Now;
    }
}
