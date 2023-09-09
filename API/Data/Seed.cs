using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUSers(DataContext context){
            if(await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.Json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var users = JsonSerializer.Deserialize<List<User>>(userData,options);

            foreach(var user in users){
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pas$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
        public static async Task SeedPhotos(DataContext context){
            if(await context.Photos.AnyAsync()) return;

            var photosData = await File.ReadAllTextAsync("Data/PhotoSeedData.Json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var photos = JsonSerializer.Deserialize<List<Photo>>(photosData,options);

            foreach (var photo in photos)
            {
                context.Add(photo);
            }


            await context.SaveChangesAsync();        
        }
    }
}