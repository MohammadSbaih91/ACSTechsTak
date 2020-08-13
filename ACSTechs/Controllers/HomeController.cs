using ACSTechs.BLL;
using ACSTechs.Common.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACSTechs.Controllers
{
    public class HomeController : Controller
    {
        private UsersBusinessLogic _UsersBusinessLogic;

        public HomeController()
        {
            _UsersBusinessLogic = new UsersBusinessLogic();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddUsers()
        {
            var Users = _UsersBusinessLogic.GetUsers();
            UsersDTO dto = new UsersDTO();
            dto.Users = Users;


            return View(dto);
        }


        [HttpPost]
        public ActionResult AddUsers(FormCollection formData)
        {
            var list = formData["CreateTextbox"].ToString();
            string[] usersList = list.Split(',');
            var users = new List<UsersDTO>();

            foreach (string user in usersList)
            {
                users.Add(new UsersDTO()
                {
                    Usrename = user,
                });
            }


            _UsersBusinessLogic.AddUsers(users);

            return RedirectToAction("AddUsers");
        }

        [HttpPost]
        public ActionResult UpdateInfo(FormCollection formData)
        {
            var list = formData["item.Id"].ToString();
            var Namelist = formData["item.Usrename"].ToString();
            string[] usersIdList = list.Split(',');
            string[] usersNameList = Namelist.Split(',');
            string[][] usersarray = new string[][] { usersIdList, usersNameList };

            var users = new List<UsersDTO>();

            for (int size = 0; size < usersarray[0].Length; size++)
            {
               

                    users.Add(new UsersDTO()
                    {
                        Id = Convert.ToInt32(usersarray[0][size]),
                        Usrename = usersarray[1][size].ToString(),
                    });

            }

          bool isUpdated=_UsersBusinessLogic.EditUsers(users);





            return RedirectToAction("AddUsers");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}