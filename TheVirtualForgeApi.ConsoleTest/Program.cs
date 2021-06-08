﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheVirtualForgeApi.ApplicationCore.DTO;
using TheVirtualForgeApi.ApplicationCore.Models;

namespace TheVirtualForgeApi.ConsoleTest
{
    /// <summary>
    /// Console application for test api endpoints
    /// </summary>
    public class Program
    {
        static HttpClient httpClient = new HttpClient();
        static Uri uri = new Uri("https://LocalHost/443");
        static int Main(string[] args)
        {
            //Get albums from controller
            GetSingleAlbumsAsync();
            Console.WriteLine("I am testing api endpoints");
            Console.ReadLine();
            return 0;
        }
        /// <summary>
        /// Get a single album
        /// </summary>
        private static void GetSingleAlbumsAsync()
        {
            var response =  httpClient.GetAsync("/api/v1/album/artist?title=Great is your mercy&artistName=Donnie McClurkin").Result;
            if (response.StatusCode== System.Net.HttpStatusCode.OK)
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<AlbumDTO>>(albumsString);
                var album = responseObjectDTO.Data;
                Console.WriteLine($"{album.ArtistName} album title {album.Title} is available in {album.AlbumType} and has stock quantity {album.Stock}");
            }
            else
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<AlbumDTO>>(albumsString);
                Console.WriteLine($"Error getting album, {responseObjectDTO.Message} with status code {responseObjectDTO.StatusCode}");

            }
        }
        /// <summary>
        /// Get all albums
        /// </summary>
        private static void GetAlbumsAsync()
        {
           
            httpClient.BaseAddress = uri;
            var response = httpClient.GetAsync("/api/v1/album").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<AlbumDTO>>(albumsString);
                var album = responseObjectDTO.Data;
                Console.WriteLine($"{album.ArtistName} album title {album.Title} is available in {album.AlbumType} and has stock quantity {album.Stock}");
            }
            else
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<AlbumDTO>>(albumsString);
                Console.WriteLine($"Error getting album, {responseObjectDTO.Message} with status code {responseObjectDTO.StatusCode}");

            }
        }
        /// <summary>
        /// Deleting album by ID
        /// </summary>
        private static void DeleteAlbumAsync()
        {
            int albumID = 1;
            httpClient.BaseAddress = uri;
            var response = httpClient.DeleteAsync($"/api/v1/album/{albumID}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<bool>>(albumsString);
                var album = responseObjectDTO.Data;
                Console.WriteLine($"Album successfully deleted");
            }
            else
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<bool>>(albumsString);
                Console.WriteLine($"Error deleting album, {responseObjectDTO.Message} with status code {responseObjectDTO.StatusCode}");

            }
        }
       /// <summary>
       /// create a new album
       /// </summary>
        private static void PostAlbumAsync()
        {
          
            httpClient.BaseAddress = uri;
            var newAlbum = new Album() { AlbumTypeID = 1, ArtistName = "Donnie McClurkin", Title = "Great is your mercy", Stock = 5 };
            var albumJson = new StringContent(JsonConvert.SerializeObject(newAlbum), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync($"/api/v1/album",albumJson).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<Album>>(albumsString);
                var album = responseObjectDTO.Data;
                Console.WriteLine($"Album successfully created");
            }
            else
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<Album>>(albumsString);
                Console.WriteLine($"Error creating album, {responseObjectDTO.Message} with status code {responseObjectDTO.StatusCode}");

            }
        }
       /// <summary>
       /// updated existing album
       /// </summary>
        private static void UpdateAlbumAsync()
        {

            httpClient.BaseAddress = uri;
            var newAlbum = new Album() { AlbumTypeID = 1, ArtistName = "Donnie McClurkin", Title = "Great is your mercy", Stock =2 };
            var albumJson = new StringContent(JsonConvert.SerializeObject(newAlbum), Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"/api/v1/album", albumJson).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<Album>>(albumsString);
                var album = responseObjectDTO.Data;
                Console.WriteLine($"Album successfully updated");
            }
            else
            {
                var albumsString = response.Content.ReadAsStringAsync().Result;
                var responseObjectDTO = JsonConvert.DeserializeObject<ResponseObjectDTO<Album>>(albumsString);
                Console.WriteLine($"Error creating album, {responseObjectDTO.Message} with status code {responseObjectDTO.StatusCode}");

            }
        }
    }
}