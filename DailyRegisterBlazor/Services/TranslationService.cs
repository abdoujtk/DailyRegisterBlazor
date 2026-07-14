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
            ["AddEvent"] = "Add Event",
            ["EditEvent"] = "Edit Event",
            ["Type"] = "Type",
            ["Amount"] = "Amount",
            ["Description"] = "Description",
            ["Date"] = "Date",
            ["debt"] = "Debt",
            ["deposit"] = "Deposit",
            ["expense"] = "Expense",
            ["product_entry"] = "Product Entry",
            ["general_note"] = "General Note",
            ["SelectContact"] = "Select a contact",
            ["NoEvents"] = "No events yet.",
            ["All"] = "All",
            ["Unpaid"] = "Unpaid",
            ["Paid"] = "Paid",
            ["Currency"] = "DZD",
            ["Today"] = "Today",
            ["UnpaidDebts"] = "Unpaid",
            ["OverdueDebts"] = "Overdue",
            ["Filters"] = "Filters",
            ["From"] = "From",
            ["To"] = "To",
            ["Clear"] = "Clear",
            ["Paid"] = "Paid",
            ["Unpaid"] = "Unpaid",
            ["Partial"] = "Partial",
            ["Remaining"] = "Remaining",
            ["PaidAmount"] = "Paid",
            ["AddPayment"] = "Add Payment",
            ["PaymentAmount"] = "Payment Amount",
            ["MarkPaid"] = "Mark Fully Paid",
            ["AddPayment"] = "Add Payment",     // EN
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
            ["AddEvent"] = "Ajouter un événement",
            ["EditEvent"] = "Modifier l'événement",
            ["Type"] = "Type",
            ["Amount"] = "Montant",
            ["Description"] = "Description",
            ["Date"] = "Date",
            ["debt"] = "Dette",
            ["deposit"] = "Dépôt",
            ["expense"] = "Dépense",
            ["product_entry"] = "Entrée produit",
            ["general_note"] = "Note générale",
            ["SelectContact"] = "Sélectionner un contact",
            ["NoEvents"] = "Aucun événement.",
            ["All"] = "Tout",
            ["Unpaid"] = "Impayé",
            ["Paid"] = "Payé",
            ["Currency"] = "DZD",
            ["Today"] = "Aujourd'hui",
            ["UnpaidDebts"] = "Impayés",
            ["OverdueDebts"] = "En retard",
            ["Filters"] = "Filtres",
            ["From"] = "Du",
            ["To"] = "Au",
            ["Clear"] = "Effacer",
            ["Paid"] = "Payé",
            ["Unpaid"] = "Impayé",
            ["Partial"] = "Partiel",
            ["Remaining"] = "Restant",
            ["PaidAmount"] = "Payé",
            ["AddPayment"] = "Ajouter paiement",
            ["PaymentAmount"] = "Montant du paiement",
            ["MarkPaid"] = "Marquer tout payé",
            ["AddPayment"] = "Ajouter paiement", // FR
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
            ["AddEvent"] = "إضافة حدث",
            ["EditEvent"] = "تعديل الحدث",
            ["Type"] = "النوع",
            ["Amount"] = "المبلغ",
            ["Description"] = "الوصف",
            ["Date"] = "التاريخ",
            ["debt"] = "دين",
            ["deposit"] = "وديعة",
            ["expense"] = "مصروف",
            ["product_entry"] = "إدخال منتج",
            ["general_note"] = "ملاحظة عامة",
            ["SelectContact"] = "اختر جهة اتصال",
            ["NoEvents"] = "لا توجد أحداث.",
            ["All"] = "الكل",
            ["Unpaid"] = "غير مدفوع",
            ["Paid"] = "مدفوع",
            ["Currency"] = "دج",
            ["Today"] = "اليوم",
            ["UnpaidDebts"] = "غير مدفوعة",
            ["OverdueDebts"] = "متأخرة",
            ["Filters"] = "تصفية",
            ["From"] = "من",
            ["To"] = "إلى",
            ["Clear"] = "مسح",
            ["Paid"] = "مدفوع",
            ["Unpaid"] = "غير مدفوع",
            ["Partial"] = "جزئي",
            ["Remaining"] = "المتبقي",
            ["PaidAmount"] = "المدفوع",
            ["AddPayment"] = "إضافة دفعة",
            ["PaymentAmount"] = "مبلغ الدفعة",
            ["MarkPaid"] = "تعليم كمدفوع بالكامل",
            ["AddPayment"] = "إضافة دفعة",       // AR
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