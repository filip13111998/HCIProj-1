   M S B A M L   `   `   `  ����G  CHCIProjekat1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HCIProjekat1HCIProjekat1  5   	       HCIProjekat1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HCIProjekat1     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  62     � Title$   Valute Converter��5   	   $	��800��6#   $
��1200��60    � Icon$ /assets/currency2.png��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �� .+�5   
   � $��
50 50 50 0q�6   $	��220��6#    J� OpacityMask# � ��60    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $
��0 10q�6   $��0��6"   $��24(�62   $��Right=�6@   $��Center=�6c   .��6�   From:6�   �� 5      -   5         ��Name$ from_tb��5   2   $
��0 10q�6   $��0��6$   $��20(�6C   $��1��6R   $	��USD��6b   $��Center=�6m   $��Center=�6�   6�   �� 5      $
��0 10q�6   $��1��6"   $��0��60   $��24(�6A   $��Right=�6O   $��Center=�6r   .��6�   To:6�   �� 5      -   5        $ to_tb��5   2   $
��0 10q�6   $��1��6$   $��20(�6A   $��1��6O   $	��RSD��6_   $��Center=�6j   $��Center=�6�   6�   �� 5      -   5        $��2��5      $��1��6#   $��24(�63   $��Center=�6X   ��5       �� 5!       �� Orientation$ 
Horizontal=�6!   .+�5"      �� -   5         ��Name$ 	searchImg��5"       $��/assets/currency4.png��63   �� 5#      $��	10 20 0 0q�6$   	Convert6@   5$      ��5&      �� 5'      	 �� 
TargetType"	 ��6   .�5(      �� 
 �� Property
 � �� �� Value �#18cade67   �� 5)      
 � �� �#fffddd67   �� 5*      
 � �� 5+      �� 5,   "    �� 
TargetType" ��62   .R�5-   &   ��  ��Name$ Border��6-   #��z��6=   ._�5.   *   �� $��Center=�6;   $��Center=�6X   5/   '    �� Triggers 50   &   P� 51   *    P� Property �@J�IsMouseOver P� Value . . �52   .   ��  �� 
TargetName$ Border��6[   
 � �� �#1a9fad53   +   55   #   57      58      5;      5=      ]� 5?   
   $��
50 50 50 0q�6   $	��500��6(   .+�5@       � -   5          �Name$ _NavigationFrame��5@        � NavigationUIVisibility$ Hidden=�6.   5A      5C      5D      