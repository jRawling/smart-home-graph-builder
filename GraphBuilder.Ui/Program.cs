using System;
using System.Collections.Generic;
using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;
using GraphBuilder.Ui;

class Program
{
	public static BrandManager brands;
	public static AppStoreManager appStores;
	public static AppManager apps;

    static void Main(string[] args)
    {
        Test();
    }

    private static void Test()
    {
		Console.WriteLine("Creating brands...");
		brands = new BrandManager();
        Console.WriteLine("Creating app stores...");
		appStores = new AppStoreManager(brands);
        Console.WriteLine("Creating apps");
		apps = new AppManager(brands, appStores);
        Console.WriteLine("Creating products:");
        ProductRepository productRepository = new ProductRepository();
		productRepository.DeleteAll();
    }

    private static void Netatmo(Brand netatmo, App alexa, App homeKit, App netatmoThermostatApp, App netatmoSecurityApp, App netatmoWeatherApp, ProductRepository productRepository)
    {
        Console.WriteLine("- Netatmo");
        Standalone netatmoThermostat = productRepository.Create(new Standalone("Thermostat", netatmo, 139.99, netatmoThermostatApp, new List<App>() { homeKit })) as Standalone;
        Standalone netatmoWeatherStation = productRepository.Create(new Standalone("Urban Weather Station", netatmo, 129.99, netatmoWeatherApp, new List<App>() { alexa })) as Standalone;
        Standalone netatmoWelcomeCam = productRepository.Create(new Standalone("Welcome Cam", netatmo, 159.99, netatmoSecurityApp, null)) as Standalone;
        Standalone netatmoPresence = productRepository.Create(new Standalone("Presence", netatmo, 249.99, netatmoSecurityApp, null)) as Standalone;
    }

    private static void Nest(Brand nest, App alexa, App nestApp, ProductRepository productRepository)
    {
        Console.WriteLine("- Nest");
        Standalone nestThermostat = productRepository.Create(new Standalone("Learning Thermostat", nest, 199, nestApp, new List<App>() { alexa })) as Standalone;
    }

    private static void SmartThings(Brand smartThings, App smartThingsApp, ProductRepository productRepository)
    {
        Console.WriteLine("- SmartThings");
        Hub smartThingsHub = productRepository.Create(new Hub("Hub", smartThings, 99)) as Hub;
        Accessory smartThingsMultiSensor = productRepository.Create(new Accessory("Multi Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsPresenceSensor = productRepository.Create(new Accessory("Presence Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsPowerOutlet = productRepository.Create(new Accessory("Power Outlet", smartThings, 44.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsMotionSensor = productRepository.Create(new Accessory("Motion Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsmoistureSensor = productRepository.Create(new Accessory("Moisture Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        productRepository.Create(new Bundle("Starter Kit", smartThings, 199.99, new List<Product>() { smartThingsHub, smartThingsMotionSensor, smartThingsMultiSensor, smartThingsPowerOutlet, smartThingsPresenceSensor }));
    }

    private static void Veho(Brand veho, App vehoApp, ProductRepository productRepository)
    {
        Console.WriteLine("- Veho");
        Standalone vehoBulb = productRepository.Create(new Standalone("Bluetooth Smart LED Light Bulb", veho, 29.99, vehoApp, null)) as Standalone;
    }

    private static void Philips(Brand philips, App alexa, App hue, App smartThingsApp, App nestApp, App homeKit, ProductRepository productRepository)
    {
        Console.WriteLine("- Philips");
        Hub philipsHueBridge = productRepository.Create(new Hub("Bridge", philips, 49.99)) as Hub;
        Accessory hueWhite = productRepository.Create(new Accessory("Hue White", philips, 14.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        Accessory hueAmbience = productRepository.Create(new Accessory("Hue Ambience", philips, 24.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        Accessory hueColour = productRepository.Create(new Accessory("Hue Colour", philips, 49.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        Accessory hueLightStripPlus = productRepository.Create(new Accessory("Hue LightStrip Plus", philips, 64.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        productRepository.Create(new Bundle("Hue Colour Starter Kit", philips, 149.99, new List<Product>() { philipsHueBridge, hueColour }));
        productRepository.Create(new Bundle("Hue Colour Starter Kit with LightStrip", philips, 174.98, new List<Product>() { philipsHueBridge, hueColour }));
        productRepository.Create(new Bundle("Hue Colour Starter Kit", philips, 59.99, new List<Product>() { philipsHueBridge, hueWhite }));
    }

    private static void BritishGas(Brand britishGas, App alexa, App hive, ProductRepository productRepository)
    {
        Console.WriteLine("- British Gas");
        Hub hiveHub = productRepository.Create(new Hub("Hub", britishGas, 79.99)) as Hub;
        Accessory hiveThermostat = productRepository.Create(new Accessory("Thermostat", britishGas, 99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Accessory hivePlug = productRepository.Create(new Accessory("Active Plug", britishGas, 39.99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Accessory hiveLight = productRepository.Create(new Accessory("Active LED Smart Bulb", britishGas, 19.99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        productRepository.Create(new Bundle("Active Heating", britishGas, 179.99, new List<Product>() { hiveHub, hiveThermostat }));
    }

    private static void Amazon(Brand amazon, App alexa, ProductRepository productRepository)
    {
        Console.WriteLine("- Amazon");
        Standalone echo = productRepository.Create(new Standalone("Echo", amazon, 149.99, alexa, null)) as Standalone;
        Standalone echoDot = productRepository.Create(new Standalone("Echo Dot", amazon, 49.99, alexa, null)) as Standalone;
    }
}