
# 📌 StringManipulation Application

Proyecto base de una aplicación para manipular cadenas de caracteres.

---

## 🔹 Pruebas Unitarias en .NET
### 📌 Usando la librería **Xunit**

Mediante el framework **.NET**, se utiliza la librería **Xunit** para realizar diferentes pruebas a una aplicación que funciona como manipulador de cadenas de caracteres.

### 🖥️ Código Principal

El siguiente fragmento de código nos muestra el método **Main** que contiene la aplicación principal:

```csharp
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
            Console.WriteLine("1. Contact 2 strings");
            Console.WriteLine("2. Reverse string");
            Console.WriteLine("3. String length");
            Console.WriteLine("4. Remove white spaces");
            Console.WriteLine("5. Truncate string");
            Console.WriteLine("6. Check if the word is palindrome");
            Console.WriteLine("7. Count character concurrency");
            Console.WriteLine("8. Pluralize a word");
            Console.WriteLine("9. Express a quantity in words");
            Console.WriteLine("10. Convert from Roman to number");
            Console.WriteLine("11. Read text file");

            int optionSelected = int.Parse(Console.ReadLine());
            StringOperations stringOperations = new StringOperations(logger);

            switch (optionSelected)
            {
                case 1:
                    Console.WriteLine("Write a string 1");
                    string input = Console.ReadLine();
                    Console.WriteLine("Write a string 2");
                    string input2 = Console.ReadLine();
                    Console.WriteLine(stringOperations.ConcatenateStrings(input, input2));
                    break;
                case 2:
                    Console.WriteLine("Write a string");
                    string inputToReverse = Console.ReadLine();
                    Console.WriteLine(stringOperations.ReverseString(inputToReverse));
                    break;
                case 3:
                    Console.WriteLine("Write a string");
                    string inputLength = Console.ReadLine();
                    Console.WriteLine(stringOperations.GetStringLength(inputLength));
                    break;
                case 4:
                    Console.WriteLine("Write a string");
                    string inputWhiteSpaces = Console.ReadLine();
                    Console.WriteLine(stringOperations.RemoveWhitespace(inputWhiteSpaces));
                    break;
                case 5:
                    Console.WriteLine("Write a string");
                    string inputTruncate = Console.ReadLine();
                    Console.WriteLine("Set max length");
                    int maxLength = int.Parse(Console.ReadLine());
                    Console.WriteLine(stringOperations.TruncateString(inputTruncate, maxLength));
                    break;
                default:
                    break;
            }
        }
    }
}
```

---

## 🔍 Fase de Pruebas

### ✅ ConcatenateString

```csharp
[Theory]
[InlineData("hola", "mundo")]
[InlineData("¿cómo", "estás?")]
public void ConcatenateString_validation(string str1, string str2)
{
    var stringOperations = new StringOperations();
    var resultado = stringOperations.ConcatenateStrings(str1, str2);
    Assert.Equal($"{str1} {str2}", resultado);
}
```

### 🔄 ReverseString

```csharp
[Theory]
[InlineData("amor","roma")]
[InlineData("los","sol")]
public void ReverseString_validation(string str1, string expectedResult)
{
    var stringOperations = new StringOperations();
    var resultado = stringOperations.ReverseString(str1);
    Assert.Equal(expectedResult, resultado);
}
```

### 📏 GetStringLength

```csharp
[Theory]
[InlineData("mensaje",7)]
[InlineData("computadora",11)]
public void GetStrings_v
