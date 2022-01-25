using AutoMapper;
using Common.Services;
using Common.Services.Identity;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data;
using Mystore.Api.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Identity
{
    public class UserDetailsRepository : DataService<User>, IUserDetailsRepository
    {
        private readonly IMapper mapper;

        public UserDetailsRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<Result<User>> SaveUserDetails(UserDetailsInputModel userDetails)
        {
            var existingDetails = await GetByUserId(userDetails.Id);

            if (existingDetails != default)
            {
                existingDetails.LastName = userDetails.LastName ?? existingDetails.LastName;
                existingDetails.FirstName = userDetails.FirstName ?? existingDetails.FirstName;
                existingDetails.CityId = userDetails.CityId != default ? userDetails.CityId : existingDetails.CityId;
                existingDetails.PhoneNumber = userDetails.PhoneNumber ?? existingDetails.PhoneNumber;

                await this.Data.SaveChangesAsync();
                return Result<User>.SuccessWith(existingDetails);
            }
            return Result<User>.Failure("Bad Request.");
        }

        public async Task<User> GetByUserId(string userId)
        =>  await this
            .All()
            .Where(x => x.Id == userId)
            .Include(x => x.City)
            .FirstOrDefaultAsync();        
    }
}
