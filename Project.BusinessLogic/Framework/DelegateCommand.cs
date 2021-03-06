﻿using System;
using System.Windows.Input;

namespace Project.BusinessLogic.Framework
{
	public class DelegateCommand: ICommand
	{
		private readonly Action<object> _action;

		private readonly Predicate<object> _predicate;

		public DelegateCommand(Action<object> action, Predicate<object> predicate = null) {
			_action = action ?? throw new ArgumentNullException();
			_predicate = predicate;
		}

		public bool CanExecute(object parameter) {
			return _predicate?.Invoke(parameter) ?? true;
		}

		public void Execute(object parameter) {
			_action(parameter);
		}

		public event EventHandler CanExecuteChanged {
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
	}
}