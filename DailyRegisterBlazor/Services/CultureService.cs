using System.Globalization;

namespace DailyRegisterBlazor.Services;

public class CultureService
{
    public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentCulture;

    public event Action? OnCultureChanged;

    public void SetCulture(string cultureCode)
    {
        var culture = new CultureInfo(cultureCode);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CurrentCulture = culture;
        OnCultureChanged?.Invoke();
    }
}