   M S B A M L   `   `   `  ����  MeetingScheduler'    !MeetingScheduler.View.UserProfile   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  UserProfile��5      .��5
      �� ��5   
   �� 5       �� 
StartPoint$	 0,1&�6"    �� EndPoint$	 1,0&�63   .��5      �  � Color$ #e6ccff��6    � Offset$ 0Q�6/   � 5      $ #ccddff��6   $	 0.7Q�6/   � 5      $ #ccccff��6   $ 1Q�6/   5      ._�5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��0,0,0,20q�6&   .+�5      �� $��User Profile��6   $��24(�60   $
��Bold"�6>   ���#3333336P   �� 5      $��2��6   ���#007ACC$	��200��66   $
��Left=�6B   $��0,5,0,0q�6]   5      �� 5      $��1��6    �� Padding$ 20q�6"    �� CornerRadius$ 10��6/   ���#007ACC$��1q�6W   ._�5      �� .+�5      �� .+�5       �� $��First Name:��6$   $
��Bold"�67   ���#007ACC6I   �� 5!      $��16(�6D   $��0,0,0,10q�6R   ��6$   �� *User.FirstName+6R   �� 5#      $��
Last Name:��6$   $
��Bold"�66   ���#007ACC6H   �� 5$      $��16(�6C   $��0,0,0,10q�6Q   ��6$   �� *User.LastName+6Q   �� 5&      $��	Username:��6$   $
��Bold"�65   ���#007ACC6G   �� 5'      $��16(�6C   $��0,0,0,10q�6Q   ��6$   �� *User.Username+6Q   �� 5)      $��Email:��6$   $
��Bold"�62   ���#007ACC6D   �� 5*      $��16(�6@   $��0,0,0,10q�6N   ��6$   �� *
User.Email+6N   �� 5,      $��Phone Number:��6$   $
��Bold"�69   ���#007ACC6K   �� 5-      $��16(�6F   $��0,0,0,10q�6T   ��6$   �� *User.PhoneNumber+6T   �� 5/       �� Orientation$ 
Horizontal=�6%   .+�50      �� $��Edit profile��6%      ButtonTheme#��[  6<   $
��Left=�52   !   $��20 0 0 0q�6<   ��51   !   �� *EditProfileCommand+52   <   �� 54      $��Leave statistics��6%   #��[  6@   $
��Left=�56   !   $��20 0 0 0q�6<   ��55   !   �� *StatisticsCommand+56   <   57      5:      5<      5=      5>      5?      5@      