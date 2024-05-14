
using PluginFramework.Managers;
using PluginFramework.Models;
using PluginFramework.Services;
using System;
using System.Collections.Generic;

namespace PluginFramework
{

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the plugin manager and load plugins from a directory
            var pluginManager = new PluginManager("path_to_plugins");

            // Create an image processor
            var imageProcessor = new ImageProcessor();

            // Simulate loading an image
            var image1 = new ImageData("Image1");

            // Get the available plugins
            var plugins = pluginManager.GetPlugins();

            // Create a list of effects to apply
            var effects = new List<Tuple<IImageEffect, Dictionary<string, object>>>();
            foreach (var plugin in plugins)
            {
                effects.Add(new Tuple<IImageEffect, Dictionary<string, object>>(plugin, new Dictionary<string, object>()));
            }

            // Add image with effects to the processor
            imageProcessor.AddImageWithEffects(image1, effects);

            // Process images
            imageProcessor.ProcessImages();

            // Retrieve and display processed images
            foreach (var processedImage in imageProcessor.GetProcessedImages())
            {
                Console.WriteLine(processedImage.Data);
            }
        }
    }

}