using System.Collections.Generic;
using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;

namespace GraphBuilder.Ui
{
	public class AppStoreManager
	{
		public AppStore AppStore { get; private set; }
		public AppStore Play { get; private set; }

		public IEnumerable<AppStore> All { get; private set; }

        public AppStoreManager(BrandManager brands)
        {
            AppStoreRepository appStoreRepository = new AppStoreRepository();
            appStoreRepository.DeleteAll();
			AppStore = appStoreRepository.Create(new AppStore("App Store", brands.Apple));
			Play = appStoreRepository.Create(new AppStore("Play", brands.Google));
			All = new List<AppStore>() { AppStore, Play };
        }
    }
}