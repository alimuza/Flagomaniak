   M S B A M L   `   `   `  ����F  BFlagomaniak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FlagomaniakFlagomaniak  5	   	       Flagomaniak.PlayerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Flagomaniak     5	   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$! ./Resources/Images/Logo.png��5   	    � Title$ Flagomaniak��5   	   $	��450��6   $	��800��6*   .��5      � .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��2* �6#   .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   $��Center=�5      $��Center=�5      .+�5      �� 
���   �$	��2pxq�6-   $
��10pxq�6D    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 2Q�6+   ._�5      �� -   5        $��newUser��5!      $��1��5      $��0q�5      
����� �$��
NOWY GRACZ��5       $
��16px(�5"      $��150px��5#      $
��50px��6+   5$      �� 5&      
���   �$	��2pxq�6-   $��10px 40px 10px 10pxq�6C    5'        5(      $ 3Q�6+   ._�5*      �� -   5        $��start��5+      $��2��5*      
���2�2�$��0q�5.      $
��16px(�5/      $��START��50      $��150px��51      $
��50px��6#   52      �� 53      
���   �$	��2pxq�6-   $
��10pxq�6C    54        55      $ 3Q�6+   ._�57      �� -   5        $
��exit��58      $��2��57      $��WYJDŹ��5:      $��150px��5;      $
��50px��5<      
��� E��$��0q�5>      $
��16px(�5?      5@      5A      &   System.Windows.Controls.DataGrid  5D      -   5        $
��grid��5F      	   AutoGenerateColumns	 .  $��0q�5E      
   CanUserAddRows
 .  $��1��5H      $
��16px(�5I      $
��Auto=�5K      $��430px��5L      $��290px��6!   ��5J      �� *	UsersList+ � 	Resources 5N      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� 
ResourceId �� TypeInTargetAssembly��%�   '        (�� J     5R   9   $" DataGridSelectAllButtonStyle��"  )�� 5O      "  6   .�5P      ��  � ��
 �q�<�67   5Q      �� 5R      " ��6   .�5S      ��  � ��
 �q�<�67   5T      5U         Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      ,  &System.Windows.Controls.DataGridColumn   Header$ Imię��6)      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5[   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5Y   )   �� *
UserName+5[   )     5\       . $ Najlepszy wynik��5]   )   $ 1* 5_   )    5^   )   �� *HeightestScore+5_   )   5a      5b      5c      5d      