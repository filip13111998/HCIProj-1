   M S B A M L   `   `   `  ����G  CSerbia-Train, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Serbia_Train.pagesSerbia_Train.pages  5      +clr-namespace:Serbia_TrainSerbia_Train  5          Serbia_Train.pages.Trafic   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Serbia_Train.pages     5      (lclr-namespace:Serbia_Train     5         Serbia_Train.HelpProvider    HelpKey$  LineTraffic��5	       N� Title$ Trafic��5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      $��3* �6   6*   �� 5      6   �� 5      $��3* �6   6*   �� 5      6   .+�5   
   � $��0��6   .+�5      �� $��1,1,1,0q�6    �� CornerRadius$ 15,15,10,10��5   !   ._�5      �� ���#a8d0e6$��40��5   %   $ 15��5   %   $	��250��5   %   $��Center=�5    %   ._�5!      �� 
�������$��Center=�60   $��28(�6T   $��All Free Timetable��6c   6�   5"      5#      5$      � 5&   
   $��1��6   .+�5'      &   System.Windows.Controls.DataGrid  -   5          Name$ All_Timetable_Grid��5(   ;   $	��900��5'         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6#      AutoGenerateColumns .     CanUserDeleteRows .    CanUserAddRows .  ��5(   #   �� 	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Train Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ 
Train.Name�  5-      $
 Start��6)    68   �� *Start+  5.      $	
 End��6)    66   �� *End+  5/      $
 Comeback Start��6)    6A   �� *ComebackStart+  50      $
 Comeback End��6)    6?   �� *ComebackEnd+  51      $
 Type Timetable��6)    6A   �� *TypeTimetable+4  .System.Windows.Controls.DataGridTemplateColumn  53      $	
 Add��6-      CellTemplate 5:      �� 5;      .R�5<   "   �� -   5        $��0 0 0 0q�5<   *   
������ .��5>   &   �� $��/assets/add.png��6,   6H   5?   #   5@      5B      5F      5G      � 5K   
   $��2��6   .+�5L      �� $��1,1,1,0q�6   $ 15,15,10,10��5N   !   ._�5O      �� ���#a8d0e6$��40��5Q   %   $ 15��5R   %   $	��250��5S   %   $��Center=�5T   %   ._�5U      �� -   5         ��Name$ Lab_Name��5U      
�������$��Center=�6B   $��28(�6f   $�� ��6u   6�   5V      5W      5X      � 5Z   
   $��3��6   .+�5[        -   5        $ Line_Timetable_Grid��5]   -   $	��900��5[      $ * 5\       .   .  .  ��5]      �� 	 5`        5a      $
 
Train Name��6)    6=   �� $ 
Train.Name�  5b      $
 Start��6)    68   �� *Start+  5c      $	
 End��6)    66   �� *End+  5d      $
 Comeback Start��6)    6A   �� *ComebackStart+  5e      $
 Comeback End��6)    6?   �� *ComebackEnd+  5f      $
 Type Timetable��6)    6A   �� *TypeTimetable+  5h      $
 Delete��6-    5o      �� 5p      .R�5q   "   �� -   5        $��0 0 0 0q�5q   *   
������ .��5s   &   �� $��/assets/del1.png��6,   6I   5t   #   5u      5w      5{      5|      5~      5      