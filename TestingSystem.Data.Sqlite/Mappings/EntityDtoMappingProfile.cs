
using AutoMapper;
using TestingSystem.Data.Sqlite.Entities;
using TestingSystem.Core.DTOs;

namespace TestingSystem.Data.Sqlite.Mappings
{
    public class EntityDtoMappingProfile : Profile
    {
        public EntityDtoMappingProfile() 
        {
            CreateMap<TestEntity, TestDataDto>().ReverseMap();
            CreateMap<TestEntity, TestProfileDto>().ReverseMap();

            CreateMap<QuestionEntity, QuestionDto>().ReverseMap();
            CreateMap<AnswerOptionEntity, AnswerOptionDto>().ReverseMap();
            CreateMap<ScoreEntity, ScoreDto>().ReverseMap();
            CreateMap<VectorEntity, VectorDto>().ReverseMap();
            CreateMap<VectorScoreEntity, VectorScoreDto>().ReverseMap();
            
            CreateMap<UserEntity, UserDataDto>().ReverseMap();
            CreateMap<UserEntity, UserProfileDto>().ReverseMap();
            CreateMap<UserEntity, UserLoginDto>().ReverseMap();
            CreateMap<UserEntity, UserRegisterDto>().ReverseMap();

            //CreateMap<TestEntity, TestDataDto>().ReverseMap();
            //CreateMap<TestEntity, TestDataDto>().ReverseMap();
        }
    }
}
