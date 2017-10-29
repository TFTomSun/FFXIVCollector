using System;
using System.Linq;
using TomSun.FFXIVCollector.Apis.Ladestone;
using TomSun.Portable.WebAutomation.Interfaces;

namespace TomSun.FFXIVCollector.Apis.Lodestone
{
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