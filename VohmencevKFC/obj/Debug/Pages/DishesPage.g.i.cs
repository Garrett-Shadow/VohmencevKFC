﻿#pragma checksum "..\..\..\Pages\DishesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CA4998A5894ED2193ABDA6929E76948AD582E73ADF8BD61E2C79B3949F95582B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using VohmencevKFC.Pages;


namespace VohmencevKFC.Pages {
    
    
    /// <summary>
    /// DishesPage
    /// </summary>
    public partial class DishesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame DishesFrame;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DishesLabel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OrderNumberLabel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox DishesList;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DishesStartButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\DishesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DishesBackButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VohmencevKFC;component/pages/dishespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DishesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DishesFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.DishesLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.OrderNumberLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.DishesList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.DishesStartButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Pages\DishesPage.xaml"
            this.DishesStartButton.Click += new System.Windows.RoutedEventHandler(this.DishesStartButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DishesBackButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\DishesPage.xaml"
            this.DishesBackButton.Click += new System.Windows.RoutedEventHandler(this.DishesBackButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
