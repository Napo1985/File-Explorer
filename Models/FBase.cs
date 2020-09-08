using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
namespace FileExplorer.ViewModels 
{
	abstract public class FBase  /* :INotifyPropertyChanged*/
	{
		#region ctor
		public FBase(string fullPath, bool isFile)
		{
			m_isFile = isFile;
			m_fullPath = fullPath;
			m_name = Path.GetFileNameWithoutExtension(m_fullPath);
		}
		#endregion


		#region events
		//public event PropertyChangedEventHandler PropertyChanged;

		//private void OnPropertyChanged(string propertyName)
		//{
		//	if (PropertyChanged != null)
		//	{
		//		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		//	}
		//}

		#endregion


		#region properties
		public string Name
		{
			get {return m_name; }
			set { m_name = value; /*OnPropertyChanged("Name");*/ }
		}

		public string FullPath
		{
			get { return m_fullPath; }
			set { m_fullPath = value; /*OnPropertyChanged("FullPath");*/ }
		}

		public bool IsFile
		{
			get {return m_isFile; }
			set { m_isFile = value; /*OnPropertyChanged("IsFile");*/ }
		}
		#endregion


		#region members
		protected string m_name;
		protected string m_fullPath;
		protected bool m_isFile;
		#endregion


	}
}
