   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingScheduler.ViewMeetingScheduler.View  5      G(clr-namespace:MeetingScheduler.UtilitiesMeetingScheduler.Utilities  5      c _Syncfusion.SfScheduler.WPF, Version=27.1.57.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89oNclr-namespace:Syncfusion.UI.Xaml.Scheduler;assembly=Syncfusion.SfScheduler.WPFSyncfusion.UI.Xaml.Scheduler 5      /    )MeetingScheduler.View.WeeklySchedulerView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MeetingScheduler.View     5      <utility(clr-namespace:MeetingScheduler.Utilities     5      e
syncfusionNclr-namespace:Syncfusion.UI.Xaml.Scheduler;assembly=Syncfusion.SfScheduler.WPF     5        N� Title$  WeeklySchedulerView��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6   .+�5   
   �� $��1��6   $��0��6%    �� Orientation$ 
Horizontal=�62   .+�5      ��    ButtonTheme#��[  5      $��Monthly��5      ��5      �� *MonthlyCommand+5      �� 5      $��Weekly��5      $��20 0 0 0q�6&   #��[  5      ��5      �� *WeeklyCommand+5      5      .  (Syncfusion.UI.Xaml.Scheduler.SfScheduler  5"   
   -   5          Name$ Schedule��5"   !      ViewType$
 Week=�63      EnableToolTip$
 True��6C   $��1��5$      $��1��6)      ItemsSource 5#      �� *Appointments+y�5%      �� *WeeklyScheduleVisibility+ � DataContext 5'      �� *DataContext+	 �� RelativeSource	 �� 
 �� AncestorType
 Page   AppointmentContextMenu 5+      �� 5,      .@�5-      m� 4  .Syncfusion.UI.Xaml.Scheduler.SchedulerCommands   Edit m� Command# Z 6   $
��Edit��50       m� CommandParameter 5.      ��  m� CommandTarget 5/      �� 	 �� "
  50      m� 51         Delete# Z 6   $��Delete��54       52      ��  53      �� 	 �� "
  54      56      58        5:   
   -   5        $ 	Schedulee��5:   !   $ Month=�64   $
 True��6E   $��1��5<      $��1��6"    5;      �� *Appointments+y�5=      �� *MonthlyScheduleVisibility+ 5>      �� *DataContext+	 �� 
 Page 5?      �� 5@      .@�5A      m� # Z 6   $
��Edit��5D       5B      ��  5C      �� 	 �� "
  5D      m� 5E      # Z 6   $��Delete��5H       5F      ��  5G      �� 	 �� "
  5H      5J      5L      5M      5N      