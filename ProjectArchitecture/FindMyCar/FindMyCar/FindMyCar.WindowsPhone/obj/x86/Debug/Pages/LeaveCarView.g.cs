﻿

#pragma checksum "C:\Users\Росица\Desktop\ProjectArchitecture\FindMyCar\FindMyCar\FindMyCar.Shared\Pages\LeaveCarView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E7BFC1B2D377A318B681265352A9EBEF"
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
    partial class LeaveCarView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 17 "..\..\..\Pages\LeaveCarView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Sign_out;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 25 "..\..\..\Pages\LeaveCarView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.LeaveCar_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 33 "..\..\..\Pages\LeaveCarView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.ShowHistory_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


