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
		public int? UserId {get; set;} 

		/// <summary>
		/// 
		/// </summary>
		public IAuctionSource AuctionSource { get; set;}
		
		/// <summary>
		/// Resulting user from checking validity 
		/// </summary>
		public User SubmittedUser { get; protected set; }
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
			
			if(UserId.HasValue)
			{
				SubmittedUser = AuctionSource.GetByAlternateKey<User>(User.ALTKEY_BidNumber, UserId.Value);
			}
			result = SubmittedUser != null;
			
			return result;
		}
		
		#endregion
	}
}
