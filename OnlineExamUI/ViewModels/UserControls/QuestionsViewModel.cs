﻿using OnlineExamUI.Commands.Questions;
using OnlineExamUI.Enums;
using OnlineExamUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static OnlineExamUI.ViewModels.BaseViewModel;

namespace OnlineExamUI.ViewModels.UserControls
{
    public class QuestionsViewModel : BaseControlViewModel
    {
        public QuestionsViewModel()
        {

        }
        public override string Header => "Suallar";

        public List<ExamModel> Exams { get; set; }
        public List<SubjectModel> Subjects { get; set; }


        private QuestionModel currentQuestion;
        public QuestionModel CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        private QuestionModel selectedQuestion;
        public QuestionModel SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                selectedQuestion = value;

                CurrentQuestion = selectedQuestion?.Clone();

                OnPropertyChanged(nameof(SelectedQuestion));

                if (SelectedQuestion != null)
                {
                    CurrentSituation = (int)Situation.SELECTED;
                }
            }
        }

        private List<QuestionModel> allQuestions;
        public List<QuestionModel> AllQuestions
        {
            get => allQuestions;
            set
            {
                allQuestions = value;
                OnPropertyChanged(nameof(AllQuestions));
            }
        }

        private ObservableCollection<QuestionModel> questions;
        public ObservableCollection<QuestionModel> Questions
        {
            get => questions;
            set
            {
                questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        #region Commands
        public SaveQuestionCommand Save => new SaveQuestionCommand(this);

        public RejectQuestionCommand Reject => new RejectQuestionCommand(this);

        public DeleteQuestionCommand Delete => new DeleteQuestionCommand(this);

        public ExcelExporterQuestionCommand ExportExcel => new ExcelExporterQuestionCommand(this);

        #endregion
    }
}
