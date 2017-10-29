using System;
using System.Runtime.CompilerServices;
using TomSun.Portable.Factories;

namespace TomSun.FFXIVCollector.Apis.Ladestone
{
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
}