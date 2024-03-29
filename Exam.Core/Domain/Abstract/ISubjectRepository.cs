﻿using Exam.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Core.Domain.Abstract
{
    public interface ISubjectRepository
    {
        int Add(Subject subject);
        List<Subject> Get();
        bool Update(Subject subject);
        Subject Get(int ID);
    }
}
