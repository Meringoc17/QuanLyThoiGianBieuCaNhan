﻿using System;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces
{
    internal interface ISerializer
    {
        void Save(Schedule calendar, string filePath);
        Schedule Load(string filePath);
    }
}
