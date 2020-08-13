using GrowingPlants.Infrastructure.Models;
using System;

namespace GrowingPlants.Infrastructure.Utilities
{
    public static class PictureHelper
    {
        /// <summary>
        /// Convert Source to Base64
        /// </summary>
        /// <param name="picture">Input Picture object</param>
        public static void ConvertToBase64(this Picture picture)
        {
            if (picture?.Source == null || picture.Source.Length == 0) return;

            picture.SourceAsBase64 = Convert.ToBase64String(picture.Source);
        }

        /// <summary>
        /// Convert Base64 to Source
        /// </summary>
        /// <param name="picture">Input Picture object</param>
        public static void ConvertToByteArray(this Picture picture)
        {
            if (picture == null || string.IsNullOrEmpty(picture.SourceAsBase64)) return;

            picture.Source = System.Text.Encoding.UTF8.GetBytes(picture.SourceAsBase64);
        }
    }
}
