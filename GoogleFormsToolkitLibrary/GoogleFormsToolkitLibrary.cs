using Plugin.GoogleFormsToolkitLibrary.Models;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.GoogleFormsToolkitLibrary
{
    public class GoogleFormsToolkitLibrary
    {
        public async Task<GoogleForm> LoadGoogleFormStructureAsync(string yourGoogleFormsUrl)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = await web.LoadFromWebAsync(yourGoogleFormsUrl).ConfigureAwait(false);

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//script").Where(
                x => x.GetAttributeValue("type", "").Equals("text/javascript") &&
                     x.InnerHtml.Contains("FB_PUBLIC_LOAD_DATA_"));

            var fbPublicLoadDataJsScriptContent = htmlNodes.First().InnerHtml;

            // cleaning up "var FB_PUBLIC_LOAD_DATA_ = " at the beginning and 
            // and ";" at the end of the script text  
            var beginIndex = fbPublicLoadDataJsScriptContent.IndexOf("[", StringComparison.Ordinal);
            var lastIndex = fbPublicLoadDataJsScriptContent.LastIndexOf(";", StringComparison.Ordinal);
            var fbPublicJsScriptContentCleanedUp = fbPublicLoadDataJsScriptContent
                                                        .Substring(beginIndex, lastIndex - beginIndex).Trim();

            var jArray = JArray.Parse(fbPublicJsScriptContentCleanedUp);

            GoogleForm googleForm = new GoogleForm();

            var description = jArray[1][0].ToObject<string>();
            var title = jArray[1][8].ToObject<string>();
            var formId = jArray[14].ToObject<string>();

            googleForm.Description = description;
            googleForm.Title = title;
            googleForm.FormId = formId;

            var arrayOfFields = jArray[1][1];

            foreach (var field in arrayOfFields)
            {
                // Check if this Field is submittable or not
                // index [4] contains the Field Answer 
                // Submit Id of a Field Object 
                // ex: ignore Fields used as Description panels
                // ex: ignore Image banner fields
                if (field.Count() < 4 && !field[4].HasValues)
                    continue;

                GoogleFormField googleFormField = new GoogleFormField();

                // Load the Question Field data
                var questionTextValue = field[1]; // Get Question Text
                var questionText = questionTextValue.ToObject<string>();

                var questionTypeCodeValue = field[3].ToObject<int>(); // Get Question Type Code   
                var isRecognizedFieldType = Enum.TryParse(questionTypeCodeValue.ToString(),
                                                out GoogleFormsFieldTypeEnum questionTypeEnum);

                var answerOptionsList = new List<string>();
                var answerOptionsListValue = field[4][0][1].ToList(); // Get Answers List
                // List of Answers Available
                if (answerOptionsListValue.Count > 0)
                {
                    foreach (var answerOption in answerOptionsListValue)
                    {
                        answerOptionsList.Add(answerOption[0].ToString());
                    }
                }

                var answerSubmitIdValue = field[4][0][0]; // Get Answer Submit Id
                var isAnswerRequiredValue = field[4][0][2]; // Get if Answer is Required to be Submitted
                var answerSubmissionId = answerSubmitIdValue.ToObject<string>();
                var isAnswerRequired = isAnswerRequiredValue.ToObject<int>() == 1 ? true : false; // 1 or 0

                googleFormField.QuestionText = questionText;
                googleFormField.QuestionType = questionTypeEnum;
                googleFormField.AnswerOptionList = answerOptionsList;
                googleFormField.AnswerSubmissionId = answerSubmissionId;
                googleFormField.IsAnswerRequired = isAnswerRequired;
            }

            return googleForm;
        }
    }
}
