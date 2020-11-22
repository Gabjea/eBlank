using System;
using System.Collections.Generic;
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
using ChaseLabs.CLUpdate;
using System.Windows.Threading;

namespace Updater
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		Dispatcher dis = Dispatcher.CurrentDispatcher;
		public MainWindow()
		{
			InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			Update();
		}

		void Update()
		{

			Task.Run(() =>
			{
				dis.Invoke(() =>
				{
					uplabel.Content = "Checking for Updates";
				},DispatcherPriority.Normal);


				string url = "https://www.dropbox.com/s/0pwy8c3zx9u98kz/app.zip?dl=1";
				string remote_version_url = "https://www.dropbox.com/s/7gdpr7gpobfpzcg/version?dl=1";
				string version_key="app: ";
				string update_path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"eBlank","Auto Updater","update");
				string application_path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "eBlank", "Auto Updater", "bin");
				string local_version_path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "eBlank", "Auto Updater", "version");

				string launch_exe= "eBlank.exe";

				var update = ChaseLabs.CLUpdate.Updater.Init(url, update_path, application_path, launch_exe);

				update.Download();
				dis.Invoke(() =>
				{
					uplabel.Content = "Downloading Update...";
				});
				update.Unzip();
				dis.Invoke(() =>
				{
					uplabel.Content = "Unziping Update...";
				});

				update.CleanUp();
				dis.Invoke(() =>
				{
					uplabel.Content = "Finishing up...";
				});

				using (var client = new System.Net.WebClient())
				{
					client.DownloadFile(remote_version_url, local_version_path);
					client.Dispose();
				}
				dis.Invoke(() =>
				{
					uplabel.Content = "Launching App...";
				});

				update.LaunchExecutable();
			});
		}
	}
}
