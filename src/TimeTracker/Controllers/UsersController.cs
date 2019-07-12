using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Data;
using TimeTracker.Domain;
using TimeTracker.Models;

namespace TimeTracker.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly TimeTrackerDbContext _dbContext;
        private readonly ILogger<UsersController> _logger;
        public UsersController(TimeTrackerDbContext dbContext, ILogger<UsersController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(long Id)
        {
            _logger.LogInformation($"Getting user by id: {Id}");
            var user = await _dbContext.Users.FindAsync(Id);

            if(user==null)
            {
                _logger.LogWarning($"User with id: {Id} not found");
                return NotFound();
            }
            return UserModel.FromUser(user);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<UserModel>>> GetPage(int page=1, int size=5)
        {
            _logger.LogInformation($"Getting a page {page} of users with page size {size}");

            var users = await _dbContext.Users
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            var totalUsers = await _dbContext.Users.CountAsync();
            return new PagedList<UserModel>
            {
                items = users.Select(UserModel.FromUser),
                Page = page,
                PageSize = size,
                TotalCount = totalUsers
            };

        }
    }
}