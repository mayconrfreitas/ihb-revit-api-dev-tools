   M S B A M L   `   `   `  ���� Y  UBLS_PDI_RevitAddin_2020, Version=2022.11.25.738, Culture=neutral, PublicKeyToken=null�Jclr-namespace:BLS_PDI_RevitAddin_2020.Commands.Mecanica.DadosEngenharia.UI<BLS_PDI_RevitAddin_2020.Commands.Mecanica.DadosEngenharia.UI  b    \BLS_PDI_RevitAddin_2020.Commands.Mecanica.DadosEngenharia.UI.DadosEngenharia_00_InsertTag_UI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     \localJclr-namespace:BLS_PDI_RevitAddin_2020.Commands.Mecanica.DadosEngenharia.UI     $	��700��$	��700��$	��700��$	��600��$	��600��$	��600��  � Title$  Dados Engenharia�����#F2F2F2 � WindowStyle$
 None=�'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome .    WindowChrome      ResizeBorderThickness$ 0q�.���  � ColumnDefinitions �� $��20 ��� $��* ��� $��20 � � RowDefinitions �� $��60 ��� $��20 ��� $��10 ��� $��25 ��� $��* ��� $��10 ��� $��50 ��� $��20 �.+�]� -    ]�Name$ Header��$��0��$��0��$��2��$��3�����#344454.+��� -    ��Name$
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
�������$��14(� �� IsCancel . �� $��3��$��1�����#E98A9E �� CornerRadius$ 5,5,0,0��._���  �� Orientation$ Vertical=�.+��� -    ��Name$ DtGridTitle��$��Tags Equipamentos��$
��Wrap=� �� TextAlignment$ Center=�$��Center=�$��Center=�
�������$��0,4,0,5q�]� -	   $ DockList��$��1��$��4��$��1��.+�&   System.Windows.Controls.DataGrid  -
     Name$ dtGrid_Equipamentos��   HorizontalGridLinesBrush �#969391   VerticalGridLinesBrush �#969391   CanUserReorderColumns .     CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Visible=�"   VerticalScrollBarVisibility$ Visible=�����  � 	Resources    WrappedColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%c   &	        �� "  .���  � �� �� .R��� $
��Wrap=����� ��  � ��$ Center=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 28    CellTemplate �� .R�	�   	� 	GroupName$  radios��! d� 	IsChecked! �� *
IsSelected+" �� UpdateSourceTrigger$" PropertyChanged=�0  *System.Windows.Controls.DataGridTextColumn  #   Header$	# Tag��$   
IsReadOnly$ . %   CanUserSort% . &   SortDirection$& 	AscendingX�'   HeaderStyle#' [  $
 auto 1  +System.Windows.Controls.DataGridBoundColumn(   Binding( �� *BLSTagEquipamento+  $
# Nome��$ . % . #' [  $
 auto ( �� *BLSSubcategoria+  $# Capacidade Op. Nominal��$ . % . #' [  $
 auto ( �� *BLSCapacidadeOperacionalNom+  $# Capacidade Op. Projeto��$ . % . #' [  $
 auto ( �� *BLSCapacidadeOperacionalProj+  $# Unidade��$ . % . #' [  $
 auto ( �� *
BLSUnidade+  $# Descrição��$ . % . #' [  $
 auto ( �� *BLSDescricaoEquipamento+  $# Potência Unitária��$ . % . #' [  $
 auto ( �� *BLSPotenciaUnitaria+  $# Peso Unitário��$ . % . #' [  $
 auto ( �� *BLSMassaUnitaria+  $# Folha de Dados��$ . % . #' [  $
 auto ( �� *BLSFolhaDeDados+  $# Fluxograma de Engenharia��$ . % . #' [  $
 auto ( �� *BLSFluxogramaEngenharia+  $# 
Fornecedor��$ . % . #' [  $
 auto ( �� *BLSFornecedor+  $# Observação��$ . % . #' [  $
 auto ( �� *BLSObservacaoEquipamento+]� -   $ DockButtons��$��1��$��6��$��1��.+��� -   $
 btnMain��$��	Preencher��$��0,5,0,5q�$��40��$��Stretch=�$	��Top=����#344454
�������{�.  ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��