﻿using Microsoft.AspNetCore.Identity;

namespace BZ2KMT_SOF_2023231.Models
{
    public class SiteUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
