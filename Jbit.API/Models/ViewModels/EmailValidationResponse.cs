namespace Jbit.API.Models.ViewModels
{
    public class EmailValidationResponse
    {
        public EmailValidationResponse()
        {

        }

        public EmailValidationResponse(bool isEmailUnique)
        {
            IsEmailUnique = isEmailUnique;
        }

        public bool IsEmailUnique { get; set; }
    }
}
