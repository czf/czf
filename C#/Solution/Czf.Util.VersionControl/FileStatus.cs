
namespace Czf.Util.VersionControl
{
    /// <summary>
    /// Container object for git status information about a file.
    /// </summary>
	public class FileStatus
	{

		#region Properties

        /// <summary>
        /// Gets or sets the status of the file.
        /// </summary>
        /// <value>The status (normal, modified, added, conflicted, unversioned, etc.)</value>
		public string Status { get; set; }

        /// <summary>
        /// Gets or sets the last commit which modified this file.
        /// </summary>
        /// <value>The last commit number, as a string.</value>
		public string LastCommit { get; set; }

        /// <summary>
        /// Gets or sets the error message in the event of a status lookup failure.
        /// </summary>
        /// <value>The error message.</value>
		public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets the last commit revision and/or status, suitable for use in a file name.
        /// </summary>
        /// <value>The revision and status (e.g., "1234", "1234modified", "unversioned").</value>
		public string RevisionAndStatus
		{
			get
			{
				if ((Status == "normal") && (LastCommit != string.Empty))
				{
					return LastCommit;
				}
				else if (LastCommit == string.Empty)
				{
					return Status;
				}
				else
				{
					return LastCommit + "." + Status;
				}
			}
		}

		#endregion

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStatus"/> class.
        /// </summary>
		public FileStatus()
		{
			Status = "unknown";
			LastCommit = string.Empty;
			ErrorMessage = string.Empty;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStatus"/> class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="lastCommit">The last commit.</param>
		public FileStatus(string status, string lastCommit)
		{
			Status = status;
			LastCommit = lastCommit;
			ErrorMessage = string.Empty;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStatus"/> class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="lastCommit">The last commit.</param>
        /// <param name="error">The error.</param>
		public FileStatus(string status, string lastCommit, string error)
		{
			Status = status;
			LastCommit = lastCommit;
			ErrorMessage = error;
		}

		#endregion
	}

}
