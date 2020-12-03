using CreateAccountPage_ex4.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace CreateAccountPage_ex4.Services
{
    public class CreateAccountService : ICreateAccountService
    {
        public async Task<bool> CreateAccount(UserModel user)
        {
            string base_url = "http://10.0.2.2/APIForTestingXamarin/api/tblUsers";
            if(Device.RuntimePlatform != Device.Android)
            {
                base_url = "http://localhost/APIForTestingXamarin/api/tblUsers";
            }

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(base_url.ToString());

                UserModel userInput = new UserModel()
                {
                    userName = user.userName,
                    firstName = user.firstName,
                    lasttName = user.lasttName,
                    email = user.email,
                    password = user.password,
                    passwordConfirm = user.passwordConfirm
                };

                string jsonData = JsonConvert.SerializeObject(userInput);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage respone = await client.PostAsync(base_url, content);

                if(respone.StatusCode.ToString()== "Created")
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch(Exception ex)
            {
                return await Task.FromResult(false);
            }

        }
    }
}
