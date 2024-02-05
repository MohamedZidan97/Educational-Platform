using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTeacher.Application.Features.Exams.Commends.Add;
using TopTeacher.Application.Features.Exams.Commends.Update;
using TopTeacher.Application.Features.Exams.Queries.Get;
using TopTeacher.Application.Features.Materials.Commends.Add;
using TopTeacher.Application.Features.Materials.Commends.Update;
using TopTeacher.Application.Features.Materials.Queries.GetById;
using TopTeacher.Entites.ExamsModel;
using TopTeacher.Entites.MaterialsModel;

namespace TopTeacher.Application.Profiles
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Material, MaterialsAddRequest>().ReverseMap();
            CreateMap<Material, MaterialsUpdateRequest>().ReverseMap();
            CreateMap<Material, MaterialsGetByIdResponse>().ReverseMap();
            CreateMap<Exam, ExamAddRequest>().ReverseMap();
            CreateMap<Exam, ExamGetResponse>().ReverseMap();
            CreateMap<Exam, ExamUpdateCommend>().ReverseMap();
        }
    }
}
