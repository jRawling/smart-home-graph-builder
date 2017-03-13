using System;
using Neo4j.Driver.V1;
using System.Collections.Generic;
using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;

class Program
{
    static void Main(string[] args)
    {
        Test();
    }

    private static void Test()
    {
        Console.WriteLine("Creating app stores");
        AppStoreRepository appStoreRepository = new AppStoreRepository();
        appStoreRepository.DeleteAll();
        AppStore appleStore = appStoreRepository.Create(new AppStore("Apple App Store"));
        AppStore googleStore = appStoreRepository.Create(new AppStore("Google"));

        Console.WriteLine("Creating brands");
        BrandRepository brandRepository = new BrandRepository();
        brandRepository.DeleteAll();
        Brand amazon = brandRepository.Create(new Brand("Amazon"));
        Brand belkin = brandRepository.Create(new Brand("Belkin"));
        Brand britishGas = brandRepository.Create(new Brand("British Gas"));
        Brand veho = brandRepository.Create(new Brand("Veho"));
        Brand philips = brandRepository.Create(new Brand("Philips"));
        Brand smartThings = brandRepository.Create(new Brand("SmartThings"));
        Brand nest = brandRepository.Create(new Brand("Nest"));
        Brand apple = brandRepository.Create(new Brand("Apple"));
        Brand netatmo = brandRepository.Create(new Brand("Netatmo"));
        Brand netgear = brandRepository.Create(new Brand("Netgear"));
        Brand ring = brandRepository.Create(new Brand("Ring"));
        Brand panasonic = brandRepository.Create(new Brand("Panasonic"));
        Brand dlink = brandRepository.Create(new Brand("D-Link"));

        //Console.WriteLine("Creating catagories");
        //Category lighting = catalogue.CreateCategory("Lighting");
        //Category heating = catalogue.CreateCategory("Heating");
        //Category smartAssistant = catalogue.CreateCategory("Smart Assistant");
        //Category hub = catalogue.CreateCategory("Hub");

        Console.WriteLine("Creating apps");
        AppRepository appRepository = new AppRepository();
        appRepository.DeleteAll();
        App alexa = appRepository.Create(new App("Alexa", amazon, new List<AppStore>() { appleStore }));
        App hive = appRepository.Create(new App("Hive", britishGas, new List<AppStore>() { appleStore }));
        App hue = appRepository.Create(new App("Hue", philips, new List<AppStore>() { appleStore }));
        App vehoApp = appRepository.Create(new App("Veho Kasa", veho, new List<AppStore>() { appleStore }));
        App smartThingsApp = appRepository.Create(new App("SmartThings Mobile", smartThings, new List<AppStore>() { appleStore }));
        App nestApp = appRepository.Create(new App("Nest", nest, new List<AppStore>() { appleStore }));
        App homeKit = appRepository.Create(new App("Home Kit", apple, new List<AppStore>() { appleStore }));
        App netatmoThermostatApp = appRepository.Create(new App("Thermostat by Netatmo", netatmo, new List<AppStore>() { appleStore }));
        App netatmoSecurityApp = appRepository.Create(new App("Netatmo Security", netatmo, new List<AppStore>() { appleStore }));
        App netatmoWeatherApp = appRepository.Create(new App("Netatmo Weather", netatmo, new List<AppStore>() { appleStore }));

        Console.WriteLine("Creating products:");
        ProductRepository productRepository = new ProductRepository();
        productRepository.DeleteAll();

        Console.WriteLine("- Amazon");
        Standalone echo = productRepository.Create(new Standalone("Echo", amazon, 149.99, alexa, null)) as Standalone;
        Standalone echoDot = productRepository.Create(new Standalone("Echo Dot", amazon, 49.99, alexa, null)) as Standalone;

        Console.WriteLine("- British Gas");
        Hub hiveHub = productRepository.Create(new Hub("Hub", britishGas, 79.99)) as Hub;
        Accessory hiveThermostat = productRepository.Create(new Accessory("Thermostat", britishGas, 99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Accessory hivePlug = productRepository.Create(new Accessory("Active Plug", britishGas, 39.99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Accessory hiveLight = productRepository.Create(new Accessory("Active LED Smart Bulb", britishGas, 19.99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        productRepository.Create(new Bundle("Active Heating", britishGas, 179.99, new List<Product>() { hiveHub, hiveThermostat }));

        Console.WriteLine("- Philips");
        Hub philipsHueBridge = productRepository.Create(new Hub("Bridge", philips, 49.99)) as Hub;
        Accessory hueWhite = productRepository.Create(new Accessory("Hue White", philips, 14.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        Accessory hueAmbience = productRepository.Create(new Accessory("Hue Ambience", philips, 24.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        Accessory hueColour = productRepository.Create(new Accessory("Hue Colour", philips, 49.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        Accessory hueLightStripPlus = productRepository.Create(new Accessory("Hue LightStrip Plus", philips, 64.99, hue, new List<App>() { alexa, homeKit, nestApp, smartThingsApp }, philipsHueBridge)) as Accessory;
        productRepository.Create(new Bundle("Hue Colour Starter Kit", philips, 149.99, new List<Product>() { philipsHueBridge, hueColour }));
        productRepository.Create(new Bundle("Hue Colour Starter Kit with LightStrip", philips, 174.98, new List<Product>() { philipsHueBridge, hueColour }));
        productRepository.Create(new Bundle("Hue Colour Starter Kit", philips, 59.99, new List<Product>() { philipsHueBridge, hueWhite }));

        Console.WriteLine("- Veho");
        Standalone vehoBulb = productRepository.Create(new Standalone("Bluetooth Smart LED Light Bulb", veho, 29.99, vehoApp, null)) as Standalone;

        Console.WriteLine("- SmartThings");
        Hub smartThingsHub = productRepository.Create(new Hub("Hub", smartThings, 99)) as Hub;
        Accessory smartThingsMultiSensor = productRepository.Create(new Accessory("Multi Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsPresenceSensor = productRepository.Create(new Accessory("Presence Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsPowerOutlet = productRepository.Create(new Accessory("Power Outlet", smartThings, 44.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsMotionSensor = productRepository.Create(new Accessory("Motion Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        Accessory smartThingsmoistureSensor = productRepository.Create(new Accessory("Moisture Sensor", smartThings, 29.99, smartThingsApp, null, smartThingsHub)) as Accessory;
        productRepository.Create(new Bundle("Starter Kit", smartThings, 199.99, new List<Product>() { smartThingsHub, smartThingsMotionSensor, smartThingsMultiSensor, smartThingsPowerOutlet, smartThingsPresenceSensor }));

        Console.WriteLine("- Nest");
        Standalone nestThermostat = productRepository.Create(new Standalone("Learning Thermostat", nest, 199, nestApp, new List<App>() { alexa })) as Standalone;

        Console.WriteLine("- Netatmo");
        Standalone netatmoThermostat = productRepository.Create(new Standalone("Thermostat", netatmo, 139.99, netatmoThermostatApp, new List<App>() { homeKit })) as Standalone;
        Standalone netatmoWeatherStation = productRepository.Create(new Standalone("Urban Weather Station", netatmo, 129.99, netatmoWeatherApp, new List<App>() { alexa })) as Standalone;
        Standalone netatmoWelcomeCam = productRepository.Create(new Standalone("Welcome Cam", netatmo, 159.99, netatmoSecurityApp, null)) as Standalone;
        Standalone netatmoPresence = productRepository.Create(new Standalone("Presence", netatmo, 249.99, netatmoSecurityApp, null)) as Standalone;
    }
}