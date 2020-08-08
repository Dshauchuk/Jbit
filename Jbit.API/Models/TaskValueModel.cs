namespace Jbit.API.Models.ViewModels
{
    public class TaskValueModel
    {
        public TaskValueModel()
        {

        }

        public TaskValueModel(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
