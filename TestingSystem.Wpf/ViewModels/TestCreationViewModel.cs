
using System.Collections.ObjectModel;
using TestingSystem.Core.DTOs;
using TestingSystem.Core.Services;
using TestingSystem.Wpf.Utils;

namespace TestingSystem.Wpf.ViewModels
{
    public class TestCreationViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISessionManager _sessionManager;
        private readonly ITestService _testService;
        public ObservableCollection<TestVM> Tests { get; } = new ObservableCollection<TestVM>();

        //private async Task LoadVectorsAsync() => VectorVM.AllVectors = new ObservableCollection<VectorVM>(await _testService.GetVectorsList());


        public TestCreationViewModel(INavigationService navigationService, ISessionManager sessionManager, ITestService testService)
        {
            _navigationService = navigationService;
            _sessionManager = sessionManager;
            _testService = testService;

            //LoadVectorsAsync().ConfigureAwait(false);

            // Инициализация тестового набора данных
            var test = new TestVM
            {
                Name = "Тест по математике",
                Description = "Основы алгебры",
                Author = _sessionManager.CurrentUser
            };

            var question = new QuestionVM
            {
                Text = "Вопрос 1: Решите уравнение",
                Test = test
            };

            var answer = new AnswerOptionVM
            {
                Text = "Вариант A",
                Question = question,
                Score = new ScoreVM()
            };


            answer.Score.VectorScores.Add(new VectorScoreVM { Vector = new VectorVM { Name = "Новый вектор", Description="Description", IsEditable=true }, Value = 5, Score=answer.Score });
            question.AnswerOptions.Add(answer);
            test.Questions.Add(question);

            Tests.Add(test);

        }

        
    }
}
