   M S B A M L   `   `   `  ���� \  XBLS_PDI_RevitAddin_2020, Version=2020.0.8321.26872, Culture=neutral, PublicKeyToken=null�Eclr-namespace:BLS_PDI_RevitAddin_2020.Commands.Eletrica.ListaCabos.UI7BLS_PDI_RevitAddin_2020.Commands.Eletrica.ListaCabos.UI  b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes j    dBLS_PDI_RevitAddin_2020.Commands.Eletrica.ListaCabos.UI.ListaCabos_02_Adicionar_Cabos_Aos_Trechos_UI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     WlocalEclr-namespace:BLS_PDI_RevitAddin_2020.Commands.Eletrica.ListaCabos.UI     ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     $	��500��$	��500��$	��500��$	��650��$	��650��$	��650��  � Title$  Lista de Cabos�����#F2F2F2 � WindowStyle$
 None=�'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome .    WindowChrome      ResizeBorderThickness$ 0q�.���  � ColumnDefinitions �� $��20 ��� $	��350 ��� $��* ��� $��20 � � RowDefinitions �� $��60 ��� $��20 ��� $��10 ��� $��25 ��� $��15 ��� $��25 ��� $��10 ��� $��25 ��� $��10 ��� $��25 ��� $��* ��� $��15 ��� $��25 ��� $��10 ��� $	��130 ��� $��10 ��� $��50 ��� $��20 �.+�]� -    ]�Name$ Header��$��0��$��0��$��2��$��4�����#344454.+��� -    ��Name$
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
�������$��14(� �� IsCancel . �� $��12                 ��$��1��$��2�����#E98A9E �� CornerRadius$ 5,5,5,5��._��� -    ��Name$ chkCopiarCircuitos��$
��Left=�$��Center=�$7��1Adicionar Circuito(s) a trechos de outro Circuito��$��5 0 5 0q�
��������� $��0,0,5,0q� �� Padding$ 2q�$��1q�$��5��$��1�����#E98A9E$ 5 5 5 5��._��� $A��;Selecione os condutos que receberão os circuitos apontados��$��8 0 0 0q�$
��Wrap=� �� TextAlignment$
 Left=�$��Center=�
��������� -	   $
 btnSelecionar��$��5��$��2��$��Selecionar...��$��0,0,0,0q�$
��auto��$��Stretch=�$��Stretch=����#344454
�������{�.  � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5���� $��0,0,5,0q�$ 2q�$��1q�$��7��$��1�����#E98A9E$ 5 5 5 5��._��� $;��5Selecione o modo de seleção dos elementos / trechos��$��8 0 0 0q�$
��Wrap=�$
 Left=�$��Center=�
��������� -
    ��Name$ cmbBx_ModoSelecao��$��7��$��2�� �� 
IsEditable .   �� 
IsReadOnly .   �� SelectedIndex$ 0��.@��� $��Trecho - Trecho�� � ToolTip$F @A seleção será por trecho em todos os elementos selecionados.���� $��Elemento - Trecho��$� �O primeiro elemento selecionado será selecionado sozinho (os demais elementos do trecho serão desconsiderados) e nos demais elementos serão selecionados os trechos.���� $��Trecho - Elemento��$� �O último elemento será selecionado sozinho (os demais elementos do trecho serão desconsiderados) e nos demais elementos serão selecionados os trechos.���� $��Elemento - Elemento��$f `Toda seleção será do elemento sozinho (os demais elementos do trecho serão desconsiderados).����  �� Orientation$ 
Horizontal=�$��14��$��1��$��2��.+��� -    ��Name$ stkPanel_CircuitosCopiar��$ Vertical=�$��Stretch=�$��Stretch=�$��0 0 5 0q�{�.  .+��� $ 5,5,0,0��$	��220��$��25�����#E98A9E._�]� $��Stretch=�.+��� -    ��Name$ title_prefilter_Copiar��$��Circuito a copiar��$
��Wrap=�$
 Left=�$��Center=�$��7 0 3 0q�$	��100��
��������� -    ��Name$ filter_Copiar��$��Center=�$��Right=� �� TextAlignment$
 Left=�$	��100��$��0 2 10 2q����	#FFFFEDF1$��Filtro tag cabo...��
��������� -    ��Name$ ListBox_CircuitoCopiar��$	��105��$��Stretch=����� .R�� $	��0,2q� �� $��* �.+��� $ 
Horizontal=�.+�	�  	�Name$ radioCircuito��-     	� 	GroupName$  grpCircuitoCopiar��$��Center=�$��Center=�$��0 0 5 0q�! d� 	IsChecked! �� *
IsSelected+" �� Mode$" TwoWay=�# �� UpdateSourceTrigger$# PropertyChanged=����� *identificacao_cabo+�� -   $ stkPanel_TagsTrecho��$ Vertical=�$��Stretch=�$��Stretch=�$��7 0 0 0q�{�.  .+��� ���#E98A9E$ 5,5,0,0��$	��220��$��25��._��� $ 
Horizontal=�.+��� -   $ chkAllTagsTrecho��$�� ��$��Center=�$��Center=�$��7 0 3 0q�$! FalseY��� $��Trechos para onde copiar��$
��Wrap=�$
 Left=�$��Center=�
�������$��0,4,0,5q��� -   $ ListBox_TagsTrecho��$	��105��$��Stretch=����� .R�� $	��0,2q� �� $��* �.+��� $ 
Horizontal=�.+��� $ chkTagTrecho��-   $��Center=�$��Center=�$��0 0 5 0q�! �� *
IsSelected+$" TwoWay=�$# PropertyChanged=�.���� ���� *TagTrechoIdElemento+�� $��0 0 20 0q����� *	TagTrecho+�� $��3��$��1��$��2�����#E98A9E$ 5,5,5,5��._��� $ 
Horizontal=�.+��� -   $ chkFiltroCondutos��$�� ��$��Center=�$��Center=�$��7 0 3 0q�$! FalseY��� $ ��Filtrar condutos pelo tipo��$
��Wrap=�$
 Left=�$��Center=�
�������$��0,4,10,5q��� -   $ txtBxFiltroCondutos��$��0 4 5 4q�{�.  $	��270���� $��9��$��1��$��2�����#E98A9E$ 5,5,0,0��._�]� $��Stretch=�.+��� -   $�� ��$
��Left=�$��Center=�$��7 0 3 0q�$! FalseY��� -   $ title_preFilter��$;��5Selecione os circuitos a serem inseridos nos condutos��$
��Wrap=�$
 Left=�$��Center=�$
��Left=�$	��310��
�������$��0,4,0,5q��� -   $ filter��$��Center=�$��Right=�$
 Left=�$	��100��$��0 2 10 2q����	#FFFFEDF1$��Filtro tag cabo...��
�������]� -   $ DockList��$��1��$��10��$��1��$��2��.+��� -   $ ListBox_Cabos��$��Stretch=����� .R�� $	��0,2q� �� $��* �.+��� $ stkPanelRowLinha��$ 
Horizontal=�.+��� $ chkRow��$��Center=�$��Center=�$��0 0 30 0q�! �� *
IsSelected+$" TwoWay=�$# PropertyChanged=�.���� ���� *identificacao_cabo+�� $��0 0 20 0q����� *equipamento_de+$ �� StringFormat$$ De:  {0}���� $��0 0 20 0q����� *equipamento_para+$$ 
Para:  {0}���� -   $ 
stkButtons��$ 
Horizontal=�$��1��$��16��$��1��$��2��.+��� -   $
 
btnInserir��$��5,5,5,5q�$��40��$	��216��$
��Left=�$	��Top=����#344454
�������{�.  ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� $1��+Inserir circuitos nos condutos selecionados��$
��Wrap=�$ Center=��� -   $
 
btnExcluir��$��5,5,5,5q�$��40��$	��216��$��Right=�$	��Top=����#344454
�������{�.  ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� $1��+Excluir circuitos nos condutos selecionados��$
��Wrap=�$ Center=�