using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet]
        public async  Task<ActionResult<IEnumerable<MemberDTO>>>GetUsers(){
            var users = await userRepository.GetUsersAsync();

            var usersToReturn = mapper.Map<IEnumerable<MemberDTO>>(users);

            return Ok(usersToReturn);
            
        }

       
        [HttpGet("{UserName}")]
        public async  Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            var user = await userRepository.GetUserByUserNameAsync(username);

            return mapper.Map<MemberDTO>(user);
        }

    }
}