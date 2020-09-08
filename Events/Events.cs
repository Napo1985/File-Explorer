using FileExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileExplorer.Events 
{
	public class ClickEvents
	{

		public List<FBase> OnFFClick(TreeViewItem fatherItem)
		{
			try
			{
				FBase current = (FBase)fatherItem.DataContext;

				return GetFromPath(current.FullPath);
			}
			catch (Exception ex)
			{
				return null;
			}


		}

		private List<FBase> GetFromPath(string path)
		{
			List<FBase> retval = new List<FBase>();

			string[] filePaths = Directory.GetFiles(path);
			foreach (var item in filePaths)
			{
				retval.Add(new ViewModels.File(item, false));
			}

			string[] subdirectoryEntries = Directory.GetDirectories(path);
			foreach (var item in subdirectoryEntries)
			{
				string cleanName = Path.GetFileName(item);
				retval.Add(new Folder(item, true));
			}
			return retval;

		}

	}
}
