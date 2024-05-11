using Humanizer;
using Microsoft.Extensions.Logging;
using StringManipulation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace StringManipulationTest
{
    public class StringManipulationTest
    {

        /* Método de pruebas para validar un método que concatena strings*/ 

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

        /* Método de pruebas para validar un método que retorna 
           los valores de un string al contrario */

        [Theory]
        [InlineData("amor","roma")]
        [InlineData("los","sol")]
        public void ReverseString_validation(string str1, string expectedResult)
        {
            //Arrannge
            var stringOperations = new StringOperations();

            //Act
            var resultado = stringOperations.ReverseString(str1);

            //Assert
            Assert.Equal(expectedResult, resultado);
        }

        /* Método para evaluar o validar que un 
           método devuelva la cantidad de carácteres de un string */

        [Theory]
        [InlineData("mensaje",7)]
        [InlineData("computadora",11)]
        public void GetStrings_validation(string str1, int expectedResult) 
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var resultado = stringOperations.GetStringLength(str1);

            //Assert 
            Assert.Equal(expectedResult , resultado);
        }

        /* Método para validar que una excepción realmente es llamada por cierto método*/

        [Fact]
        public void GetString_Exception_validation() 
        {
            //Arrange
            var stringOperations = new StringOperations();
            string str = null;

            //Assert y Act
            Assert.Throws<ArgumentNullException>(() => stringOperations.GetStringLength(str));
        }


        /* Método para validar que un método devuelve 
           una cadena de caracteres sin especios en blanco*/

        [Theory]
        [InlineData("h ola mundo","holamundo")]
        [InlineData("jua  n e s mi No mbre", "juanesmiNombre")]
        public void RemovewhitespaceString_validation(string str, string expectedResult)
        {
            //Assert
            var stringOperations = new StringOperations();

            //Act
            var resultado = stringOperations.RemoveWhitespace(str);

            //Assert
            Assert.Equal(expectedResult, resultado);
        }

        /* Método para validar que un método realice un truncamiento a un string*/
        [Fact]
        public void TruncateString_validation()
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var resultado = stringOperations.TruncateString("hola mundo", 5);

            //Assert
            Assert.Equal("hola ", resultado);
        }

        /* Método para validar que una excepción realmente es llamada por cierto método*/

        [Fact]
        public void TruncateString_Exception_validation()
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Assert y Act
            Assert.Throws<ArgumentOutOfRangeException>(() => stringOperations.TruncateString(null, 0));
        }

        /* Método que valida si un método verifica 
         * que cierto string sea o no sea una palabra palindroma*/

        [Theory]
        [InlineData("reconocer")]
        [InlineData("radar")]
        public void isPalindromeString_validation(string str) 
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var resultado = stringOperations.IsPalindrome(str);

            //Assert
            Assert.True(resultado);
        }

        /* Método que valida que un método contabilice 
         * el número de veces de cierta letra seleccionada, 
         * además de contabilizar el número de ocurrencias del método mismo 
         * con el uso de un logger*/

        [Fact]
        public void CountOcurrences_validation() 
        {
            // Create a instance Logger events register to CountOcurrence method
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                //Add console logger
                builder.AddConsole();
            });

            // Create a logger
            var logger = loggerFactory.CreateLogger<StringOperations>();

            //Arrange
            var stringOperations = new StringOperations(logger);

            //Act
            var result = stringOperations.CountOccurrences("alcachofa", 'a');

            //Assert
            Assert.Equal(3, result);
        }

        /* Método para validar que un metodo pluralice 
         * determinados cadena de caracteres*/

        [Theory]
        [InlineData("work","works")]
        [InlineData("friend","friends")]
        [InlineData("family","families")]
        public void PluralizeString_validation(string str, string ExpectedResult) 
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var result = stringOperations.Pluralize(str);

            //Assert
            Assert.Equal(ExpectedResult, result);
        }

        /* Método para validar que un método pueda anteponer números a una palabra
         * proporcionada y, en consecuencia pluraliza o singulariza dicha palabra*/

        [Theory]
        [InlineData("bodega", 10, "diez bodegas")]
        [InlineData("perro", 1, "uno perro")]
        [InlineData("prueba", 0, "cero pruebas")]
        public void QuantityinWords_validation(string str, int quantity, string expectedResult) 
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var result = stringOperations.QuantintyInWords(str, quantity);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        /* Método para validar que un método de la clase StringOperations
         * pueda convertir una cadena de caracteres en números enteros romanos*/

        [Theory]
        [InlineData("i", 1)]
        [InlineData("v", 5)]
        [InlineData("x", 10)]
        [InlineData("l", 50)]
        [InlineData("c", 100)]
        [InlineData("m", 1000)]
        public void FromRomanToNumber_validation(string str, int expectedResult) 
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Act
            var result = stringOperations.FromRomanToNumber(str);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}