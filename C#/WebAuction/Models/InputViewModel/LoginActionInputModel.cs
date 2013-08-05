/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 8/4/2013
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Czf.App.WebAuction.Models.InputViewModel
{
	/// <summary>
	/// Description of LoginActionInputModel.
	/// </summary>
	public class LoginActionInputModel
	{
		#region Properties
		/// <summary>
		/// gets or sets the UserId 
		/// </summary>
		public int? UserId {get; set;} 
		
		#endregion
		#region Constructor
		/// <summary>
		/// constructor 
		/// </summary>
		public LoginActionInputModel()
		{		}
		#endregion
		
				
		#region Methods
		/// <summary>
		/// Populates the InputModel with the passed in values
		/// </summary>
		/// <param name="userId">the user id</param>
		public void PopulateInput(int? userId)
		{
			UserId = userId;
		}
		
		/// <summary>
		/// Determins if the supplied inputmodel is valid
		/// </summary>
		/// <returns>true if the input model is in an acceptable state, otherwise false</returns>
		public bool CheckValidity()
		{
			bool result = false;
			result = UserId.HasValue;
			return result;
		}
		
		#endregion
	}
}
