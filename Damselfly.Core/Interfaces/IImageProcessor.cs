﻿using System.IO;
using System.Collections.Generic;
using Damselfly.Core.ImageProcessing;
using System.Threading.Tasks;

namespace Damselfly.Core.Interfaces
{
    public class ImageProcessResult
    {
        public bool ThumbsGenerated { get; set; }
        public string ImageHash { get; set; }
    }
    /// <summary>
    /// Interface representing a generic image processing pipeline. This
    /// allows us to swap out different implementations etc depending on
    /// performance and other characteristics.
    /// </summary>
    public interface IImageProcessor
    {
        Task<ImageProcessResult> CreateThumbs(FileInfo source, IDictionary<FileInfo, ThumbConfig> destFiles );
        void TransformDownloadImage(string input, Stream output, string waterMarkText = null);
        ICollection<string> SupportedFileExtensions { get; }
    }
}
