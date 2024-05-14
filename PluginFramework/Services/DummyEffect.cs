using PluginFramework.Models;

namespace PluginFramework.Services
{
    public class DummyEffect : IImageEffect
    {
        public string Name => "Dummy Effect";

        public void ApplyEffect(ref ImageData image, Dictionary<string, object> parameters)
        {
            // Simulate applying an effect by appending text
            image.Data += " + DummyEffectApplied";
        }
    }

}
