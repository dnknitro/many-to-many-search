using System;
using System.Windows.Forms;

namespace ManyToManySearch
{
	internal static class ManyToManySearchProgram
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ManyToManySearchForm());
		}
	}
}