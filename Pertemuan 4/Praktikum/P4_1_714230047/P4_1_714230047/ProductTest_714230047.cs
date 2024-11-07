using System;

namespace P4_1_714230047
{
    class ProductTest_714230047
    {
        static void Main(string[] args)
        {
            Book_714230047 product1 = new Book_714230047("Book", "C# Object-Oriented Solution", "300");
            DVD_714230047 product2 = new DVD_714230047("Eternal Sunshine of the Spotless Mind", "145");

            product1.DisplayInfo();
            product2.DisplayInfo();
        }
    }
}