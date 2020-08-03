namespace Jbit.API.Models.ViewModels
{
    public class CreateCompetitionViewModel
    {
        public CreateCompetitionViewModel()
        {

        }

        public CreateCompetitionViewModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
