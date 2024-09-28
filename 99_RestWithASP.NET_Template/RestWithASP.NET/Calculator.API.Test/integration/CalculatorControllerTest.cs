using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CalculatorAPITest.integration
{
    public class CalculatorControllerTest : IClassFixture<WebApplicationFactory<RestWithASPNET.Program>>
    {
        private readonly HttpClient _client;

        public CalculatorControllerTest(WebApplicationFactory<RestWithASPNET.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("1", "2", "3")]
        [InlineData("1,6", "2,5", "4,1")]
        [InlineData("-1,1", "-2,0", "-3,1")]
        public async Task Shoul_sum_correctly(string firstNumber, string secondNumber, string expectedSum)
        {
            var requestUrl = $"/calculator/sum/{firstNumber}/{secondNumber}";
            var response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedSum, result);
        }

		[Theory]
		[InlineData("1", "2", "-1")]
		[InlineData("1,6", "2,5", "-0,9")]
		[InlineData("-1,1", "-2,0", "0,9")]
		public async Task Should_subtract_correctly(string firstNumber, string secondNumber, string expectedSubtraction)
		{
			var requestUrl = $"/calculator/sub/{firstNumber}/{secondNumber}";
			var response = await _client.GetAsync(requestUrl);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expectedSubtraction, result);
		}

		[Theory]
		[InlineData("1", "2", "2")]
		[InlineData("1,6", "2,5", "4,00")]
		[InlineData("-1,1", "-2,0", "2,20")]
		public async Task Should_multiply_correctly(string firstNumber, string secondNumber, string expectedMultiplication)
		{
			var requestUrl = $"/calculator/mult/{firstNumber}/{secondNumber}";
			var response = await _client.GetAsync(requestUrl);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expectedMultiplication, result);
		}

		[Theory]
		[InlineData("1", "2", "0,5")]
		[InlineData("1,6", "2,5", "0,64")]
		[InlineData("-1,1", "-2,0", "0,55")]
		public async Task Should_divide_correctly(string firstNumber, string secondNumber, string expectedDivision)
		{
			var requestUrl = $"/calculator/div/{firstNumber}/{secondNumber}";
			var response = await _client.GetAsync(requestUrl);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expectedDivision, result);
		}

		[Theory]
		[InlineData("1", "2", "1,5")]
		[InlineData("1,6", "2,5", "2,05")]
		[InlineData("-1,1", "-2,0", "-1,55")]
		public async Task Should_calculate_mean_correctly(string firstNumber, string secondNumber, string expectedMean)
		{
			var requestUrl = $"/calculator/mean/{firstNumber}/{secondNumber}";
			var response = await _client.GetAsync(requestUrl);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expectedMean, result);
		}

		[Theory]
		[InlineData("4", "2")]
		[InlineData("2,5", "1,58113883008419")]
		public async Task Should_calculate_square_root_correctly(string firstNumber, string expectedSquareRoot)
		{
			var requestUrl = $"/calculator/squareRoot/{firstNumber}";
			var response = await _client.GetAsync(requestUrl);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expectedSquareRoot, result);
		}


		[Theory]
		[InlineData("sum", "abc", "123")]
		[InlineData("sum", "123", "def")]
		[InlineData("sub", "abc", "123")]
		[InlineData("sub", "123", "def")]
		[InlineData("mult", "abc", "123")]
		[InlineData("mult", "123", "def")]
		[InlineData("div", "abc", "123")]
		[InlineData("div", "123", "def")]
        [InlineData("mean", "abc", "123")]
        [InlineData("mean", "123", "def")]
        public async Task Should_Return_BadRequest_For_Two_Args_Operation(string operation, string firstNumber, string secondNumber)
		{
			var requestUrl = $"/calculator/{operation}/{firstNumber}/{secondNumber}";
			var response = await _client.GetAsync(requestUrl);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}

        [Theory]
        [InlineData("abc")]
        [InlineData("def")]
        [InlineData("0")]
        public async Task Should_Return_BadRequest_For_SquareRoot(string firstNumber)
        {
            var requestUrl = $"/squareRoot/{firstNumber}";
            var response = await _client.GetAsync(requestUrl);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
