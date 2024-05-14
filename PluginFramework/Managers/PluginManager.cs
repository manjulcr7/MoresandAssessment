using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginFramework.Managers
{


    public class PluginManager
    {
        private List<IImageEffect> _plugins = new List<IImageEffect>();

        public PluginManager(string pluginDirectory)
        {
            LoadPlugins(pluginDirectory);
        }

        private void LoadPlugins(string pluginDirectory)
        {
            var dllFiles = Directory.GetFiles(pluginDirectory, "*.dll");
            foreach (var file in dllFiles)
            {
                var assembly = Assembly.LoadFrom(file);
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IImageEffect).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        var plugin = (IImageEffect)Activator.CreateInstance(type);
                        _plugins.Add(plugin);
                    }
                }
            }
        }

        public IEnumerable<IImageEffect> GetPlugins()
        {
            return _plugins;
        }

        public void AddPlugin(IImageEffect plugin)
        {
            _plugins.Add(plugin);
        }

        public void RemovePlugin(IImageEffect plugin)
        {
            _plugins.Remove(plugin);
        }
    }

}
