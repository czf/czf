using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;
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
		/// <param name = "message"></param>
		public FileStatus GetFileStatus(string file, out string message)
		{
			message = string.Empty;
			
			
			Process command = new Process();
			
			command.StartInfo.UseShellExecute = false;
			command.StartInfo.CreateNoWindow = true;
			command.StartInfo.RedirectStandardOutput = true;
			command.StartInfo.RedirectStandardError = true;
			
			
			command.StartInfo.FileName = _gitPath;
			command.StartInfo.Arguments = "status --porcelain \"" + file + "\"" ;
			
			command.Start();
			string output = command.StandardOutput.ReadToEnd();
			string error = command.StandardError.ReadToEnd();
			command.WaitForExit();
			if (error.Length > 0)
			{
				message += ("error with file: " + file)+ "\n";
				return new FileStatus("error", 0, error);
			}
			else
			{
				FileStatus fileStatus = new FileStatus();

				
				if (output.Length >2)
				{
					message += ("OUTPUT!!")+ "\n";
					fileStatus.Status = output.Substring(0,2).Trim();
				}
				else {
					fileStatus.Status = "N";//normal?
				}
				
				command.StartInfo.Arguments = "log --format=%cd --max-count=1 --date=iso \""+ file + "\"";
				command.Start();
				output = command.StandardOutput.ReadToEnd().Trim();
				message += ("git committime: " + output) + "\n";
				if (!string.IsNullOrEmpty(output)) {
					DateTime lastCommit = DateTime.Now;
					if (DateTime.TryParse(output, out lastCommit)) {
						fileStatus.LastCommitDateAsInt = lastCommit.Ticks;
						message += ("Parsed Time")+ "\n";
					}
					else
					{
						message += ("Could not parse time")+ "\n";
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
        /// <param name="gitPath">The git.exe cli tool path.</param>
		public GitStatus(string gitPath)
		{
			_gitPath = gitPath;
		}

		#endregion

	}
}
