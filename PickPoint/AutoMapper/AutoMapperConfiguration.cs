﻿using AutoMapper;

namespace PickPoint.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ModelToEntityMappingProfile>();
                x.AddProfile<EntityToModelMappingProfile>();
            });
        }
    }
}
