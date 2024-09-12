using Microsoft.AspNetCore.Mvc;
using PracticeOne.Entities;
using PracticeOne.Models;

namespace PracticeOne.Controllers.Home
{
    public class HomeController : Controller
    {
        static List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity{Id=1,Name="William",LastName="Shakespeare",Birthday = new DateTime(1990,5,23), Email = "william@gmail.com", IsActive = true, IsDeleted =false},
            new UserEntity{Id=2,Name="Sarah",LastName="Thompson",Birthday = new DateTime(1995,5,23), Email = "sarah@gmail.com", IsActive = true, IsDeleted =false},
            new UserEntity{Id=3,Name="James",LastName="Peterson",Birthday = new DateTime(1995,5,23), Email = "james@gmail.com", IsActive = true, IsDeleted =false},
            new UserEntity{Id=4,Name="Michael",LastName="Johnson",Birthday = new DateTime(1960,5,23), Email = "michael@gmail.com", IsActive = false, IsDeleted =false},
            new UserEntity{Id=5,Name="Emily",LastName="Richards",Birthday = new DateTime(1950,5,23), Email = "emily@gmail.com", IsActive = false, IsDeleted =true},
        };
        public IActionResult Index()
        {
            //I selected the ones that were not deleted by rotating the list with Where and with select, I equalized it to the listview and converted it to a list and sent it to the view.
            var viewModel = _users.Where(x => x.IsDeleted == false).Select(x => new UserListView 
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Birthday = x.Birthday,
                IsActive = x.IsActive,
            }).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAddViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData); //We sent the formdata with the back view to prevent the data entered from being lost in case of any problems.
            }
            int maxId = _users.Max(x => x.Id); //I got the largest id with max
            //We convert our entered data into entity
            var newUser = new UserEntity()
            {
                Id = maxId + 1,
                Name = formData.Name,
                LastName = formData.LastName,
                Birthday = formData.Birthday,
                Email = formData.Email,
            };
            _users.Add(newUser);
            return RedirectToAction("Index");
            
        }

        public IActionResult Details(int id)
        {
            var userDetail = _users.FirstOrDefault(x => x.Id == id);  
            return View(userDetail);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userEdit = _users.FirstOrDefault(x => x.Id == id);
            if(userEdit == null)
            {
                return NotFound();
            }
            var userEditModel = new UserEditViewModel()
            {
                Id = userEdit.Id,
                Name = userEdit.Name,
                LastName=userEdit.LastName,
                Birthday = userEdit.Birthday,
            };

            return View(userEditModel);
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel updateUser)
        {
            if (ModelState.IsValid)
            {
                var user = _users.FirstOrDefault(x => x.Id == updateUser.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.Name = updateUser.Name;
                user.LastName = updateUser.LastName;
                user.Birthday = updateUser.Birthday;
                return RedirectToAction("Index");
            }
            return View(updateUser);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleteUser = _users.FirstOrDefault(x=>x.Id == id);
            if (deleteUser == null)
            {
                return NotFound();
            }

            return View(deleteUser);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var confirmDelete = _users.FirstOrDefault(y => y.Id == id);
            if(confirmDelete == null)
            {
                return NotFound();
            }
            _users.Remove(confirmDelete);
            return RedirectToAction("Index");
        }

        
    }
}
