using System;
using System.Windows.Forms;

namespace ManyToManySearch
{
	internal static class ManyToManySearchProgram
	{
		public static bool IsDesignTime = true;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			IsDesignTime = false;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ManyToManySearchForm());
		}
	}
}