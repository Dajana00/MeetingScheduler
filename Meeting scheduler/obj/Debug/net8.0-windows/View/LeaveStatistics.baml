   M S B A M L   `   `   `  ����K  GMeetingScheduler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingScheduler.ViewMeetingScheduler.View  5      +    %MeetingScheduler.View.LeaveStatistics   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MeetingScheduler.View     5        � Title$  LeaveStatistics��5	      .��5
      � .+�5   
   �� .+�5      �� $��Leave Statistics��6   $��24(�60   $
��Bold"�6>   $��10q�6P   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�5      �� $��Select Month:��6   $��5q�61   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ MonthPicker��5         DisplayDateStart 
2023-01-016Y      SelectedDate 62   �� *SelectedMonth+   DisplayDateEnd 6w   �� *Today+�� 5      $��Refresh��6      ButtonTheme#��[  6X   $��5q�6}   ��6+   �� *RefreshStatisticsCommand+6}   5      &   System.Windows.Controls.DataGrid  5        DataGridStyle#��[ 6      AutoGenerateColumns$ False��6f      CanUserAddRows$ False��6�   $��10q�6�   ��6>   �� *LeaveStatistics+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Type��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *	LeaveType+  5      $	 
Start Date��6)   
 6=   �� *	StartDate+  5      $	 End Date��6)   
 6;   �� *	EndDate+  5      $	 Duration (Days)��6)   
 6B   �� *
Duration+  5      $	 Status��6)   
 69   �� *Status+5      �� 5      $��Export to CSV��6   $��10q�6T   $��Center=�6`   #��[  5      ��5   -   �� *ExportToCSVCommand+5      5       5#      5$      