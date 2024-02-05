﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Account
{
    public class AccountResponse
    {
        public string? Message { get; set; }
        public bool IsAuthenticed { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public List<string>? Roles { get; set; }

        public string? Token { get; set; }

        public DateTime? ExpiresOn { get; set; }

       // [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set;}

    }
}
