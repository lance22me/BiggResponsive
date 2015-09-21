using System.Web.Mvc;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Utilities;
using System.Collections.Generic;
using BiggResponsive.Domain.Extensions;
using BiggResponsive.Domain.Viewmodels;

namespace BiggResponsive.Controllers
{
	public class ElementaryController : Controller
	{
		private readonly IGroupService groupService;
   
		public ElementaryController(IGroupService groupService)
		{
			this.groupService = groupService;
		}

		[HttpGet]
		public ActionResult BasicGetData()
		{
			return PartialView("_BasicGetData");
		}
        public ActionResult GridWithGoodies()
		{
			return PartialView("_GridWithGoodies");
		}

		[HttpGet]
		public ActionResult BasicFiltering()
		{
			return PartialView("_BasicFiltering");
		}

		[HttpGet]
		public ActionResult BasicForm()
		{
			return PartialView("_BasicForm");
		}

		[HttpGet]
		public ActionResult ExternalFile()
		{
			return PartialView("_ExternalFile");
		}

		[HttpGet]
		public ActionResult FormInputMasks()
		{
			return PartialView("_FormInputMasks");
		}

		[HttpGet]
		public ActionResult FormWithEditDelete()
		{
			return PartialView("_FormWithEditDelete");
		}

		[HttpGet]
		public ActionResult FormWithModal()
		{
			return PartialView("_FormWithModal");
		}

		[HttpGet]
		public ActionResult FormWithNestedObjects()
		{
			return PartialView("_FormWithNestedObjects");
		}

		[HttpGet]
		public ActionResult LocalStorage()
		{
			return PartialView("_LocalStorage");
		}

		[HttpGet]
		public ActionResult Pagination()
		{
			return PartialView("_Pagination");
		}


		/// <summary>
		/// Add new groups.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult GroupCreate()
		{
			return PartialView("_GroupCreate");
		}

		/// <summary>
		/// Add people to existing groups
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult GroupManager()
		{
			return PartialView("_GroupManager");
		}

		// Going through a 'normal' MVC controller because the 'Group' demos require SessionState
		// which is not aviable in the WebAPI/REST services.

		public ActionResult AddGroup(Group group)
		{
			Guard.ArgumentNotNull(group, "Group");

			var groups = this.groupService.Add(group); // will return a refreshed list of groups.
			return this.Json(groups, JsonRequestBehavior.AllowGet).AsCamelCaseResolverResult();
		}

		public JsonResult GetAllGroups()
		{
			var groups = this.groupService.GetAll();
			return this.Json(groups, JsonRequestBehavior.AllowGet).AsCamelCaseResolverResult(); ;
		}

		/// <summary>
		/// IN PROGRESS
		/// </summary>
		/// <returns></returns>
		public ActionResult AddPersonToGroup(GroupPerson groupPerson)
		{
			Guard.ArgumentNotNull(groupPerson.SelectedGroup, "SelectedGroup");
			Guard.ArgumentNotNull(groupPerson.SelectedMember, "SelectedMember");

			var refreshedGroup = this.groupService.ToggleGroupMember(groupPerson.SelectedGroup, groupPerson.SelectedMember);

			return this.Json(string.Empty, JsonRequestBehavior.AllowGet).AsCamelCaseResolverResult(); ;
		}

	}
}