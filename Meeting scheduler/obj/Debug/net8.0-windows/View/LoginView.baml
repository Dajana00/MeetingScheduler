   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingScheduler.ViewMeetingScheduler.View  5   	   Q-clr-namespace:MeetingScheduler.CustomControlsMeetingScheduler.CustomControls  5   	   G(clr-namespace:MeetingScheduler.ViewModelMeetingScheduler.ViewModel  5   	   %    MeetingScheduler.View.LoginView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MeetingScheduler.View     5   	   HcustomControls-clr-namespace:MeetingScheduler.CustomControls     5   	   >	viewModel(clr-namespace:MeetingScheduler.ViewModel     5   	     � WindowStartupLocation$  CenterScreen=�5	       � Title$ 	LoginView��5   	   $	��450��6   $	��800��6(    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6(    �� 	Converter# [  66   .��5      �� 
����h{�$��2q�5      ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #e6ccff��6   	 � Offset$	 0Q�6/   6<   � 5      $ #ccddff��6   $		 0.7Q�6/   6>   � 5      $ #ccccff��6   $	 1Q�6/   6<   5      ._�5!   
   �� $��Center=�6   $��Center=�60   $	��300��6M   .+�5"      �� $��	Username:��6   $��12(�5#      $��Medium"�5$      $��
Montserrat)�5%      �� 5'      $��12(�5(      $��
Montserrat)�5)      
������ 
 �� 
CaretBrush

 ��h{�
����h{�$	��150��5-      $��25��5.        
inputFIeld#��[ 5/      $��
10,5,10,10q�51      ��5'      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�51      �� 53      $��	Password:��6   $��12(�54      $��Medium"�55      $��
Montserrat)�56      9   3MeetingScheduler.CustomControls.BindablePasswordBox  58      $��12(�5:      $��
Montserrat)�5;      
������ 
����h{�$	��150��5>         Password 59      �� *
Password+$ TwoWay=�$ PropertyChanged=�5?      �� 5A      ���#D7596D$
��Wrap=�5C      $��12(�5D      ��5A      �� *ErrorMessage+5E      �� 5G      $��Login��6   $	��110��5H      $��0,20,0,0q�5I        ButtonTheme#��[ 5J       � Cursor$
 Hand��5K      ��5G   %   �� *LoginCommand+5K      �� 5M      $��Reset password��6   $	��110��5N      $��0,20,0,0q�5O      #��[ 5P      $
 Hand��5Q      ��5M   .   �� *ResetPasswordCommand+5Q      5R      5S      5T      