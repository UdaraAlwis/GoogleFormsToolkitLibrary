using System.Collections.Generic;

namespace GoogleFormsToolkitLibrary.Models
{
    /// <summary>
    /// A model representing a Google Form structure
    /// consist of main the properties of a Google Form
    /// </summary>
    public class GoogleForm
    {
        /// <summary>
        /// Document Name of your Google Form
        /// </summary>
        public string FormDocName { get; set; }

        /// <summary>
        /// Form ID of your Google Form
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// Title of your Google Form
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of your Google Form
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of Question Fields in your Google Form
        /// </summary>
        public List<GoogleFormField> QuestionFieldList { get; set; }
    }
}
