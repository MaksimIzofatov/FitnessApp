using FitnessAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppBL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercise.dat";
        private const string ACTIVITIES_FILE_NAME = "activity.dat";
        private readonly User _user;

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExerises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities() => Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, _user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, _user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExerises() => Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        
        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
