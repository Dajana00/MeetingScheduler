﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Domain
{
    public interface INavigationService
    {
        void NavigateTo(string pageKey, object parameter = null);
        void NavigateBack();
    }
}
