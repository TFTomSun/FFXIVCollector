using System;
using System.Linq;
using System.Threading.Tasks;
using TomSun.Portable.Factories;

namespace TomSun.FFXIVCollector.Apis.Lodestone
{
    public class LodestoneAutomation
    {
        public async Task<CharacterSearchResultModel[]> SearchCharactersAsync(string name)
        {
            using (var webView = Api.Create.HttpClientWebView())
            {
                var searchString = name.Replace(" ", "+");
                var searchBaseUri = new Uri($"https://eu.finalfantasyxiv.com/lodestone/community/search");
                var searchUri = searchBaseUri
                    .AddParameter("q", searchString)
                    .AddParameter("timezone_info", @"{""today"":{""method"":""point"",""epoch"":1509228000,""year"":2017,""month"":10,""date"":29}}")
                    .AddParameter("_", "1509292185491");
               
                await Task.Run(() => webView.NavigateAsync(searchUri));

                var divs = webView.Nodes().Divs().ToArray();

                var characterAnchors = webView.Nodes().Divs().Where(
                    ).Classes("frame__chara__box").Select(p => p.Parent).ToArray();
                return characterAnchors.Select(a => new CharacterSearchResultModel(a)).ToArray();
            }
        }
    }
}
