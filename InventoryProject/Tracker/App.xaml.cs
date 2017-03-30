﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Tracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static TrackerRepository.TrackerRepository trackerRepository;

        static App()
        {
            trackerRepository = new TrackerRepository.TrackerRepository();
        }

        public static TrackerRepository.TrackerRepository TrackerRepository
        {
            get
            {
                return trackerRepository;
            }
        }
    }
}