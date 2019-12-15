using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.GoogleFormsToolkitLibrary.Models
{
    /// <summary>
    /// A Question Field in a Google Form
    /// </summary>
    public class GoogleFormField
    {
        /// <summary>
        /// Type of the Question Field
        /// </summary>
        public GoogleFormsFieldTypeEnum QuestionType { get; set; }

        /// <summary>
        /// Question text of the Field
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// The unique Id need to be used 
        /// when submitting the answer
        /// I also refer to this as: Field Id
        /// </summary>
        public string AnswerSubmissionId { get; set; }

        /// <summary>
        /// Available Answer List for any kind of 
        /// multiple answer selection field
        /// </summary>
        public List<string> AnswerOptionList { get; set; } = new List<string>();

        /// <summary>
        /// If the answer is required to Submit
        /// </summary>
        public bool IsAnswerRequired { get; set; }
    }
}
