using datntdev.Microservices.Models.TokenAuth;
using datntdev.Microservices.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace datntdev.Microservices.Web.Tests.Controllers;

public class HomeController_Tests : MicroservicesWebTestBase
{
    [Fact]
    public async Task Index_Test()
    {
        await AuthenticateAsync(null, new AuthenticateModel
        {
            UserNameOrEmailAddress = "admin",
            Password = "123qwe"
        });

        //Act
        var response = await GetResponseAsStringAsync(
            GetUrl<HomeController>(nameof(HomeController.Index))
        );

        //Assert
        response.ShouldNotBeNullOrEmpty();
    }
}