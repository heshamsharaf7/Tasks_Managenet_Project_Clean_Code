﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UrTask.Application.Enums.ResultsTypes
{
    public enum ResultsTypes
    {
        Done,
        Incorrect_Input,
        Duplicate,
        Record_Not_Found,
        Reference_Not_Found,
        System_Policies, // من سياسات النظام او خصائصه وتظهر في حالة تم مخالفتها او تعديها
        Exception,
        None
    }
}
