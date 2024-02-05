using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Entites;

namespace TopTeacher.Persistance.Helper
{
    public  class FunctionsOfHelper
    {
        private readonly ApplicationDbContext dbContext;

        public FunctionsOfHelper(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AcademicYear> GetAcademic (Guid id)
        {

            return await dbContext.academicYears.Where(e => e.AcademicYearId == id).SingleOrDefaultAsync();

        }
    }
}
