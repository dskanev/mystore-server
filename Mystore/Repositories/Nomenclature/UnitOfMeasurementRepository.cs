﻿using AutoMapper;
using Common.Services;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Nomenclature
{
    public class UnitOfMeasurementRepository : DataService<UnitOfMeasurement>, IUnitOfMeasurementRepository
    {
        private readonly IMapper mapper;

        public UnitOfMeasurementRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        public IQueryable<UnitOfMeasurement> GetAll()
            => this.All();

        public async Task<Result> SaveAsync(UnitOfMeasurement unit)
        {
            try
            {
                if (unit.Description == null || unit.Description == "")
                {
                    return Result.Failure("Unit description is required.");
                }

                await this.Data.AddAsync(unit);
                await this.Data.SaveChangesAsync();

                return Result.Success;
            }
            catch(Exception e)
            {
                return Result.Failure(e.Message);
            }            
        }
    }
}
