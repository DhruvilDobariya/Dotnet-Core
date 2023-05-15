namespace BookAPI.Domain.ViewModels
{
    /// <summary>
    /// This model is use for join book with author
    /// </summary>
    public class BookWithAuthor : BOSD03
    {
        /// <summary>
        /// AuthorName
        /// </summary>
        public string D01F02 { get; set; } = null!;
    }
}
