using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RailRay.API.Data;
using RailRay.API.Models.Domain;
using RailRay.API.Models.DTOs;

namespace RailRay.API.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class UserController : ControllerBase
    {
        private readonly RailRayDbContext dbContext;
        public UserController(RailRayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET to get all users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = dbContext.Users.ToList();
            var userDtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                Title = u.Title,
                FirstName = u.FirstName,
                LastName = u.LastName,
               
            });

            return Ok(userDtos);

        }

        //POST register a new user
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequestDto registerUserRequestDto)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.Email == registerUserRequestDto.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already registered.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Title = registerUserRequestDto.Title,
                FirstName = registerUserRequestDto.FirstName,
                LastName = registerUserRequestDto.LastName,
                Email = registerUserRequestDto.Email,
                Password = registerUserRequestDto.Password,
                NIC = registerUserRequestDto.NIC,
                Passport = registerUserRequestDto.Passport,
                PhoneNumber = registerUserRequestDto.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow

            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var userDto = new UserDto
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, userDto);
        }


        // POST: Login
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = dbContext.Users.FirstOrDefault(u =>
                u.Email == loginRequestDto.Email && u.Password == loginRequestDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };
            return Ok(userDto);

        }

        //GET user by Id
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }


            var userDto = new UserDto
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };
            return Ok(userDto);
        }


    }
}
