using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CocosSharpMemoryLeakSample
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = nameof(MainPage);

            var btnStart = new Button { Text = "Game Start" };
            btnStart.Clicked += (s, e) => Navigation.PushAsync(new GamePage());

            var btnGC = new Button { Text = "GC.Collect();" };
            btnGC.Clicked += (s, e) => GC.Collect();

            Content = new StackLayout { Children = { btnStart, btnGC } };
        }
    }
}
