﻿using Exam.Core;
using Exam.Core.Domain.Entities;
using OnlineExamUI.Enums;
using OnlineExamUI.Helpers;
using OnlineExamUI.Mappers;
using OnlineExamUI.Models;
using OnlineExamUI.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace OnlineExamUI.Commands.Exams
{
    public class SaveExamCommand : BaseExamCommand
    {
        public SaveExamCommand(ExamsViewModel viewModel) :base(viewModel)
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
                    // STEP 1. Validate model data
                    if (viewModel.CurrentExam.IsValid(out string message))
                    {
                        // STEP 2. Create BranchEntity from BranchModel
                        ExamMapper examMapper = new ExamMapper();
                        Exam1 exam = examMapper.Map(viewModel.CurrentExam);
                        exam.Creator = Kernel.CurrentUser;

                        // STEP 3. Save BranchEntity to db
                        if (exam.ID != 0)
                        {
                            DB.ExamRepository.Update(exam);

                            ExamModel updatedModel = viewModel.AllExams.FirstOrDefault(x => x.ID == viewModel.CurrentExam.ID);
                            int updatedIndex = viewModel.AllExams.IndexOf(updatedModel);

                            viewModel.AllExams[updatedIndex] = viewModel.CurrentExam;
                        }
                        else
                        {
                            viewModel.CurrentExam.ID = DB.ExamRepository.Add(exam);

                            viewModel.CurrentExam.No = viewModel.Exams.Count + 1;

                            viewModel.AllExams.Add(viewModel.CurrentExam);
                        }

                        viewModel.UpdateDataFiltered();

                        // STEP 4. Set Situation to Normal
                        viewModel.SelectedExam = null;
                        viewModel.CurrentExam = new ExamModel();
                        viewModel.CurrentSituation = (int)Situation.NORMAL;
                    }
                    else
                    { 
                        MessageBox.Show(message, UIMessages.ValidationCommonMessage, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        
    }
}
