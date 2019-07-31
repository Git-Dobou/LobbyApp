using App.Models;

namespace App.Services {
    public interface ILoginService {
        Member CurrentMember { get; set; }
        bool CheckLogin (string passWord, string passwordHash);
    }
}