using System;
using System.Collections.Generic;
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
            Assert.True(result.QuestionFieldList.Count > 0);
        }

        [Fact]
        public async void SubmitDataToGoogleForm_Success()
        {
            // Retrieve the Field ID List of my sample Google Forms page
            // https://docs.google.com/forms/d/e/1FAIpQLSeuZiyN-uQBbmmSLxT81xGUfgjMQpUFyJ4D7r-0zjegTy_0HA/viewform

            var googleFormLink =
                "https://docs.google.com/forms/d/e/" +
                "1FAIpQLSeuZiyN-uQBbmmSLxT81xGUfgjMQpUFyJ4D7r-0zjegTy_0HA" +
                "/formResponse";

            Dictionary<string,string> formData = new Dictionary<string, string>
            {
                {"entry.1277095329", $"Unit Tests execution: {DateTime.Now.Ticks}"}, // Question Field 1

                {"entry.995005981","Banana Plums"}, // Question Field 2

                {"entry.1155533672","Monkeys with hoodies"},  // Question Field 3

                {"entry.1579749043","Jumping Apples"}, // Question Field 4

                {"entry.815399500_year","2019"},  // Question Field 5
                {"entry.815399500_month","11"},
                {"entry.815399500_day","11"},

                {"entry.940653577_hour","04"},  // Question Field 6
                {"entry.940653577_minute","12"},
            };

            var googleFormsToolkitLibrary = new GoogleFormsToolkitLibrary();
            var result = await googleFormsToolkitLibrary.SubmitToGoogleFormAsync(googleFormLink, formData);

            Assert.True(result);
        }
    }
}
