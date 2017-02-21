namespace XBreweryDbPrismApp.Views.Details
{
    public interface IDetailPageFeatures
    {
        string GetBreweryDescription(string breweryId);
        bool IsBreweryFavorite(string breweryId);
        void SetAsFavorite(string id);
        void RemoveFromFavorites(string id);


    }
}