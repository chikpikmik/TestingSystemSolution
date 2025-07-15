using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingSystem.Core.Models;
using TestingSystem.Utils;

namespace TestingSystem.ViewModels
{
    public class CreateTestVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ObservableCollection<TestHI> Tests { get; } = new ObservableCollection<TestHI>();

        public CreateTestVM(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Инициализация тестового набора данных
            var test = new TestHI
            {
                Name = "Тест по математике",
                Description = "Основы алгебры",
            };

            var question = new QuestionHI
            {
                Text = "Вопрос 1: Решите уравнение",
                Parent = test,
            };

            var answer = new AnswerOptionHI
            {
                Text = "Вариант A",
                Parent = question,
            };

            answer.Childrens.Add(new VectorScoreHI { VectorName = "How cool is it?", Value = 5, Parent = answer });
            question.Childrens.Add(answer);
            test.Childrens.Add(question);

            Tests.Add(test);
        }
    }

    public abstract class HierarchyItem : ViewModelBase
    {
        public ObservableCollection<HierarchyItem> Childrens { get; } = new ObservableCollection<HierarchyItem>();
        public HierarchyItem? Parent { get; set; }
        public ICommand AddChildCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }
    }

    // Уровень 1
    public class TestHI : HierarchyItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public ImageSource? Image { get; set; }

        public TestHI()
        {
            AddChildCommand = new RelayCommand(() =>
                Childrens.Add(new QuestionHI { Text = "Новый вопрос", Parent = this }));
        }
    }

    // Уровень 2
    public class QuestionHI : HierarchyItem
    {
        public string Text { get; set; }
        //public List<ImageSource>? Images { get; set; }

        public QuestionHI()
        {
            AddChildCommand = new RelayCommand(() =>
                Childrens.Add(new AnswerOptionHI { Text = "Новый вариант", Parent = this }));
        }
    }

    // Уровень 3
    public class AnswerOptionHI : HierarchyItem
    {
        public string Text { get; set; }
        public Score Score { get; set; } = new Score();
        //public ImageSource? Image { get; set; }

        public AnswerOptionHI()
        {
            AddChildCommand = new RelayCommand(() =>
                Childrens.Add(new VectorScoreHI { VectorName = "Новое вектор-значение", Parent = this }));
        }
    }

    // Уровень 4
    public class VectorScoreHI : HierarchyItem
    {
        public string VectorName { get; set; }
        public string VectorDescription { get; set; }
        public double Value { get; set; } = 0;

        public VectorScoreHI() => AddChildCommand = null;
    }
}
