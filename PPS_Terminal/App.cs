using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace PPS_Terminal
{
	public class App : Application
	{
		private bool _contentLoaded;

		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				base.StartupUri = new Uri("Window1.xaml", UriKind.Relative);
				Uri resourceLocater = new Uri("/PPS_Terminal;component/app.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocater);
			}
		}

		[DebuggerNonUserCode, STAThread]
		public static void Main()
		{
			App app = new App();
			app.InitializeComponent();
			app.Run();
		}
	}
}
