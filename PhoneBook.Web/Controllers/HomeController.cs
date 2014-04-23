using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hik.PhoneBook.Data;
using Hik.PhoneBook.Data.Entities;
using Hik.PhoneBook.Data.Repositories;
using Hik.PhoneBook.Services;

namespace Hik.PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPhoneService _phoneService;
        private readonly ICityService _cityService;

        public HomeController(IPersonService personService, ICityService cityService, IPhoneService phoneService)
        {
            _personService = personService;
            _cityService = cityService;
            _phoneService = phoneService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PeopleList()
        {
            try
            {
                var personList = _personService.GetPeopleList();
                return Json(new { Result = "OK", Records = personList });
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", Message = ex.Message});
            }
        }

        public JsonResult CityList()
        {
            try
            {
                var cityList = _cityService.GetCityList().Select(c => new { DisplayText = c.Name, Value = c.Id });
                return Json(new { Result = "OK", Options = cityList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult CreatePerson(Person person)
        {
            try
            {
                _personService.CreatePerson(person);
                return Json(new { Result = "OK", Record = person });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult UpdatePerson(Person person)
        {
            try
            {
                _personService.UpdatePerson(person);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult DeletePerson(int id)
        {
            try
            {
                _personService.DeletePerson(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult PhoneList(int personId)
        {
            try
            {
                var personList = _phoneService.GetPhoneListOfPerson(personId);
                return Json(new { Result = "OK", Records = personList });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult CreatePhone(Phone phone)
        {
            try
            {
                _phoneService.CreatePhone(phone);
                return Json(new { Result = "OK", Record = phone });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult UpdatePhone(Phone phone)
        {
            try
            {
                _phoneService.UpdatePhone(phone);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult DeletePhone(int id)
        {
            try
            {
                _phoneService.DeletePhone(id);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}
