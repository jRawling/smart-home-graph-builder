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
			Alexa = appRepository.Create(new App("Alexa", brands.Amazon, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			HomeKit = appRepository.Create(new App("HomeKit", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			Hive = appRepository.Create(new App("Hive", brands.BritishGas, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			Hue = appRepository.Create(new App("Hue", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			Veho = appRepository.Create(new App("Veho", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			SmartThings = appRepository.Create(new App("SmartThings", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			Nest = appRepository.Create(new App("Nest", brands.Nest, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			NetatmoThermostat = appRepository.Create(new App("Netatmo Thermostat", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play })); 
			NetatmoSecurity = appRepository.Create(new App("Netatmo Security", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play }));
			NetatmoWeather = appRepository.Create(new App("Netatmo Weather", brands.Apple, new List<AppStore>() { appStores.AppStore, appStores.Play }));
		}
	}
}