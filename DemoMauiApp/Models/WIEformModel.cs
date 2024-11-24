using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMauiApp.Models
{
    public class WIEformModel
    {
        public string Name { get; set; }
        public QuestionSetModel QuestionSet { get; set; }
    }

    public class QuestionSetModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuestionGroupModel> QuestionGroups { get; set; }
    }

    public class QuestionGroupModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResponseType { get; set; }
        public List<CascadingSettingModel> CascadingSettings { get; set; }

    }

    public class CascadingSettingModel
    {
        public List<string> CascadingValues { get; set; }
        public string CascadingGroupName { get; set; }
    }
}
