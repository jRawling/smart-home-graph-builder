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
        public App Ring { get; private set; }
        public App SmartCam { get; private set; }

        public AppManager(BrandManager brands, StoreManager stores) 
		{
			AppRepository appRepository = new AppRepository();
			appRepository.DeleteAll();
			Alexa = appRepository.Create(new App("Alexa", brands.Amazon, stores.All));
			HomeKit = appRepository.Create(new App("HomeKit", brands.Apple, stores.All));
			Hive = appRepository.Create(new App("Hive", brands.BritishGas, stores.All));
			Hue = appRepository.Create(new App("Hue", brands.Philips, stores.All));
			Veho = appRepository.Create(new App("Veho", brands.Veho, stores.All));
			SmartThings = appRepository.Create(new App("SmartThings", brands.SmartThings, stores.All));
			Nest = appRepository.Create(new App("Nest", brands.Nest, stores.All));
			NetatmoThermostat = appRepository.Create(new App("Netatmo Thermostat", brands.Netatmo, stores.All));
			NetatmoSecurity = appRepository.Create(new App("Netatmo Security", brands.Netatmo, stores.All));
			NetatmoWeather = appRepository.Create(new App("Netatmo Weather", brands.Netatmo, stores.All));
            Ring = appRepository.Create(new App("Ring", brands.Ring, stores.All));
            SmartCam = appRepository.Create(new App("SmartCam", brands.Samsung, stores.All));
		}
	}
}