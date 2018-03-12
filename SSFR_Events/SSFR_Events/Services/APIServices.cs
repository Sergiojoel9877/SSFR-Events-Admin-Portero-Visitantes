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

            HttpContent content = new StringContent(Json);

            var response = await client.PostAsync("api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }
    }
}
