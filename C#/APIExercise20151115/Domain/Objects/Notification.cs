namespace Czf.Domain
{
	/// <summary>
	/// Represents a Notification for various events
	/// </summary>
	public class Notification
	{
		/// <summary>
		/// Identifier for the Notification
		/// </summary>
		public long Id { get; private set;}

		/// <summary>
		/// Message explaining the notification
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// Create a new notification
		/// </summary>
		/// <param name="id">unique Id</param>
		/// <param name="message">message explaining the notification</param>
		public Notification(long id, string message)
		{
			Id = id;
			Message = message;
		}
	}
}
