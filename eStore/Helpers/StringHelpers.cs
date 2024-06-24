using FuzzySharp;

namespace eStore.helpers {
    public static class StringHelpers
    {
        /// <summary>
        /// Performs a fuzzy search to determine if the given search term matches the given text.
        /// </summary>
        /// <param name="searchTerm">The search term to match.</param>
        /// <param name="text">The text to be searched.</param>
        /// <returns>True if the search term matches the text with a similarity ratio greater than the threshold; otherwise, false.</returns>
        public static bool FuzzySearch(string searchTerm, string text)
        {
            int threshold = 80;
            return Fuzz.Ratio(searchTerm, text) > threshold;
        }

    }

};


