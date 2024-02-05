using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Entites.MaterialsModel
{
    public class TypeOfMaterial
    {
        public Guid TypeOfMaterialId { get; set; }

        public string Name { get; set; }

        public ICollection<Material> Materials { get; set;}


    }
}
