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
		public FileStatus GetFileStatus(string file)
		{
			
			
			
			Process command = new Process();
			
			command.StartInfo.UseShellExecute = false;
			command.StartInfo.CreateNoWindow = true;
			command.StartInfo.RedirectStandardOutput = true;
			command.StartInfo.RedirectStandardError = true;
			//command.StartInfo.FileName = @"D:\Program Files (x86)\Git\cmd\" + _gitPath;
			
			
			command.StartInfo.FileName = _gitPath;
			command.StartInfo.Arguments = "status --porcelain \"" + file + "\"" ;
			
			File.WriteAllText("outputTest.txt", "FULL: " + command.StartInfo.WorkingDirectory+ " " + command.StartInfo.FileName+ " "+ command.StartInfo.Arguments);
			command.Start();
			File.WriteAllText("outputTest2.txt",file);
			string output = command.StandardOutput.ReadToEnd();
			string error = command.StandardError.ReadToEnd();
			File.WriteAllText("outputTest.txt3", output +  "\n\n" + error);
			command.WaitForExit();
			if (error.Length > 0)
			{
				Console.WriteLine("error with file: " + file);
				return new FileStatus("error", 0, error);
			}
			else
			{
				XmlDocument XmlOutput = new XmlDocument();
				FileStatus fileStatus = new FileStatus();

				
				if (output.Length >2)
				{
					fileStatus.Status = output.Substring(0,2);
					string[] states = {"M","A","U","D"};
					if (states.Any(x=>output.Contains(x)))
					{
						command.StartInfo.Arguments = "log --format=%ad \""+ file + "\"";
							command.Start();
						output = command.StandardOutput.ReadToEnd();
						if (output != null && output != string.Empty)
						{
							DateTime lastCommit = DateTime.Now;
							if(DateTime.TryParse(output,out lastCommit))
							{
								fileStatus.LastCommitDateAsInt = lastCommit.Ticks;
							}
						}
							
					}
				}
				else {
					fileStatus.Status = "normal";
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
