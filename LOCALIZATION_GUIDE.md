# Developer Guide: Adding New Languages

This guide explains how to add support for a new language to the **Habit Tracker console application**.

---

## 1. Add the language to `Languages.json`

The `Languages.json` file is located in the [`Resources`](Resources) folder.
It contains the list of supported languages.

Example format in `Languages.json`:

```json
{
  "en": "English",
  "uk": "Українська",
  "fr": "Français",
  "ja": "日本語",
  "es": "Español"  // add new languages here
}
```

* **Key**: ISO 639-1 two-letter language code (e.g. `"en"`, `"uk"`, `"fr"`, `"es"`).
* The language **code** (like `"en"`, `"uk"`, `"fr"`) must always be a valid [IETF language tag](https://en.wikipedia.org/wiki/IETF_language_tag) — typically two-letter codes.
* However, the **display name** in `Languages.json` can be written in **any script you like**, not only in Latin letters.
  For example: `"Українська"`, `"日本語"`, `"Español"` are all valid.
* This means your language selection menu can show names in native alphabets for a better user experience.

---

## 2. Add a localization file for the new language

In the [`Resources/Localizations`](Resources/Localizations) folder, create a new JSON file named after the language code, e.g. `en.json` for Spanish.

The content of this file must be a key-value dictionary where:

* **Key**: is a unique identifier used in the app.
* **Value**: is the translated text for that language.

---

## 3. Example of a localization file

Below is an example based on the existing [`en.json`](Resources/Localizations/en.json) file:

```json
{
  "WelcomeMessage": "📅 Welcome to Habit Tracker!",
  "ChooseOption": "Choose an option:",
  "MenuAddHabit": "1. Add Habit",
  "MenuViewHabits": "2. View Habits",
  "MenuMarkComplete": "3. Mark Habit Complete",
  "MenuViewHistory": "4. View Habit History",
  "MenuDeleteHabit": "5. Delete Habit",
  "MenuResetHabit": "6. Reset Habit",
  "MenuSetReminders": "7. Set Email Reminders",
  "MenuChangeLanguage": "8. Change Language",
  "MenuToggleTheme": "9. Toggle Theme",
  "MenuSyncCalendar": "10. Sync Google Calendar",
  "MenuExit": "11. Exit",
  "InvalidOption": "❗ Invalid option.",
  "EnterHabitName": "Enter habit name: ",
  "AddedHabit": "➕ Added habit: {0}",
  "NoHabitsYet": "No habits yet.",
  "YourHabits": "📋 Your Habits:",
  "HabitLineFormat": "{0}. {1} - Current streak: {2} {3} - Max streak: {4}",
  "SelectHabitComplete": "Select habit number to mark complete: ",
  "InvalidHabitNumber": "❌ Invalid habit number.",
  "SelectHabitHistory": "Select habit number to view history: ",
  "SelectHabitDelete": "Select habit number to delete: ",
  "DeletedHabit": "❌ Deleted habit: {0}",
  "ReminderTimePrompt": "What time would you like to receive your reminder? \nMust set it in HH:mm format.",
  "EnterTime": "Enter time: ",
  "InvalidTimeFormat": "❌ Invalid time format.",
  "ReminderSet": "⏰ Reminder set for {0}.",
  "ReminderWaiting": "⏳ Waiting {0:F1} min until next reminder at {1}",
  "ReminderCancelled": "⏹️ Reminder cancelled.",
  "ReminderCancelledAfterSend": "⏹️ Reminder cancelled after first send.",
  "MissingEmailCredentials": "❌ Missing email credentials.",
  "EmailSubject": "Daily Habit Reminder",
  "EmailSent": "✅ Email sent at {0:T}",
  "EmailBodyHeader": "📌 Your habits for today:\n\n",
  "EmailBodyHabitLine": "- {0}",
  "HabitMarkedComplete": "✅ «{0}» marked as complete for {1}.",
  "HabitAlreadyCompletedToday": "⚠️ You've already marked this habit complete today.",
  "HabitHistoryFor": "📅 History for «{0}»:",
  "HabitHistoryDateLine": "- {0}",
  "SelectHabitReset": "Select habit number to reset: ",
  "ConfirmReset": "Are you sure you want to reset habit {0}",
  "ResetedHabit": "❌ Reseted habit: {0}",
  "ResetCancelled": "Reset habit cancelled."
}
```

---

## 4. Keeping localization files up to date

* Whenever you add new **features or messages** to the app, you **must update all localization files** to include the new keys and their translations.
* The application always uses these keys to display text.
  If a key is missing in a specific language file, it will **fallback to English** (or display the key itself if not found).

---

## 5. Testing

* After adding a new language, run the app and test switching to that language.
* Make sure all menu items, prompts, and system messages are displayed correctly.

---

<details>
  <summary>Additional Information: Configuration Files Location</summary>

Configuration files such as user settings are stored in the application data folder specific to your operating system. For example:

- **Windows:**  
  `%AppData%\HabitTrackerApp\settings.json`  
  (usually something like `C:\Users\<UserName>\AppData\Roaming\HabitTrackerApp\settings.json`)

- **Linux/macOS:**  
  Typically under the user's home directory, e.g.  
  `~/.config/HabitTrackerApp/settings.json`

You can access and modify these files if needed, but be careful to keep the JSON structure valid.

</details>

✅ **That’s it!**
If you need a template JSON file or examples, check the existing [`en.json`](Resources/Localizations/en.json) or ask the team for the latest localization templates.
