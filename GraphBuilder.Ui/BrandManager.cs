using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphBuilder.Ui
{
    public class BrandManager
    {
        public BrandManager()
        {
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

        }
    }
}
