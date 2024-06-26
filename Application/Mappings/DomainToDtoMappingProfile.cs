﻿using Application.Dto;
using AutoMapper;
using Domain.Entity;

namespace Application.Mappings;

public class DomainToDtoMappingProfile : Profile{
    public DomainToDtoMappingProfile() {
        CreateMap<TodoTask, TodoTaskDto>().ReverseMap();
        CreateMap<TodoTaskDto, TodoTask>().ReverseMap();
        CreateMap<UpdateTodoTaskDto, TodoTask>().ReverseMap();
        CreateMap<UpdateTodoTaskDto, TodoTask>().ReverseMap();
    }
}