namespace TimeUtil.Components.Helpers;

internal static class TextHelpers
{
    public static string GetMultiSelectionText<T>(IEnumerable<T>? collection)
    {
        int count = collection?.Count() ?? 0;

        if (count == 0)
        {
            return "";
        }

        return $"{count} categor{(count > 1 ? "ies have" : "y has")} been selected";
    }
}
