using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo;

namespace Todo
{
	public class ElementViewModel : INotifyPropertyChanged
	{
		public ElementViewModel()
		{
			_ToDoElement = new ToDoElement { datum = "Unknown", text = "Unknown", prio = 0 };
		}

		private ToDoElement _ToDoElement;

		public ToDoElement toDo
		{
			get
			{
				return _ToDoElement;
			}
			set
			{
				_ToDoElement = value;
			}
		}

		public string datum
		{
			get
			{
				return toDo.datum;
			}
			set
			{
				if (toDo.datum != value)
				{
					toDo.datum = value;
					RaisePropertyChanged("Datum");
				}
			}
		}

		public string text
		{
			get
			{
				return toDo.text;
			}
			set
			{
				if (toDo.text != value)
				{
					toDo.text = value;
					RaisePropertyChanged("Text");
				}
			}
		}

		public int prio
		{
			get
			{
				return toDo.prio;
			}
			set
			{
				if (toDo.prio != value)
				{
					toDo.prio = value;
					RaisePropertyChanged("Prio");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(string propertyName)
		{
			// take a copy to prevent thread issues
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		//Anzahl Plus
		private void updatePrioPExecute()
		{
			prio = prio + 1;
		}

		//Anzahl Plus
		private bool canUpdatePrioPExecute()
		{
			if (prio > 5)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public ICommand prioPlus { get { return new RelayCommand(updatePrioPExecute, canUpdatePrioPExecute); } }

		//Anzahl Minus
		private void updatePrioMExecute()
		{
			prio = prio - 1;
		}

		//Anzahl Minus
		private bool canUpdatePrioMExecute()
		{
			if (prio < 2)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public ICommand anzahlMinus { get { return new RelayCommand(updatePrioMExecute, canUpdatePrioMExecute); } }
	}
}
