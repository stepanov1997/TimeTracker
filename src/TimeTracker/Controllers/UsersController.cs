using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            if (user == null)
            {
                _logger.LogWarning($"User with id: {Id} not found");
                return NotFound();
            }

            return UserModel.FromUser(user);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<UserModel>>> GetPage(int page = 1, int size = 5)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(long Id)
        {
            _logger.LogInformation($"Deleting user by id: {Id}");
            var user = await _dbContext.Users.FindAsync(Id);

            if (user == null)
            {
                _logger.LogWarning($"User with id: {Id} not found");
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create(UserInputModel model)
        {
            _logger.LogInformation($"Creating a new user with name {model.Name}");

            var user = new User();
            model.MapTo(user);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var resultModel = UserModel.FromUser(user);

            return CreatedAtAction(nameof(GetById), "users", new {id = user.Id}, resultModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update(long id, UserInputModel model)
        {
            _logger.LogInformation($"Updating user with id {id}");
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                _logger.LogWarning($"User with id: {id} not found");
                return NotFound();
            }

            model.MapTo(user);

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return UserModel.FromUser(user);
        }
    }
}