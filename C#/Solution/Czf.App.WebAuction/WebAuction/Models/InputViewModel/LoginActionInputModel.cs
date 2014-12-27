/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 8/4/2013
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Interfaces.Consumers;
using Czf.Domain.Interfaces.Sources;
using Czf.Domain.AuctionObjects;
using Czf.Util.Common;
namespace Czf.App.WebAuction.Models.InputViewModel
{
	/// <summary>
	/// Description of LoginActionInputModel.
	/// </summary>
	public class LoginActionInputModel: IAuctionSourceConsumer
	{
		#region Properties
		/// <summary>
		/// gets or sets the UserId 
		/// </summary>
		public string UserId {get; set;} 

		/// <summary>
		/// a reference to the AuctionSource
		/// </summary>
		public IAuctionSource AuctionSource { get; set;}
		
		/// <summary>
		/// Resulting user from checking validity 
		/// </summary>
		public User SubmittedUser { get; protected set; }
		#endregion
		#region Constructor
		/// <summary>
		///  Create an instance of LoginActionInputModel
		/// </summary>
		public LoginActionInputModel(){}
		
		/// <summary>
		///  Create an instance of LoginActionInputModel 
		/// </summary>
		public LoginActionInputModel(User user)
		{		
			if(user != null)
			{
				UserId = user.UserName;
			}
		}
		#endregion
		
				
		#region Methods
		/// <summary>
		/// Populates the InputModel with the passed in values
		/// </summary>
		/// <param name="userId">the user id</param>
		public void PopulateInput(string userId)
		{
			UserId = userId;
		}
		
		/// <summary>
		/// Determins if the supplied inputmodel is valid
		/// </summary>
		/// <returns>true if the input model is in an acceptable state, otherwise false</returns>
		public bool CheckValidity()
		{
			//TODO Error/warning Messages
			bool result = false;
			
			if(!string.IsNullOrEmpty(UserId.Trim() ))
			{
				SubmittedUser = AuctionSource.GetByAlternateKey<User>(User.ALTKEY_BidNumber, UserId.Trim());
			}
			result = SubmittedUser != null;
			
			return result;
		}
		
		#endregion
	}
}
