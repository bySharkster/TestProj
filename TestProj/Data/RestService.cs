﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProj.Models;

namespace TestProj.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";
        public RestService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applications/x-www-form-urlencoded "));
            
        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant type", grant_type),
                new KeyValuePair<string, string>("username", user.Username),
                new KeyValuePair<string, string>("password", user.Password)
            };
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.LoginUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.Expire_date = dt.AddSeconds(response.Expire_in);
            return response;
        }
        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }
        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Access_token);
            try
            {
                var Result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var Jsonresult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(Jsonresult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Access_token);
            try
            {
                var response = await client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var Jsonresult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(Jsonresult);
                        return ContentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }

            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
