using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CalculatorClientApp.Models;
namespace CalculatorClientApp.Services
{
    public class CalculatorWebAPIProxy
    {
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5013/api/" : "http://localhost:5013/api/";
        

        public CalculatorWebAPIProxy()
        {
            this.client = new HttpClient();
            this.baseUrl = BaseAddress;
        }

        public async Task<ExerciseResult> SolvePostAsync(Exercise exercise)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}solve";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(exercise);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ExerciseResult result = JsonSerializer.Deserialize<ExerciseResult>(resContent, options);
                    return result;
                }
                else
                {
                    ExerciseResult exerciseResult = new ExerciseResult
                    {
                        Success = false
                    };
                    return exerciseResult;
                }
            }
            catch (Exception ex)
            {
                ExerciseResult exerciseResult = new ExerciseResult
                {
                    Success = false
                };
                return exerciseResult;
            }
        }

        public async Task<ExerciseResult> SolveGetAsync(Exercise exercise)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}solve?firstVal={exercise.FirstVal}&op={exercise.Op}&secondVal={exercise.SecondVal}";
            try
            {
                //Call the server API
                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ExerciseResult result = JsonSerializer.Deserialize<ExerciseResult>(resContent, options);
                    return result;
                }
                else
                {
                    ExerciseResult exerciseResult = new ExerciseResult
                    {
                        Success = false
                    };
                    return exerciseResult;
                }
            }
            catch (Exception ex)
            {
                ExerciseResult exerciseResult = new ExerciseResult
                {
                    Success = false
                };
                return exerciseResult;
            }
        }


    }
}

