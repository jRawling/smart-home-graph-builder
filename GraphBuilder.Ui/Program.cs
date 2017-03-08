using System;
using Neo4j.Driver.V1;
using System.Collections.Generic;
using GraphBuilder.Entities;
using GraphBuilder.Repositories;

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
        AppStore appleStore = appStoreRepository.Create(new AppStore("Apple"));
        //  AppStore googleStore = appStoreRepository.Create(new AppStore("Google"));

        Console.WriteLine("Creating brands");
        BrandRepository brandRepository = new BrandRepository();
        brandRepository.DeleteAll();
        Brand amazon = brandRepository.Create(new Brand("Amazon"));
        //  Brand belkin = brandRepository.Create(new Brand("Belkin"));
        Brand britishGas = brandRepository.Create(new Brand("British Gas"));
        Brand lifx = brandRepository.Create(new Brand("LIFX"));
        Brand philips = brandRepository.Create(new Brand("Philips"));
        Brand smartThings = brandRepository.Create(new Brand("SmartThings"));

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
        App lifxApp = appRepository.Create(new App("LIFX", lifx, new List<AppStore>() { appleStore }));
        App smartThingsApp = appRepository.Create(new App("SmartThings Mobile", smartThings, new List<AppStore>() { appleStore }));

        Console.WriteLine("Creating products:");
        ProductRepository productRepository = new ProductRepository();
        productRepository.DeleteAll();
        Console.WriteLine("- Amazon");
        Standalone echo = productRepository.Create(new Standalone("Echo", amazon, alexa, null)) as Standalone;
        Console.WriteLine("- British Gas");
        Hub hiveHub = productRepository.Create(new Hub("Hive Hub", britishGas)) as Hub;
        Accessory hiveThermostat = productRepository.Create(new Accessory("Hive Thermostat", britishGas, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Console.WriteLine("- Philips");
        Console.WriteLine("- LIFX");
        Standalone lifxBulb = productRepository.Create(new Standalone("LIFX White", lifx, lifxApp, new List<App>() { smartThingsApp, alexa })) as Standalone;
        Console.WriteLine("- SmartThings");
    }
}