using System.Runtime.InteropServices;
using MathApi.Services;
using MathApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MathApi.Tests.Services;

public class MathServiceTests
{
     private readonly ServiceProvider _services;

     public MathServiceTests()
     {
          var serviceCollection = new ServiceCollection();
          serviceCollection.AddTransient<IMathService, MathService>();
          this._services = serviceCollection.BuildServiceProvider();
     }

     [Fact]
     public async Task ShouldAddTwoNumbersCorrectly()
     {
          //Given
          var mathService = _services.GetRequiredService<IMathService>();
          var a = 1;
          var b = 2;
          
          //When
          var result = await mathService.AddAsync(a, b, CancellationToken.None);
          
          //Then
          Assert.Equal(3, result);
     }

     [Fact]
     public async Task ShouldAddTwoNumbersInCorrectly()
     {
          //Given
          var mathService = _services.GetRequiredService<IMathService>();
          var a = long.MaxValue;
          var b = 2;
          
          //When
          var task = async ()=> await mathService.AddAsync(a, b, CancellationToken.None);
          
          //Then
          await Assert.ThrowsAsync<OverflowException>(task);
     }

     [Theory]
     [InlineData(long.MaxValue, 1)]
     [InlineData(long.MinValue, -2)]

     public async Task ThrowsOverflowExceptionWhenNotInRange(long a, long b)
     {
          //Given
          var mathService = _services.GetRequiredService<IMathService>();
          
          //When
          var task = async ()=> await mathService.AddAsync(a, b, CancellationToken.None);
          
          //Then
          await Assert.ThrowsAsync<OverflowException>(task);
     }
}