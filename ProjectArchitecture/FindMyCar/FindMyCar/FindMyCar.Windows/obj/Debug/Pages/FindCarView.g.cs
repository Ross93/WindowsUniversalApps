﻿

#pragma checksum "C:\Users\Росица\Desktop\ProjectArchitecture\FindMyCar\FindMyCar\FindMyCar.Shared\Pages\FindCarView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BFA5B9D25922E61C6FEF2C2528866C1F"
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
    partial class FindCarView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 23 "..\..\Pages\FindCarView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Sign_out;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 32 "..\..\Pages\FindCarView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SendSms;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 42 "..\..\Pages\FindCarView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.findCar;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


