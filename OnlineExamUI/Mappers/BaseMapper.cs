﻿using Exam.Core.Domain.Entities;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Mappers
{
    public abstract class BaseMapper<T1, T2> where T1 : BaseEntity where T2 : BaseModel
    {
        public abstract T1 Map(T2 t);

        public abstract T2 Map(T1 t);
    }
}
