using BroyLiftFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BroyLiftFront.Services
{
    public class ApiService
    {
        public async Task<List<Exercise>> GetDiary()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", ""));
            var response = await httpClient.GetStringAsync("https://broylift.azurewebsites.net/api/exercise");
            return JsonConvert.DeserializeObject<List<Exercise>>(response);
        }

        //public async Task<Exercise> GetDiary(int id)
        //{
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", ""));
        //    var response = await httpClient.GetStringAsync("https://broylift.azurewebsites.net/api/instructors/" + id);
        //    return JsonConvert.DeserializeObject<Exercise>(response);
        //}

        public async Task<bool> StartExercise(Exercise exercise)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(exercise);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", ""));
            var response = await httpClient.PostAsync("https://broylift.azurewebsites.net/api/exercise", content);
            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<TokenResponse> GetToken(string email, string password)
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"grant_type=password&username={email}&password={password}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://broylift.azurewebsites.net//Token", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(jsonResult);
            return result;
        }

        public async Task<bool> RegisterUser(string email, string password, string confirmPassword)
        {
            var registerModel = new Register()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://broylift.azurewebsites.net/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }
    }
}

