using System;
using System.Collections.Generic;
using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;
using GraphBuilder.Ui;

class Program
{
	public static BrandManager brands;
	public static StoreManager stores;
	public static AppManager apps;
	public static ProductRepository products;

    static void Main(string[] args)
    {
        Test();
    }

    private static void Test()
    {
		Console.WriteLine("Creating brands");
		brands = new BrandManager();
        Console.WriteLine("Creating app stores");
		stores = new StoreManager(brands);
        Console.WriteLine("Creating apps");
		apps = new AppManager(brands, stores);
        Console.WriteLine("Creating product:");
        products = new ProductRepository();
		products.DeleteAll();

		Console.WriteLine("- Amazon");
		products.Create(new Standalone("Echo", brands.Amazon, 149.99, apps.Alexa, null));
		products.Create(new Standalone("Echo Dot", brands.Amazon, 49.99, apps.Alexa, null));

		Console.WriteLine("- British Gas");
		Hub hiveHub = products.Create(new Hub("Hub", brands.BritishGas, 79.99)) as Hub;
		Accessory hiveThermostat = products.Create(new Accessory("Thermostat", brands.BritishGas, 99, apps.Hive, new List<App>() { apps.Alexa }, hiveHub)) as Accessory;
		Accessory hivePlug = products.Create(new Accessory("Active Plug", brands.BritishGas, 39.99, apps.Hive, new List<App>() { apps.Alexa }, hiveHub)) as Accessory;
		Accessory hiveLight = products.Create(new Accessory("Active LED Smart Bulb", brands.BritishGas, 19.99, apps.Hive, new List<App>() { apps.Alexa }, hiveHub)) as Accessory;
	//	products.Create(new Bundle("Active Heating", brands.BritishGas, 179.99, new List<Product>() { hiveHub, hiveThermostat }));

		Console.WriteLine("- Nest");
		products.Create(new Standalone("Learning Thermostat", brands.Nest, 199, apps.Nest, new List<App>() { apps.Alexa }));

        Console.WriteLine("- Netatmo");
		products.Create(new Standalone("Thermostat", brands.Netatmo, 139.99, apps.NetatmoThermostat, new List<App>() { apps.Alexa, apps.HomeKit }));
		products.Create(new Standalone("Urban Weather Station", brands.Netatmo, 129.99, apps.NetatmoWeather, new List<App>() { apps.Alexa }));
		products.Create(new Standalone("Welcome Cam", brands.Netatmo, 159.99, apps.NetatmoSecurity, null));
		products.Create(new Standalone("Presence", brands.Netatmo, 249.99, apps.NetatmoSecurity, null));

		Console.WriteLine("- Philips");
		Hub philipsHueBridge = products.Create(new Hub("Bridge", brands.Philips, 49.99)) as Hub;
		Accessory hueWhite = products.Create(new Accessory("Hue White", brands.Philips, 14.99, apps.Hue, new List<App>() { apps.Alexa, apps.HomeKit, apps.Nest, apps.SmartThings }, philipsHueBridge)) as Accessory;
		Accessory hueAmbience = products.Create(new Accessory("Hue Ambience", brands.Philips, 24.99, apps.Hue, new List<App>() { apps.Alexa, apps.HomeKit, apps.Nest, apps.SmartThings }, philipsHueBridge)) as Accessory;
		Accessory hueColour = products.Create(new Accessory("Hue Colour", brands.Philips, 49.99, apps.Hue, new List<App>() { apps.Alexa, apps.HomeKit, apps.Nest, apps.SmartThings }, philipsHueBridge)) as Accessory;
		Accessory hueLightStripPlus = products.Create(new Accessory("Hue LightStrip Plus", brands.Philips, 64.99, apps.Hue, new List<App>() { apps.Alexa, apps.HomeKit, apps.Nest, apps.SmartThings }, philipsHueBridge)) as Accessory;
		//products.Create(new Bundle("Hue Colour Starter Kit", brands.Philips, 149.99, new List<Product>() { philipsHueBridge, hueColour }));
		//products.Create(new Bundle("Hue Colour Starter Kit with LightStrip", brands.Philips, 174.98, new List<Product>() { philipsHueBridge, hueColour }));
		//products.Create(new Bundle("Hue White Starter Kit", brands.Philips, 59.99, new List<Product>() { philipsHueBridge, hueWhite }));

		Console.WriteLine("- Ring");
        products.Create(new Standalone("Video Doorbell", brands.Ring, 159.99, apps.Ring, null));
        products.Create(new Standalone("Stick Up Cam", brands.Ring, 159.99, apps.Ring, null));
        products.Create(new Standalone("Chime", brands.Ring, 24.99, apps.Ring, null));

        Console.WriteLine("- Samsung");
        products.Create(new Standalone("SmartCam HD Pro", brands.Samsung, 119.99, apps.SmartCam, new List<App>() { apps.SmartThings }));

        Console.WriteLine("- SmartThings");
		Hub smartThingsHub = products.Create(new Hub("Hub", brands.SmartThings, 99)) as Hub;
		Accessory smartThingsMultiSensor = products.Create(new Accessory("Multi Sensor", brands.SmartThings, 29.99, apps.SmartThings, null, smartThingsHub)) as Accessory;
		Accessory smartThingsPresenceSensor = products.Create(new Accessory("Presence Sensor", brands.SmartThings, 29.99, apps.SmartThings, null, smartThingsHub)) as Accessory;
		Accessory smartThingsPowerOutlet = products.Create(new Accessory("Power Outlet", brands.SmartThings, 44.99, apps.SmartThings, null, smartThingsHub)) as Accessory;
		Accessory smartThingsMotionSensor = products.Create(new Accessory("Motion Sensor", brands.SmartThings, 29.99, apps.SmartThings, null, smartThingsHub)) as Accessory;
		Accessory smartThingsmoistureSensor = products.Create(new Accessory("Moisture Sensor", brands.SmartThings, 29.99, apps.SmartThings, null, smartThingsHub)) as Accessory;
		//products.Create(new Bundle("Starter Kit", brands.SmartThings, 199.99, new List<Product>() { smartThingsHub, smartThingsMotionSensor, smartThingsMultiSensor, smartThingsPowerOutlet, smartThingsPresenceSensor }));

        Console.WriteLine("- Veho");
		products.Create(new Standalone("Bluetooth Smart LED Light Bulb", brands.Veho, 29.99, apps.Veho, null));
    }
}