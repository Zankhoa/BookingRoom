   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:projectproject  5   	       project.WindowBooking   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:project     5   	     � Title$  WindowBooking��5   	   $	��450��6   $	��800��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��162* �6   �� 5      $
��377* �6   �� 5      $
��261* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgvDisplay��5      $��1��6%      AutoGenerateColumns$ False��65      CanUserAddRows$ False��6Q   ���	#FFFFFEFE   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Roomid��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Roomid+  5      $ RoomName��6%    68   �� *Name+  5      $ Capacity��6%    68   �� *
Capacity+  5      $ 	FloorRoom��6%    69   �� *	FloorRoom+  5      $	 Dom��6%    63   �� *
Dom.Name+5      �� 5   
   $��2��6   $��0,0,0,0q�6%   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5       �� $��RoomName��6   $��79��6+   $
��Bold"�66   �� 5!      -   5        $��txtRoomName��5!      $	��158��6-   $��Center=�69   $��1,0,0,0q�6[    �� 
IsReadOnly$
 True��6l   5"      �� 5$      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5%      �� $��Capacity��6   $��79��6+   $
��Bold"�66   �� 5&      -   5        $��	txtCapity��5&      $	��158��6+   $��Center=�67   $��1,0,0,0q�6Y   $
 True��6j   5'      �� 5)      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5*      �� $��	FloorRoom��6   $��79��6,   $
��Bold"�67   �� 5+      -   5        $��txtFloorRoom��5+      $	��158��6.   $��Center=�6:   $��1,0,0,0q�6\   $
 True��6m   5,      �� 5/      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�50      �� $	��Dom��6   $��79��6&   $
��Bold"�61   �� 51      -   5        $��cbxDom��51      $	��158��6)   ${�False��66   53      54      �� 56      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�57      �� $��	StartDate��6   $��79��6,   $
��Bold"�67   (  "System.Windows.Controls.DatePicker  58      -   5        $��dpkstart��58      $	��158��6-   $��Center=�69   $��1,0,0,0q�6[   59      �� 5;      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5<      �� $��EndDate��6   $��79��6*   $
��Bold"�65     5=      -   5        $��dpkend��5=      $	��158��6+   $��Center=�67   $��1,0,0,0q�6Y   5>      �� 5@      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5A      �� $
��Note��6   $��54��6'   $
��Bold"�62   �� 5B      -   5        $��txtNote��5B      $	��158��6)   $��Center=�65   $��26,0,0,0q�6W   5C      � 5E      $��0,29,0,0q�6    5F      �� 5G      $��* �6'   .+�5I      �� -	   5        $��
btnBooking��5I   +   $��Booking��6   $��0��6=   $��50��6M   ���	#FF70C6646q   5J      5K      �� 5M   
   $ Vertical=�6   $��0��6-   $��
0, 5, 0 ,5q�6>   .+�5N      �� .+�5O      �� $
��Bold"�6   $��Adobe Caslon Pro)�6.   $��16(�6L   ���	#FF4A97D2$��	27,31,0,0q�6q   Booking Room6�   5P      �� 5Q      .+�5R      �� -
   5        $��history��5R   4   $��History booking��6   $��98��6D   $��0,61,0,5q�6e   ���	#FF70C664$��34��6�   5S      �� 5T      .+�5U      �� -   5        $��Logout��5U   +   $��Logout��6   $��98��6:   $��0,61,0,5q�6Z   ���	#FF70C664$��34��6�   5V      5Y      5Z      5[      