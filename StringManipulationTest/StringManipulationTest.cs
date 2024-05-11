using Humanizer;
using StringManipulation;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace StringManipulationTest
{
    public class StringManipulationTest
    {
        [Theory]
        [InlineData("hola", "mundo")]
        [InlineData("¿cómo", "estás?")]
        public void ConcatenateString_validation(string str1, string str2)
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var resultado = stringOperations.ConcatenateStrings(str1, str2);

            //Assert
            Assert.Equal($"{str1} {str2}", resultado);
        }
    }
}