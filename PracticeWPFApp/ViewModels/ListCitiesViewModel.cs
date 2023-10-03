using PracticeWPFApp.Models;
using PracticeWPFApp.Models.API;
using PracticeWPFApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPFApp.ViewModels
{
    public class ListCitiesViewModel : BaseViewModel
    {
        public List<Cities> CitiesList { get; set; }
        public string CityName { get; set; }
        public Cities SelectedCity { get; set; }
        public string ActualToken { get; set; }

        //Вывести список городов (Будет готово позже)
        private RelayCommand? _getcities;
        public RelayCommand GetCities
        {
            get 
            {
                return _getcities ??
                    (_getcities = new(obj =>
                    {
                        ActualToken = TokenWorker.ValidToken(ActualToken);
                        CitiesList = new (HTTPRequests.GetCities(ActualToken));
                    }));
            }
        }
        //Перейти на окно прогноза погоды в городе (Будет готово позже)
        private RelayCommand? _openforecastview;
        public RelayCommand OpenForecastView
        {
            get 
            {
                return _openforecastview ??
                    (_openforecastview = new(obj =>
                    {Ы
                        ViewWorker.OpenForecastView();
                    }));
            }
        }
    }
}
