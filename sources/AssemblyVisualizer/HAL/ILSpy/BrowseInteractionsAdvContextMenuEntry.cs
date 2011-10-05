﻿// Copyright 2011 Denis Markelov
// This code is distributed under Microsoft Public License 
// (for details please see \docs\Ms-PL)

#if ILSpy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.ILSpy;
using ICSharpCode.TreeView;
using ICSharpCode.ILSpy.TreeNodes;
using AssemblyVisualizer.InteractionBrowser;

namespace AssemblyVisualizer.HAL.ILSpy
{
    [ExportContextMenuEntry(Header = "Interactions (advanced)")]
    sealed class BrowseInteractionsAdvContextMenuEntry : IContextMenuEntry
    {
        public bool IsVisible(SharpTreeNode[] selectedNodes)
        {
            return (selectedNodes.All(n => n is TypeTreeNode));
        }

        public bool IsEnabled(SharpTreeNode[] selectedNodes)
        {
            return true;
        }

        public void Execute(SharpTreeNode[] selectedNodes)
        {
            var types = selectedNodes
                .OfType<TypeTreeNode>()
                .Select(n => HAL.Converter.Type(n.TypeDefinition))
                .ToArray();

            var window = new InteractionBrowserWindow(types, false)
            {
                Owner = MainWindow.Instance
            };
            window.Show();
        }
    }
}

#endif