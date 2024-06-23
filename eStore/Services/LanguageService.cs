﻿
using System.Net.Http.Headers;
using System.Text;
using eStore.Repositories;
using eStore.Services.Interfaces;
using Newtonsoft.Json;

namespace eStore.Services
{
    public class LanguageService(IConfiguration configuration, HttpClient httpClient, IStoreRepository storeRepository) : ILanguageService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;
        private IStoreRepository _storeRepository = storeRepository;

        /// <summary>
        /// Gets the response asynchronously based on the user input.
        /// </summary>
        /// <param name="userInput">The user input to process.</param>
        /// <returns>The response generated by processing the user input.</returns>
        public async Task<string> GetResponseAsync(string userInput)
        {
            var key = _configuration["LanguageService:Key"];
            var endpoint = _configuration["LanguageService:Endpoint"];

            try
            {               
                var categories = _storeRepository.GetProducts().Select(p => p.Category).Distinct().ToArray().ToString();

                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", key);
                request.Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "system", content = @"You are a helpful assistant. When a user asks about products, objects, or nouns, follow these guidelines:
                            1. Provide the name of the product, object, or noun in the 'product' field as an array and set 'is_related_to_product' to true.
                            2. Provide a short description in the 'natural_response' field.
                            3. Suggest names of products in the 'product' field as an array when explicitly or implicitly asked for one or more products. Otherwise, leave the 'product' field as an empty array.
                            4. If the query asks for something but does not provide a relevant product or object name, set 'is_non_relevant_query' to true and state in 'natural_response' that you cannot assist further unless a specific product or object is specified.
                            5. Guide the user to ask specifically about products or objects that match the provided category."},
                        new { role = "user", content = "This is the user’s input: '" + userInput + "'" + $". If there are products associated with the element, compare them with the provided categories: {categories} and indicate if they match."
                        + @"Return the answer in the following JSON format: 
                            {
                                'product': <product_array>,
                                'is_related_to_category': <true_or_false>,
                                'natural_response': '<short_response>',
                                'is_related_to_product': <true_or_false>,
                                'is_greeting': <true_or_false>,
                                'is_farewell': <true_or_false>,
                                'is_non_relevant_query': <true_or_false>
                            }"}
                    },
                    max_tokens = 150
                }), Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                var deserializedResponse = JsonConvert.DeserializeObject<OpenAiResponse>(responseContent);
                if (deserializedResponse == null)
                {
                    return "Sorry, I couldn't process your request.";
                }

                var content = deserializedResponse.Choices[0].Message.Content;
                content = content.Replace("'", "\"");
                var chatResponse = JsonConvert.DeserializeObject<BotResponse>(content);
                
                if (chatResponse == null)
                {
                    return "Sorry, I couldn't process your request.";
                }
                
                return chatResponse.Natural_Response;
            }
            catch (Exception ex)
            {
                return ex.Message + $"Endpoint: {endpoint}";
            }
    
            
        }
    }

    
    
}

