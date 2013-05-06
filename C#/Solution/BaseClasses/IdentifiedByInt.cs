/*
 * Created by SharpDevelop.
 * User: Chris
 * Date: 12/24/2012
 * Time: 1:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Czf.Domain.Interfaces;
namespace Czf.Domain.BaseClasses
{
	/// <summary>
	/// Description of IdentifiedByInt.
	/// </summary>
	public class IdentifiedByInt : ICachable
	{
		public int? Id { get; private set; }
		
		
		#region ICachable
		public bool ReadyForCache()
		{
			return Id.HasValue;
		}
		#endregion
	}
}
