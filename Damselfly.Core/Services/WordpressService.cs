﻿using System;
using System.Linq;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;
using Damselfly.Core.Models;
using System.IO;
using Damselfly.Core.Interfaces;
using Damselfly.Core.ImageProcessing;

namespace Damselfly.Core.Services
{
    /// <summary>
    /// Service for accessing Wordpress and uploading media.
    /// </summary>
    public class WordpressService
    {
        public static WordpressService Instance { get; private set; }
        private WordPressClient _client;

        public WordpressService()
        {
            Instance = this;

            ResetClient();
        }

        /// <summary>
        /// Upload the basket imagesconfigured Wordpress  site's media library
        /// TODO: Add option to watermark and resize images when uploading
        /// </summary>
        /// <returns></returns>
        public async Task UploadBasketToWordpress()
        {
            try
            {
                var images = BasketService.Instance.SelectedImages
                                   .Select(x => x)
                                   .ToList();

                StatusService.Instance.StatusText = $"Uploading {images.Count()} to Wordpress...";

                Logging.LogVerbose($"Checking token validity...");

                bool validToken = await CheckTokenValidity();

                if( validToken )
                {
                    foreach (var image in images)
                    {
                        using var memoryStream = new MemoryStream();

                        //This saves to the memoryStream with encoder
                        ImageProcessService.Instance.TransformDownloadImage(image.FullPath, memoryStream);

                        // The position needs to be reset, before we push it to Wordpress
                        memoryStream.Position = 0; 

                        StatusService.Instance.StatusText = $"Uploading {image.FileName} to Wordpress.";

                        await _client.Media.Create(memoryStream, image.FileName);

                        Logging.LogVerbose($"Image uploaded: {image.FullPath} successfully.");
                    }

                    StatusService.Instance.StatusText = $"{images.Count()} images uploaded to Wordpress.";
                }
                else
                {
                    Logging.LogError($"Token was invalid.");
                    StatusService.Instance.StatusText = $"Authentication error uploading to Wordpress.";
                }
            }
            catch (Exception e)
            {
                Logging.LogError($"Error uploading to Wordpress: {e.Message}");
                StatusService.Instance.StatusText = $"Error uploading images to Wordpress. Please check the logs.";
            }
        }

        /// <summary>
        /// See if the token we have is valid. If it is, return true.
        /// If it's invalid (either we never had one, or it's expired)
        /// request a new one.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CheckTokenValidity()
        {
            bool gotToken = false;

            if (_client == null)
            {
                // Create the one-time client.
                // TODO: Destroy this if the settings are updated.
                _client = GetClient();

                if (_client == null)
                    return false;
            }

            // Now check if we have a valid token (they expire after
            // 24 hours) and if not, obtain one
            gotToken = await _client.IsValidJWToken();

            if (! gotToken )
            {
                var user = ConfigService.Instance.Get(ConfigSettings.WordpressUser);
                var pass = ConfigService.Instance.Get(ConfigSettings.WordpressPassword);

                Logging.LogVerbose($"No valid JWT token. Requesting a new one.");

                await _client.RequestJWToken( user, pass );

                gotToken = await _client.IsValidJWToken();
            }

            var state = gotToken ? "valid" : "invalid";
            Logging.LogVerbose($"JWT token is {state}.");

            return gotToken;
        }

        /// <summary>
        /// Reset the client - use this if the settings are updated.
        /// </summary>
        public void ResetClient()
        {
            _client = GetClient();

            if( _client != null )
                Logging.Log("Wordpress API client reset.");
        }

        /// <summary>
        /// Create the Wordpress PCL client.
        /// </summary>
        /// <returns></returns>
        private WordPressClient GetClient()
        {
            WordPressClient client = null;

            try
            {
                var wpUrl = ConfigService.Instance.Get(ConfigSettings.WordpressURL);

                if (!String.IsNullOrEmpty(wpUrl))
                {
                    var baseUrl = new Uri(wpUrl);
                    var url = new Uri(baseUrl, "/wp-json/");

                    Logging.LogVerbose($"Initialising Wordpress Client for {url}...");

                    // JWT authentication
                    client = new WordPressClient(url.ToString());
                    client.AuthMethod = AuthMethod.JWT;

                    Logging.Log($"JWT Auth token generated successfully.");
                }
                else
                    Logging.Log("Wordpress integration was not configured.");
            }
            catch (Exception ex)
            {
                Logging.LogError($"Unable to create Wordpress Client: {ex.Message}");
                client = null;
            }

            return client;
        }

    }
}
