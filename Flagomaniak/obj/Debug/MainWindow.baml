   M S B A M L   `   `   `  ����  Flagomaniak    Flagomaniak.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowState$  	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Flagomaniak��5	   	    � Icon$! ./Resources/Images/Logo.png��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��7* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��Gracz:��6   $��20 0 0 0q�5      $��Center=�5      $��Center=�5      $
��30px(�5      $
��Bold"�5      �� 5       -   5        $��userName��5       $
��30px(�5!      $��Center=�5"      $��Center=�5#      $
��Bold"�5$      ��5%      �� *
UserName+�� 5'      -   5        $��
pointLabel��5'      $��	30 0 0 0 q�5(      $��30(�5)      $
��Bold"�5*      $y�Hidden=�5+      $��Center=�5,      $��Center=�5-      $��Punkty:��5.      �� 50      -   5        $��	lblPoints��50      $��30(�51      $y�Hidden=�52      $��Center=�53      $��Center=�54      $
��Bold"�55      ��56      �� *Points+57      �� 59      -   5        $��continentName��59      $��1��5:      $��Center=�5<      $��Center=�5=      $
��50px(�5>      $
��Bold"�5?      $��0,-1,0,1q�6"   ��5;      �� *ContinentName+5?   "   �� 5A      $ 
Horizontal=�6   $��2��5B      .+�5C      �� -   5        $
��undo��5C      $��90��5D      $��40��5E      $��10q�5F      $��16(�5G      $��DemiBold"�5H      
����� �$��COFNIJ��5J      5K      �� 5M      -   5        $��btnCheckAnswer��5M      $��90��5N      $��40��5O      $��10q�5P      $��16(�5Q      $��DemiBold"�5R      
����� �$��SPRAWDŹ��5T      5U      �� 5W      -   5        $��newGame��5W      $��90��5X      $��40��5Y      $��10q�5Z      $��16(�5[      $��DemiBold"�5\      
�������$��NOWA GRA��5^      5_      �� 5a      -   5        $��about��5a      $��90��5b      $��40��5c      $��10 0 0 0q�5d      $��16(�5e      $��DemiBold"�5f      
�������$��O GRZE��5h       � ToolTip$� �Musisz dopasować wszystkie flagi i nazwy państw do krajów, przeciągając je w odpowiednie miejsca na mapie.
Aby zdobyć 25 punktów za każde państwo, musisz dobrze dopasować zarówno flagę, jak i nazwę państwa,
w przeciwnym przypadku stracisz 10 punktów.
Złe odpowiedzi zostaną na koniec gry oznaczone na czerwono, natomiast dobre - na zielono.
Możesz powiększyć widok mapy za pomocą scrolla myszki.
Powodzenia!��5i      5j      5k      � 5m   
   $��1��6    5n      �� 5o      $��1* �6#   �� 5p      $��8* �6#   �� 5q      $
��1.3* �6#   .+�5t      �� -	   5        $	��map��5t       J� 	AllowDrop . $��1��5v      ��5z      �� 5{      	 �� ImageSource	 6!   �� *ContinentMap+5~      �� 5�      -
   5        $��coutriesNames��5�      $��2��5�      $��0q�5�      $��Center=�5�      $��Center=�5�      ��5�      �� 5�      .R�5�      �� $ Vertical=�6%   $��Center=�5�   $   $��Center=�5�   $   5�      ��5�      �� 5�      .R�5�      �� 
���   �$��2q�5�      ._�5�      �� $
��14px(�5�       ��5�       �� 5�       5�      5�      5�      �� 5�      -   5        $��coutriesFlags��5�      $��0��5�      $��0q�5�      ��5�      �� 5�      .R�5�      �� $ Vertical=�6%   $��Center=�5�   $   $��Center=�5�   $   5�      ��5�      �� 5�      .R�5�      �� 
���   �$	��2pxq�65   ._�5�      �� $
��Fill=�5�   $   $
��90px��5�   $   $
��70px��5�   $   ��5�   $   �� 5�   $   5�      5�      5�      5�      5�      5�      