using Model.Database;
using Model.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessApp.ViewModels
{
    public class TrainingViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Uebungen> _uebungenList;
        public ObservableCollection<Uebungen> UebungenList
        {
            get { return _uebungenList; }
            set
            {
                _uebungenList = value;
                OnPropertyChanged(nameof(UebungenList));
            }
        }
        private LoadExercises _loadExercixes;

        public TrainingViewModel(LoadExercises queryService)
        {
            _loadExercixes = queryService;
            LoadUebungen();
        }

        


        private async Task LoadUebungen()
        {
            List<Uebungen> uebungen = await _loadExercixes.LoadUebungenAsync();
            UebungenList = new ObservableCollection<Uebungen>(uebungen);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
