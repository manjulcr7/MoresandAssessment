using PluginFramework.Models;
using PluginFramework.Services;
using System;
using System.Collections.Generic;

namespace PluginFramework
{


    public class ImageProcessor
    {
        private List<Tuple<ImageData, List<Tuple<IImageEffect, Dictionary<string, object>>>>> _imagesWithEffects
            = new List<Tuple<ImageData, List<Tuple<IImageEffect, Dictionary<string, object>>>>>();

        public void AddImageWithEffects(ImageData image, List<Tuple<IImageEffect, Dictionary<string, object>>> effects)
        {
            _imagesWithEffects.Add(new Tuple<ImageData, List<Tuple<IImageEffect, Dictionary<string, object>>>>(image, effects));
        }

        public void ProcessImages()
        {
            foreach (var imageWithEffects in _imagesWithEffects)
            {
                var image = imageWithEffects.Item1;
                var effects = imageWithEffects.Item2;

                foreach (var effect in effects)
                {
                    effect.Item1.ApplyEffect(ref image, effect.Item2);
                }
            }
        }

        public IEnumerable<ImageData> GetProcessedImages()
        {
            foreach (var imageWithEffects in _imagesWithEffects)
            {
                yield return imageWithEffects.Item1;
            }
        }
    }

}
