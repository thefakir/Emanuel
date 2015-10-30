using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.DataAccess;
using Emanuel.Models;

namespace Emanuel.ViewModel
{
    class ChurchViewModel
    {
        private ChurchFromDB _churchService;

        public ChurchViewModel()
        {
            _churchService = new ChurchFromDB();
        }
        public ChurchModel GetChurchByPastorCode(int code)
        {
            return _churchService.GetChurchInfoByPastorCode(code);
        }
        
        
    }
}
