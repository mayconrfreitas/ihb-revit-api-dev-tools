   M S B A M L   `   `   `  ���� P  LIHB_BaseAddin, Version=2022.12.27.1099, Culture=neutral, PublicKeyToken=nullm;clr-namespace:IHB_BaseAddin.Commands.Eletrica.ListaCabos.UI-IHB_BaseAddin.Commands.Eletrica.ListaCabos.UI  \    VIHB_BaseAddin.Commands.Eletrica.ListaCabos.UI.ListaCabos_0203_Filtrar_Tipo_Condutos_UI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Mlocal;clr-namespace:IHB_BaseAddin.Commands.Eletrica.ListaCabos.UI     $	��400��$	��400��$	��400��$	��500��$	��500��$	��500��  � Title$  Lista de Cabos�����#F2F2F2 � WindowStyle$
 None=�'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome .    WindowChrome      ResizeBorderThickness$ 0q�.���  � ColumnDefinitions �� $��20 ��� $	��150 ��� $��* ��� $��20 � � RowDefinitions �� $��60 ��� $��20 ��� $��10 ��� $��25 ��� $��* ��� $��10 ��� $��50 ��� $��20 �.+�]� -    ]�Name$ Header��$��0��$��0��$��2��$��4�����#344454.+��� -    ��Name$
 logo��$
��Left=�$	��200��$	��350��$��Stretch=�$��Stretch=�$��20,0,0,0q�$��60��$��Uniform=�	 �� BitmapScalingMode$
	 Fant=�$	��190��]� -   $ Header_Menu��$��Bottom=�$��Right=�$��Center=�$��0,0,20,0q�.+��� -   
 ��Name$
 btnSobre��$��Sobre��$��20��$��60��
������ 
������ 
�������$��Center=��� -   $
 btnAjuda��$��Ajuda��$��20��$��60��
������ 
������ 
�������$��Center=�]� -   $ Header_Close��$��Right=�$��Right=�$	��Top=�.+��� -   $
 btnClose��$	��✖��$��30��$��35��
������ 
������ 
�������$��14(� �� IsCancel . �� $��3��$��1��$��2�����#E98A9E �� CornerRadius$ 5,5,0,0��._���  �� Orientation$ 
Horizontal=�.+��� -   $�� ��$��Center=�$��Center=�$��7 0 3 0q� d� 	IsChecked$ FalseY��� $��Tipos dos Condutos��$
��Wrap=� �� TextAlignment$ Center=�$��Center=�$	��290��
�������$��0,4,0,5q�]� -	   $ DockList��$��1��$��4��$��1��$��2��.+��� -
    ��Name$ ListBox_TiposCondutos��$��Stretch=����� .R�� $	��0,2q� �� $��* �.+���  ��Name$ stkPanelRowLinha��$ 
Horizontal=�.+���  ��Name$ chkTipo��-   $��Center=�$��Center=�$	��200��$��0 0 5 0q� ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.���� ���� *Tipo+]� -   $ DockButtons��$��1��$��6��$��1��$��2��.+�]� -   $ DockButtonsBottom��$��Bottom=�$��Stretch=�$��Bottom=�$��2��.+��� -   $
 
btnFiltrar��$��Filtrar��$��5,5,5,5q�$��40��$��Stretch=�$	��Top=����#344454
�������{�.  � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5��