using System.Collections.Generic;
using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;

namespace GraphBuilder.Ui
{
	public class AppManager
	{
		public App Alexa { get; private set; }
		public App HomeKit { get; private set; }
		public App Hive { get; private set; }
		public App Hue { get; private set; }
		public App Veho { get; private set; }
		public App SmartThings { get; private set; }
		public App Nest { get; private set; }
		public App NetatmoThermostat { get; private set; }
		public App NetatmoSecurity { get; private set; }
		public App NetatmoWeather { get; private set; }

		public AppManager(BrandManager brands, AppStoreManager appStores) 
		{
			AppRepository appRepository = new AppRepository();
			appRepository.DeleteAll();
			Alexa = appRepository.Create(new App("Alexa", brands.Amazon, appStores.All));
			HomeKit = appRepository.Create(new App("HomeKit", brands.Apple, appStores.All));
			Hive = appRepository.Create(new App("Hive", brands.BritishGas, appStores.All));
			Hue = appRepository.Create(new App("Hue", brands.Philips, appStores.All));
			Veho = appRepository.Create(new App("Veho", brands.Veho, appStores.All));
			SmartThings = appRepository.Create(new App("SmartThings", brands.SmartThings, appStores.All));
			Nest = appRepository.Create(new App("Nest", brands.Nest, appStores.All));
			NetatmoThermostat = appRepository.Create(new App("Netatmo Thermostat", brands.Netatmo, appStores.All));
			NetatmoSecurity = appRepository.Create(new App("Netatmo Security", brands.Netatmo, appStores.All));
			NetatmoWeather = appRepository.Create(new App("Netatmo Weather", brands.Netatmo, appStores.All));
		}
	}
}