
# GoogleFormsToolkitLibrary
A .NET Library for accessing Google Forms!

NuGet: https://www.nuget.org/packages/GoogleFormsToolkitLibrary/

Features:
- Works with any Google Form that is openly accessible
- Load information on a given Google Form
- Load Question Field data on a given Google Form
- Submit Form data to a given Google Forms

> I built this based on my fun little experiements on Google Forms! :) 
> https://github.com/UdaraAlwis/GoogleFormsExperiment

Story behind: [I built a Google Forms Toolkit Library for .NET!](https://theconfuzedsourcecode.wordpress.com/2019/12/17/i-built-a-google-forms-toolkit-library-for-net/)

## How to?

Just install in your .Net project, and you're good go! ;) 
Then in code simply instantiate ```GoogleFormsToolkitLibrary``` object in your code and start using.

## LoadGoogleFormStructureAsync()

```LoadGoogleFormStructureAsync(string yourGoogleFormsUrl)```
Loading Google Form's generic information and Question Field list data including Question Type, Answer Options, Submission Id, etc

#### Example:
```csharp
// Retrieve the structure of my sample Google Forms page
// https://docs.google.com/forms/d/e/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/viewform

var googleFormLink =
"https://docs.google.com/forms/d/e/" +
"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" +
"/viewform";

var googleFormsToolkitLibrary = new GoogleFormsToolkitLibrary();
var result = await googleFormsToolkitLibrary.LoadGoogleFormStructureAsync(googleFormLink);

```

## SubmitToGoogleFormAsync()
```SubmitToGoogleFormAsync(string yourGoogleFormsUrl, Dictionary<string, string> formData)```
Submit Form data to your Google Form and returns Success or Fail status.
>```string yourGoogleFormsUrl```: Link to your Google Form page
>```Dictionary<string, string> formData```: Form data dictionary to submit.  
> Dictionary<string, string> Format <<TKey: FieldSubmissionId> : <TValue: Value>>

#### Example: 
```csharp
// Submit data to my sample Google Forms page
// https://docs.google.com/forms/d/e/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/viewform

var googleFormLink =
	"https://docs.google.com/forms/d/e/" +
	"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" +
	"/formResponse";

Dictionary<string,string> formData = new Dictionary<string, string>
{
	{"entry.1277095329", $"Purple Moon Rockets"}, // Question Field 1
	{"entry.995005981","Banana Plums"}, // Question Field 2
	{"entry.1155533672","Monkeys with hoodies"},  // Question Field 3
	{"entry.1579749043","Jumping Apples"}, // Question Field 4
};

var googleFormsToolkitLibrary = new GoogleFormsToolkitLibrary();
var result = await googleFormsToolkitLibrary.SubmitToGoogleFormAsync(googleFormLink, formData);

```