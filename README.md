# Pruebas Unitarias en .NET
## usando la libreria Xunit

Mediante el framework .NET se hace uso de la libreria 
**Xunit** para realizar diferentes pruebas a una aplicación que funciona como un manipulador de cadena de caracteres.

El siguiente fragmento de código nos muestra el método main que contiene la aplicación principal:

```
using Microsoft.Extensions.Logging;
using StringManipulation;

internal class Program
{
    private static void Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            // Add console logger
            builder.AddConsole();
        });

        // Create a logger
        var logger = loggerFactory.CreateLogger<StringOperations>();


        while (true)
        {
            Console.WriteLine("Select the action");
            Console.WriteLine("1. contact 2 strings");
            Console.WriteLine("2. reverse string");
            Console.WriteLine("3. string length");
            Console.WriteLine("4. remove white spaces");
            Console.WriteLine("5. truncate string");
            Console.WriteLine("6. check if the word is palindrome");
            Console.WriteLine("7. count character concurrency");
            Console.WriteLine("8. plularize a word");
            Console.WriteLine("9. express a quantity in words");
            Console.WriteLine("10. convert from roman to number");
            Console.WriteLine("11. read text file");

            int optionSelected = int.Parse(Console.ReadLine());

            StringOperations stringOperations = new StringOperations(logger);

            switch (optionSelected)
            {
                case 1:
                    Console.WriteLine("write a string 1");
                    string input = Console.ReadLine();

                    Console.WriteLine("write a string 2");
                    string input2 = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.ConcatenateStrings(input, input2));
                    break;
                case 2:
                    Console.WriteLine("write a string");
                    string inputToReverse = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.ReverseString(inputToReverse));
                    break;
                case 3:
                    Console.WriteLine("write a string");
                    string inputLength = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.GetStringLength(inputLength));
                    break;
                case 4:
                    Console.WriteLine("write a string");
                    string inputWhiteSpaces = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.RemoveWhitespace(inputWhiteSpaces));
                    break;
                case 5:
                    Console.WriteLine("write a string");
                    string inputTruncate = Console.ReadLine();

                    Console.WriteLine("set max lenght");
                    int maxLenght = int.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.TruncateString(inputTruncate, maxLenght));
                    break;
                case 6:
                    Console.WriteLine("write a string");
                    string inputPalandrime = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.IsPalindrome(inputPalandrime));
                    break;
                case 7:
                    Console.WriteLine("write a string");
                    string inputConcurrency = Console.ReadLine();

                    Console.WriteLine("write a character");
                    char charToFind = char.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.CountOccurrences(inputConcurrency, charToFind));
                    break;
                case 8:
                    Console.WriteLine("write a string");
                    string inputToPluralize = Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.Pluralize(inputToPluralize));
                    break;
                case 9:
                    Console.WriteLine("write a word");
                    string word = Console.ReadLine();

                    Console.WriteLine("write quantity");
                    int quantity = int.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.QuantintyInWords(word, quantity));
                    break;
                case 10:
                    Console.WriteLine("write a roman number");
                    string romanNumber = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine(stringOperations.FromRomanToNumber(romanNumber));
                    break;
                case 11:
                    Console.WriteLine("");
                    IFileReaderConector fileReader = new FileReaderConector();
                    Console.WriteLine(stringOperations.ReadFile(fileReader, "information.txt"));
                    break;
                default:
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("///");

        }
    }
}
```


En base al proyecto, se decidió realizar una serie de pruebas a los diferentes componentes de la clase *StringOperations* mediante un nuevo proyecto de pruebas en **Xunit**.


# Fase de pruebas
### ConcatenateString

Se realizan pruebas al primer componente de la clase *StringOperations*, cabe resaltar que cada línea que antepone los métodos de prueba cuentan con comentarios explicando su proposito.

```
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
```

En este primer método se evalua el método *ConcatenateStrings* que permite al método retornar una concatenación de una serie de cadena de caracteres.

### ReverseString

```
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
```

En esta prueba se busca verificar que el método *ReverseString* retorne una cadena de caracteres a la inversa.

### GetStringLength

```
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
```

El método *GetString* retorna el total de caracteres contenidos en una cadena de caracteres. Por lo tanto la prueba se encarga de validar estos requerimientos.

### GetStringLengthException

 ```
 [Fact]
        public void GetString_Exception_validation() 
        {
            //Arrange
            var stringOperations = new StringOperations();
            string str = null;

            //Assert y Act
            Assert.Throws<ArgumentNullException>(() => stringOperations.GetStringLength(str));
        }
 ```

 La prueba consiste en validar que una excepción si es debidamente llamada por el método *GetStringLength*, mediante el uso del **"Assert.Throw<>"** donde se especifica la excepción que será llamada, y el método que llamará dicha excepción con sus parámetros debidos.

 ### Removewhitespace

 ```
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
 ```

 La prueba consiste en validar que el método *Removewhitespace* limpie todos los espacios en blanco de una cadena de caracteres.

 ### TruncateString
 ```
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
 ```

 La prueba realiza una validación en el que el método *TruncateString* permita truncar un string y retornar dicho valor, hasta una determinada posición(número de tipo entero).

 ### TruncateStringException

 ```
[Fact]
        public void TruncateString_Exception_validation()
        {
            //Arrange
            var stringOperations = new StringOperations();

            //Assert y Act
            Assert.Throws<ArgumentOutOfRangeException>(() => stringOperations.TruncateString(null, 0));
        }
 ``` 
 Se verifica que el método *TruncateString* valide realmente si llama a una excepción cuando recibe un valor nulo en la cadena de caracteres, o un número determinado menor o igual a cero(en la posición que se quiere truncar la cadena de caracteres). 

 ## isPalindromeString
 
 ```
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
```
la prueba valida si el método *isPalindromeString* verifica que una determinada cadena de caracteres sea o no una palabra palindroma.

## CountOcurrenceValidation

```
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
```

La prueba valida que el método *CountOcurrence* cuente el número de veces que se repite una letra determinada en una palabra proporcionada, además de registrar cada evento en un logger. 

## PluralizeString

```
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
```
La prueba valida que el método *PluralizeString* pluralice una palabra proporcionada.

## QuantityWords
```
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
```
La prueba valida que el método *QuantityWords* pueda anteponer números a una palabra proporcionada y, en consecuencia singulariza o pluraliza dicha palabra.

## FromaRomanToNumber

```
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
```

La prueba valida que el método *FromRomanToNumber* convierta una serie de caracteres determinados en números romanos.

## ReadFile

```
[Fact]
        public void ReadFile_validation() 
        {
            //Arrange
            var stringOperations = new StringOperations();
            IFileReaderConector fileReader = new FileReaderConector();
            
            string result = "";

            /* Variable que especifica la ruta donde se aloja el archivo txt (este se aloja en el mismo proyecto por lo tanto
             * solo hay que espeficiar el nombre del archivo)*/
            string path = "information.txt";

            bool validation = false;

            //Act
            if (File.Exists(path)) { result = stringOperations.ReadFile(fileReader, path); validation = true; }

            //Assert
            Assert.True(validation);

        }
```
La prueba valida que el método *ReadFile* pueda acceder a un archivo plano de tipo .txt , sea leido y mostrar el contenido del mismo.

# Nota
para ejemplos de practicidad del proyecto de pruebas el archivo .txt se encuentra dentro del mismo folder del proyecto, por lo tanto no se necesita especificar una ruta, en caso contrario especificar la ruta del archivo y/o utilizar una instancia diferente.


# Referencias

Este proyecto que se tomó como base de pruebas, proveniente del repositorio:

[yBetancurr4002/UnitTestingXUnit](https://github.com/yBetancurr4002/UnitTestingXUnit.git "referncia del proyecto base")
