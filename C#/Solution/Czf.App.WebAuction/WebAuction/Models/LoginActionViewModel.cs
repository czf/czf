/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 5/7/2013
 * Time: 9:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.AuctionObjects;
using Czf.App.WebAuction.Models.InputViewModel;
using Czf.App.WebAuction;
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
		public LoginActionInputModel Input {get; set;} 
		#endregion
		
		#region Constructors
		/// <summary>
		/// Create an instance of LoginActionViewModel
		/// </summary>
		public LoginActionViewModel(User user)
		{
			Input = new LoginActionInputModel(user);
		}
		/// <summary>
		/// Create an instance of LoginActionViewModel with the passed in input
		/// </summary>
		/// <param name="input"></param>
		public LoginActionViewModel(LoginActionInputModel input)
		{
			Input = input;
		}
		#endregion
		

	}
}
