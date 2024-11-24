using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using DemoMauiApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMauiApp.Models
{
    public enum ResponseType
    {
        GroupHeader,
        Text,
        Boolean,
        ListSingle,
    }

    public class QuestionDisplayModel : BindableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ResponseType ResponseType { get; set; }

        private string answer;
        public string Answer
        {
            get => answer;
            set
            {
                SetProperty(ref answer, value);
                //UpdateAnswerDataChanged();
            }
        }
        public List<CascadingSettingModel> CascadingSettings { get; set; }

        public int Level { get; set; }
        public string GroupName { get; set; }
        public string Cascading1QuestionName { get; set; }
        public string Cascading1GroupName { get; set; }
        public string Cascading2QuestionName { get; set; }
        public string Cascading2GroupName { get; set; }
        public string Cascading3QuestionName { get; set; }
        public string Cascading3GroupName { get; set; }
        public string Cascading4QuestionName { get; set; }
        public string Cascading4GroupName { get; set; }

        public virtual void UpdateAnswerDataChanged()
        {
            var cascadingGroupNames = CascadingSettings
                .Where(x => x.CascadingValues.Contains(Answer))
                .Select(x => x.CascadingGroupName)
                .ToList();
            WeakReferenceMessenger.Default.Send(new AnswerDataChangedMessage()
            {
                CurrentQuestion = this,
                CascadingGroupNames = cascadingGroupNames,
            });
        }
    }

    public class AnswerDataChangedMessage
    {
        public QuestionDisplayModel CurrentQuestion { get; set; }
        public List<string> CascadingGroupNames { get; set; }
    }

    public class GroupQuestionTitle : QuestionDisplayModel
    {
    }

    public class TextQuestion : QuestionDisplayModel
    {
    }

    public class BooleanQuestion : QuestionDisplayModel
    {
    }

    public class ListSingleQuestion : QuestionDisplayModel
    {
    }
}
