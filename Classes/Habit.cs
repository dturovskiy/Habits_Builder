using HabitTrackerApp.Classes.Services;

namespace HabitTrackerApp.Classes
{
    public class Habit
    {
        public string Name { get; set; }

        public List<DateTime> CompletionDates { get; set; } = new List<DateTime>();

        public int CurrentStreak { get; set; }

        public int MaxStreak { get; set; }

        public Habit(string name)
        {
            Name = name;
        }

        public void MarkComplete()
        {
            DateTime today = DateTime.Today;
            if (CompletionDates.Contains(today))
            {
                Console.WriteLine(LocalizationService.GetString("HabitAlreadyCompletedToday"));
                return;
            }

            CompletionDates.Add(today);
            Console.WriteLine(string.Format(LocalizationService.GetString("HabitMarkedComplete"), Name, today.ToShortDateString()));
            CalculateCurrentStreak();
        }

        private void CalculateCurrentStreak()
        {
            CompletionDates.Sort((a, b) => b.CompareTo(a)); // newest first
            int streak = 0;
            DateTime day = DateTime.Today;

            foreach (var date in CompletionDates)
            {
                if (date == day)
                {
                    streak++;
                    day = day.AddDays(-1);
                }
            }

            CurrentStreak = streak;
            if (CurrentStreak > MaxStreak)
            {
                MaxStreak = CurrentStreak;
            }
        }

        public void ResetCurrentStreak()
        {
            CurrentStreak = 0;
        }

        public void ShowHistory()
        {
            Console.WriteLine(string.Format(LocalizationService.GetString("HabitHistoryFor"), Name));
            foreach (var date in CompletionDates.OrderBy(d => d))
            {
                Console.WriteLine(string.Format(LocalizationService.GetString("HabitHistoryDateLine"), date.ToShortDateString()));
            }
        }
    }
}
