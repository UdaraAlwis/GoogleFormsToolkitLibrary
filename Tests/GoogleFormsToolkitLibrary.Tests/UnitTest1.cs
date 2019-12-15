using System;
using Xunit;

namespace GoogleFormsToolkitLibrary.Tests
{
    public class Tests
    {
        [Fact]
        public async void RetrieveGoogleFormStructure_Success()
        {
            // Retrieve the Field ID List of my sample Google Forms page
            // https://docs.google.com/forms/d/e/1FAIpQLSeuZiyN-uQBbmmSLxT81xGUfgjMQpUFyJ4D7r-0zjegTy_0HA/viewform

            var googleFormLink =
            "https://docs.google.com/forms/d/e/" +
            "1FAIpQLSeuZiyN-uQBbmmSLxT81xGUfgjMQpUFyJ4D7r-0zjegTy_0HA" +
            "/formResponse";

            var googleFormsToolkitLibrary = new GoogleFormsToolkitLibrary();
            var result = await googleFormsToolkitLibrary.LoadGoogleFormStructureAsync(googleFormLink);

            Assert.NotNull(result);
        }
    }
}
