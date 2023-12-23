﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class BaseApi : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        public BaseApi(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> PostToApi(string controllerMethodUrl, object model)
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                var response = await client.PostAsJsonAsync(controllerMethodUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> GetToApi(string controllerMethodUrl)
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");

                var response = await client.GetAsync(controllerMethodUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
