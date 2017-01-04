namespace Tests
{
    using HTMLPrint;
    using NUnit.Framework;

    [TestFixture]
    public sealed class PrintableURLTest
    {
        [Test]
        public void TestConstruction()  
        {
            // Proper URL works.
            Assert.DoesNotThrow( 
                () => new PrintableURL( "https://github.com/slavikdev" ) 
            );

            // Empty URL works too (ctor is logic-less).
            Assert.DoesNotThrow( 
                () => new PrintableURL( "" ) 
            );

            // NULL URL should also work on construction.
            Assert.DoesNotThrow( 
                () => new PrintableURL( null ) 
            );
        }

        [Test]
        public void TestPrintCorrectURL()  
        {
            var printable_url = new PrintableURL( "https://en.wikipedia.org/wiki/Kievan_Rus%27" );
            printable_url.Print();
        }
    }
}
