   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MeetingSchedulerMeetingScheduler  5   	   !    MeetingScheduler.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MeetingScheduler     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1300��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5       �� 
TargetType   NewButtonTheme �� Property  PrimaryBackgroundColor �� Value  PrimaryTextColor �� 
TargetType ��Name �� CornerRadius	 J� SnapsToDevicePixels
 ��Name �� Triggers P� Property P� Value �� 
TargetName  ButtonPressedColor��%�  &	        �� 5   
   " ��5      �5      �� 5       � ��# �  6/   6b   �� 5       � ��# �  6/   6\   �� 5       � ��$ 0q�64   6@   �� 5       � ��$
 Bold"�6/   6>   �� 5       � ��$ Center=�68   6J   �� 5       � ��$ Center=�66   6H   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ ButtonBorder��6%   $ 0��6;   #��z��6L   #��z��5   !   #��z��5   !   #��z��5   !   #��z��5   !   $
	 True��5   !   ._�5   "   �� $
 ContentPresenter��63   $|�False��6M   #��z��5    /   #��z��5!   /   #��z��5"   /   #	 z	 5#   /   $
��True��5$   /   6L   5&       5'      P� 5(   "    �@J�IsMouseOver$
 True��6A   . �5)   &   �� $ ButtonBorder��6-    � �� �#0080806q   �� 5*   &   $ ButtonBorder��6-    � ��$ 1q�6b   6o   5+   #   P� 5,   "    � ��$
 True��6?   . �5-   &   �� $ ButtonBorder��6-   # �  6]    � ��6�   5.   #   50      52      58      59      .��5:      �  � RowDefinitions 5;   
   �� 5<      $��1* �6   6*   �� 5=      $��7* �6   6*    � ColumnDefinitions 5?   
   �� 5@      $��1* �6   6,   �� 5A      $��4* �6   6,   .+�5D   
   �� $��/Resources/calendar.png��6   $��70��61   $��	0,0,120,0q�6<   6Q   �� 5E   
   $��	Scheduler��6   $��26(�6%   $
��Bold"�63   ���#004040$��Center=�6Z   $��	120,0,0,0q�6u   6�   �� 5F   
   $��Logout��6   $��1��6D     ButtonTheme#��[ 6T   $��Center=�6y   $��	750 0 0 0q�6�   $	��100��6�   ��6"   �� *LogoutCommand+6�   �� 5K   
   $��1��6   ���#e6ccff$ 0 70 0 0��63   ._�5N      � $��1��6   $��0,20,0,0q�6    .+�5P      A�  A� Rows$ 9��6   .+�5Q      �� $	��150��6P   $��50��6\   $��16(�6h   $��CreateLeaveRequest��6v   #��[ 6�   ��6   �� *NavigateToLeaveRequestCommand+.��5R      ��  �� Orientation$ 
Horizontal=�6%   .+�5S      �� $��Leave request��6(   $
��Bold"�6>   5T      5U      �� 5V      $��16(�6I   $	��150��6X   $��50��6d   $��Users��6�   #��[ 6�   ��6   �� *NavigateToUsersCommand+y�6p   �� *UsersButtonVisibility+.��5W      �� $ 
Horizontal=�6%   .+�5X      �� $��Users��6(   $
��Bold"�66   6J   5Y      5Z      �� 5[      $��16(�6L   $	��150��6[   $��50��6g   $��Requests��5]      #��[ 6;   ��5[      �� *NavigateToRequestsCommand+y�5\      �� *UsersButtonVisibility+.��5^      �� $ 
Horizontal=�6%   .+�5`      �� $��Requests��6(   $
��Bold"�69   6M   5a      5b      �� 5d      $��16(�6|   $	��150��6�   $��50��6�   $��
CreateUser��6�   $��Center=�6�   $��Center=�6�   #��[ 6  ��6   �� *NavigateToCreateUserCommand+y�6O   �� *UsersButtonVisibility+.��5e      �� $ 
Horizontal=�6%   .+�5f      �� $��Create user��6(   $
��Bold"�6<   6P   5g      5h      �� 5i      $��16(�6J   $	��150��6Y   $��50��6e   $��Profile��6q   $��Center=�6�   $��Center=�6�   #��[ 6�   ��6   �� *NavigateToProfleCommand+.��5j      �� $ 
Horizontal=�6%   .+�5k      �� $��Profile ��6(   $
��Bold"�69   6M   5l      5m      �� 5o      $��16(�6N   $	��150��6]   $��50��6i   $��
NewMeeting��6u   $��Center=�6�   $��Center=�6�   #��[ 6�   ��6   �� *NavigateToNewMeetingCommand+.��5p      �� $ 
Horizontal=�6%   .+�5q      �� $��New meeting��6(   $
��Bold"�6<   6P   5r      5s      �� 5t      $��16(�6M   $	��150��6\   $��50��6h   $��	Scheduler��6t   $��Center=�6�   $��Center=�6�   #��[ 6�   ��6   �� *NavigateToSchedulerCommand+.��5u      �� $ 
Horizontal=�6%   .+�5v      �� $��	Scheduler��6(   $
��Bold"�6:   6N   5w      5x      �� 5y      $��16(�6}   $	��150��6�   $��50��6�   $��SpecialEvent��6�   #��[ 6�   ��6   �� *NavigateToSpecialEventCommand+y�6P   �� *UsersButtonVisibility+.��5z      �� $ 
Horizontal=�6%   .+�5{      �� $��Add special event��6(   $
��Bold"�6B   6V   5|      5}      5~      5�      5�      � 5�   
   $��1��6   $��1��6   $
��Left=�6,   $	��916��6G   $��
50,18,0,76q�6S   .+�5�       � -   5          �Name$ 	MainFrame��5�        � NavigationUIVisibility$ Hidden=�6'   $��
40,-26,0,0q�6G   6]   5�      5�      5�      