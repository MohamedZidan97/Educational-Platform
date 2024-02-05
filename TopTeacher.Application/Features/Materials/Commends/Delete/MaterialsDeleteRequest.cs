using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Materials.Commends.Delete
{
    public class MaterialsDeleteRequest : IRequest
    {
        public Guid MaterialId { get; set; }
    }
}
