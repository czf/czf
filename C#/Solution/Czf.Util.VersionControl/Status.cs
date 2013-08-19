using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

namespace Czf.Util.VersionControl
{
    /// <summary>
    /// Provides subversion status information about files in a working copy.
    /// </summary>
	public class GitStatus
	{
		#region Privates

		private string _gitPath;

		#endregion

		#region Properties

		#endregion

		#region Methods

        /// <summary>
        /// Returns a <see cref="FileStatus" /> object with subversion information for the given file.
        /// </summary>
        /// <param name="file">The file to inspect.</param>
        /// <returns>A <see cref="FileStatus" /> for the given file.</returns>
		public FileStatus GetFileStatus(string file)
		{
			Process command = new Process();
			command.StartInfo.UseShellExecute = false;
			command.StartInfo.CreateNoWindow = true;
			command.StartInfo.RedirectStandardOutput = true;
			command.StartInfo.RedirectStandardError = true;
			command.StartInfo.FileName = _gitPath;
			command.StartInfo.Arguments = "status \"" + file + "\" --porcelain";
			command.Start();
			
			string output = command.StandardOutput.ReadToEnd();
			string error = command.StandardError.ReadToEnd();
			command.WaitForExit();
			if (error.Length > 0)
			{
				return new FileStatus("error", string.Empty, error);
			}
			else
			{
				XmlDocument XmlOutput = new XmlDocument();
				FileStatus fileStatus = new FileStatus();

				
				if (output.Length == 0)
				{
					fileStatus.Status = wcStatusNode.Attributes["item"].Value;
					if ((fileStatus.Status == "normal")
						|| (fileStatus.Status == "modified"))
					{
						XmlNode commitNode = wcStatusNode.SelectSingleNode("commit");
						if (commitNode != null)
							fileStatus.LastCommit = commitNode.Attributes["revision"].Value;
					}
				}
				return fileStatus;
			}
		}
		
		#endregion

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GitStatus"/> class.
        /// </summary>
		public GitStatus()
		{
			_gitPath = "Git.exe";
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="GitStatus"/> class.
        /// </summary>
        /// <param name="svnPath">The git.exe cli tool path.</param>
		public GitStatus(string gitPath)
		{
			_gitPath = gitPath;
		}

		#endregion

	}
}
