   M S B A M L   `   `   `  ���� M  IAlchemist the Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Alchemist_the_GameAlchemist_the_Game  #    Alchemist_the_Game.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:Alchemist_the_Game       � Title$  Алхимик��$	��550��$	��500�� � Icon$# erlenmeyer-311360_960_720.png�� � 
ResizeMode$ CanMinimize=�.��� $��Center=�$	��500��$	��500��$��Center=�.+�&   System.Windows.Controls.DataGrid  -   $��ElementsINFOdataGRID��   
IsReadOnly . $
��Left=�$	��250��$	��500��$	��Top=�   SelectionUnit$ FullRow=�   SelectionMode$ Single=�   AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Элемент��	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 110 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Name+  $ Открыт��$		 130 
 �� *
OpenDate+�� -    ��Name$ ingredient1Button��$	��250��$��50��$��?��$��Right=�$	��Top=��� $
��Wrap=�$��Right=�$	��Top=�$��
0,29,110,0q�$��52���� $��50(�
���   �$
��Bold"�.�+�� -   $ ingredient2Button��$	��250��$��50��$��?��$��Right=�$	��Top=�$��0,86,0,0q��� $
��Wrap=�$��Right=�$	��Top=�$��0,117,110,0q�$��52���� $��50(�
���   �$
��Bold"�.�=�� -   $ resultButton��$	��250��$��50��$��?��$��250,174,0,276q��� -   $ newGameButton��$��30��$&�� Начать новую игру��$��316,290,65,175q��� -   $ 
SaveButton��$��30��$!��Сохранить игру��$��316,327,65,143q��� -   $ 
LoadButton��$��30��$!��Загрузить игру��$��316,362,65,108q��� -   $ 
helpButton��$��30��$��Как играть?��$��316,432,65,38q��� -	   $ soundButton��$��30��$!��Выключить звук��$��316,397,65,73q��� $
��Wrap=�$��Right=�$��Bottom=�$	��240��$��	0,0,5,250q��� -
    �Name$ ScoreBox��$��16(�
���   �.��� $
��Wrap=�$��Right=�$��Bottom=�$	��150���� $��12(�
���   �.�&$Мещеряков Иван, ИТ-22