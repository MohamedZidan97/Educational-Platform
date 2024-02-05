using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.MaterialsModel;

namespace TopTeacher.Application.Features.Materials.Commends.Add
{
    public class MaterialsAddHandler : IRequestHandler<MaterialsAddRequest, MaterialsAddResponse>
    {
        private readonly IBaseRepositories<Material> baseRep;
        private readonly IMapper mapper;

        public MaterialsAddHandler(IBaseRepositories<Material> baseRep,IMapper mapper)
        {
            this.baseRep = baseRep;
            this.mapper = mapper;
        }

        public async Task<MaterialsAddResponse> Handle(MaterialsAddRequest request, CancellationToken cancellationToken)
        {
            var lesson = mapper.Map<Material>(request);
           
            await baseRep.AddAsync(lesson);

            var response = new MaterialsAddResponse() { Success = true };

            return response;
        }
    }
}
