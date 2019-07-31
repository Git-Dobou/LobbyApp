using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Interfaces;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers {
    [Route ("api/[controller]")]
    public class MemberController : Controller {
        private readonly IMemberService _memberService;
        public MemberController (IMemberService memberService) {
            _memberService = memberService;
        }

        [HttpGet ("[action]")]
        public IEnumerable<Member> GetAllMembers () {
            return _memberService.Members;
        }

        [HttpPost ("[action]")]
        public void RegisterMember ([FromBody] Member member) {
            _memberService.RegisterMember (member);
        }
    }
}