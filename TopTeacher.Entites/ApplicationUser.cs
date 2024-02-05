using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
      
        public string PhoneNumberOfStudentGuardian { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public bool IsOnline { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}
