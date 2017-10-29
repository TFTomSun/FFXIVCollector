using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using NUnit.Framework;
using TomSun.Portable.Factories;

namespace TomSun.FFXIVCollector.Tests.Common
{
    [TestFixture]
    public abstract class UnitTest<TSelf>
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
}
