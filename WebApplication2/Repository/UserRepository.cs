using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
	
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
            _httpContextAccessor = httpContextAccessor;
        }
		public bool Add(AppUser user)
		{
			throw new NotImplementedException();
		}

		public bool Delete(AppUser user)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<AppUser>> GetAllUsers()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<AppUser> GetUserById(string id)
		{
			return await _context.Users.FindAsync(id);
		}
		public async Task<AppUser> GetByIdNoTracking(string id)
		{
			return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(AppUser user)
		{
			_context.Update(user);
			return Save();
  		}
		public async Task<List<Club>> GetAllUserClubs(string id)
		{
			var userClubs = _context.Clubs.Where(r => r.appUser.Id == id);
			return userClubs.ToList();
		}
		public async Task<List<Race>> GetAllUserRaces(string id)
		{
			var userRaces = _context.Races.Where(r => r.AppUser.Id == id);
			return userRaces.ToList();
		}
	}
}
