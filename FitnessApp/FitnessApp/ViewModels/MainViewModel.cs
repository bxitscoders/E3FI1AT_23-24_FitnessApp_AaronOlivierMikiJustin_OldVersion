using FitnessApp.Core;


namespace FitnessApp.ViewModels
{
    internal class MainViewModel : ObservableObject
    {

        // Commands to switch between views
        public RelayCommand StartTrainingViewCommand { get; set; }
        public RelayCommand TrainingViewCommand { get; set; }
        public RelayCommand ExerciseOverviewViewCommand { get; set; }
        public RelayCommand ProgressViewCommand { get; set; }


        // Creating ViewModel-objects for MainViewModel-constructor
        public StartTrainingViewModel StartTrainingVM { get; set; }
        public TrainingViewModel TrainingVM { get; set; }
        public ProgressViewModel ProgressVM { get; set; }
        public ExerciseOverviewViewModel ExerciseOverviewVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        // MainViewModel-constructor
        public MainViewModel()
        {
            StartTrainingVM = new StartTrainingViewModel();
            TrainingVM = new TrainingViewModel();
            ProgressVM = new ProgressViewModel();
            ExerciseOverviewVM = new ExerciseOverviewViewModel();

            CurrentView = StartTrainingVM;

            StartTrainingViewCommand = new RelayCommand(o =>
            {
                CurrentView = StartTrainingVM;
            });

            TrainingViewCommand = new RelayCommand(o =>
            {
                CurrentView = TrainingVM;
            });

            ExerciseOverviewViewCommand = new RelayCommand(o =>
            {
                CurrentView = ExerciseOverviewVM;
            });

            ProgressViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProgressVM;
            });

        }
    }
}
