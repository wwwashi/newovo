   M S B A M L   `   `   `  ����A  =newOvo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:newOvo.PagesnewOvo.Pages  5          newOvo.Pages.Admin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:newOvo.Pages     5        N� Title$  Admin��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��100* �6    � RowDefinitions 5   
   �� 5      $��56 �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ AddEmployer��5   ,   $��Center=�6   $+��%Добавить сотрудника��6A   $��3��6_   $��0��6o   $��5,0,5,0q�5   	   $��Center=�6   $��30��6>   $��Center=�6J   $��12(�5   	   $
��Bold"�6   6)   �� 5   
   -   5        $��	txtSearch��5      $��0��6#   $��30��60   $
��Left=�6<   $��Center=�6^   $��0��6�   $��Center=�6�   $��
5, 0, 5, 0q�6�   6�   �� 5   
   -   5        $��
cmbSorting��5      $��30��6%   $
��Left=�61   $��Center=�6S   $��0��6u   $��1��6�    �� SelectedIndex$ 0��6�   $��Center=�6�   $��
5, 0, 5, 0q�6�   .@�5      �� $
��Bold"�6   По возрастанию6:   �� 5      $
��Bold"�6   По убыванию67   5      �� 5    
   -   5        $��	cmbFilter��5       $��30��6$   $
��Left=�60   $��Center=�6R   $��2q�6t   $��0��6�   $��2��6�   $ 0��6�   $��
5, 0, 5, 0q�6�   $��Center=�6�   .@�5!      �� $
��Bold"�6   Должность65   �� 5"      $
��Bold"�6   Фамилия63   �� 5#      $
��Bold"�6   Имя6/   �� 5$      $
��Bold"�6   Отчество64   5%      �� 5&   
   -   5         ��Name$ LViewPpl��5&   6   $��5q�6   ���	#FFE5E5E5$��1��6H   $��0��6Y   $��4��6i   $��1��6}   $��Disabled=�5'      ��6O   �� ��5(      �� 5)      .R�5*      � 5+      ��5-      �� 5.      .R�5/      �� ���	#FF151515$��3q�65   ���	#FFD7D7D7 �� Padding$ 5q�6`    �� CornerRadius$ 15��6l   ._�50      � .+�51      �� $	��150��6)   $	��150��68   $	��195��6G   $	��195��6W   $��1��6g   $��5q�6w   .+�52   "   �� $��
ImageUsers��6(   $��85��6:   $��85��6E   $��5q�6Q   $��0��6\   $��/Resources/profile.png��6i   �� 53   "   $��Center=�6,   $��3,3,3,0q�6I   $��16(�6Z   $
��Wrap=�6h   $
��Bold"�6|   �� 54   .   �62   �� *UsersRole.NameRole+55   #   �� 56   "   $��Center=�6,   $��3,3,3,0q�6I   $��14(�6Z   $
��Wrap=�6h   �� 57   .   $;�5                                                     ��62    �� 59   .   �62   �� *	Surname+ �� 5:   .   �62   �� *Name+ �� 5;   .   �62   �� *	Midname+5<   #   5=      5>      5?      5@      5B      �� 5D   
   -   5        $!��Сохранить в Excel��5D      $��30��6-   $��2��6V   $��3��6c   $��5q�6s   $��Center=�6~   5E      5F      