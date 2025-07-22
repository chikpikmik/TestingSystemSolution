
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestingSystem.Core.DTOs;
using TestingSystem.Wpf.Utils;

namespace TestingSystem.Wpf.ViewModels
{
    public class TestVM : ViewModelBase
    {
        private int? _id;
        private string _name = "";
        private string _description = "";
        private UserProfileDto _author;
        private ObservableCollection<QuestionVM> _questions = new();

        public int? Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public UserProfileDto Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public ObservableCollection<QuestionVM> Questions
        {
            get => _questions;
            set => SetProperty(ref _questions, value);
        }

        public ICommand AddChildCommand { get; protected set; }
        public TestVM()
        {
            AddChildCommand = new RelayCommand(() =>
                Questions.Add(new QuestionVM { Text = "Новый вопрос", Test = this }));
        }
    }

    public class QuestionVM : ViewModelBase
    {
        private int? _id;
        private string _text = "";
        private ObservableCollection<AnswerOptionVM> _answerOptions = new();
        private TestVM _test;

        public int? Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public ObservableCollection<AnswerOptionVM> AnswerOptions
        {
            get => _answerOptions;
            set => SetProperty(ref _answerOptions, value);
        }

        public TestVM Test
        {
            get => _test;
            set => SetProperty(ref _test, value);
        }

        public ICommand AddChildCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        public QuestionVM()
        {
            AddChildCommand = new RelayCommand(() =>
                AnswerOptions.Add(new AnswerOptionVM { Text = "Новый вариант", Question = this, Score = new ScoreVM() }));
            DeleteCommand = new RelayCommand(() =>
                Test?.Questions.Remove(this));
        }
    }

    public class AnswerOptionVM : ViewModelBase
    {

        private int? _id;
        private string _text = "";
        private QuestionVM _question;
        private ScoreVM _score;

        public int? Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public QuestionVM Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        public ScoreVM Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        public ICommand AddChildCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }

        public AnswerOptionVM()
        {
            AddChildCommand = new RelayCommand(() =>
                Score?.VectorScores.Add(new VectorScoreVM { Vector = new VectorVM { Name = "", IsEditable=true }, Score = Score }));
            DeleteCommand = new RelayCommand(() =>
                Question?.AnswerOptions.Remove(this));
        }
    }

    public class ScoreVM : ViewModelBase
    {
        public static ObservableCollection<ScoreVM> AllScores { get; set; } = new();
        
        private ObservableCollection<VectorScoreVM> _vectorScores = new();
        public ObservableCollection<VectorScoreVM> VectorScores
        {
            get => _vectorScores;
            set => SetProperty(ref _vectorScores, value);
        }

        public ScoreVM() => AllScores.Add(this);

        public override string ToString() => AllScores.IndexOf(this).ToString();
    }

    public class VectorScoreVM : ViewModelBase
    {
        private double _value;
        private ScoreVM _score;
        private VectorVM _vector;

        public double Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ScoreVM Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }

        public VectorVM Vector
        {
            get => _vector;
            set => SetProperty(ref _vector, value);
        }

        public ICommand DeleteCommand { get; protected set; }
        public VectorScoreVM()
        {
            DeleteCommand = new RelayCommand(() =>
                Score?.VectorScores.Remove(this));
        }

    }

    public class VectorVM : ViewModelBase
    {
        public static ObservableCollection<VectorVM> AllVectors { get; set; } = new();

        private int? _id;
        private string _name = "";
        private string _description = "";
        private bool _isEditable;

        public int? Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public bool IsEditable
        {
            get => _isEditable;
            set => SetProperty(ref _isEditable, value);
        }

        public ICommand saveButtonCommand { get; protected set; }
        public VectorVM()
        {
            saveButtonCommand = new RelayCommand(() => {
                IsEditable = false;
                AllVectors.Insert(0, this);
            });
        }

        public override string ToString() => Name;
    }

}
