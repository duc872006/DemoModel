using Example04.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Example04.Controllers
{
    public class MemberController : Controller
    {
        private static List<Member> members = new List<Member>
        {
            new Member
            {
                MemberId = "01",
                Username = "admin",
                Password = "123456",
                Fullname = "Nguyễn Văn An",
                Email = "an@gmail.com"
            },

            new Member
            {
                MemberId = "02",
                Username = "user01",
                Password = "123456",
                Fullname = "Trần Văn Bình",
                Email = "binh@gmail.com"
            },

            new Member
            {
                MemberId = "03",
                Username = "user02",
                Password = "123456",
                Fullname = "Lê Văn Cường",
                Email = "cuong@gmail.com"
            }
        };

        public IActionResult Index()
        {
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            members.Add(member);

            return RedirectToAction("Index");
        }

     
        public IActionResult Details(string id)
        {
            var member = members.FirstOrDefault(x => x.MemberId == id);

            return View(member);
        }

        
        public IActionResult Edit(string id)
        {
            var member = members.FirstOrDefault(x => x.MemberId == id);

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            var oldMember = members.FirstOrDefault(
                x => x.MemberId == member.MemberId
            );

            if (oldMember != null)
            {
                oldMember.Username = member.Username;
                oldMember.Password = member.Password;
                oldMember.Fullname = member.Fullname;
                oldMember.Email = member.Email;
            }

            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(string id)
        {
            var member = members.FirstOrDefault(x => x.MemberId == id);

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var member = members.FirstOrDefault(x => x.MemberId == id);

            if (member != null)
            {
                members.Remove(member);
            }

            return RedirectToAction("Index");
        }
    }
}