using System.Collections.Generic;
using System.Linq;

namespace XBreweryDbApp.Features.BreweryList
{
    class BreweryListProvider
    {
        public IEnumerable<Brewery> GetBreweries()
        {
            return Enumerable.Range(0, 20)
                .Select(i => new Brewery { Name = "Brewery " + i })
                .ToList();
        }
    }
}
