using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTeacher.Application.Features.Materials.Queries.Get
{
    public class MaterialsGetRequest : IRequest<IEnumerable<MaterialsGetResponse>>
    {
        //not found any colums to send it
    }
}
