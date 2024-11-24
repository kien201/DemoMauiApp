using CommunityToolkit.Mvvm.Messaging;
using DemoMauiApp.Models;
using DemoMauiApp.Services;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoMauiApp.ViewModels
{
    public class WIEformPageViewModel : ViewModelBase
    {
        private WIEformModel _WIEform;
        public WIEformModel WIEform
        {
            get => _WIEform;
            set => SetProperty(ref _WIEform, value);
        }

        private ObservableCollection<QuestionDisplayModel> questions;
        public ObservableCollection<QuestionDisplayModel> Questions
        {
            get => questions;
            set => SetProperty(ref questions, value);
        }

        public WIEformPageViewModel(NavigationService service)
            : base(service)
        {
            Questions = new ObservableCollection<QuestionDisplayModel>();
        }

        public override async Task OnNavigate(object? parameter)
        {
            await LoadData();

            WeakReferenceMessenger.Default.Unregister<AnswerDataChangedMessage>(this);
            WeakReferenceMessenger.Default.Register<AnswerDataChangedMessage>(this, (r, o) =>
            {
                if (o.CurrentQuestion == null || o.CurrentQuestion.Level >= 4)
                    return;
                int questionIndex = Questions.IndexOf(o.CurrentQuestion);
                if (questionIndex >= 0)
                {
                    var a = Questions.Where(x => 
                        x.GroupName == o.CurrentQuestion.GroupName
                        && x.Cascading1QuestionName == o.CurrentQuestion.Cascading1QuestionName
                        && x.Cascading2QuestionName == o.CurrentQuestion.Cascading2QuestionName
                        && x.Cascading3QuestionName == o.CurrentQuestion.Cascading3QuestionName
                        && x.Cascading4QuestionName == o.CurrentQuestion.Cascading4QuestionName).ToList();

                    foreach (var cascadingGroupName in o.CascadingGroupNames)
                    {
                        var cascadingGroup = WIEform
                            .QuestionSet
                            .QuestionGroups
                            .Where(x => x.Name.Equals(cascadingGroupName))
                            .FirstOrDefault();

                        if (cascadingGroup != null && cascadingGroup.Questions.Any())
                        {
                            int currentIndex = questionIndex;
                            Questions.Insert(currentIndex++, BuildQuestion(new QuestionModel()));

                            foreach(var question in cascadingGroup.Questions)
                            {
                                Questions.Insert(currentIndex++, BuildQuestion(question));
                            }
                        }
                    }       
                }
            });
        }

        private async Task LoadData()
        {
            WIEform = await GetWIEformData();

            Questions.Clear();
            foreach (var group in WIEform.QuestionSet.QuestionGroups)
            {
                Questions.Add(new GroupQuestionTitle()
                {
                    ResponseType = ResponseType.GroupHeader,
                    Name = group.Name,
                });

                foreach (var question in group.Questions)
                {
                    Questions.Add(BuildQuestion(question));
                }
            }
        }

        private void AddQuestionCascading()
        {

        }

        private QuestionDisplayModel BuildQuestion(QuestionModel question)
        {
            QuestionDisplayModel questionDisplay;
            switch (question.ResponseType)
            {
                case "Text":
                    questionDisplay = new TextQuestion()
                    {
                        ResponseType = ResponseType.Text,
                    };
                    break;
                case "Boolean":
                    questionDisplay = new BooleanQuestion()
                    {
                        ResponseType = ResponseType.Boolean,
                    };
                    break;
                case "List":
                    questionDisplay = new ListSingleQuestion()
                    {
                        ResponseType = ResponseType.ListSingle,
                    };
                    break;
                default:
                    questionDisplay = new TextQuestion()
                    {
                        ResponseType = ResponseType.Text,
                    };
                    break;
            }

            questionDisplay.Name = question.Name;
            questionDisplay.Description = question.Description;
            questionDisplay.CascadingSettings = question.CascadingSettings;

            //questionDisplay.Level = currentQuestion.Level + 1;
            //questionDisplay.Cascading4Name = currentQuestion.Cascading4Name ?? currentQuestion.Cascading3Name;
            //questionDisplay.Cascading3Name = currentQuestion.Cascading3Name ?? currentQuestion.Cascading2Name;
            //questionDisplay.Cascading2Name = currentQuestion.Cascading2Name ?? currentQuestion.Cascading1Name;
            //questionDisplay.Cascading1Name = currentQuestion.Cascading1Name ?? currentQuestion.GroupName;
            //questionDisplay.GroupName = currentQuestion.GroupName ?? cascadingGroupName;
            return questionDisplay;
        }

        private async Task<WIEformModel> GetWIEformData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("WIEformData.json");
            using var reader = new StreamReader(stream);
            var model = await reader.ReadToEndAsync();

            return JsonSerializer.Deserialize<WIEformModel>(model, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
