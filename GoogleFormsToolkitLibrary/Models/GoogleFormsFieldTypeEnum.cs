using System.ComponentModel;

namespace GoogleFormsToolkitLibrary.Models
{
    /// <summary>
    /// Found the Field type representation values with trial
    /// and error try out of blood sweat and tears lol! ;)
    /// </summary>
    public enum GoogleFormsFieldTypeEnum
    {
        [Description("Short Answer Field")]
        ShortAnswerField = 0,
        [Description("Paragraph Field")]
        ParagraphField = 1,

        [Description("Multiple Choice Field")]
        MultipleChoiceField = 2,
        [Description("Check Boxes Field")]
        CheckBoxesField = 4,
        [Description("Drop Down Field")]
        DropDownField = 3,

        // FileUpload - Not supported (needs user log in session)
        [Description("File Upload Field")]
        FileUploadField = 13,

        [Description("Linear Scale Field")]
        LinearScaleField = 5,
        // represents both: Multiple Choice Grid | Checkbox Grid
        [Description("Grid Choice Field")]
        GridChoiceField = 7,

        [Description("Date Field")]
        DateField = 9,
        [Description("Time Field")]
        TimeField = 10,
    }
}
