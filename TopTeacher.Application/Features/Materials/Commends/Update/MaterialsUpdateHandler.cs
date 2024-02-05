using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.MaterialsModel;

namespace TopTeacher.Application.Features.Materials.Commends.Update
{
    public class MaterialsUpdateHandler : IRequestHandler<MaterialsUpdateRequest>
    {
        private readonly IBaseRepositories<Material> baseRep;
        private readonly IMapper mapper;

        public MaterialsUpdateHandler(IBaseRepositories<Material> baseRep, IMapper mapper )
        {
            this.baseRep = baseRep;
            this.mapper = mapper;
        }
        public async Task Handle(MaterialsUpdateRequest request, CancellationToken cancellationToken)
        {
            var update = mapper.Map<Material>(request);

            await baseRep.UpdateAsync(update);
        }
    }
}
