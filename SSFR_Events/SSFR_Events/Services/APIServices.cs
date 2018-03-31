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

            var client = App.client;

            var model = new UserSignUp_In
            {
                Email = email,
                Password = passWord,
                ConfirmPassword = confirmPassWord
            };

            var Json = JsonConvert.SerializeObject(model);

            var content = new StringContent(Json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("/api/Account/Register", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return false;
            }
            
        }

        public async Task<bool> LoginAsync(string email, string password)
        {

            var client = App.client;

            var model = new UserSignUp_In
            {
                Email = email,
                Password = password,
            };

            var Json = JsonConvert.SerializeObject(model);

            var content = new StringContent(Json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/Account/Login", content);

            return response.IsSuccessStatusCode;

        }
    }
}
