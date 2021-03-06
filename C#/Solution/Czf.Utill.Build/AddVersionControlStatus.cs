﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Czf.Util.VersionControl;
using System.Text.RegularExpressions;

namespace Czf.Util.Build
{
	/// <summary>
	/// Adds working copy subversion meta data to a file list.
	/// </summary>
	public class AddVersionControlStatus : Task
	{
		#region Privates

		long? _maxCommit;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the input files.
		/// </summary>
		/// <value>The input files.</value>
		[Required]
		public ITaskItem[] InputFiles { get; set; }

		/// <summary>
		/// Gets or sets the output files.
		/// </summary>
		/// <value>The output files.</value>
		[Output]
		public ITaskItem[] OutputFiles { get; private set; }

		/// <summary>
		/// Filename match filter for InputFiles. If set, the Filename of each InputFile must match the filter.
		/// </summary>
		/// <value>
		/// The filename match filter.
		/// </value>
		/// <remarks>Note: Filename only, not Extension.</remarks>
		public string MatchFilenameFilter { get; set; }

		/// <summary>
		/// An aggregate list of the files in the input set.
		/// </summary>
		/// <value>The status (normal, modified, added, conflicted, unversioned, etc.)</value>
		[Output]
		public string MergeFileStatus { get; private set; }

		/// <summary>
		/// The last commit which modified a file in the input set.
		/// </summary>
		/// <value>The last commit number, as a string.</value>
		[Output]
		public string MergeLastCommitDateAsInt
		{
			get
			{
				return (_maxCommit.HasValue) ? _maxCommit.Value.ToString() : String.Empty;
			}
		}

		/// <summary>
		/// Gets the last commit revision and/or status aggregate value for the input files suitable for use in a file name.
		/// </summary>
		/// <value>The revision and status (e.g., "1234", "1234modified", "unversioned").</value>
		[Output]
		public string MergeRevisionAndStatus
		{
			get
			{
				if ((MergeFileStatus == "normal") && (MergeLastCommitDateAsInt != string.Empty))
				{
					return MergeLastCommitDateAsInt;
				}
				else if (MergeLastCommitDateAsInt == string.Empty)
				{
					return MergeFileStatus;
				}
				else
				{
					return MergeLastCommitDateAsInt.Replace(".normal", "").Replace("normal.", "") + "." + MergeFileStatus;
				}
			}
		}
		#endregion

		#region Methods

        /// <summary>
        /// Executes the AddVersionControlStatus task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
		public override bool Execute()
		{
			_maxCommit = null;
			MergeFileStatus = String.Empty;

			GitStatus versionControlStatus = new GitStatus();
			FileStatus fileStatus;
			
			if ((MatchFilenameFilter ?? String.Empty) == String.Empty)
			{
				OutputFiles = InputFiles;
			}
			else
			{
				Regex filter = new Regex(MatchFilenameFilter, RegexOptions.IgnoreCase);
				OutputFiles = InputFiles.Where(i => filter.IsMatch(i.GetMetadata("Filename"))).ToArray();
			}
			
			
			foreach (ITaskItem file in OutputFiles)
			{
				string msg = string.Empty;
				fileStatus = versionControlStatus.GetFileStatus(file.ToString(), out msg);
				file.SetMetadata("VersionControlFileStatus", fileStatus.Status);
				Log.LogMessage("last commitdate as int:" + fileStatus.LastCommitDateAsInt);
				Log.LogMessage(msg);
				file.SetMetadata("LastCommitDateAsInt", fileStatus.LastCommitDateAsInt.ToString());
				file.SetMetadata("RevisionDateAndStatus", fileStatus.RevisionAndStatus);
				if (fileStatus.LastCommitDateAsInt != 0)
				{
					if (_maxCommit.HasValue)
					{
						if (fileStatus.LastCommitDateAsInt > _maxCommit.Value)
						{
							_maxCommit = fileStatus.LastCommitDateAsInt;
						}
					}
					else
					{
						_maxCommit = fileStatus.LastCommitDateAsInt;
					}
				}
				if (MergeFileStatus.IndexOf(fileStatus.Status) == -1)
				{
					if (MergeFileStatus.Length == 0)
					{
						MergeFileStatus = fileStatus.Status;
					}
					else
					{
						MergeFileStatus += "." + fileStatus.Status;
					}
				}
			}
			return true;
		}

		#endregion
	}
}
