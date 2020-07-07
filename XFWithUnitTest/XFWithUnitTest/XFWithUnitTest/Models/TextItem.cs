using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace XFWithUnitTest.Models
{
    public class TextItem : BindableBase
    {
        private string _textTitle;
        private string _textText;
        private DateTime _textDateTime;
        private string _locationLatLong;

        public string TextTitle
        {
            get => _textTitle;
            set => SetProperty(ref _textTitle, value);
        }

        public string Text
        {
            get => _textText;
            set => SetProperty(ref _textText, value);
        }

        public DateTime TextDateTime
        {
            get => _textDateTime;
            set => SetProperty(ref _textDateTime, value);
        }

        public string LocationLatLong
        {
            get => _locationLatLong;
            set => SetProperty(ref _locationLatLong, value);
        }
    }
}
