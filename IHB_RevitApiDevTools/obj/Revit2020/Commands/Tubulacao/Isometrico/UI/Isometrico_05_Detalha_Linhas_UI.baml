   M S B A M L   `   `   `  ���� P  LIHB_BaseAddin, Version=2022.12.27.1099, Culture=neutral, PublicKeyToken=nullo<clr-namespace:IHB_BaseAddin.Commands.Tubulacao.Isometrico.UI.IHB_BaseAddin.Commands.Tubulacao.Isometrico.UI  T    NIHB_BaseAddin.Commands.Tubulacao.Isometrico.UI.Isometrico_05_Detalha_Linhas_UI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Nlocal<clr-namespace:IHB_BaseAddin.Commands.Tubulacao.Isometrico.UI     $	��600��$	��600��$	��600��$	��600��$	��600��$	��600��  � Title$  	Rotina 05�����#F2F2F2 � WindowStyle$
 None=�'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome .    WindowChrome      ResizeBorderThickness$ 0q�.���  � ColumnDefinitions �� $��20 ��� $	��150 ��� $��* ��� $��20 � � RowDefinitions �� $��60 ��� $��20 ��� $��10 ��� $��25 ��� $��* ��� $��10 ��� $��40 ��� $��10 ��� $��40 ��� $��10 ��� $��50 ��� $��20 �.+�]� -    ]�Name$ Header��$��0��$��0��$��2��$��4�����#344454.+��� -    ��Name$
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
Horizontal=�.+��� -   $�� ��$��Center=�$��Center=�$��7 0 3 0q��� $��Tags das Linhas��$
��Wrap=� �� TextAlignment$ Center=�$��Center=�$	��490��
�������]� -	   $ DockList��$��1��$��4��$��1��$��2��.+��� -
    ��Name$ ListBox_Linhas��$��Stretch=����� .R�� $	��0,2q� �� $��* �.+���  ��Name$ stkPanelRowLinha��$ 
Horizontal=�.+���  ��Name$ chkTagLinha��$��Center=�$��Center=�$	��260�� d� 	IsChecked ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.���� ���� *
TagLinha+�� $ chkCreateDimensions��$��Center=�$��Center=�$��5q� �� $ CreateDimensions�$ TwoWay=�$ PropertyChanged=�.���� $��Cotas���� $ chkCreateTags��$��Center=�$��Center=�$��5q� �� $ 
CreateTags�$ TwoWay=�$ PropertyChanged=�.���� $
��Tags���� $ chkCreateSheets��$��Center=�$��Center=�$��5q� �� $ CreateSheets�$ TwoWay=�$ PropertyChanged=�.���� $��Formatos���� $ chkCreateTriangles��$��Center=�$��Center=�$��5q� �� $ CreateTriangles�$ TwoWay=�$ PropertyChanged=�.���� $��Triângulos��]� $��6��$��1��$��2��$��Center=�$��Stretch=�.+��� $��0,0,5,0q� �� Padding$ 2q�$��1q����#E98A9E$ 5��$��30��$	��130��._��� $��Escolha o formato��$
��Wrap=�$ Center=�$��Center=�
��������� -    ��Name$ Cb_TitleBlock��$��Right=�$��Center=�$	��410������ .R��� ���� *TitleBlockName+]� $��8��$��1��$��2��$��Center=�$��Stretch=�.+��� $��0,0,5,0q�$ 2q�$��1q����#E98A9E$ 5��$��30��$	��130��._��� $��Escolha a cota��$
��Wrap=�$ Center=�$��Center=�
��������� -   $ Cb_Dimensions��$��Right=�$��Center=�$	��410������ .R��� ���� *DimensionName+]� -   $ DockButtons��$��1��$��10��$��1��$��2��.+�]� -   $ DockButtonsBottom��$��Bottom=�$��Stretch=�$��Bottom=�$��2��.+��� -   $
 btnGerar��$��Gerar Detalhamento��$��5,5,5,5q�$��40��$��Stretch=�$	��Top=����#344454
�������{�.  � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5��