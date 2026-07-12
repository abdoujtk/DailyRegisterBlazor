using System.Globalization;

namespace DailyRegisterBlazor.Services;

public class TranslationService
{
    private readonly Dictionary<string, Dictionary<string, string>> _translations = new()
    {
        ["en"] = new()
        {
            ["AppTitle"] = "Daily Register",
            ["Contacts"] = "Contacts",
            ["AddContact"] = "Add Contact",
            ["Edit"] = "Edit",
            ["Delete"] = "Delete",
            ["Save"] = "Save",
            ["Cancel"] = "Cancel",
            ["Search"] = "Search...",
            ["Name"] = "Name",
            ["Phone"] = "Phone",
            ["Notes"] = "Notes",
            ["NoContacts"] = "No contacts yet.",
            ["DarkMode"] = "Dark Mode",
            ["LightMode"] = "Light Mode",
            ["Language"] = "Language",
        },
        ["fr"] = new()
        {
            ["AppTitle"] = "Registre Quotidien",
            ["Contacts"] = "Contacts",
            ["AddContact"] = "Ajouter un contact",
            ["Edit"] = "Modifier",
            ["Delete"] = "Supprimer",
            ["Save"] = "Enregistrer",
            ["Cancel"] = "Annuler",
            ["Search"] = "Rechercher...",
            ["Name"] = "Nom",
            ["Phone"] = "Téléphone",
            ["Notes"] = "Notes",
            ["NoContacts"] = "Aucun contact.",
            ["DarkMode"] = "Mode sombre",
            ["LightMode"] = "Mode clair",
            ["Language"] = "Langue",
        },
        ["ar"] = new()
        {
            ["AppTitle"] = "سجل اليومي",
            ["Contacts"] = "جهات الاتصال",
            ["AddContact"] = "إضافة جهة اتصال",
            ["Edit"] = "تعديل",
            ["Delete"] = "حذف",
            ["Save"] = "حفظ",
            ["Cancel"] = "إلغاء",
            ["Search"] = "بحث...",
            ["Name"] = "الاسم",
            ["Phone"] = "الهاتف",
            ["Notes"] = "ملاحظات",
            ["NoContacts"] = "لا توجد جهات اتصال.",
            ["DarkMode"] = "الوضع الداكن",
            ["LightMode"] = "الوضع الفاتح",
            ["Language"] = "اللغة",
        },
    };

    private string _currentCulture = "en";

    public string CurrentCulture
    {
        get => _currentCulture;
        private set
        {
            if (_currentCulture != value)
            {
                _currentCulture = value;
                OnLanguageChanged?.Invoke();
            }
        }
    }

    public event Action? OnLanguageChanged;

    public string Get(string key)
    {
        if (_translations.TryGetValue(CurrentCulture, out var dict) &&
            dict.TryGetValue(key, out var value))
            return value;
        return key;
    }

    public void SetLanguage(string cultureCode)
    {
        var culture = new CultureInfo(cultureCode);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CurrentCulture = cultureCode;
    }
}