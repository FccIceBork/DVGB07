﻿#pragma checksum "C:\Users\brull\source\repos\DVGB07\Labb3\Texted\Text_editor\Text_editor\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EDA7F4E7E733F8BF4711CA7EC97A1CAD32586D42193A8DD2D1ED55B70546EDB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Text_editor
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 18
                {
                    this.Titel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // MainPage.xaml line 20
                {
                    this.Select_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 4: // MainPage.xaml line 31
                {
                    this.Text_box = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.Text_box).TextChanged += this.Text_box_TextChanged;
                }
                break;
            case 5: // MainPage.xaml line 22
                {
                    this.Menu = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 6: // MainPage.xaml line 23
                {
                    this.Ny = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.Ny).Click += this.Ny_Click;
                }
                break;
            case 7: // MainPage.xaml line 24
                {
                    this.Spara = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.Spara).Click += this.Spara_Click;
                }
                break;
            case 8: // MainPage.xaml line 25
                {
                    this.Spara_som = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.Spara_som).Click += this.Spara_som_Click;
                }
                break;
            case 9: // MainPage.xaml line 26
                {
                    this.Oppna = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.Oppna).Click += this.Oppna_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

