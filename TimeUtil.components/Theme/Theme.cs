using MudBlazor.Utilities;
using MudBlazor;

namespace TimeUtil.Components.Theme;
internal static class Theme
{
    static Theme()
    {
        MudTheme theme = new()
        {
            Palette = new()
            {
                Background = "#f2f3f5",
                AppbarBackground = Colors.Pink.Accent4,
                DarkContrastText = "#fff"
            }
        };
        Palette paletterDark = theme.PaletteDark;
        MudColor surface = "#37363B";
        MudColor DarkBackground = "#242428";
        MudColor white = "rgb(235, 236, 240)";
        paletterDark.Background = DarkBackground;
        paletterDark.Dark = surface.ColorDarken(0.25);
        paletterDark.Surface = surface;
        paletterDark.DrawerBackground = surface;
        paletterDark.AppbarBackground = surface;
        paletterDark.AppbarText = white;
        paletterDark.DrawerText = white;
        paletterDark.TextPrimary = white;
        paletterDark.ActionDefault = white;
        MudTheme = theme;
    }
    public static MudTheme MudTheme { get; }
}
