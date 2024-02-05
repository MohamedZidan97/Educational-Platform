using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.MaterialsModel
{
    public class Material
    {
        public Guid MaterialId { get; set; }
        public string Name { get; set; }

        public string Term { get; set; }

        public string Unit { get; set; }

        public string Lesson { get; set; }
        public DateTime CreatedDate { get; set; }

        //public string FileUrl { get; set; }
        public Guid TypeOfMaterialId { get; set; }
        public TypeOfMaterial TypesOfMaterials { get; set; }


        public Guid AcademicYearId { get; set; }
        public AcademicYear AcademicsYears { get; set; }


        public Material()
        {
            MaterialId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

    }
}
