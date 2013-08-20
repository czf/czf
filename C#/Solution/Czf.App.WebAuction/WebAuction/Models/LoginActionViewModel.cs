/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/7/2013
 * Time: 9:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.App.WebAuction.Models.InputViewModel;
namespace Czf.App.WebAuction.Models
{
	/// <summary>
	/// Data pertaining to login.
	/// </summary>
	public class LoginActionViewModel
	{
		#region Properties
		/// <summary>
		/// Gets or sets the Input
		/// </summary>
		LoginActionInputModel Input {get; set;} 
		#endregion
		
		#region Constructors
		public LoginActionViewModel()
		{
			Input = new LoginActionInputModel();
		}
		#endregion
		

	}
}
