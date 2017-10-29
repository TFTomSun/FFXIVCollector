using System;
using System.Threading.Tasks;
using TomSun.Portable.Factories;
using System.Linq;
using System.Runtime.CompilerServices;
using TomSun.Portable.WebAutomation.Interfaces;

namespace TomSun.FFXIVCollector.Apis.Ladestone
{
    public class LadestoneAutomation
    {
        public async Task<CharacterSearchResultModel[]> SearchCharacter(string name)
        {
            using (var webView = Api.Create.HttpClientWebView())
            {
                var searchString = name.Replace(string.Empty, "+");

                await Task.Run(() => webView.Navigate(
                    new Uri($"https://eu.finalfantasyxiv.com/lodestone/community/search/?q={searchString}")));

                var characterAnchors = webView.Nodes().Paragraphs().Where(
                    ).Classes("frame__chara__box").Select(p => p.Parent);
                return characterAnchors.Select(a => new CharacterSearchResultModel(a)).ToArray();
            }
        }
    }

    public abstract class Model
    {
        private IExtendableObject Cache { get; } = new ExtendableObject();

        protected T Get<T>(Func<T> getDefault = null, [CallerMemberName] string propertyName = null)
        {
            return this.Cache.GetMember(propertyName, getDefault);
        }

        protected void Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            this.Cache.SetMember(propertyName, value);
        }
    }

    public class CharacterSearchResultModel: Model
    {
        public IHtmlNode CharacterResultAnchor { get; }

        internal CharacterSearchResultModel(IHtmlNode characterResultAnchor)
        {
            this.CharacterResultAnchor = characterResultAnchor;
        }

        [Obsolete("For serialization purposes only")]
        internal CharacterSearchResultModel()
        {
        }


        public string ImageUrl
        {
            get => this.Get(() => this.CharacterResultAnchor.Descendants().Images().Single().Src());
            set => this.Set(value);
        }

        public string DetailsUrl =>
            $"https://eu.finalfantasyxiv.com//lodestone/character/{this.Id}/";

        public int Id
        {
            get => this.Get(() =>this.CharacterResultAnchor.Href().Split(
                '/', StringSplitOptions.RemoveEmptyEntries).Last().ToInt32());
            set => this.Set(value);
        }
    }
}
