using Newtonsoft.Json;
using PracticeWPFApp.Utilities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeWPFApp.Models.API
{
    public class HTTPRequests
    {
        public const string BaseURL = "https://localhost:7213";
        #region Аккаунт
        // Запрос на регистрацию
        public static void RegisterUser(string username, string password,
            string fio)
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest("/Auth/CreateAccount", Method.Post);

            User user = new()
            {
                ID = Guid.NewGuid(),
                Login = username,
                Password = password,
                Fio = fio
            };
            
            request.AddJsonBody(user);
            client.Execute(request);
        }
        // Запрос на авторизацию
        public static string GetToken(string username, string password)
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest($"/Auth/GetToken?login={username}&&password={password}", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                MessageBox.Show("Ошибка. Что произошло? Не придумала, но обязательно расскажу позже!");

            string token = response.Content!;
            TokenWorker.AddToken(token);

            return token;
        }
        #endregion

        #region Прогноз
        // Запрос на вывод списка городов
        public static List<Cities> GetCities(string token)
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest($"/Weather/GetCities?token={token}", Method.Get);
            var response = client.Execute(request);
            var result = new List<Cities>();

            try
            {
                result = JsonConvert.DeserializeObject<List<Cities>>(response.Content!);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            return result!;
        }
        // Запрос на показ прогноза погоды
        public static List<Weathers> GetWeather(string token)
        {
            var client = new RestClient(BaseURL);
            var request = new RestRequest($"/Weather/GetWeatherByCity?token={token}", Method.Get);
            var response = client.Execute(request);
            var result = new List<Weathers>();

            try
            {
                result = JsonConvert.DeserializeObject<List<Weathers>>(response.Content!);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            return result!;
        }
        #endregion
    }
}
