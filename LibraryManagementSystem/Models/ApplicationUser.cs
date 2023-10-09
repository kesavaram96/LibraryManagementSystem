﻿using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
    }
}
