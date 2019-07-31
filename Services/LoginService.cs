using App.Interfaces;
using App.Models;

namespace App.Services {
    public class LoginService : ILoginService {
        private Member currentMember;
        public Member CurrentMember { get => currentMember; set => currentMember = value; }
        private readonly IMemberService _memberService;

        public LoginService (IMemberService memberService) {
            _memberService = memberService;
        }
        public bool CheckLogin (string passWord, string passwordHash) => SecurePasswordHasher.Verify (passWord, passwordHash);

    }
}