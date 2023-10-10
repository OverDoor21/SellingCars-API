using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository userRepository;
        public readonly IMapper mapper;
        
        
        
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
           
        }

        [AllowAnonymous]
        [HttpGet]
        public async  Task<ActionResult<IEnumerable<MemberDTO>>>GetUsers(){
            var users = await userRepository.GetMembersAsync();
            return Ok(users);
        }

       
        [HttpGet("{UserName}")]
        public async  Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            return await userRepository.GetMemberAsync(username);
        }

    }
}