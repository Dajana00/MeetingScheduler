   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingScheduler.ViewMeetingScheduler.View  5      /    )MeetingScheduler.View.EditProfileDataView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MeetingScheduler.View     5        � WindowStartupLocation$  CenterScreen=�5       � Title$ EditProfileDataView��5	      .��5   
   �� 
����h{�$��2q�6/   ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #e6ccff��6    � Offset$ 0Q�6/   � 5      $ #ccddff��6   $	 0.7Q�6/   � 5      $ #ccccff��6   $ 1Q�6/   5      ._�5      � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��0��6   $��0,0,0,20q�6*   .+�5      �� $��Edit User Profile��6    $��24(�69   $
��Bold"�6G   ���#3333336Y   �� 5      $��2��6    ���#007ACC$	��200��6:   $
��Left=�6F   $��0,5,0,0q�6a   5      �� 5!      $��1��6    �� CornerRadius$ 10��6'   ._�5"      �� .+�5#      �� .+�5$      �� $��First Name:��6(   $
��Bold"�6;   ���#007ACC6M   �� 5%      $��16(�6f   $��0,5,0,10q�6t   ��6&   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6t   �� 5'      $��
Last Name:��6(   $
��Bold"�6:   ���#007ACC6L   �� 5(      $��16(�6e   $��0,5,0,10q�6s   ��6&   �� *
LastName+$ PropertyChanged=�6s   �� 5*      $��	Username:��6(   $
��Bold"�69   ���#007ACC6K   �� 5+      $��16(�6e   $��0,5,0,10q�6s   ��6&   �� *
Username+$ PropertyChanged=�6s   �� 5-      $��Email:��6(   $
��Bold"�66   ���#007ACC6H   �� 5.      $��16(�6b   $��0,5,0,10q�6p   ��6&   �� *Email+$ PropertyChanged=�6p   �� 50      $��Phone Number:��6(   $
��Bold"�6=   ���#007ACC6O   �� 51      $��16(�6h   $��0,5,0,10q�6v   ��6&   �� *PhoneNumber+$ PropertyChanged=�6v   53      54      55      �� 58      $��2��6   	 �� Orientation$	 
Horizontal=�6*   $��Right=�6C   $��0,20,0,0q�6_   .+�59      �� $
��Save��6   $	��100��6,   $��0,0,10,0q�68      ButtonTheme#��[  5:      ���#007ACC
�������$��5q�5;   E   ��5<      �� *SaveCommand+�� 5=      $��Cancel��6   $	��100��6.   #��[  5>      ���#D32F2F
�������$��5q�5?   E   ��5@      �� *CancelCommand+5A      5C      5D      5E      