   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingScheduler.ViewMeetingScheduler.View  5   	   -    'MeetingScheduler.View.ResetPasswordView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MeetingScheduler.View     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ ResetPassword��5   	   $	��450��6   $	��800��6,   .��5	      �� 
����h{�$��2q�5   	   ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #e6ccff��6    � Offset$ 0Q�6/   6<   � 5      $ #ccddff��6   $	 0.7Q�6/   6>   � 5      $ #ccccff��6   $ 1Q�6/   6<   5      ._�5   
   �� $��Center=�6   $��Center=�60   $	��300��6M   .+�5      �� $��Enter your email:��6   $��12(�5      $��Medium"�5      $��
Montserrat)�5      �� 5      $��12(�5      $��
Montserrat)�5      
������  �� 
CaretBrush
 ��h{�
����h{�$	��150��5"      $��25��5#         
inputFIeld#��[  5$      $��
10,5,10,10q�5%      ��5      �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�5%      �� 5&      $��12(�61   
���  ����6   �� *	Message+6R   �� 5(      $��Enter your username:��6   $��12(�5)   
   $��Medium"�5*   
   $��
Montserrat)�5+   
   �� 5-      $��12(�5.      $��
Montserrat)�5/      
������ 
 ��h{�
����h{�$	��150��53      $��25��54      #��[  55      $��
10,5,10,10q�56      ��5-      �� *
Username+$ PropertyChanged=�56      �� 57      $��12(�61   
���  ����6   �� *	Message+6R   �� 59      $��Send new password��6   $	��130��5:      $��0,20,0,0q�5;        ButtonTheme#��[ 5<       � Cursor$
 Hand��5=      ��59   1   �� *ResetPasswordCommand+5=      5>      5?      5@      