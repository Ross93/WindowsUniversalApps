﻿

#pragma checksum "C:\Users\Росица\Desktop\ProjectArchitecture\FindMyCar\FindMyCar\FindMyCar.Shared\Pages\CarLeftView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1420CB3D43FD8069CD3610013F44DAD8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindMyCar.Pages
{
    partial class CarLeftView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 24 "..\..\..\Pages\CarLeftView.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.Grid_DoubleTapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 42 "..\..\..\Pages\CarLeftView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.changeCarButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 50 "..\..\..\Pages\CarLeftView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Sign_out;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 58 "..\..\..\Pages\CarLeftView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.sendSMSButton_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 91 "..\..\..\Pages\CarLeftView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Leave_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

