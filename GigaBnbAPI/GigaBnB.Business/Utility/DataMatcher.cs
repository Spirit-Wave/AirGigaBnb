using System.Text.RegularExpressions;

namespace GigaBnB.Business.Utility;

static class DataMatcher
{
    public static bool MatchEmail(string email)
    {
        Regex validateEmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        return !validateEmailRegex.IsMatch(email);
    }
}