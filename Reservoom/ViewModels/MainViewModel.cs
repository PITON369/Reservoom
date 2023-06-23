﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel() 
        {
            //CurrentViewModel = new MakeReservationViewModel();
            CurrentViewModel = new ReservationListingViewModel();
        }
    }
}