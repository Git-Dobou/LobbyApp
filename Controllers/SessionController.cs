using System.Collections.Generic;
using App.Interfaces;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Session> GetAllSessions()
        {            
            return _sessionService.Sessions;
        }
    }
}
