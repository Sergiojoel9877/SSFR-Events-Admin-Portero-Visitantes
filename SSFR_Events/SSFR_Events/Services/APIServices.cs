using Newtonsoft.Json;
using SSFR_Events.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SSFR_Events.Services
{
    public class APIServices
    {
        public async Task<bool> RegisterAsync(string email, string passWord, string confirmPassWord)
        {

            var client = App.Oauthclient;

            var model = new UserSignUp
            {
                Email = email,
                Password = passWord,
                ConfirmPassword = confirmPassWord
            };

            var Json = JsonConvert.SerializeObject(model);

            var content = new StringContent(Json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("api/Account/Register", content);

                Console.WriteLine("" + await response.Content.ReadAsStringAsync());

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return false;
            }
            
        }

        public async Task<string> LoginAsync(string email, string password, bool remember)
        {

            var client = App.Oauthclient;

            var model = new UserSignIn
            {
                Email = email,
                Password = password,
                RememberMe = false,
            };

            var Json = JsonConvert.SerializeObject(model);

            var content = new StringContent(Json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("api/Account/Login", content);

                var data = await response.Content.ReadAsStringAsync();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<string> GetUserClaims()
        {
            HttpResponseMessage response = await App.client.GetAsync("api/Account/Claim");

            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine(json);

            return json;
            
        }
    }
}
