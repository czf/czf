using System.Collections.Specialized;
using System.Web.Http;
using Czf.Domain.Interfaces;
using Czf.Repositories;
namespace InventoryAPI.Controllers
{
	public abstract class BaseController : ApiController
    {
		private static IRepository _repository = new InMemoryRepository();

		/// <summary>
		/// Repository for this API
		/// </summary>
		public IRepository Repository
		{
			get
			{
				return BaseController.GetRepository();
			}
		}
		
		/// <summary>
		/// Adds the errors to the modelstate
		/// </summary>
		/// <param name="errors">errors to add to the modelstate</param>
		protected void CopyErrorsToModelState(NameValueCollection errors)
		{
			if (errors != null)
			{
				foreach (string key in errors)
				{
					ModelState.AddModelError(key, errors[key]);
				}
			}
		}

		/// <summary>
		/// Repository to use for the api
		/// </summary>
		/// <returns></returns>
		public static IRepository GetRepository()
		{
			return _repository;
		}
	}
}
