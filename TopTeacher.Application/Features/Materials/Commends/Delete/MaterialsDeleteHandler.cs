using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Interfaces;
using TopTeacher.Entites.MaterialsModel;

namespace TopTeacher.Application.Features.Materials.Commends.Delete
{
    public class MaterialsDeleteHandler : IRequestHandler<MaterialsDeleteRequest>
    {
        private readonly IBaseRepositories<Material> baseRep;

        public MaterialsDeleteHandler(IBaseRepositories<Material> baseRep)
        {
            this.baseRep = baseRep;
        }
        public async Task Handle(MaterialsDeleteRequest request, CancellationToken cancellationToken)
        {
            await baseRep.DeleteAsync(request.MaterialId);
        }
    }
}
