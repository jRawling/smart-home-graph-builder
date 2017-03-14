using System.Collections.Generic;
using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;

namespace GraphBuilder.Ui
{
	public class StoreManager
	{
		public Store Store { get; private set; }
		public Store Play { get; private set; }

		public IEnumerable<Store> All { get; private set; }

        public StoreManager(BrandManager brands)
        {
            StoreRepository storeRepository = new StoreRepository();
            storeRepository.DeleteAll();
			Store = storeRepository.Create(new Store("App Store", brands.Apple));
			Play = storeRepository.Create(new Store("Play", brands.Google));
			All = new List<Store>() { Store, Play };
        }
    }
}