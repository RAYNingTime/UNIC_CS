   M S B A M L   `   `   `  ����N  J"Ali's-Supermarket", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ali_s_SupermarketAli_s_Supermarket  5   	   "    Ali_s_Supermarket.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Ali_s_Supermarket     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��My supermarket��6   $��3��5      $��Center=�5      $	��Top=�5      $��10q�5      $��32(�5      $
��Bold"�6   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��10 �6#   �� 5      $��2* �6#   .+�5      � $��0��6    5       �� 5!      $
��auto �6'   �� 5"      $��2* �6'    5%      �� 5&      $
��auto �6$   �� 5'      $
��auto �6$   �� 5(      $
��auto �6$   �� 5)      $
��auto �6$   �� 5*      $
��auto �6$   .+�5.      �� $��Manage Items��6   $��2��5/      $��Center=�50      $	��Top=�51      $��10q�52      $��16(�53      $
��Bold"�6   �� 56      $
��Name��6   $��1��6'   $��5q�57      �� 58      -   5         ��Name$ NameTextBox��58      $��1��59      $��1��6"   $��5q�62   �� 5<      $��	Unit Type��6   $��2��6,   $��5q�5=      �� 5>      $��2��6   $��1��6*   $��5q�6:   .+�5?      	� -   5         	�Name$ WeightRadioButton��5?   "   $��Weight��6=   $��5q�6N   	� 5@      -   5        $ QuantityRadioButton��5@   "   $��Quantity��6?   $��5q�6R   5A      �� 5D      $��
Unit Price��6   $��3��6-   $��5q�5E      �� 5F      -   5        $ PriceTextBox��5F      $��3��5G      $��1��6"   $��5q�62   �� 5J      -   5         ��Name$ 	AddButton��5J      $�� Add > ��6,   $��4��5K      $��2��6&   $��5q�5L      6$   5N      � 5P      $��1��6   $��1��6#   ���#F0F0F060   � 5R      $��2��6   $��1��6#    5S      �� 5T      $
��auto �6$   �� 5U      $��* �6$   �� 5V      $
��auto �6$   .+�5Y      �� -   5         ��Name$ 
OrderLabel��5Z      $��Order��5Y      $��Center=�5[      $	��Top=�5\      $��10q�5]      $��16(�5^      $
��Bold"�6   �� 5`      -   5         ��Name$ ItemStackPanel��5`      $��1��65   $��10q�6B   �� 5b      -   5        $ PlaceOrderButton��5b      $��Place Order��5c      $��2��5d      $��30��5e      6(   5g      5h      5j      5k      