using JWT_Authentication.DMO;
using static JWT_Authentication.Services.AdventureWorksService;

namespace JWT_Authentication.Services
{
    public class AdventureWorksService: IAdventureWorksService
    {
        public interface IAdventureWorksService
        {
            List<Product> GetProductByColor(string color);
            List<Person> GetPerson();
        }

        private AdventureWorks2019Context _context;
        public AdventureWorksService(AdventureWorks2019Context context)
        {
            _context = context;
        }
        public List<Product> GetProductByColor(string color)
        {
            return _context.Products.Where(c => c.Color == color).ToList();
        }
        public List<Person> GetPerson()
        {
            return _context.People.ToList();
        }
    }
}
