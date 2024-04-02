using EFcoreApp;
using EFcoreApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace writeonceApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserDetailController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserDetailController> _logger;
        private readonly IUnitOfWork _unitOfWork;
       

        public UserDetailController(ILogger<UserDetailController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            
        }

        [HttpGet(Name = "GetUser")]
        public async Task<IEnumerable<User>> Get()
        {

            var user = await _unitOfWork.Users.GetByIdAsync(1);

            return Enumerable.Range(1, 5).Select(index => new User
            {
                Name = user.Name
            })
            .ToArray();
        }
    }
}
