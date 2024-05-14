using PluginFramework.Models;

namespace PluginFramework.Services
{
    public interface IImageEffect
    {
        string Name { get; }
        void ApplyEffect(ref ImageData image, Dictionary<string, object> parameters);
    }

}
