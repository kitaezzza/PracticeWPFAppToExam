using PracticeWPFApp.Models.API;
using PracticeWPFApp.Utilities;
using PracticeWPFApp.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PracticeWPFApp.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        //Авторизоваться
        private RelayCommand? _gettoken;
        public RelayCommand GetToken
        {
            get
            {
                return _gettoken ??
                    (_gettoken = new(obj=>
                    {
                        HTTPRequests.GetToken(Login, Password);
                        ViewWorker.OpenListCitiesView();
                    }));
            }
        }

        //Перейти в окно регистрации
        private RelayCommand? _openregisterview;
        public RelayCommand OpenRegisterView
        {
            get
            {
                return _openregisterview ??
                    (_openregisterview = new(obj =>
                    {
                        ViewWorker.OpenRegisterView();
                    }));
            }
        }
    }
}
