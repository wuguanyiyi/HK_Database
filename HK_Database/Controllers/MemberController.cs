using HK_Database.Data;
using HK_Database.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HK_Database.Controllers
{
    public class MemberController : Controller
    {
        private readonly HKContext _context;
        public MemberController(HKContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var member = _context.Member.Select(x => 
                new AllMemberViewModel {
                    MemberName = x.MemberName,
                    MemberEmail = x.MemberEmail,
                    MemberPhone = x.MemberPhone,
                    MemberAccount = x.MemberAccount,
                    MemberPassword = x.MemberPassword}
                );
            return View(member.ToList());
        }
    }
}
