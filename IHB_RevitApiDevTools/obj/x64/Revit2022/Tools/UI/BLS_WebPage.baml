   M S B A M L   `   `   `  ???? \  XBLS_PDI_RevitAddin_2020, Version=2020.0.8321.26872, Culture=neutral, PublicKeyToken=nullS.clr-namespace:BLS_PDI_RevitAddin_2020.Tools.UI BLS_PDI_RevitAddin_2020.Tools.UI  T PCefSharp.Wpf, Version=65.0.1.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf 2    ,BLS_PDI_RevitAddin_2020.Tools.UI.BLS_WebPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:BLS_PDI_RevitAddin_2020.Tools.UI     EcefSharp0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     $	??600??$	??600??$	??600??$	??600??  ? Title$  BLS Browser?????#F2F2F2 ? WindowStyle$
 None=?'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome .    WindowChrome      ResizeBorderThickness$ 0q?.???  ? ColumnDefinitions ?? $??20 ??? $	??150 ??? $??* ??? $??20 ? ? RowDefinitions ?? $??60 ??? $??20 ??? $??10 ??? $??* ??? $??10 ?.+?]? -    ]?Name$ Header??$??0??$??0??$??2??$??4?????#344454.+??? -    ??Name$
 logo??$
??Left=?$	??200??$	??350??$??Stretch=?$??Stretch=?$??20,0,0,0q?$??60??$??Uniform=?	 ?? BitmapScalingMode$
	 Fant=?$	??190??]? -   $ Header_Menu??$??Bottom=?$??Right=?$??Center=?$??0,0,20,0q?.+??? -   
 ??Name$
 btnSobre??$??Sobre??$??20??$??60??
?????? 
?????? 
???????$??Center=??? -   $
 btnAjuda??$??Ajuda??$??20??$??60??
?????? 
?????? 
???????$??Center=?]? -   $ Header_Close??$??Right=?$??Right=?$	??Top=?.+??? -   $
 btnClose??$	??✖??$??30??$??35??
?????? 
?????? 
???????$??14(? ?? IsCancel . ?? -    ??Name$ 
tabControl??$??Stretch=?$??Stretch=?$??1??$??2??$??3??.@??? -	   $??Autorização Forge??.??%  CefSharp.Wpf.ChromiumWebBrowser  -
     Name$ 
webBrowser??$??Bottom=?   Address$ http://localhost:3000/??$??Stretch=?$??Stretch=?