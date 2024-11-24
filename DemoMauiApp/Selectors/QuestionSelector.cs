using DemoMauiApp.Models;

namespace DemoMauiApp.Selectors
{
    public class QuestionSelector : DataTemplateSelector
    {
        public DataTemplate GroupHeaderDataTemplate { get; set; }
        public DataTemplate TextDataTemplate { get; set; }
        public DataTemplate BooleanDataTemplate { get; set; }
        public DataTemplate ListSingleDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var question = (QuestionDisplayModel)item;

            switch(question.ResponseType)
            {
                case ResponseType.GroupHeader:
                    return GroupHeaderDataTemplate;
                case ResponseType.Text:
                    return TextDataTemplate;
                case ResponseType.Boolean:
                    return BooleanDataTemplate;
                case ResponseType.ListSingle:
                    return ListSingleDataTemplate;
                default:
                    return TextDataTemplate;
            }
        }
    }
}
