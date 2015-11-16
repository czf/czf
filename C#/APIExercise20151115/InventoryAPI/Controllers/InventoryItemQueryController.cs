using System.Web.Http;
using Czf.Domain;

namespace InventoryAPI.Controllers
{
	[RoutePrefix("InventoryItemQuery")]
    public class InventoryItemQueryController : BaseController
    {
		/// <summary>
		/// Remove the inventory item with the specificied label and creates a notification when the item is removed
		/// </summary>
		/// <param name="label">label of the InventoryItem to return</param>
		/// <returns>appropriate HTTP response code based on success, fail, error and the item removed</returns>
		[HttpPost]
		[Route("")]
		public IHttpActionResult Query(string label = null)
		{
			if (label == null)
			{
				return BadRequest("must request by label");
			}

			InventoryItem result = Repository.Get<InventoryItem>(InventoryItem.LOOKUPMETHOD_label, label);
			if (result != null)
			{
				Repository.Delete<InventoryItem>(result.Id);
				Repository.Add<Notification>("Item removed from inventory. ItemId: " + result.Id + "Label: " + result.Label);

			}

			return Ok(result);
		}
	}
}
