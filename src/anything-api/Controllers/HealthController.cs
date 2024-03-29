﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace anything_api.Controllers;

[Route("/")]
[ApiController]
public class HealthController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("I'm live 🚀");
    }
}