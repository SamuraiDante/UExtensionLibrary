using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExtensionLibrary.Classes
{   /// <summary>
	///	Unfinished, dont use
	/// </summary>
	internal class CDBInterface
	{
		public string ConnectionString { get; set; }

		public DataTable Query(string sql)
		{
			DataTable ReturnData = new DataTable();

			return ReturnData;
			;
		}
	}
}
