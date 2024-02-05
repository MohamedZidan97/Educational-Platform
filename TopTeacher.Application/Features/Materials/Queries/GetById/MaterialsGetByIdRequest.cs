using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Materials.Queries.GetById
{
    public class MaterialsGetByIdRequest : IRequest<MaterialsGetByIdResponse>
    {
        public Guid MaterialId { get; set; }
    }
}
