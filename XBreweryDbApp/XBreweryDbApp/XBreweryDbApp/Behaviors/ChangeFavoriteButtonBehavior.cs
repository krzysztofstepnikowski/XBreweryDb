using System;
using Xamarin.Forms;

namespace XBreweryDbApp.Behaviors
{
    public class ChangeFavoriteButtonBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button button)
        {
            button.Clicked += OnButtonChanged;
            base.OnAttachedTo(button);
        }


        protected override void OnDetachingFrom(Button button)
        {
            button.Clicked -= OnButtonChanged;
            base.OnDetachingFrom(button);
        }


        private void OnButtonChanged(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.BackgroundColor = button.BackgroundColor != Color.Red ? Color.Red : Color.Green;
            button.Text = button.Text != "Dodaj do ulubionych"
                ? button.Text = "Dodaj do ulubionych"
                : button.Text = "Usuń z ulubionych";
        }
    }
}
