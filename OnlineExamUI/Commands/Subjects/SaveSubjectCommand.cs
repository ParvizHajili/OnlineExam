﻿using Exam.Core;
using Exam.Core.Domain.Entities;
using Exam.ViewModels.UserControls;
using OnlineExamUI.Enums;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineExamUI.Commands.Subjects
{
    public class SaveSubjectCommand : BaseSubjectCommand
    {
        public SaveSubjectCommand(SubjectsViewModel viewmodel) : base(viewmodel)
        {

        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else if(viewModel.CurrentSituation==(int)Situation.SELECTED)
            {
                viewModel.CurrentSituation = (int)Situation.EDIT;
            }
            else
            {
                if ((viewModel.CurrentSituation == (int)Situation.ADD) || viewModel.CurrentSituation == (int)Situation.EDIT)
                {
                    SubjectMapper subjectMapper = new SubjectMapper();
                    Subject subject = subjectMapper.Map(viewModel.CurrentSubject);

                    subject.Creator = Kernel.CurrentUser;
                    if (subject.ID != 0)
                    {
                        DB.SubjectRepository.Update(subject);

                        SubjectModel updatedModel = viewModel.AllSubjects.FirstOrDefault(x => x.ID == viewModel.CurrentSubject.ID);
                        int updatedIndex= viewModel.AllSubjects.IndexOf(updatedModel);

                        viewModel.AllSubjects[updatedIndex] = viewModel.CurrentSubject;
                    }
                    else
                    {
                        viewModel.CurrentSubject.ID= DB.SubjectRepository.Add(subject);
                        viewModel.CurrentSubject.No = viewModel.Subjects.Count + 1;

                        viewModel.AllSubjects.Add(viewModel.CurrentSubject);
                    }

                    viewModel.UpdateDataFiltered();

                    viewModel.SelectedSubject = null;
                    viewModel.CurrentSubject = new SubjectModel();
                    viewModel.CurrentSituation = (int)Situation.NORMAL;
                }
            }
        }
    }
}
