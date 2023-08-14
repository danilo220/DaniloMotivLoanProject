﻿using Microsoft.EntityFrameworkCore;
using MotivWebApp.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Models
{
    //Used https://json2csharp.com/ with the random user api response payload to make my life easier :)
    //Decided to add all classes in a Single life for the Random User Api response but I normally would seperate these in different files
    
    //Root class to be serialized
    public class RandomUserDetails
    {
        public List<RandomUserDetail> results { get; set; }
        public Info info { get; set; }
    }
    public class RandomUserDetail: IUser<Name>
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public Login Login { get; set; }

        [JsonProperty("dob")]
        public Dob Dob { get; set; }

        [JsonProperty("registered")]
        public Registered Registered { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }

        [JsonProperty("nat")]
        public string Nat { get; set; }
    }
    public class Coordinates
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public class Dob
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }

    public class Id
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Info
    {
        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("results")]
        public int? Results { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class Location
    {
        [JsonProperty("street")]
        public Street Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postcode")]
        public object? Postcode { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }
    }

    public class Login
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("sha1")]
        public string Sha1 { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }
    }
    public class Name
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must provide your first name")]
        [JsonProperty("first")]
        public string First { get; set; }

        [Required(ErrorMessage = "You must provide your last name")]
        [JsonProperty("last")]
        public string Last { get; set; }
    }

    public class Picture
    {
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class Registered
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }
    }

    public class Street
    {
        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Timezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
