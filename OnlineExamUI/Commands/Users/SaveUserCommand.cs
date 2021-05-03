﻿using OnlineExamUI.Enums;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Commands.Users
{
   public  class SaveUserCommand : BaseUserCommand
    {
        public SaveUserCommand(UsersViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                viewModel.CurrentSituation = (int)Situation.ADD;
            }
            else if (viewModel.CurrentSituation == (int)Situation.SELECTED)
            {
                viewModel.CurrentSituation = (int)Situation.EDIT;
            }
            else
            {
                if (viewModel.CurrentSituation == (int)Situation.ADD || viewModel.CurrentSituation == (int)Situation.EDIT)
                {

                    //ExamMapper examMapper = new ExamMapper();
                    //Exam1 exam = examMapper.Map(viewModel.CurrentExam);

                    //exam.Creator = Kernel.CurrentUser;
                    //if (exam.ID != 0)
                    //{
                    //    DB.ExamRepository.Update(exam);

                    //    ExamModel updatedModel = viewModel.AllExams.FirstOrDefault(x => x.ID == viewModel.CurrentExam.ID);
                    //    int updatedIndex = viewModel.AllExams.IndexOf(updatedModel);

                    //    viewModel.AllExams[updatedIndex] = viewModel.CurrentExam;
                    //}
                    //else
                    //{
                    //    viewModel.CurrentExam.ID = DB.ExamRepository.Add(exam);
                    //    viewModel.CurrentExam.No = viewModel.Exams.Count + 1;

                    //    viewModel.AllExams.Add(viewModel.CurrentExam);
                    //}

                    //viewModel.UpdateDataFiltered();

                    //viewModel.SelectedExam = null;
                    //viewModel.CurrentExam = new ExamModel();
                    //viewModel.CurrentSituation = (int)Situation.NORMAL;
                }
            }
        }
    }
}