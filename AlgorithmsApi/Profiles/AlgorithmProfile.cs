
using Algorithms.Dtos;
using Algorithms.Models;
using AutoMapper;

namespace Algorithms.Profiles
{
    //Profile to map our Dtos with our Api models
    public class AlgorithmProfile : Profile 
    {
        public AlgorithmProfile()
        {
            CreateMap<Algorithm, AlgorithmReadDto>();
            CreateMap<AlgorithmCreateDto, Algorithm>();
            CreateMap<AlgorithmPutDto, Algorithm>();
            CreateMap<Algorithm, AlgorithmPutDto>();
        }
    }
}