using FileExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileExplorer.Events;
namespace FileExplorer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ClickEvents clickEventsIns = new ClickEvents();
		
		public MainWindow()
		{
			InitializeComponent();
			LoadDrives();
		}

		private void LoadDrives()
		{
			List<string> drives = GetAllDrivers();
			foreach (var item in drives)
			{
				TreeViewItem treeItem = new TreeViewItem();
				treeItem.Header = item;
				treeItem.IsExpanded = true;
				treeItem.DataContext = new Folder(item, false);
				myTree.Items.Add(treeItem);
			}
		}

		private void MasterItemSelected(object sender, RoutedEventArgs e)
		{
			TreeViewItem fatherItem = (TreeViewItem)myTree.SelectedItem;
			FBase fof = (FBase)fatherItem.DataContext;
			List<FBase> nextLevel = clickEventsIns.OnFFClick(fatherItem);
			if (nextLevel != null)
			{
				fatherItem.Items.Clear();
				foreach (var ffItem in nextLevel)
				{

					TreeViewItem x = new TreeViewItem();
					x.DataContext = (object)ffItem;
					x.Header = ffItem.Name;
					fatherItem.Items.Add(x);
				}
			}

			
		}

		private List<string> GetAllDrivers ()
		{
			DriveInfo[] allDrives = DriveInfo.GetDrives();

			List<string> ret = new List<string>();

			foreach (var item in allDrives)
			{
				ret.Add(item.RootDirectory.ToString());
				
			}
			return ret;
		}

		private void treeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			TreeViewItem fatherItem = sender as TreeViewItem;
			MasterItemSelected(sender, e);
		}

	}
}
