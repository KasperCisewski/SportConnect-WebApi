﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportConnect.Infrastructure.Services.Abstraction;

namespace SportConnect.Api.Controllers
{
    [Route("api/sportEvent")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly ISportEventService _sportEventService;

        public SportEventController(ISportEventService sportEventService)
        {
            _sportEventService = sportEventService;
        }
    }
}