using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
		{
			_userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
			{
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                    ProfileImageUrl = user.ProfileImageUrl,

                };
                result.Add(userViewModel);
			}
            return View(result);
        }
        public async Task<IActionResult> Detail(string id)
		{
            var userRaces = await _userRepository.GetAllUserRaces(id);
            var userClubs = await _userRepository.GetAllUserClubs(id);
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Mileage,
                ProfileImageUrl= user.ProfileImageUrl,
                Clubs = userClubs,
                Races = userRaces,
            };
            return View(userDetailViewModel);
		}
    }
}
