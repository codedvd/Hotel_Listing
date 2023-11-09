﻿using Microsoft.AspNetCore.Identity;

namespace Hotel_Listing.api.Models
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
