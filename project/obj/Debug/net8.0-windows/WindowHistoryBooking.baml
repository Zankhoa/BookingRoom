   M S B A M L   `   `   `  ����B  >project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:projectproject  5   	   "    project.WindowHistoryBooking   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:project     5   	     � Title$  WindowHistoryBooking��5   	   $	��450��6&   $	��800��63   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��125* �6   �� 5      $
��461* �6   �� 5      $
��214* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgvDisplay��5      $��1��6%      AutoGenerateColumns$ False��65      CanUserAddRows$ False��6Q   ���	#FFFFFEFE   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Student��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Account.FullName+  5      $
 Room��6%    64   �� *	Room.Name+  5      $	 Dom��6%    63   �� *
Dom.Name+  5      $
 Note��6%    64   �� *Note+  5      $ 	StartDate��6%    69   �� *	StartDate+  5      $ 	StartDate��6%    69   �� *	EndDate+  5      $ Status��6%    66   �� *Status.Name+5      �� 5   
   $��2��6   .+�5!      ��  �� Orientation$ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5"      �� $��AssignmentId��6   $��54��6/   $
��Bold"�6:   �� 5#      -   5        $��txtAssignmentId��5#      $	��130��61   $��Center=�6=   $��26,0,0,0q�6_   5$      �� 5&      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5'      �� $��	AccountId��6   $��79��6,   $
��Bold"�67   �� 5(      -   5        $��cbxAccountId��5(      $	��130��6/   $��Center=�6;   $��1,0,0,0q�6]   5)      �� 5+      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5-      �� $
��Room��6   $��79��6'   $
��Bold"�62   �� 5.      -   5        $��	cbxRoomId��5.      $	��130��6,   $��Center=�68   $��1,0,0,0q�6Z   5/      �� 51      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�52      �� $	��Dom��6   $��79��6&   $
��Bold"�61   �� 53      -   5        $��cbxDom��53      $	��130��6)   $��Center=�65   $��1,0,0,0q�6W   54      �� 57      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�58      �� $��	StartDate��6   $��79��6,   $
��Bold"�67   (  "System.Windows.Controls.DatePicker  59      -   5        $��dpkstart��59      $	��130��6-   $��Center=�69   $��1,0,0,0q�6[   5:      �� 5<      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5=      �� $��EndDate��6   $��79��6*   $
��Bold"�65     5>      -   5        $��dpkend��5>      $	��130��6+   $��Center=�67   $��1,0,0,0q�6Y   5?      �� 5A      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5B      �� $
��Note��6   $��54��6'   $
��Bold"�62   �� 5C      -   5        $��txtNote��5C      $	��130��6)   $��Center=�65   $��26,0,0,0q�6W   5D      �� 5F      $ 
Horizontal=�6   $��
0, 5, 0 ,5q�62   .+�5G      �� $��Status��6   $��79��6)   $
��Bold"�64   �� 5H      -	   5        $��	cbxStatus��5H      $	��130��6,   $��Center=�68   $��1,0,0,0q�6Z   5I      � 5K      $��0,29,0,0q�6    5L      �� 5M      $��* �6'   .+�5O      �� -
   5        $��Cancel��5O   *   $��Cancel��6   $��0��68   $��50��6H   ���	#FFF15A5A6h   5P      5Q      �� 5S   
   $ Vertical=�6   $��0��6-   $��0,5,0,5q�6>   .+�5T      �� .+�5U      �� $
��Bold"�6   $��Adobe Caslon Pro)�6.   $��16(�6L   ���	#FF4A97D2$��7,31,0,0q�6q   History Booking6�   5V      �� 5W      .+�5X      �� -   5        $
��back��5X   )   $
��Back��6   $��98��66   $��0,61,0,5q�6T   ���	#FF79EDED$��34��6}   5Y      �� 5Z      .+�5[      �� -   5        $��Logout��5[   +   $��Logout��6   $��98��6:   $��0,61,0,5q�6Z   ���	#FF79EDED$��34��6�   5\      5_      5`      5a      