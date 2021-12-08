using AutoMapper;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using Mystore.Api.Data;
using Mystore.Api.Data.Models.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Repositories.Identity
{
    public class UserDetailsRepository : DataService<UserDetails>, IUserDetailsRepository
    {
        private readonly IMapper mapper;

        public UserDetailsRepository(IdentityDbContext db, IMapper mapper)
        : base(db)
            => this.mapper = mapper;

        public async Task<Result<UserDetails>> SaveUserDetails(UserDetails userDetails)
        {
            var existingDetails = await GetByUserId(userDetails.UserId);

            if (existingDetails != default)
            {
                existingDetails.LastName = userDetails.LastName ?? existingDetails.LastName;
                existingDetails.FirstName = userDetails.FirstName ?? existingDetails.FirstName;
                existingDetails.CityId = userDetails.CityId != default ? userDetails.CityId : existingDetails.CityId;
                existingDetails.PhoneNumber = userDetails.PhoneNumber ?? existingDetails.PhoneNumber;

                await this.Data.SaveChangesAsync();
                return Result<UserDetails>.SuccessWith(existingDetails);
            }
            else
            {
                await this.Data.AddAsync(userDetails);
                await this.Data.SaveChangesAsync();
                return Result<UserDetails>.SuccessWith(userDetails);
            }
        }

        public async Task<UserDetails> GetByUserId(string userId)
        =>  await this
            .All()
            .Where(x => x.UserId == userId)
            .Include(x => x.City)
            .FirstOrDefaultAsync();

        public async Task<long> GetDetailsIdForUser(string userId)
        => await this
            .All()
            .Where(x => x.UserId == userId)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();
    }
}
