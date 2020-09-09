using FileExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

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


		public bool RunSearch (ProgressBar pb,string path, string file)
		{
			string[] files = Directory.GetFiles(path);
			int percentFactor;
			if (files.Length < 100)
				percentFactor = files.Length % 100;
			else
				percentFactor = files.Length / 100;

			//Dispatcher.CurrentDispatcher.Invoke(() =>
			//{
			//	pb.Dispatcher.Invoke(() => pb.Value = 0);

			//});
			pb.Dispatcher.Invoke(() => pb.Value = 10);

			for (int i = 0; i < files.Length; i++)
			{
				if (Path.GetFileName(files[i]).Equals(file))
				{
					pb.Dispatcher.Invoke(() => pb.Value = 100);
					return true;
				}
				else
				{
					if (files.Length <100)
						pb.Dispatcher.Invoke(() => pb.Value = i * percentFactor);
					else
						pb.Dispatcher.Invoke(() => pb.Value = i / percentFactor);
					
				}
				Thread.Sleep(10);
			}
			pb.Dispatcher.Invoke(() => pb.Value = 0);
			return false;
		}
	}
}
