using System;
using Xunit;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace Contact.API.Test
{
    public class UnitTest1
    {
        Entities.Contact Contact;

        public UnitTest1()
        {
            Contact = new Entities.Contact()
            {
                
                UUID = Guid.NewGuid().ToString(),
                Name = "ad_" + new Random().Next(1, 9999),
                LastName = "soyad_" + new Random().Next(1, 9999),
                Firm = "firma-" + new Random().Next(1, 9999),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                ContactInformations = new List<Entities.ContactInformation>() {
                new Entities.ContactInformation(){
                 Type = Common.Enums.InformationType.Location,
                Value ="istanbul"},
                new Entities.ContactInformation(){
                 Type = Common.Enums.InformationType.EmailAddress,
                Value ="mail_"+ + new Random().Next(1, 9999)+"@test.com"},
                new Entities.ContactInformation(){
                 Type = Common.Enums.InformationType.PhoneNumber,
                Value ="+09053" + new Random().Next(10000,99999)}
                },
            };
        }


        [Fact]
        public async void GetServiceTest()
        {
            var client = new TestClientProvider().Client;

            // Act
            var okResult = await client.GetAsync("api/contact");

            okResult.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async void CreateServiceTest()
        {
            var client = new TestClientProvider().Client;
            var content = new StringContent(JsonSerializer.Serialize(Contact), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("api/contact", content);
            // Act

            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
