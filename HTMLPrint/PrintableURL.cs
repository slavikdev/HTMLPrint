namespace HTMLPrint
{
    using System.Windows.Forms;

    public sealed class PrintableURL : IPrintable
    {
        #region Init

        public PrintableURL( string url )
        {
            _url = url;
        }

        #endregion


        #region Printable

        public void Print()
        {
            var browser = new WebBrowser();
            browser.DocumentCompleted += OnDocumentCompleted;
            browser.Navigate( _url );
        }

        #endregion


        #region Event handlers

        private static void OnDocumentCompleted( object sender,
            WebBrowserDocumentCompletedEventArgs e )
        {
            using ( var browser = (WebBrowser)sender )
            {
                // Print the document now that it is fully loaded.
                browser.Print();
            }
        }

        #endregion


        #region Fields

        private readonly string _url;

        #endregion
    }
}