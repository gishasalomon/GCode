using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest_TestCI
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				return ConfigureApp
                    .Android
                    .ApkFile(@"C:\Users\gisha\Documents\testci\TestCI\TestCI\TestCI.Android\bin\Release\com.companyname-Signed.apk")
                    .StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}