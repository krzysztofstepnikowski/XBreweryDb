namespace XBreweryDbPrismApp.Features.BreweryList
{
    public class Brewery
    {
        public string Id { get; set; }
       
        public bool IsFavorite { get; set; }
       
        public string Name { get; set; }


        public Brewery()
        {
        }

        public Brewery(string id, bool isFavorite, string name)
        {
            Id = id;
            IsFavorite = isFavorite;
            Name = name;
           
        }
    }
}
