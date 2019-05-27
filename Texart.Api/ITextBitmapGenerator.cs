﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SkiaSharp;

namespace Texart.Api
{
    /// <summary>
    /// An <see cref="ITextBitmapGenerator"/> is used to generate <see cref="ITextBitmap"/>s given
    /// some configuration options.
    /// </summary>
    /// <seealso cref="ITextBitmap"/>
    /// <seealso cref="ITextBitmapRenderer"/>
    public interface ITextBitmapGenerator
    {
        /// <summary>
        /// Gets the ratio of source resolution to generated resolution. That is, one
        /// pixel in the generated text will come from sampling <c>Math.Pow(PixelSamplingRatio, 2)</c>
        /// pixels.
        /// For example, if <see cref="PixelSamplingRatio"/> is <c>2</c>, then <c>4</c>
        /// pixels from the image will be used to generate <c>1</c> character.
        /// Consequently, a value of <c>1</c> is loss-less.
        /// Note that implementations are only required to support ratios that perfectly divide both the width
        /// and height of the provided bitmap.
        /// For the sake of maintaining aspect ratio, implementations must "chunk" images evenly on both X and
        /// Y axes (using this many pixels).
        /// This creates the unfortunately scenario in the case that the width and height are distinct prime
        /// numbers (where the only valid sampling ratio is <c>1</c>). In that case, the image should be
        /// resized or cropped before text generation.
        /// </summary>
        /// <see cref="GenerateAsync"/>
        /// <see cref="TxBitmap.GetPerfectPixelRatios(SkiaSharp.SKBitmap)"/>
        int PixelSamplingRatio { get; }

        /// <summary>
        /// Generates a <see cref="ITextBitmap"/> with the <see cref="PixelSamplingRatio"/> adjusted dimensions.
        /// </summary>
        /// <param name="bitmap">The bitmap to generate data from.</param>
        /// <returns></returns>
        /// <seealso cref="PixelSamplingRatio"/>
        Task<ITextBitmap> GenerateAsync(SKBitmap bitmap);
    }
}
