using System;
using Xamarin.Forms;

namespace XBreweryDbApp.Behaviors
{
    public class ChangeFavoriteIconButtonBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button button)
        {
            button.Clicked += ChangeIconButton;
            base.OnAttachedTo(button);
        }


        protected override void OnDetachingFrom(Button button)
        {
            button.Clicked -= ChangeIconButton;
            base.OnDetachingFrom(button);
        }

        private void ChangeIconButton(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Image.File = button.Image.File != "ic_favorite_border_black_24dp.png"
                ? button.Image.File = "ic_favorite_border_black_24dp.png"
                : button.Image.File = "ic_favorite_black_24dp.png";
        }
    }
}
