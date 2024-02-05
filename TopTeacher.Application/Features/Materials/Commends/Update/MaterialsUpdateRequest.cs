using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Entites.MaterialsModel;
using TopTeacher.Entites;

namespace TopTeacher.Application.Features.Materials.Commends.Update
{
    public class MaterialsUpdateRequest : IRequest
    {
        public Guid MaterialId { get; set; }

        public string Name { get; set; }

        public string Term { get; set; }

        public string Unit { get; set; }

        public string Lesson { get; set; }

        //public string FileUrl { get; set; }
        public Guid TypeOfMaterialId { get; set; }
        //public TypeOfMaterial TypesOfMaterials { get; set; }


        public Guid AcademicYearId { get; set; }
        //public AcademicYear AcademicsYears { get; set; }
    }
}
