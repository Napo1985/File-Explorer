using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModels
{
	class File :FBase
	{
		#region ctor
		public File(string fullPath, bool isFile) : base(fullPath, isFile)
		{

		}
		#endregion

	}
}
