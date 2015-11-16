using System.Collections.Specialized;
using System.Web.Http;
using Czf.Domain;
using Czf.Domain.InputModel;
namespace InventoryAPI.Controllers
{
	/// <summary>
	/// Actions relating to an InventoryItem
	/// </summary>
	[RoutePrefix("InventoryItem")]
	public class InventoryItemController : BaseController
	{ 
		/// <summary>
		/// Add new InventoryItems
		/// </summary>
		/// <param name="inputModel">data of the new item</param>
		/// <returns>appropriate HTTP response code based on success, fail, error</returns>
		[HttpPost]
		[Route("")]
		public IHttpActionResult Post(InventoryItemInputModel inputModel)
		{
			NameValueCollection errors = null;
	
			if(inputModel == null )
			{
				errors = new NameValueCollection();
				errors.Add("input", "Can't be null");
				CopyErrorsToModelState(errors);
			}
			else if ((errors = inputModel.CheckValidity()).Count > 0)
			{
				CopyErrorsToModelState(errors);
			}
			else
			{
				InventoryItem result = Repository.Add<InventoryItem>(inputModel);

				return Ok(result);
			}

			return BadRequest(ModelState);
			
		}
	}
}
