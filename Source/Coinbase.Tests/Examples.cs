﻿using System;
using System.Collections.Generic;
using Coinbase.Commerce.Models;
using Newtonsoft.Json.Linq;

namespace Coinbase.Tests
{
   public static class Examples
   {
      public const string Pagination = @"
      {
        ""order"": ""desc"",
        ""starting_after"": null,
        ""ending_before"": null,
        ""total"": 25,
        ""yielded"": 20,
        ""limit"": 20,
        ""previous_uri"": null,
        ""next_uri"": ""https://api.commerce.coinbase.com/checkouts?limit=20&starting_after=fb6721f2-1622-48f0-b713-aac6c819b67a"",
        ""cursor_range"": [""a76721f2-1611-48fb-a513-aac6c819a9d6"", ""fb6721f2-1622-48f0-b713-aac6c819b67a""]
    }";

      public static Pagination PaginationModel => new Pagination
         {
            Order = ListOrder.Desc,
            StartingAfter = null,
            EndingBefore = null,
            Total = 25,
            Yielded = 20,
            Limit = 20,
            PreviousUri = null,
            NextUri = "https://api.commerce.coinbase.com/checkouts?limit=20&starting_after=fb6721f2-1622-48f0-b713-aac6c819b67a",
            CursorRange = new[] {"a76721f2-1611-48fb-a513-aac6c819a9d6", "fb6721f2-1622-48f0-b713-aac6c819b67a"}
         };

      public const string Charge = @"
{
      ""code"": ""66BEOV2A"",
      ""name"": ""The Sovereign Individual"",
      ""description"": ""Mastering the Transition to the Information Age"",
      ""logo_url"": ""https://commerce.coinbase.com/charges/ybjknds.png"",
      ""hosted_url"": ""https://commerce.coinbase.com/charges/66BEOV2A"",
      ""created_at"": ""2017-01-31T20:49:02Z"",
      ""expires_at"": ""2017-01-31T21:04:02Z"",
      ""checkout"": {
          ""id"": ""a76721f2-1611-48fb-a513-aac6c819a9d6""
      },
      ""timeline"": [
        {
          ""time"": ""2017-01-31T20:49:02Z"",
          ""status"": ""NEW""
        }
      ],
      ""metadata"": {},
      ""pricing_type"": ""fixed_price"",
      ""pricing"": {
        ""local"": { ""amount"": ""100.00"", ""currency"": ""USD"" },
        ""bitcoin"": { ""amount"": ""1.00"", ""currency"": ""BTC"" },
        ""ethereum"": { ""amount"": ""10.00"", ""currency"": ""ETH"" }
      },
      ""payments"": [],
      ""addresses"": {
        ""bitcoin"": ""mymZkiXhQNd6VWWG7VGSVdDX9bKmviti3U"",
        ""ethereum"": ""0x419f91df39951fd4e8acc8f1874b01c0c78ceba6""
      }
    }
";

      public static string ChargeWithMetadata(string jsonMetadata)
      {
         return Charge.Replace(@"""metadata"": {}", $@"""metadata"": {jsonMetadata}");
      }

      public static Charge ChargeModel => new Charge
         {
            Code = "66BEOV2A",
            Name = "The Sovereign Individual",
            Description = "Mastering the Transition to the Information Age",
            LogoUrl = "https://commerce.coinbase.com/charges/ybjknds.png",
            HostedUrl = "https://commerce.coinbase.com/charges/66BEOV2A",
            CreatedAt = DateTimeOffset.Parse("2017-01-31T20:49:02Z"),
            ExpiresAt = DateTimeOffset.Parse("2017-01-31T21:04:02Z"),
            Checkout = new Checkout {Id = "a76721f2-1611-48fb-a513-aac6c819a9d6"},
            Timeline = new[]
               {
                  new Timeline
                     {
                        Time = DateTimeOffset.Parse("2017-01-31T20:49:02Z"),
                        Status = "NEW"
                     }
               },
            Metadata = new JObject(),
            PricingType = PricingType.FixedPrice,
            Pricing = new Dictionary<string, Money>
               {
                  {"local", new Money {Amount = 100.0m, Currency = "USD"}},
                  {"bitcoin", new Money {Amount = 1.0m, Currency = "BTC"}},
                  {"ethereum", new Money {Amount = 10.0m, Currency = "ETH"}}
               },
            Payments = new Payment[0],
            Addresses = new Dictionary<string, string>
               {
                  {"bitcoin", "mymZkiXhQNd6VWWG7VGSVdDX9bKmviti3U"},
                  {"ethereum", "0x419f91df39951fd4e8acc8f1874b01c0c78ceba6"}
               }

         };

      public const string Checkout = @"{
    ""id"": ""30934862-d980-46cb-9402-43c81b0cabd5"",
    ""name"": ""The Sovereign Individual"",
    ""description"": ""Mastering the Transition to the Information Age"",
    ""logo_url"": ""https://commerce.coinbase.com/charges/ybjknds.png"",
    ""requested_info"": [],
    ""pricing_type"": ""fixed_price"",
    ""local_price"": { ""amount"": ""100.0"", ""currency"": ""USD"" }
}";

      public static string CheckoutWithRequestInfo(string jsonRequestInfo) =>
         Checkout.Replace(@"""requested_info"": []", $@"""requested_info"": [{jsonRequestInfo}]");
      public static Checkout CheckoutModel => new Checkout
         {
            Id = "30934862-d980-46cb-9402-43c81b0cabd5",
            Name = "The Sovereign Individual",
            Description = "Mastering the Transition to the Information Age",
            LogoUrl = "https://commerce.coinbase.com/charges/ybjknds.png",
            RequestedInfo = new HashSet<string> {},
            PricingType = PricingType.FixedPrice,
            LocalPrice = new Money {Amount = 100.0m, Currency = "USD"}
         };


      public const string Event = @"{
    ""id"": ""24934862-d980-46cb-9402-43c81b0cdba6"",
    ""type"": ""charge:created"",
    ""api_version"": ""2018-03-22"",
    ""created_at"": ""2017-01-31T20:49:02Z"",
    ""data"": {
      ""code"": ""66BEOV2A"",
      ""name"": ""The Sovereign Individual"",
      ""description"": ""Mastering the Transition to the Information Age"",
      ""hosted_url"": ""https://commerce.coinbase.com/charges/66BEOV2A"",
      ""created_at"": ""2017-01-31T20:49:02Z"",
      ""expires_at"": ""2017-01-31T21:04:02Z"",
      ""timeline"": [
        {
          ""time"": ""2017-01-31T20:49:02Z"",
          ""status"": ""NEW""
        }
      ],
      ""metadata"": {},
      ""pricing_type"": ""no_price"",
      ""payments"": [],
      ""addresses"": {
        ""bitcoin"": ""mymZkiXhQNd6VWWG7VGSVdDX9bKmviti3U"",
        ""ethereum"": ""0x419f91df39951fd4e8acc8f1874b01c0c78ceba6""
      }
    }
}";

      public static Event EventModel =>
         new Event
            {
               Id = "24934862-d980-46cb-9402-43c81b0cdba6",
               Type = "charge:created",
               ApiVersion = "2018-03-22",
               CreatedAt = DateTimeOffset.Parse("2017-01-31T20:49:02Z"),
               Data = JObject.FromObject(new 
                  {
                     code = "66BEOV2A",
                     name = "The Sovereign Individual",
                     description = "Mastering the Transition to the Information Age",
                     hosted_url = "https://commerce.coinbase.com/charges/66BEOV2A",
                     created_at = DateTimeOffset.Parse("2017-01-31T20:49:02Z"),
                     expires_at = DateTimeOffset.Parse("2017-01-31T21:04:02Z"),
                     timeline = new[]
                        {
                           new {time = DateTimeOffset.Parse("2017-01-31T20:49:02Z"), status = "NEW"}
                        },
                     metadata = new JObject(),
                     pricing_type = PricingType.NoPrice,
                     payments = new Payment[0],
                     addresses = new Dictionary<string, string>
                        {
                           {"bitcoin", "mymZkiXhQNd6VWWG7VGSVdDX9bKmviti3U"},
                           {"ethereum", "0x419f91df39951fd4e8acc8f1874b01c0c78ceba6"}
                        }
                  })
            };
   }
}