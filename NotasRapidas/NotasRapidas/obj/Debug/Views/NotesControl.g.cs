﻿

#pragma checksum "C:\Users\W8\documents\visual studio 2012\Projects\NotasRapidas\NotasRapidas\Views\NotesControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "377F89D385C2BA5DBD4605F29CEF3E4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NotasRapidas.Views
{
    partial class NotesControl : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\Views\NotesControl.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.TextBox_TextChanged_1;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 15 "..\..\Views\NotesControl.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.TextBox_TextChanged_2;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 24 "..\..\Views\NotesControl.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnAdd_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 25 "..\..\Views\NotesControl.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnDelete_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


