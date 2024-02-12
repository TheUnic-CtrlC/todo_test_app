using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Models
{
    internal class ToDoModel : INotifyPropertyChanged
    {

		private string _todoText;
		private bool _isDone;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDone
		{
			get { return _isDone; }
			set 
			{
				if (_isDone == value)
					return;
				_isDone = value; 
				OnPropertyChanged("IsDone");
			}
		}

        public string TodoText
		{
			get { return _todoText; }
			set 
			{ 
				if (_todoText == value)
					return;
				_todoText = value; 
				OnPropertyChanged("TodoText");
			}
		}

        public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName = "")
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
