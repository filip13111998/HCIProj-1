   M S B A M L   `   `   `  ����G  CHCIProjekat1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HCIProjekat1HCIProjekat1  5   	       HCIProjekat1.TableWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HCIProjekat1     5   	     � Icon$  /assets/tabel.png��5   	    � Title$ TableWindow��5	   	   $	��800��6   $	��700��6*   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        ���#fffddd   AutoGenerateColumns .     CanUserAddRows .  ��5   f   �� *
lTranItm+ � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� 	Resources �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%F  '        '  �     �� 5      "  6    5      ���� 5      '��       " ��6    .�5      ��  � ��$ Center=�6D   5      5      5      �� 5      "  6   .�5      ��  � �� �#18cade63   �� 5       � �� �#fffddd63   �� 5       � ��$ Center=�6C   5      5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Date��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.2* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Date+6L     5      $

 Open��6%   $
 0.2* 6M    63   �� *Open+6M     5      $

 High��6%   $
 0.2* 6M    63   �� *High+6M     5       $	
 Low��6%   $
 0.2* 6K    62   �� *Low+6K     5!      $
 Close��6%   $
 0.2* 6O    64   �� *Close+6O   5%      5(      5)      