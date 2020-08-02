namespace Jbit.Common.Services
{
    /// <summary>
    /// Defines the cotract of task rating calculation
    /// </summary>
    public interface ITaskRatingCalculator
    {
        /// <summary>
        /// Calculate task raiting
        /// </summary>
        /// <returns></returns>
        decimal GetRating();
    }
}
