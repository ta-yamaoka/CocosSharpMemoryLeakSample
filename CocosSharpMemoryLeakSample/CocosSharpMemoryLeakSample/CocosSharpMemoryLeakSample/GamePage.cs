using CocosSharp;
using CocosSharpMemoryLeakSample.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CocosSharpMemoryLeakSample
{
    public class GamePage : ContentPage
    {
        private CCGameView gv = null;
        private CCScene scene = null;

        public GamePage() { Title = nameof(GamePage); }

        public void HandleViewCreated(object sender, EventArgs e)
        {
            gv = sender as CCGameView;

            if (gv != null)
            {
                scene = new GameScene(gv);
                gv.RunWithScene(scene);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Content = new CocosSharpView()
            {
                // MemoryLeak1
                ViewCreated = HandleViewCreated,
            };
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (scene != null)
            {
                scene.RemoveAllChildren(true);
                scene.RemoveAllListeners();
                scene.Dispose();
                scene = null;
            }

            if (gv != null)
            {
                gv.ViewCreated -= HandleViewCreated;    // MemoryLeak1対応コード
                //gv.Dispose(); // RunWithSceneを使う場合、このコードを実行すると落ちることがある
                gv = null;
            }

            if (Content != null)
                Content = null;
        }
    }
}
