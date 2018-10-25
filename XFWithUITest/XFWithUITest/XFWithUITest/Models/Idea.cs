using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace XFWithUITest.Models
{
    public class Idea : BindableBase
    {
        private string _ideaTitle;
        private string _ideaText;
        private DateTime _noteDateTime;

        public string IdeaTitle
        {
            get => _ideaTitle;
            set => SetProperty(ref _ideaTitle, value);
        }

        public string IdeaText
        {
            get => _ideaText;
            set => SetProperty(ref _ideaText, value);
        }

        public DateTime NoteDateTime
        {
            get => _noteDateTime;
            set => SetProperty(ref _noteDateTime, value);
        }
    }
}
