   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingScheduler.ViewMeetingScheduler.View  5      G(clr-namespace:MeetingScheduler.UtilitiesMeetingScheduler.Utilities  5      ,    &MeetingScheduler.View.MonthlyScheduler   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MeetingScheduler.View     5      >	converter(clr-namespace:MeetingScheduler.Utilities     5        N� Title$  MonthlyScheduler��5
       � 	Resources 5      :  4MeetingScheduler.Utilities.DateToVisibilityConverter   DateToVisibilityConverter6   0MeetingScheduler.Utilities.DateToEventsConverter  DateToEventsConverter��%:   &	        &	        5   
   6.     5   
   6*   5      .��5      �� 
����h{�$��2q�6+   ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #e6ccff��6    � Offset$ 0Q�6/   � 5      $ #ccddff��6   $	 0.7Q�6/   � 5      $ #ccccff��6   $ 1Q�6/   5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5"      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��Center=�6?   .+�5#      �� $	��←��6   $��30��6,     ButtonTheme#��[ 6`   ��67   �� *PreviousMonthCommand+6`   �� 5$      $��16(�6:   $��5q�6H   ��6   �� *CurrentMonth+6H   �� 5%      $��.��6   $��16(�6%   $��0q�63   �� 5&      $��16(�62   $��5q�6@   ��6   �� *Year+6@   �� 5'      $	��→��6   $��30��6,   #��[ 6\   ��67   �� *NextMonthCommand+6\   5(      �� 5+      $��1��6   ��6(   �� *
DayHeaders+��5,      �� 5-      .R�5.      A�  A� Columns$ 7��6&   5/      ��51      �� 52      .R�53      �� $��Center=�65   $
��Bold"�6R   ��6$   �� 6R   54      56      �� 59      $��2��6   ��6(   �� *DaysInMonth+��5:      �� 5;      .R�5<      A� $ 7��6&   5=      ��5?      �� 5@      .R�5A      �� 
�������$	��0.5q�64   ._�5B      �� .+�5C   "   �� $
��Left=�5E   ,   $
��Bold"�6G   ��5C   ,   �� *
Date.Day+y�5D   ,   �� *Date+	 �� 	Converter#	 [  5E   G   �� 5F   "   ��6/   �� *Events+��5G   &   �� 5H   *   .R�5I   .   �� 
 �� CornerRadius$
 5��6R    �� Padding$ 5q�6c   $��5q�5J   5   $	��170��6A   $��60��6M   ��5I   5   �� *Color+._�5K   2   �� .+�5L   6   �� $ 
Horizontal=�6A   .+�5M   :   �� 
���   �$
��Bold"�6r   $��0,0,5,0q�6�   ��6D   �� *	FirstName+6�   �� 5N   :   
���   �$
��Bold"�6q   ��6D   �� *
LastName+6q   5O   7   �� 5P   6   $ 
Horizontal=�6A   .+�5Q   :   �� 
���   �$
��Bold"�6n   ��6D   �� *Title+6n   �� 5R   :   $��, ��6D   
���   �$
��Bold"�6a   �� 5S   :   
���   �$
��Bold"�6t   ��6D   �� *Description+6t   5T   7   5U   3   5V   /   5W   +   5Y   #   5Z      5[      5\      5^      5_      5`      5a      