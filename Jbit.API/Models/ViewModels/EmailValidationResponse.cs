namespace Jbit.API.Models.ViewModels
{
    public class EmailValidationResponse
    {
        public EmailValidationResponse()
        {

        }

        public EmailValidationResponse(bool isEmailUnique)
        {
            IsEmailUnique = IsEmailUnique;
        }

        public bool IsEmailUnique { get; set; }
    }
}
