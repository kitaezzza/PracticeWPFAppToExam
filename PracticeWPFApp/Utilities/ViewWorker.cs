using PracticeWPFApp.Views.Account;
using PracticeWPFApp.Views.Forecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeWPFApp.Utilities
{
    public class ViewWorker
    {
        public static void OpenRegisterView()
        {
            RegisterView view = new();
            view.Show();
            Window wnd = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();
            wnd?.Close();
        }

        public static void ReturnLoginView() 
        {
            LoginView view = new();
            view.Show();
            Window wnd = Application.Current.Windows.OfType<RegisterView>().FirstOrDefault();
            wnd?.Close();
        }

        public static void OpenListCitiesView()
        {
            ListCitiesView view = new();
            view.Show();
            Window wnd = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();
            wnd?.Close();
        }

        //Будет готово позже.
        public static void OpenForecastView()
        {
            ForecastView view = new();
            view.Show();
        }
    }
}
