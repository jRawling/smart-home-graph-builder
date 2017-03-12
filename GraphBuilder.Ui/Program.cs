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
        //  AppStore googleStore = appStoreRepository.Create(new AppStore("Google"));

        Console.WriteLine("Creating brands");
        BrandRepository brandRepository = new BrandRepository();
        brandRepository.DeleteAll();
        Brand amazon = brandRepository.Create(new Brand("Amazon"));
        //  Brand belkin = brandRepository.Create(new Brand("Belkin"));
        Brand britishGas = brandRepository.Create(new Brand("British Gas"));
        Brand veho = brandRepository.Create(new Brand("Veho"));
        Brand philips = brandRepository.Create(new Brand("Philips"));
        Brand smartThings = brandRepository.Create(new Brand("SmartThings"));
        Brand nest = brandRepository.Create(new Brand("Nest"));
        Brand apple = brandRepository.Create(new Brand("Apple"));

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

        Console.WriteLine("Creating products:");
        ProductRepository productRepository = new ProductRepository();
        productRepository.DeleteAll();
        Console.WriteLine("- Amazon");
        Standalone echo = productRepository.Create(new Standalone("Echo", amazon, 149.99, alexa, null)) as Standalone;
        Standalone echoDot = productRepository.Create(new Standalone("Echo Dot", amazon, 49.99, alexa, null)) as Standalone;
        Console.WriteLine("- British Gas");
        Hub hiveHub = productRepository.Create(new Hub("Hive Hub", britishGas, 79.99)) as Hub;
        Accessory hiveThermostat = productRepository.Create(new Accessory("Hive Thermostat", britishGas, 99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Accessory hivePlug = productRepository.Create(new Accessory("Hive Active Plug", britishGas, 39.99, hive, new List<App>() { alexa }, hiveHub)) as Accessory;
        Bundle hiveActiveHeating = productRepository.Create(new Bundle("Hive Active Heating", britishGas, 179.99, new List<Product>() { hiveHub, hiveThermostat })) as Bundle;
        Console.WriteLine("- Philips");
        Console.WriteLine("- Veho");
        Standalone vehoBulb = productRepository.Create(new Standalone("Veho Kasa Bluetooth Smart LED Light Bulb - B22", veho, 29.99, vehoApp, null)) as Standalone;
        Console.WriteLine("- SmartThings");
        Console.WriteLine("- Nest");
        Standalone nestThermostat = productRepository.Create(new Standalone("Nest Learning Thermostat", nest, 199, nestApp, null)) as Standalone;
    }
}