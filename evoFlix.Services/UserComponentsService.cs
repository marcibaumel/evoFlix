﻿using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;

namespace evoFlix.Services
{
    /*Ebből a servic-ből lesz betöltve a user-adata*/

    public class UserComponentsService
    {
        
        private UnitOfWork unitOfWork;
       

        public UserComponentsService()
        {
            unitOfWork = new UnitOfWork();
        }


        public void getUserName(int Number)
        {

        }

        public void getUserProfilPitcure(int Number)
        {

        }

    }
}
