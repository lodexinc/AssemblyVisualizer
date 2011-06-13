﻿// Copyright 2011 Denis Markelov
// This code is distributed under Apache 2.0 license 
// (for details please see \docs\LICENSE, \docs\NOTICE)

using System.Windows.Media;
using ICSharpCode.ILSpy;
using ICSharpCode.ILSpy.TreeNodes;
using Mono.Cecil;

namespace ILSpyVisualizer.AssemblyBrowser.ViewModels
{
	class PropertyViewModel : MemberViewModel
	{
		private readonly PropertyDefinition _propertyDefinition;

		public PropertyViewModel(PropertyDefinition propertyDefinition)
		{
			_propertyDefinition = propertyDefinition;
		}

		public override ImageSource Icon
		{
			get { return PropertyTreeNode.GetIcon(_propertyDefinition); }
		}

		public override string Text
		{
			get
			{
				return PropertyTreeNode
					.GetText(_propertyDefinition, MainWindow.Instance.CurrentLanguage) as string;
			}
		}
	}
}
