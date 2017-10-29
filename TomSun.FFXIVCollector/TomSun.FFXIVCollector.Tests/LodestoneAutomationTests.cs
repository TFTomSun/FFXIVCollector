using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TomSun.FFXIVCollector.Apis.Ladestone;
using TomSun.FFXIVCollector.Apis.Lodestone;
using TomSun.FFXIVCollector.Tests.Common;

namespace TomSun.FFXIVCollector.Tests
{

    public class LodestoneAutomationTests : UnitTest<LodestoneAutomationTests>
    {
        private LodestoneAutomation Automation => this.Get(() => new LodestoneAutomation());

        [Test]
        public void SimpleTest()
        {

        }
        [Test]
        public async Task SearchCharacterTest()
        {
            var results = await this.Automation.SearchCharactersAsync("ley sego");
            var result = results.Single();
            Assert.AreEqual(2215586, result.Id);
            Assert.IsTrue(
                result.ImageUrl.Contains(
                "https://img2.finalfantasyxiv.com/f/a0bdcaae75305f3061b894ddddf4a1a2_3fbff0e6b620e4d259dc427abc6574dafc0_96x96.jpg"));
        }
    }
}
