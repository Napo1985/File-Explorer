using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModels
{
	class Folder : FBase
	{
		#region members
		private Dictionary<string, File> m_files = new Dictionary<string, File>();
		private Dictionary<string, Folder> m_folders = new Dictionary<string, Folder>();
		#endregion

		#region ctor
		public Folder(string fullPath, bool isFile) : base(fullPath, isFile)
		{

		}

		#endregion

		#region functions
		public bool IsContainFiles()
		{
			return m_files.Count != 0 ? true : false;
		}

		public bool IsContainFolders()
		{
			return m_folders.Count != 0 ? true : false;
		}

		public void GetNextLevel(string fullPath)
		{
			string[] filePaths = Directory.GetFiles(fullPath);
			foreach (var item in filePaths)
			{
				string cleanName = Path.GetFileNameWithoutExtension(item);
				m_files.Add(cleanName, new File(fullPath, true));
			}

			string[] subdirectoryEntries = Directory.GetDirectories(fullPath);
			foreach (var item in subdirectoryEntries)
			{
				string cleanName = Path.GetFileNameWithoutExtension(item);
				m_folders.Add(cleanName, new Folder(fullPath, false));
			}
		}
		#endregion

	}
}
