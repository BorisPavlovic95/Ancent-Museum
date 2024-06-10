using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static StackExchange.Redis.Role;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenService tokenService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Address = new Address
                {
                    FirstName = registerDto.Address.FirstName,
                    LastName = registerDto.Address.LastName,
                    Phone = registerDto.Address.Phone,
                    Birthday = registerDto.Address.Birthday,
                    FavoriteExhibit = registerDto.Address.FavoriteExhibit,
                    City = registerDto.Address.City
                }
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {


            var user = await _userManager.FindByEmailFromClaimsPrincipal(User);
            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName

            };
        }
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("address")]
        [Authorize]
        public async Task<ActionResult<AddressDto>> GetUserAdress()
        {


            var user = await _userManager.FindUserByClaimsPrincipaleWithAddress(User);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var user = await _userManager.FindUserByClaimsPrincipaleWithAddress(HttpContext.User);

            user.Address = _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }

        [Authorize]
        [HttpPut("update-profile")]
        public async Task<ActionResult<AddressDto>> UpdateUserProfile(UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindUserByClaimsPrincipaleWithAddress(HttpContext.User);

            // Update user properties based on the DTO
            user.DisplayName = userUpdateDto.DisplayName;

            if (userUpdateDto.Address != null)
            {
                user.Address = _mapper.Map<AddressDto, Address>(userUpdateDto.Address);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var updatedUserDto = new UserDto
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                    // Add other properties as needed
                };

                return Ok(updatedUserDto);
            }

            return BadRequest("Problem updating the user");
        }


        [HttpGet("current")]
        public async Task<ActionResult<UserWithAddressDto>> GetCurrentUserWithAddress()
        {
            var user = await _userManager.FindUserByClaimsPrincipaleWithAddress(User);



            var userWithAddressDto = new UserWithAddressDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName,
                Address = new AddressDto
                {
                    FirstName = user.Address.FirstName,
                    LastName = user.Address.LastName,
                    Phone = user.Address.Phone,
                    Birthday = user.Address.Birthday,
                    FavoriteExhibit = user.Address.FavoriteExhibit,
                    City = user.Address.City
                }
            };

            return userWithAddressDto;
        }
      






    }
}
