using GraphBuilder.Ui.Entities;
using GraphBuilder.Ui.Repositories;

namespace GraphBuilder.Ui
{
	public class BrandManager
	{
		public Brand Amazon { get; private set; }
		public Brand Apple { get; private set; }
		public Brand Belkin { get; private set; }
		public Brand BritishGas { get; private set; }
		public Brand Philips { get; private set; }
		public Brand SmartThings { get; private set; }
		public Brand Nest { get; private set; }
		public Brand Netatmo { get; private set; }
		public Brand Netgear { get; private set; }
		public Brand Ring { get; private set; }
		public Brand Panasonic { get; private set; }
		public Brand Dlink { get; private set; }
		public Brand Google { get; private set; }
		public Brand Veho { get; private set; }
		public Brand Tado { get; private set; }
        public Brand Samsung { get; private set; }

        public BrandManager()
        {
            BrandRepository brandRepository = new BrandRepository();
            brandRepository.DeleteAll();
            Amazon = brandRepository.Create(new Brand("Amazon"));
            Belkin = brandRepository.Create(new Brand("Belkin"));
            BritishGas = brandRepository.Create(new Brand("British Gas"));
            Veho = brandRepository.Create(new Brand("Veho"));
            Philips = brandRepository.Create(new Brand("Philips"));
            SmartThings = brandRepository.Create(new Brand("SmartThings"));
            Nest = brandRepository.Create(new Brand("Nest"));
            Apple = brandRepository.Create(new Brand("Apple"));
            Netatmo = brandRepository.Create(new Brand("Netatmo"));
            Netgear = brandRepository.Create(new Brand("Netgear"));
            Ring = brandRepository.Create(new Brand("Ring"));
            Panasonic = brandRepository.Create(new Brand("Panasonic"));
			Dlink = brandRepository.Create(new Brand("D-Link"));
			Google = brandRepository.Create(new Brand("Google"));
            Samsung = brandRepository.Create(new Brand("Samsung"));
        }
    }
}