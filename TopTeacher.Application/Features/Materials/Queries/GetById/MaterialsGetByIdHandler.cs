using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.MaterialsModel;
using TopTeacher.Entites;

namespace TopTeacher.Application.Features.Materials.Queries.GetById
{
    public class MaterialsGetByIdHandler : IRequestHandler<MaterialsGetByIdRequest, MaterialsGetByIdResponse>
    {
        private readonly IBaseRepositories<Material> baseRep;
        private readonly IBaseRepositories<AcademicYear> baseAcademicRep;
        private readonly IBaseRepositories<TypeOfMaterial> baseTypesRep;
        private readonly IMapper mapper;

        public MaterialsGetByIdHandler(IBaseRepositories<Material> baseRep, IBaseRepositories<AcademicYear> baseAcademicRep, IBaseRepositories<TypeOfMaterial> baseTypesRep, IMapper mapper)
        {
            this.baseRep = baseRep;
            this.baseAcademicRep = baseAcademicRep;
            this.baseTypesRep = baseTypesRep;
            this.mapper = mapper;
        }
        public async Task<MaterialsGetByIdResponse> Handle(MaterialsGetByIdRequest request, CancellationToken cancellationToken)
        {
            var material = await baseRep.GetByIdAsync(request.MaterialId);

            var typeFile = await baseTypesRep.GetByIdAsync(material.TypeOfMaterialId);

            var academicYear = await baseAcademicRep.GetByIdAsync(material.AcademicYearId);

           var response =  mapper.Map<MaterialsGetByIdResponse>(material);

            response.TypeOfMaterial = typeFile.Name;
            response.AcademicYear = academicYear.Name;


            return response;


        }
    }
}
