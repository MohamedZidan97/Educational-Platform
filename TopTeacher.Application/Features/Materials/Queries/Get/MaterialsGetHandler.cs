using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites;
using TopTeacher.Entites.MaterialsModel;

namespace TopTeacher.Application.Features.Materials.Queries.Get
{
    public class MaterialsGetHandler : IRequestHandler<MaterialsGetRequest, IEnumerable<MaterialsGetResponse>>
    {
        private readonly IBaseRepositories<Material> baseRep;
        private readonly IBaseRepositories<AcademicYear> baseAcademicRep;
        private readonly IBaseRepositories<TypeOfMaterial> baseTypesRep;
        private readonly IMapper mapper;

        public MaterialsGetHandler(IBaseRepositories<Material> baseRep, IBaseRepositories<AcademicYear> baseAcademicRep, IBaseRepositories<TypeOfMaterial> baseTypesRep, IMapper mapper)
        {
            this.baseRep = baseRep;
            this.baseAcademicRep = baseAcademicRep;
            this.baseTypesRep = baseTypesRep;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MaterialsGetResponse>> Handle(MaterialsGetRequest request, CancellationToken cancellationToken)
        {
            var allMaterials = await baseRep.GetAllAsync();
            var allTypesOfMaterials = await baseTypesRep.GetAllAsync();
            var allAcademicYears = await baseAcademicRep.GetAllAsync();
            var response = from M in allMaterials
                           join T in allTypesOfMaterials
                           on M.TypeOfMaterialId equals T.TypeOfMaterialId
                           join A in allAcademicYears
                           on M.AcademicYearId equals A.AcademicYearId
                           select new MaterialsGetResponse
                           {
                               TypeOfMaterialId = M.TypeOfMaterialId,
                               AcademicYearId = M.AcademicYearId,
                               Lesson = M.Lesson,
                               Name = M.Name,
                               Term = M.Term,
                               Unit = M.Unit,
                               TypeOfMaterial = T.Name,
                               AcademicYear = A.Name

                           };
            return response.ToList();
        }
    }
}
