using BookStore.Domain.UserInfo;
using BookStore.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<Users> _repository;

        public UserController(IRepository<Users> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<Users> Add(Users user)
        {
            var result = await _repository.InsertAsync(user);
            return result;
        }
    }
}
