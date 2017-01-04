namespace HTMLPrint
{
    using System.Windows.Forms;

    /// <summary>
    /// Implements functionality to print HTML pages by specified URL.
    /// Uses web browser control.
    /// </summary>
    public sealed class PrintableURL : IPrintable
    {
        #region Init

        /// <summary>
        /// Creates instance of printable URL with specified URL address.
        /// </summary>
        /// <param name="url">URL address to use for printing.</param>
        public PrintableURL( string url )
        {
            _url = url;
        }

        #endregion


        #region Printable

        /// <summary>
        /// Prints specified URL by loading it by web browser control.
        /// Printing is done upon document completion to ensure it's properly loaded. 
        /// </summary>
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
                browser.Print();
            }
        }

        #endregion


        #region Fields

        private readonly string _url;

        #endregion
    }
}