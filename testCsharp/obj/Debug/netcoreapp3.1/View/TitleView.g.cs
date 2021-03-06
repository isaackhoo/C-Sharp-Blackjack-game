﻿#pragma checksum "..\..\..\..\View\TitleView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF3F80D8E8B2B3AFC8695D9EA9921C7C783990BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using testCsharp.View;
using testCsharp.View.Theme;


namespace testCsharp.View {
    
    
    /// <summary>
    /// TitleView
    /// </summary>
    public partial class TitleView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleIlluminaPrimary;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleIlluminaSecondary;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleBlackjackPrimary;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleBlackjackSecondary;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SinglePlayerButton;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HostGameButton;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button JoinGameButton;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\View\TitleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SettingsButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BlackJack;component/view/titleview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\TitleView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TitleIlluminaPrimary = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TitleIlluminaSecondary = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TitleBlackjackPrimary = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TitleBlackjackSecondary = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SinglePlayerButton = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\..\..\View\TitleView.xaml"
            this.SinglePlayerButton.Click += new System.Windows.RoutedEventHandler(this.onStartSinglePlayer);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HostGameButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.JoinGameButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.SettingsButton = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\..\..\View\TitleView.xaml"
            this.SettingsButton.Click += new System.Windows.RoutedEventHandler(this.GoToSettingsPage);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

