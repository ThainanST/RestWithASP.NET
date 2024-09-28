using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using System.Runtime.CompilerServices;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{SecondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsValidTwoArgs(firstNumber, secondNumber) )
            {
                var sum = Calculator.Sum(ConvertToDecimal(firstNumber), ConvertToDecimal(secondNumber));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{SecondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsValidTwoArgs(firstNumber, secondNumber))
            {
                var subtraction = Calculator.Subtraction(ConvertToDecimal(firstNumber), ConvertToDecimal(secondNumber));
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mult/{firstNumber}/{SecondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsValidTwoArgs(firstNumber, secondNumber))
            {
                var multiplication = Calculator.Multiplication(ConvertToDecimal(firstNumber), ConvertToDecimal(secondNumber));
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("div/{firstNumber}/{SecondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsValidToDiv(firstNumber, secondNumber))
            {
                var division = Calculator.Division(ConvertToDecimal(firstNumber), ConvertToDecimal(secondNumber));
                return Ok(division.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{SecondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsValidTwoArgs(firstNumber, secondNumber))
            {
                var mean = Calculator.Mean(ConvertToDecimal(firstNumber), ConvertToDecimal(secondNumber));
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("squareRoot/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsValidToSquareRoot(firstNumber) )
            {
                var squareRoot = Calculator.SquareRoot(ConvertToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid input");
        }
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsValidTwoArgs(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                return true;
            }
            return false;
        }

        private bool IsValidToDiv(string firstNumber, string secondNumber)
        {
            if (!IsValidTwoArgs(firstNumber, secondNumber)) return false;
            if (ConvertToDecimal(secondNumber) == 0) return false;
            return true;
        }

        private bool IsValidToSquareRoot(string firstNumber)
        {
            if (!IsNumeric(firstNumber)) return false;
            if (ConvertToDecimal(firstNumber) < 0) return false;
            return true;
        }
    }
}
