using PracticeWPFApp.Models.API;
using PracticeWPFApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPFApp.ViewModels
{
    public class RegisterViewModel: BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }

        private RelayCommand? _returnloginview;
        public RelayCommand? ReturnLoginView
        {
            get
            {
                return _returnloginview ??
                    (_returnloginview = new(obj =>
                    {
                        HTTPRequests.RegisterUser(Login, Password, Fio);
                        ViewWorker.ReturnLoginView();
                    }));
            }
        }
    }
}
