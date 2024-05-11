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


        

    }
}