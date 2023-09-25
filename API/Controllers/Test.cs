using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Test : BaseApiController
    {
        [HttpGet("Test")]
       public Task<string> test()
{
    string hello = "hello world!";
    return Task.FromResult(hello);
}
    }
}