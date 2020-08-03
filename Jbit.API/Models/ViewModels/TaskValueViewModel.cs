namespace Jbit.API.Models.ViewModels
{
    public class TaskValueViewModel
    {
        public TaskValueViewModel()
        {

        }

        public TaskValueViewModel(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
